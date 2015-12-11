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
    /// 在删除之前检查是否存在外键约束(辅助类)
    /// </summary>
    public static class CheckFKReferences
    {
        /// <summary>
        /// 检查是否存在外键约束
        /// </summary>
        /// <param name="iIden">要删除记录的主键</param>
        /// <param name="tableName">记录所在的表</param>
        public static bool CheckFKBeforeDelete(string tableName, int iIden, out string errMessage)
        {
            try
            {
                string strForeignSql = @"
select object_name(constid) as name  ,
object_name(fkeyid) as foreignTables,
[dbo].[fnpbConcatStringDistinctEX](col_name(fkeyid,fkey)+'=@'+col_name(rkeyid,rkey),' AND ') as foreignColumn ,
object_name(rkeyid) as primaryTables,
[dbo].[fnpbConcatStringDistinct](col_name(rkeyid,rkey)) as primaryColumn 
from sysforeignkeys c
INNER JOIN dbo.sysobjects F WITH (NOLOCK) ON F.id = C.constId
WHERE object_name(rkeyid)=@tableName and col_name(rkeyid,rkey)<>'icompanyId' and
Convert(bit,ObjectProperty(F.id,'CnstIsDeleteCascade')) =0
GROUP BY  constid,fkeyid,rkeyid
ORDER BY [fkeyid],[rkeyid]";
                var db = DatabaseFactory.CreateDatabase();
                DbCommand cmd = db.GetSqlStringCommand(strForeignSql);
                db.AddInParameter(cmd, "tableName", DbType.String, tableName);
                DataTable fts = db.ExecuteDataSet(cmd).Tables[0];
                //取得当前表的所有外键信息
                string fId, fTable;
                int count = 0;
                foreach (DataRow row in fts.Rows)
                {
                    fId = row["foreignColumn"].ToString();
                    fTable = row["foreignTables"].ToString();
                    string sql = "SELECT COUNT(*) FROM {0} with(nolock) WHERE {1}".FormatEx(fTable, fId);

                    DbCommand fcmd = db.GetSqlStringCommand(sql);
                    db.AddInParameter(fcmd, row["primaryColumn"].ToString(), DbType.Int16, iIden);

                    count = int.Parse(db.ExecuteScalar(fcmd).ToString());
                    if (count > 0)
                    {
                        if (row["foreignTables"].ToString() != "saUserRole")
                        {
                            string sql2 = "SELECT [sDescription] FROM [dbo].[dvTableDefine] WHERE [sTableName]='{0}'".FormatEx(fTable);
                            string description = db.ExecuteScalar(CommandType.Text, sql2).ToStringEx();
                            if (description.IsNullOrWhiteSpace())
                                description = fTable;
                            errMessage = "您要删除的数据已在[{0}]中使用，要删除该条数据，请先删除[{0}]中的相关数据后，再执行此删除操作！".FormatEx(description);
                            return false;
                        }
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

