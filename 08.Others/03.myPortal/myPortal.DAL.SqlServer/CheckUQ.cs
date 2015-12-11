using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using myPortal.Foundation.Extensions;

namespace myPortal.DAL.SqlServer
{
    /// <summary>
    /// 在新增之前检查是否存在数据(辅助类)
    /// </summary>
    public static class CheckUQ
    {
        /// <summary>
        /// 新增之前检查是否存在数据
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <param name="model">实体</param>
        /// <param name="errMessage">错误消息</param>
        /// <returns>存在则返回TRUE,否则返回FALSE</returns>
        public static bool CheckUqBeforeInsert(string sTableName, object model, out string errMessage)
        {
            try
            {
                var db = DatabaseFactory.CreateDatabase();
                DataTable uqs = GetUQS(sTableName);
                string sParams, sTable, sConditions;
                int count = 0;
                foreach (DataRow row in uqs.Rows)
                {
                    sParams = row["sParams"].ToString();
                    sTable = row["sTableName"].ToString();
                    sConditions = row["sConditions"].ToString();
                    string query = "SELECT COUNT(*) FROM {0} with(nolock) WHERE {1}".FormatEx(sTable, sConditions);
                    DbCommand fcmd = db.GetSqlStringCommand(query);
                    foreach (var item in sParams.Split(','))
                    {
                        db.AddInParameter(fcmd, item.ToString(), DbType.String, GetPropertyValue(model, item.Trim()));
                    }
                    count = int.Parse(db.ExecuteScalar(fcmd).ToString());
                    if (count > 0)
                    {
                        string sql2 = "SELECT [sDescription] FROM [dbo].[dvTableDefine] WHERE [sTableName]='{0}'".FormatEx(sTableName);
                        string description = db.ExecuteScalar(CommandType.Text, sql2).ToStringEx();
                        if (description.IsNullOrWhiteSpace())
                            description = sTableName;
                        errMessage = "您要添加的数据已在[{0}]中存在，无法添加重复数据！".FormatEx(description);
                        return false;
                    }
                }
                errMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 获取唯一键列表
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <returns>唯一键列表</returns>
        private static DataTable GetUQS(string sTableName)
        {
            string sql = @"
WITH result AS
(  
	SELECT [sIndexName]=A.name,[sTableName]=C.name,[sColumnName]=D.name
		,[bUnique]=Convert(Bit,CASE WHEN (A.status & 2)<>0 THEN 1 ELSE 0 END)
		,[bPrimaryKey]=Convert(Bit,CASE WHEN E.xType='PK' THEN 1 ELSE 0 END)
		,[bClustered]=Convert(Bit,CASE WHEN A.status & 16<>0 THEN 1 ELSE 0 END)
		,[bConstraint]=Convert(Bit,CASE WHEN E.xType IS NULL THEN 0 ELSE 1 END)
	FROM dbo.sysindexes A WITH(NOLOCK)
	INNER JOIN dbo.sysindexkeys B WITH(NOLOCK) ON A.id=B.id AND A.indid=B.indid
	INNER JOIN dbo.sysobjects C WITH(NOLOCK) ON A.id=C.id
	INNER JOIN dbo.syscolumns D WITH(NOLOCK) ON D.id=A.id AND D.colid=B.colid
	LEFT JOIN dbo.sysobjects E WITH(NOLOCK) ON E.xtype in ('PK','UQ') AND E.parent_obj=C.id AND A.name=E.name 
	WHERE C.name=@sTableName
)
SELECT [sIndexName],[sTableName],sConditions=[dbo].[fnpbConcatStringDistinctEx]([sColumnName]+'=@'+[sColumnName],' and '),
sParams=[dbo].[fnpbConcatStringDistinct]([sColumnName])
FROM result 
WHERE [bUnique]=1 AND [bPrimaryKey]=0 
GROUP BY [sIndexName],[sTableName]
ORDER BY [sIndexName]";
            var db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "sTableName", DbType.String, sTableName);
            return db.ExecuteDataSet(cmd).Tables[0];
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj">实体</param>
        /// <param name="sPropertyName">属性名</param>
        /// <returns>属性值</returns>
        private static string GetPropertyValue(object obj, string sPropertyName)
        {
            try
            {
                Type Ts = obj.GetType();
                object o = Ts.GetProperty(sPropertyName).GetValue(obj, null);
                string Value = Convert.ToString(o);
                if (string.IsNullOrEmpty(Value)) return null;
                return Value;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 更新之前检查数据是否存在
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <param name="model">实体</param>
        /// <param name="errMessage">出错消息</param>
        /// <returns>存在则返回TRUE,否则返回FALSE</returns>
        public static bool CheckUqBeforeUpdate(string sTableName, object model, out string errMessage)
        {
            try
            {
                var db = DatabaseFactory.CreateDatabase();
                DataTable uqs = GetUQS(sTableName);
                string sParams, sTable, sConditions;
                foreach (DataRow row in uqs.Rows)
                {
                    sParams = row["sParams"].ToString();
                    sTable = row["sTableName"].ToString();
                    sConditions = row["sConditions"].ToString();
                    string query = "SELECT iIden FROM {0} with(nolock) WHERE {1}".FormatEx(sTable, sConditions);
                    DbCommand fcmd = db.GetSqlStringCommand(query);
                    foreach (var item in sParams.Split(','))
                    {
                        db.AddInParameter(fcmd, item.ToString(), DbType.String, GetPropertyValue(model, item.Trim()));
                    }
                    object o = db.ExecuteScalar(fcmd);
                    if (!o.ToStringEx().IsNullOrWhiteSpace() && o.ToStringEx() != GetPropertyValue(model, "iIden").ToStringEx())
                    {
                        string sql2 = "SELECT [sDescription] FROM [dbo].[dvTableDefine] WHERE [sTableName]='{0}'".FormatEx(sTableName);
                        string description = db.ExecuteScalar(CommandType.Text, sql2).ToStringEx();
                        if (description.IsNullOrWhiteSpace())
                            description = sTableName;
                        errMessage = "您要更新的数据已在[{0}]中存在，无法更新数据！".FormatEx(description);
                        return false;
                    }
                }
                errMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                return false;
            }
        }

    }
}
