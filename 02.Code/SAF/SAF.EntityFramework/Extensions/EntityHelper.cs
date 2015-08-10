using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;
using SAF.Foundation;
using System.Data;
using System.Linq.Expressions;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    internal static class EntityHelper
    {
        private const string sSqlableInfo = @"
SELECT  Name= a.name, 
        DataType=TYPE_NAME(a.[system_type_id]),
        MaxLength= a.[max_length], 
        IsAllowNull=a.[is_nullable],
        IsPrimaryKey = CASE WHEN EXISTS ( SELECT top 1 1
                                  FROM sysobjects o
                                  INNER JOIN sysindexes i ON i.name = o.name
                                  INNER JOIN sysindexkeys k ON i.id = k.id AND i.indid = k.indid
                                  WHERE     xtype = 'PK' AND parent_obj = a.[object_id] AND k.colid = a.[column_id] )
                    THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END, 
         IsIdentity =a.[is_identity],
         IsVersionNumber=CAST(CASE WHEN TYPE_NAME(a.[system_type_id])='timestamp' THEN 1 ELSE 0 END AS BIT),
         b.InsertDefaultValue,b.UpdateDefaultValue
FROM    sys.columns a
LEFT JOIN dbo.sysTableColumn b with(nolock) ON a.[object_id]=OBJECT_ID(:tableName) AND a.name=b.ColumnName
WHERE   a.[object_id] = OBJECT_ID(:tableName)
ORDER BY a.[column_id] 
";
        internal static IEnumerable<FieldInfo> GetTableFields(string connectionName, string tableName)
        {
            string EntityTableFieldsCacheKey = CacheKey.EntityPropertiesPrefix + connectionName + "_" + tableName;
            List<FieldInfo> fields = CacheService.RetriveObject(EntityTableFieldsCacheKey) as List<FieldInfo>;
            if (fields == null)
            {
                var ds = DataPortal.ExecuteDataset(connectionName, sSqlableInfo, tableName);
                fields = new List<FieldInfo>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    var info = new FieldInfo()
                    {
                        Name = dr["Name"].ToString(),
                        DataType = SqlDataType2DbType.GetType(dr["DataType"].ToString()),
                        MaxLength = Convert.ToInt32(dr["MaxLength"]),
                        IsAllowNull = Convert.ToBoolean(dr["IsAllowNull"]),
                        IsPrimaryKey = Convert.ToBoolean(dr["IsPrimaryKey"]),
                        IsIdentity = Convert.ToBoolean(dr["IsIdentity"]),
                        IsVersionNumber = Convert.ToBoolean(dr["IsVersionNumber"]),
                        InsertDefaultValue=dr["InsertDefaultValue"],
                        UpdateDefaultValue = dr["UpdateDefaultValue"]
                    };
                    fields.Add(info);
                }
                CacheService.AddObject(EntityTableFieldsCacheKey, fields);
            }
            return fields;
        }

        public static string GetFieldName<T>(Expression<Func<T, object>> propertyLambdaExpression)
        {
            if (propertyLambdaExpression == null) throw new ArgumentNullException("propertyLambdaExpression");

            var lambda = propertyLambdaExpression as LambdaExpression;
            if (lambda == null) throw new ArgumentException("Not a lambda expression", "member");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null || memberExpr.Member == null) throw new ArgumentException("Not a member access", "propertyLambdaExpression");

            return memberExpr.Member.Name;
        }

    }

    internal class FieldInfo
    {
        public string Name { get; set; }
        public DbType DataType { get; set; }
        public int MaxLength { get; set; }
        public bool IsAllowNull { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsVersionNumber { get; set; }

        public object UpdateDefaultValue { get; set; }

        public object InsertDefaultValue { get; set; }
    }

    internal static class SqlDataType2DbType
    {
        private static Dictionary<string, DbType> dic = new Dictionary<string, DbType>();

        static SqlDataType2DbType()
        {
            dic.Add("image", DbType.Binary);
            dic.Add("text", DbType.String);
            dic.Add("uniqueidentifier", DbType.Guid);
            dic.Add("date", DbType.Date);
            dic.Add("time", DbType.Time);
            dic.Add("datetime2", DbType.DateTime2);
            dic.Add("datetimeoffset", DbType.DateTimeOffset);
            dic.Add("tinyint", DbType.Int16);
            dic.Add("smallint", DbType.Int16);
            dic.Add("int", DbType.Int32);
            dic.Add("smalldatetime", DbType.DateTime);
            dic.Add("real", DbType.Double);
            dic.Add("money", DbType.Currency);
            dic.Add("datetime", DbType.DateTime);
            dic.Add("float", DbType.Decimal);
            dic.Add("sql_variant", DbType.Binary);
            dic.Add("ntext", DbType.String);
            dic.Add("bit", DbType.Boolean);
            dic.Add("decimal", DbType.Decimal);
            dic.Add("numeric", DbType.Decimal);
            dic.Add("smallmoney", DbType.Currency);
            dic.Add("bigint", DbType.Int64);
            dic.Add("hierarchyid", DbType.Binary);
            dic.Add("varbinary", DbType.Binary);
            dic.Add("varchar", DbType.String);
            dic.Add("binary", DbType.Binary);
            dic.Add("char", DbType.String);
            dic.Add("timestamp", DbType.Int64);
            dic.Add("nvarchar", DbType.String);
            dic.Add("nchar", DbType.String);
            dic.Add("xml", DbType.Xml);
        }

        public static DbType GetType(string dataType)
        {
            if (dic.ContainsKey(dataType))
                return dic[dataType];
            return DbType.String;
        }
    }

 
}
