using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Data;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework.SqlGenerators
{
    /// <summary>
    /// 
    /// </summary>
    internal class UpdateCommandGenerator : ISqlCommandObjectGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="connectionName"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public SqlCommandObject GenerateCommand(string connectionName, string tableName, System.Data.DataRow dr)
        {
            List<SqlCommandParameter> paramList = new List<SqlCommandParameter>();
            SqlCommandObject cmd = new SqlCommandObject();
            StringBuilder setBuilder = new StringBuilder();
            StringBuilder whereBuilder = new StringBuilder();

            var tableFields = EntityHelper.GetTableFields(connectionName, tableName);

            int count = tableFields.Count(p => p.IsPrimaryKey);
            if (count < 1)
                throw new FieldNotFoundException(string.Format("主键在表中没有定义,表名为:{0}", tableName));

            if (count > 1)
            {
                throw new FieldNotFoundException(string.Format("实体类不支持复合主键,表名为:{0}", tableName));
            }

            string primaryKey = tableFields.FirstOrDefault(p => p.IsPrimaryKey).Name;

            if (!dr.Table.Columns.Contains(primaryKey))
            {
                throw new FieldNotFoundException(string.Format("主键列\"{0}\"在查询结果中不存在,无法生成Update脚本.", primaryKey));
            }

            foreach (var field in tableFields)
            {
                string fieldName = field.Name.Trim();

                if (dr.Table.Columns.Contains(fieldName) && !field.IsIdentity && !field.IsVersionNumber)
                {
                    if (field.IsPrimaryKey)
                    {
                        whereBuilder.Append(string.Format("[{0}] = @Orig_{1} ", fieldName, fieldName));
                        paramList.Add(new SqlCommandParameter() { Name = "@Orig_{0}".FormatWith(fieldName), Value = dr[fieldName, DataRowVersion.Original] });
                    }

                    if (!dr[fieldName].Equals(dr[fieldName, DataRowVersion.Original]))
                    {
                        if (field.UpdateDefaultValue != null && field.UpdateDefaultValue != DBNull.Value)
                        {
                            var paramValue = DefaultValueHelper.GetValue(field.UpdateDefaultValue);
                            setBuilder.Append(string.Format("[{0}] = {1}, ", fieldName, paramValue));
                        }
                        else
                        {
                            setBuilder.Append(string.Format("[{0}] = @Curr_{1}, ", fieldName, fieldName));
                            paramList.Add(new SqlCommandParameter() { Name = "@Curr_{0}".FormatWith(fieldName), DataType = field.DataType, Value = dr[fieldName] });
                        }
                    }
                    else
                    {
                        if (field.UpdateDefaultValue != null && field.UpdateDefaultValue != DBNull.Value)
                        {
                            var paramValue = DefaultValueHelper.GetValue(field.UpdateDefaultValue);
                            setBuilder.Append(string.Format("[{0}] = {1}, ", fieldName, paramValue));
                        }
                    }
                }
            }
            int index = 0;
            string set = setBuilder.ToString();
            index = set.LastIndexOf(",");
            if (index >= 0)
                set = set.Substring(0, index);
            if (!string.IsNullOrWhiteSpace(set))
            {
                cmd.CommandText = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, set, whereBuilder.ToString());
                cmd.Parameters = paramList.ToArray();
            }
            else
            {
                cmd = null;
            }
            return cmd;
        }
    }
}
