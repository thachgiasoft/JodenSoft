using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using myPortal.Foundation.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace myPortal.DAL.SqlServer
{
    public class saUser : IsaUser
    {
        public void ChangePassword(int iUserId, string newPwd)
        {
            string sql = @" update saUser set sPassword=@sPassword where iIden=@iUserId";
            Database db = DatabaseFactory.CreateDatabase();
            var cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "iUserId", DbType.Int32, iUserId);
            db.AddInParameter(cmd, "sPassword", DbType.String, newPwd);
            db.ExecuteNonQuery(cmd);
        }

        public saUserInfo GetUser(int iUserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM [dbo].[saUser] WITH(NOLOCK)");
            strSql.Append(" where iIden=@iUserId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "iUserId", DbType.Int32, iUserId);
            saUserInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            if (model != null)
            {
                string sql = "SELECT * FROM dbo.saUserRole WITH(NOLOCK) WHERE [iUserId]=@iUserId";
                DbCommand cmd = db.GetSqlStringCommand(sql);
                db.AddInParameter(cmd, "iUserId", DbType.Int32, iUserId);
                using (IDataReader dataReader = db.ExecuteReader(cmd))
                {
                    while (dataReader.Read())
                    {
                        var m = saUserRole.ReaderBind(dataReader);
                        model.UserOrgRole.Add(m);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iUserId">用户ID</param>
        public void Delete(int iUserId)
        {
            StringBuilder sDeleteUser = new StringBuilder();
            sDeleteUser.Append(" update dbo.saUser set bUsable=0  WHERE iIden = @iUserId and bIsSystem=0");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sDeleteUser.ToString());
            db.AddInParameter(dbCommand, "iUserId", DbType.Int32, iUserId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Update(saUserInfo model)
        {
            string errMessage = string.Empty;
            if (!CheckUQ.CheckUqBeforeUpdate(saUserInfo.sTableName, model, out errMessage))
                throw new Exception(errMessage);

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update saUser set ");
            strSql.Append(" sUserNo=@sUserNo,");
            strSql.Append(" sUserName=@sUserName,");
            strSql.Append(" sEmail=@sEmail,");
            strSql.Append(" sRemark=@sRemark,");
            strSql.Append(" bUsable=@bUsable");
            strSql.Append(" where iIden=@iIden ");

            string deleteSql = "delete saUserRole where iUserId={0}".FormatEx(model.iIden);

            StringBuilder strSqlUor = new StringBuilder();
            strSqlUor.Append("insert into saUserRole(");
            strSqlUor.Append("iIden,iUserId,iRoleId)");
            strSqlUor.Append(" values (");
            strSqlUor.Append("@iIden,@iUserId,@iRoleId)");

            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trans = con.BeginTransaction();
                try
                {
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
                    db.AddInParameter(dbCommand, "sUserNo", DbType.String, model.sUserNo);
                    db.AddInParameter(dbCommand, "sUserName", DbType.String, model.sUserName);
                    db.AddInParameter(dbCommand, "sEmail", DbType.String, model.sEmail);
                    db.AddInParameter(dbCommand, "sRemark", DbType.String, model.sRemark);
                    db.AddInParameter(dbCommand, "bUsable", DbType.Boolean, model.bUsable);
                    db.ExecuteNonQuery(dbCommand, trans);

                    db.ExecuteNonQuery(trans, CommandType.Text, deleteSql);

                    if (model.UserOrgRole != null && model.UserOrgRole.Count() > 0)
                    {
                        foreach (var item in model.UserOrgRole)
                        {
                            DbCommand cmd = db.GetSqlStringCommand(strSqlUor.ToString());
                            db.AddInParameter(cmd, "iIden", DbType.Int32, item.iIden);
                            db.AddInParameter(cmd, "iUserId", DbType.Int32, item.iUserId);
                            db.AddInParameter(cmd, "iRoleId", DbType.Int32, item.iRoleId);
                            db.ExecuteNonQuery(cmd, trans);
                        }
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<saUserInfo> GetAllUser()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM [dbo].[saUser] WITH(NOLOCK)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            IList<saUserInfo> list = new List<saUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Create(saUserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into saUser(iIden,sUserNo,sUserName,sPassword,sEmail,sRemark,bUsable,bIsSystem)");
            strSql.Append(" values (@iIden,@sUserNo,@sUserName,@sPassword,@sEmail,@sRemark,@bUsable,0)");

            string deleteSql = "delete saUserRole where iUserId={0}".FormatEx(model.iIden);

            StringBuilder strSqlUor = new StringBuilder();
            strSqlUor.Append("insert into saUserRole(iIden,iUserId,iRoleId)");
            strSqlUor.Append(" values (@iIden,@iUserId,@iRoleId)");

            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trans = con.BeginTransaction();
                try
                {
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
                    db.AddInParameter(dbCommand, "sUserNo", DbType.String, model.sUserNo);
                    db.AddInParameter(dbCommand, "sUserName", DbType.String, model.sUserName);
                    db.AddInParameter(dbCommand, "sPassword", DbType.String, model.sPassword);
                    db.AddInParameter(dbCommand, "sEmail", DbType.String, model.sEmail);

                    db.AddInParameter(dbCommand, "sRemark", DbType.String, model.sRemark);

                    db.AddInParameter(dbCommand, "bUsable", DbType.String, model.bUsable);
                    db.ExecuteNonQuery(dbCommand, trans);

                    db.ExecuteNonQuery(trans, CommandType.Text, deleteSql);

                    if (model.UserOrgRole != null && model.UserOrgRole.Count() > 0)
                    {
                        foreach (var item in model.UserOrgRole)
                        {
                            DbCommand cmd = db.GetSqlStringCommand(strSqlUor.ToString());
                            db.AddInParameter(cmd, "iIden", DbType.Int32, item.iIden);
                            db.AddInParameter(cmd, "iUserId", DbType.Int32, item.iUserId);
                            db.AddInParameter(cmd, "iRoleId", DbType.Int32, item.iRoleId);

                            db.ExecuteNonQuery(cmd, trans);
                        }
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="iUserIds">用户IDs</param>
        public void Delete(string[] iUserIds)
        {
            string ids = string.Empty;
            string message = string.Empty;
            foreach (var item in iUserIds)
            {
                ids += "'" + item + "',";
            }
            ids += "'-1'";
            StringBuilder sDeleteUser = new StringBuilder();
            sDeleteUser.Append(" update [dbo].[saUser] set bUsable=0 where iIden in ({0}) and bIsSystem=0".FormatEx(ids));

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sDeleteUser.ToString());
            db.ExecuteNonQuery(dbCommand);
            
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public static myPortal.Model.saUserInfo ReaderBind(IDataReader dataReader)
        {
            myPortal.Model.saUserInfo model = new myPortal.Model.saUserInfo();
            object ojb;
            ojb = dataReader["iIden"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.iIden = Convert.ToInt32(ojb.ToString());
            }

            model.sUserNo = dataReader["sUserNo"].ToString();
            model.sUserName = dataReader["sUserName"].ToString();
            model.sPassword = dataReader["sPassword"].ToString();
            model.sEmail = dataReader["sEmail"].ToString();
            model.sRemark = dataReader["sRemark"].ToString();
            ojb = dataReader["bUsable"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bUsable = (bool)ojb;
            }
            ojb = dataReader["bIsSystem"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bIsSystem = (bool)ojb;
            }
            return model;
        }

        public IList<saUserInfo> GetAllUser(int iCompanyId)
        {
            string strSql = @"
SELECT a.* 
FROM [dbo].[saUser] a WITH(NOLOCK)";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            IList<saUserInfo> list = new List<saUserInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable GetPageList(QueryUserParams param)
        {
            string fields = @" * ";
            string table = @" saUser A with(nolock) ";
            StringBuilder where = new StringBuilder();
            where.Append(" 1=1 ");


            if (!param.sUserNo.IsNullOrWhiteSpace())
            {
                where.Append(" and A.sUserNo like '%{0}%'".FormatEx(param.sUserNo.Trim()));
            }

            if (!param.sUserName.IsNullOrWhiteSpace())
            {
                where.Append(" and A.sUserName like '%{0}%'".FormatEx(param.sUserName.Trim()));
            }

            string order = "A.sUserNo Asc ";

            int pages = 0;
            int records = 0;
            DataTable dt = new DbServer().PageQuery(table, fields.ToString(), order.ToString(), where.ToString(), string.Empty, string.Empty, param.PageControl.PageSize, param.PageControl.PageIndex, 0, out pages, out records);
            param.PageControl.TotalPageCount = pages;
            param.PageControl.TotalRecordCount = records;
            return dt;
        }
    }
}
