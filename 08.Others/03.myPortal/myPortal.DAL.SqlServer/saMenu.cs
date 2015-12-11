using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using myPortal.Foundation.Extensions;

namespace myPortal.DAL.SqlServer
{
    public class saMenu : IsaMenu
    {
        public IList<saMenuInfo> GetMenus(int iUserId)
        {
            string sql = @"
IF EXISTS(
	SELECT TOP 1 1 
	FROM dbo.saUser a WITH(NOLOCK)
	JOIN dbo.saUserRole b WITH(NOLOCK) ON a.iIden=b.iUserId
	JOIN dbo.saRole c WITH(NOLOCK) ON b.iRoleId=c.iIden
	WHERE a.bUsable=1 AND c.IsActive=1 AND c.bIsAdministrator=1 AND a.iIden=@iUserId)
BEGIN

	SELECT d.iIden, d.sName, d.iParent, d.iSort, d.sUrl, d.iLevel, d.iOpenMode
	FROM [dbo].[saMenu] d 
	ORDER BY d.[iLevel], d.[iParent], d.[iSort],d.[iIden]

END
ELSE BEGIN

	SELECT DISTINCT d.iIden, d.sName, d.iParent, d.iSort, d.sUrl, d.iLevel, d.iOpenMode
	FROM [dbo].[saUser] a
	JOIN [dbo].[saUserRole] b ON [a].[iIden] = [b].[iUserId]
	JOIN [dbo].[saRoleMenu] c ON [b].[iRoleId] = [c].[iRoleId]
	JOIN [dbo].[saMenu] d ON [c].[iMenuId] = [d].[iIden]
	WHERE a.[iIden]=@iUserId
	ORDER BY d.[iLevel], d.[iParent], d.[iSort],d.[iIden]

END";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "iUserId", DbType.Int32, iUserId);
            List<saMenuInfo> list = new List<saMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(cmd))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }

        public IList<saMenuInfo> GetAllMenus()
        {
            string sql = @"SELECT * FROM dbo.saMenu WITH(NOLOCK) ORDER BY iLevel,iParent,iSort,iIden";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            List<saMenuInfo> list = new List<saMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(cmd))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }

        #region Static Method
        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public static myPortal.Model.saMenuInfo ReaderBind(IDataReader dataReader)
        {
            myPortal.Model.saMenuInfo model = new myPortal.Model.saMenuInfo();
            object ojb;
            ojb = dataReader["iIden"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iIden = (int)ojb;
            }
            model.sName = dataReader["sName"].ToString();
            ojb = dataReader["iParent"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iParent = (int)ojb;
            }
            ojb = dataReader["iSort"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iSort = (int)ojb;
            }
            model.sUrl = dataReader["sUrl"].ToString();
            ojb = dataReader["iLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iLevel = (int)ojb;
            }
            ojb = dataReader["iOpenMode"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iOpenMode = (int)ojb;
            }
            return model;
        }

        #endregion

        public void Delete(string[] iMenuIds)
        {
            string ids = string.Empty;
            foreach (var item in iMenuIds)
            {
                ids += "'" + item + "',";
            }
            ids += "'-1'";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand("sppbDeleteTreeNode");
            db.AddInParameter(cmd, "sTableName", DbType.String, saMenuInfo.sTableName);
            db.AddInParameter(cmd, "sKeyFieldName", DbType.String, "iIden");
            db.AddInParameter(cmd, "sParentFieldName", DbType.String, "iParent");
            db.AddInParameter(cmd, "iIdens", DbType.String, ids);
            db.ExecuteNonQuery(cmd);
        }


        public IList<saMenuInfo> GetChildMenus(int iMenuId)
        {
            string sql = @"SELECT * FROM dbo.saMenu WITH(NOLOCK) WHERE iParent=@iMenuId order by iSort";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "iMenuId", DbType.Int32, iMenuId);
            List<saMenuInfo> list = new List<saMenuInfo>();
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
        /// 得到一个对象实体
        /// </summary>
        public myPortal.Model.saMenuInfo GetMenu(int iMenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from saMenu with(nolock)");
            strSql.Append(" where iIden=@iMenuId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iMenuId", DbType.Int32, iMenuId);
            myPortal.Model.saMenuInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        public void Update(saMenuInfo menu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update saMenu set ");
            strSql.Append("sName=@sName,");
            strSql.Append("iParent=@iParent,");
            strSql.Append("iSort=@iSort,");
            strSql.Append("sUrl=@sUrl,");
            strSql.Append("iLevel=@iLevel,");
            strSql.Append("iOpenMode=@iOpenMode");
            strSql.Append(" where iIden=@iIden ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, menu.iIden);
            db.AddInParameter(dbCommand, "sName", DbType.String, menu.sName);
            db.AddInParameter(dbCommand, "iParent", DbType.Int32, menu.iParent);
            db.AddInParameter(dbCommand, "iSort", DbType.Int32, menu.iSort);
            db.AddInParameter(dbCommand, "sUrl", DbType.String, menu.sUrl);
            db.AddInParameter(dbCommand, "iLevel", DbType.Int32, menu.iLevel);
            db.AddInParameter(dbCommand, "iOpenMode", DbType.Int32, menu.iOpenMode);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Create(saMenuInfo menu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into saMenu(");
            strSql.Append("iIden,sName,iParent,iSort,sUrl,iLevel,iOpenMode,iCreator)");
            strSql.Append(" values (");
            strSql.Append("@iIden,@sName,@iParent,@iSort,@sUrl,@iLevel,@iOpenMode,@iCreator)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, menu.iIden);
            db.AddInParameter(dbCommand, "sName", DbType.String, menu.sName);
            db.AddInParameter(dbCommand, "iParent", DbType.Int32, menu.iParent);
            db.AddInParameter(dbCommand, "iSort", DbType.Int32, menu.iSort);
            db.AddInParameter(dbCommand, "sUrl", DbType.String, menu.sUrl);
            db.AddInParameter(dbCommand, "iLevel", DbType.Int32, menu.iLevel);
            db.AddInParameter(dbCommand, "iOpenMode", DbType.Int32, menu.iOpenMode);
            db.AddInParameter(dbCommand, "iCreator", DbType.Int32, menu.iCreator);
            db.ExecuteNonQuery(dbCommand);
        }
    }
}
