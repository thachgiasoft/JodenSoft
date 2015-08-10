using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using SAF.Foundation;
using System.Data;
using SAF.EntityFramework.Server;

namespace SAF.EntityFramework.SqlGenerators
{
    /// <summary>
    /// 
    /// </summary>
    internal class DeleteCommandGenerator : ISqlCommandObjectGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="connectionName"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public SqlCommandObject GenerateCommand(string connectionName,string tableName, System.Data.DataRow dr)
        {
            List<SqlCommandParameter> paramList = new List<SqlCommandParameter>();
            SqlCommandObject cmd = new SqlCommandObject();

            //生成WHERE子句
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
                throw new FieldNotFoundException(string.Format("主键列\"{0}\"在查询结果中不存在,无法生成Delete脚本.", primaryKey));
            }

            StringBuilder whereBuilder = new StringBuilder();

            foreach (var field in tableFields)
            {
                string fieldName = field.Name.Trim() ;
                if (field.IsPrimaryKey)
                {
                    if (dr.Table.Columns.Contains(fieldName))
                    {
                        whereBuilder.Append(string.Format("[{0}]=@Orig_{1} AND ", fieldName, fieldName));
                        paramList.Add(new SqlCommandParameter() { Name = "@Orig_{0}".FormatWith(fieldName), DataType = field.DataType, Value = dr[fieldName, DataRowVersion.Original] });
                    }
                }
            }

            string where = whereBuilder.ToString();

            int index = where.LastIndexOf("AND");
            if (index >= 0)
                where = where.Substring(0, index);

            cmd.CommandText = string.Format("DELETE {0} WHERE {1}", tableName, where);
            cmd.Parameters = paramList.ToArray();
            return cmd;
        }
    }
}
