using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using myPortal.Model;

namespace myPortal.DAL.SqlServer
{
    public class saUserRole : IsaUserRole
    {

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public static myPortal.Model.saUserRoleInfo ReaderBind(IDataReader dataReader)
        {
            myPortal.Model.saUserRoleInfo model = new myPortal.Model.saUserRoleInfo();
            object ojb;
            ojb = dataReader["iIden"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iIden = (int)ojb;
            }
            ojb = dataReader["iUserId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iUserId = (int)ojb;
            }


            ojb = dataReader["iRoleId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iRoleId = (int)ojb;
            }

            return model;
        }

        public IList<Model.saUserRoleInfo> GetList(int iRoleId, int iUserId)
        {
            string strSql = @"
SELECT a.* 
FROM [dbo].[saUserRole] a WITH(NOLOCK)
where iRoleId=@iRoleId and a.[iUserId]<>@iUserId";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "iRoleId", DbType.Int32, iRoleId);
            db.AddInParameter(dbCommand, "iUserId", DbType.Int32, iUserId);
            IList<saUserRoleInfo> list = new List<saUserRoleInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        public int UserHasAuditRight(int iUserId)
        {
            string strSql = "SELECT COUNT(*) FROM dbo.saUserRole WHERE iUserId=@iUserId";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "iUserId", DbType.Int32, iUserId);
            object obj = db.ExecuteScalar(dbCommand);
            if (obj != null)
                return int.Parse(obj.ToString());
            else
                return 0;
        }
    }
}
