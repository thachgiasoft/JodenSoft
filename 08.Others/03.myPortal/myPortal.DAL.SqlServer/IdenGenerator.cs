using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using System.Data.Objects;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using myPortal.Foundation.Extensions;

namespace myPortal.DAL.SqlServer
{
    /// <summary>
    /// iIden生成器
    /// </summary>
    public class IdenGenerator : IIdenGenerator
    {
        /// <summary>
        /// 生成新的iIden
        /// </summary>
        /// <param name="sGroupName">iIden的分组名称，一般为表名</param>
        /// <returns>返回生成的iIden</returns>
        public int NewIden(string sGroupName)
        {
            if (sGroupName.IsNullOrWhiteSpace())
                throw new ArgumentNullException("NewIden.sGroupName");
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection dbconn = db.CreateConnection())
            {
                dbconn.Open();
                DbTransaction trans = dbconn.BeginTransaction();
                try
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("sppbGenerateIden");
                    db.AddInParameter(dbCommand, "@sGroup", DbType.String, sGroupName);
                    db.AddInParameter(dbCommand, "@iCount", DbType.Int32, 1);
                    db.AddInParameter(dbCommand, "@iType", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "@iStart", DbType.Int32, 4);
                    db.AddInParameter(dbCommand, "@bSave", DbType.Boolean, true);
                    db.AddInParameter(dbCommand, "@bReturn", DbType.Boolean, false);
                    db.ExecuteScalar(dbCommand, trans);
                    object obj = db.GetParameterValue(dbCommand, "@iStart");
                    int newId = int.MinValue;
                    if (obj != null && obj != DBNull.Value)
                    {
                        newId = int.Parse(obj.ToString());
                    }
                    trans.Commit();
                    return newId;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    dbconn.Close();
                }
            }
        }
    }
}
