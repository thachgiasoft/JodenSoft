using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace myPortal.DAL.SqlServer
{
    public class saBulletinType : IsaBulletinType
    {
        public IList<saBulletinTypeInfo> GetAllBulletinType()
        {
            string sql = "SELECT * FROM dbo.saBulletinType with(NOLOCK) order by iSort";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            List<saBulletinTypeInfo> list = new List<saBulletinTypeInfo>();
            using (IDataReader dataReader = db.ExecuteReader(cmd))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;

        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        private static myPortal.Model.saBulletinTypeInfo ReaderBind(IDataReader dataReader)
        {
            myPortal.Model.saBulletinTypeInfo model = new myPortal.Model.saBulletinTypeInfo();
            object ojb;
            ojb = dataReader["iIden"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iIden = (int)ojb;
            }
            model.sName = dataReader["sName"].ToString();
            ojb = dataReader["iSort"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iSort = (int)ojb;
            }

            ojb = dataReader["bUsable"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bUsable = (bool)ojb;
            }
            return model;
        }


        public void Create(saBulletinTypeInfo saBulletinType)
        {
            string errMessage = string.Empty;
            if (!CheckUQ.CheckUqBeforeInsert(saBulletinTypeInfo.sTableName, saBulletinType, out errMessage))
                throw new Exception(errMessage);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into saBulletinType(");
            strSql.Append("iIden,sName,iSort,bUsable)");

            strSql.Append(" values (");
            strSql.Append("@iIden,@sName,@iSort,@bUsable)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, saBulletinType.iIden);
            db.AddInParameter(dbCommand, "sName", DbType.String, saBulletinType.sName);
            db.AddInParameter(dbCommand, "iSort", DbType.Int32, saBulletinType.iSort);
            db.AddInParameter(dbCommand, "bUsable", DbType.Boolean, saBulletinType.bUsable);
            db.ExecuteScalar(dbCommand);
        }

        public void Update(saBulletinTypeInfo saBulletinType)
        {
            string errMessage = string.Empty;
            if (!CheckUQ.CheckUqBeforeUpdate(saBulletinTypeInfo.sTableName, saBulletinType, out errMessage))
                throw new Exception(errMessage);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update saBulletinType set ");
            strSql.Append("sName=@sName,");
            strSql.Append("bUsable=@bUsable,");
            strSql.Append("iSort=@iSort");
            strSql.Append(" where iIden=@iIden ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, saBulletinType.iIden);
            db.AddInParameter(dbCommand, "sName", DbType.String, saBulletinType.sName);
            db.AddInParameter(dbCommand, "iSort", DbType.Int32, saBulletinType.iSort);
            db.AddInParameter(dbCommand, "bUsable", DbType.Boolean, saBulletinType.bUsable);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Delete(string[] iIdens)
        {
            string ids = string.Empty;
            string message = string.Empty;
            foreach (var item in iIdens)
            {
                //if (!CheckFKReferences.CheckFKBeforeDelete(saBulletinTypeInfo.sTableName, int.Parse(item), out message))
                //    throw new Exception(message);
                ids += "'" + item + "',";
            }
            ids += "'-1'";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update saBulletinType set  bUsable=0 ");
            strSql.Append(" where iIden in ({0}) ");
            Database db = DatabaseFactory.CreateDatabase();

            db.ExecuteNonQuery(CommandType.Text, string.Format(strSql.ToString(), ids));
        }
    }
}
