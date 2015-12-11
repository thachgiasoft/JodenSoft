using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using myPortal.Foundation.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using myPortal.Foundation.Utils;

namespace myPortal.DAL.SqlServer
{
    public class saBulletin : IsaBulletin
    {
        public IList<saBulletinInfo> GetAllBulletins()
        {
            string sql = @"
declare @dt datetime
set @dt=GETDATE()
SELECT *
FROM [dbo].[saBulletin] WITH(NOLOCK)
WHERE bUsable=1 AND tStartTime<=@dt AND tEndTime>=@dt ";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            List<saBulletinInfo> list = new List<saBulletinInfo>();
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
        /// 1分钟以内发布的算是新公告
        /// </summary>
        /// <returns></returns>
        public IList<saBulletinInfo> GetNewBulletins()
        {
            string sql = @"
declare @dt datetime
set @dt=GETDATE()
SELECT *
FROM [dbo].[saBulletin] WITH(NOLOCK)
WHERE bUsable=1 AND tStartTime<=@dt AND tEndTime>=@dt AND tUpdateTime>=DATEADD(mi,-10,@dt)";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            List<saBulletinInfo> list = new List<saBulletinInfo>();
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
        /// 批量删除数据
        /// </summary>
        public void DeleteBulletins(string[] iBulletinIds)
        {
            string ids = string.Empty;
            foreach (var item in iBulletinIds)
            {
                ids += "'" + item + "',";
            }
            ids += "'-1'";
            string sql = "update saBulletin set bUsable=0 where iIden in ({0})".FormatEx(ids);
            var db = DatabaseFactory.CreateDatabase();
            db.ExecuteNonQuery(CommandType.Text, sql);
        }


        public saBulletinInfo GetBulletin(int iBulletinId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from saBulletin with(nolock)");
            strSql.Append(" where iIden=@iIden ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, iBulletinId);
            saBulletinInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        public void Create(saBulletinInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into saBulletin(");
            strSql.Append(" iIden,sTitle,sContent,tStartTime,tEndTime,iBulletinType,iBulletinLevel,tCreateTime,iCreator,tUpdateTime,bUsable)");
            strSql.Append(" values (");
            strSql.Append(" @iIden,@sTitle,@sContent,@tStartTime,@tEndTime,@iBulletinType,@iBulletinLevel,@tCreateTime,@iCreator,@tUpdateTime,@bUsable)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
            db.AddInParameter(dbCommand, "sTitle", DbType.String, model.sTitle);
            db.AddInParameter(dbCommand, "sContent", DbType.String, model.sContent);
            db.AddInParameter(dbCommand, "tStartTime", DbType.DateTime, model.tStartTime);
            db.AddInParameter(dbCommand, "tEndTime", DbType.DateTime, model.tEndTime);
            db.AddInParameter(dbCommand, "iBulletinType", DbType.Int32, model.iBulletinType);
            db.AddInParameter(dbCommand, "iBulletinLevel", DbType.Int32, model.iBulletinLevel);
            db.AddInParameter(dbCommand, "tCreateTime", DbType.DateTime, model.tCreateTime);
            db.AddInParameter(dbCommand, "iCreator", DbType.Int32, model.iCreator);
            db.AddInParameter(dbCommand, "tUpdateTime", DbType.DateTime, model.tUpdateTime);
            db.AddInParameter(dbCommand, "bUsable", DbType.Boolean, model.bUsable);
            db.ExecuteScalar(dbCommand);
        }


        public void Update(saBulletinInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update saBulletin set ");
            strSql.Append(" sTitle=@sTitle,");
            strSql.Append(" sContent=@sContent,");
            strSql.Append(" tStartTime=@tStartTime,");
            strSql.Append(" tEndTime=@tEndTime,");
            strSql.Append(" iBulletinType=@iBulletinType,");
            strSql.Append(" iBulletinLevel=@iBulletinLevel,");
            strSql.Append(" tUpdateTime=@tUpdateTime");
            strSql.Append(" where iIden=@iIden");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
            db.AddInParameter(dbCommand, "sTitle", DbType.String, model.sTitle);
            db.AddInParameter(dbCommand, "sContent", DbType.String, model.sContent);
            db.AddInParameter(dbCommand, "tStartTime", DbType.DateTime, model.tStartTime);
            db.AddInParameter(dbCommand, "tEndTime", DbType.DateTime, model.tEndTime);
            db.AddInParameter(dbCommand, "iBulletinType", DbType.Int32, model.iBulletinType);
            db.AddInParameter(dbCommand, "iBulletinLevel", DbType.Int32, model.iBulletinLevel);
            db.AddInParameter(dbCommand, "tUpdateTime", DbType.DateTime, model.tUpdateTime);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public static saBulletinInfo ReaderBind(IDataReader dataReader)
        {
            if (dataReader == null)
                return null;
            saBulletinInfo model = new saBulletinInfo();
            object ojb;
            ojb = dataReader["iIden"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iIden = (int)ojb;
            }
            model.sTitle = dataReader["sTitle"].ToString();
            model.sContent = dataReader["sContent"].ToString();
            ojb = dataReader["tStartTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tStartTime = (DateTime)ojb;
            }
            ojb = dataReader["tEndTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tEndTime = (DateTime)ojb;
            }
            ojb = dataReader["iBulletinType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iBulletinType = (int)ojb;
            }
            ojb = dataReader["iBulletinLevel"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iBulletinLevel = (int)ojb;
            }
            ojb = dataReader["tCreateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tCreateTime = (DateTime)ojb;
            }
            ojb = dataReader["iCreator"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iCreator = (int)ojb;
            }
            ojb = dataReader["tUpdateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tUpdateTime = (DateTime)ojb;
            }
            ojb = dataReader["bUsable"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bUsable = (bool)ojb;
            }
            return model;
        }


        public IList<saBulletinInfo> GetAll(string tStar, string tEnd, string sCaption)
        {
            string sql = @"
SELECT iIden, sTitle, sContent, tStartTime, tEndTime, iBulletinType, 
iBulletinLevel, tCreateTime, iCreator, tUpdateTime, bUsable 
FROM [dbo].[saBulletin] WITH(NOLOCK)
WHERE bUsable=1 AND tUpdateTime>=@tStar AND tUpdateTime<=@tEnd  and sTitle like '%'+@sCaption+'%'";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "tStar", DbType.String, tStar);
            db.AddInParameter(cmd, "tEnd", DbType.String, tEnd);
            db.AddInParameter(cmd, "sCaption", DbType.String, sCaption);
            List<saBulletinInfo> list = new List<saBulletinInfo>();
            using (IDataReader dataReader = db.ExecuteReader(cmd))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }



      
    }
}
