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
    internal class InsertCommandGenerator : ISqlCommandObjectGenerator
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

            StringBuilder fieldsBuilder = new StringBuilder();
            StringBuilder fieldParamsBuilder = new StringBuilder();

            //生成字段列表
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
                throw new FieldNotFoundException(string.Format("主键列\"{0}\"在查询结果中不存在,无法生成Insert脚本.", primaryKey));
            }

            foreach (var field in tableFields)
            {
                string fieldName = field.Name.Trim();

                if (dr.Table.Columns.Contains(fieldName) && !field.IsIdentity && !field.IsVersionNumber)
                {
                    fieldsBuilder.Append(string.Format("[{0}], ", fieldName));

                    if (dr[fieldName] != null && dr[fieldName] != DBNull.Value)
                    {
                        fieldParamsBuilder.Append(string.Format("@Curr_{0}, ", fieldName));
                        paramList.Add(new SqlCommandParameter() { Name = "@Curr_{0}".FormatEx(fieldName), DataType = field.DataType, Value = dr[fieldName] });
                    }
                    else
                    {
                        if (field.InsertDefaultValue != null && field.InsertDefaultValue != DBNull.Value)
                        {
                            var paramValue = DefaultValueHelper.GetValue(field.InsertDefaultValue);
                            fieldParamsBuilder.Append(string.Format("{0}, ", paramValue));
                        }
                        else
                        {
                            fieldParamsBuilder.Append(string.Format("@Curr_{0}, ", fieldName));
                            paramList.Add(new SqlCommandParameter() { Name = "@Curr_{0}".FormatEx(fieldName), DataType = field.DataType, Value = DBNull.Value });
                        }
                    }
                }
            }

            string fields = fieldsBuilder.ToString();
            string fieldParams = fieldParamsBuilder.ToString();

            if (!string.IsNullOrWhiteSpace(fields) && fields.LastIndexOf(",") >= 0)
            {
                fields = fields.Substring(0, fields.LastIndexOf(","));
                fieldParams = fieldParams.Substring(0, fieldParams.LastIndexOf(","));
            }
            cmd.CommandText = string.Format(" INSERT {0} ({1}) VALUES({2})", tableName, fields, fieldParams);
            cmd.Parameters = paramList.ToArray();
            return cmd;
        }
    }
}
