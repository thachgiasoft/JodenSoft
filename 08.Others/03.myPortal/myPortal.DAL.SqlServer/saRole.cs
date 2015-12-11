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
    /// <summary>
    /// 
    /// </summary>
    public class saRole : IsaRole
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<saRoleInfo> GetAllRole()
        {
            string sql = @"SELECT * FROM [dbo].[saRole] WITH(NOLOCK) order by iSort";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            List<saRoleInfo> list = new List<saRoleInfo>();
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
        /// 
        /// </summary>
        /// <param name="iRoleIds"></param>
        public void Delete(string[] iRoleIds)
        {
            string ids = string.Empty;
            foreach (var item in iRoleIds)
            {
                ids += "'" + item + "',";
            }
            ids += "'-1'";

            Database db = DatabaseFactory.CreateDatabase();
            string sql = "update saRole set IsActive=0 where iIden in ({0}) and bIsAdministrator=0".FormatEx(ids);
            db.ExecuteNonQuery(CommandType.Text, sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="iMenuIds"></param>
        public void Update(saRoleInfo model, string iMenuIds)
        {
            string errMessage = string.Empty;
            if (!CheckUQ.CheckUqBeforeUpdate(saRoleInfo.sTableName, model, out errMessage))
                throw new Exception(errMessage);

            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trans = con.BeginTransaction();
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" update saRole set ");
                    strSql.Append(" sName=@sName,");
                    strSql.Append(" iSort=@iSort,");
                    strSql.Append(" sRemark=@sRemark,");
                    strSql.Append(" IsActive=@IsActive");
                    strSql.Append(" where iIden=@iIden ");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
                    db.AddInParameter(dbCommand, "sName", DbType.String, model.sName);
                    db.AddInParameter(dbCommand, "iSort", DbType.Int32, model.iSort);
                    db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, model.IsActive);
                    db.AddInParameter(dbCommand, "sRemark", DbType.String, model.sRemark);
                    db.ExecuteNonQuery(dbCommand, trans);
                    //删除角色的权限
                    string sql = "delete saRoleMenu where iRoleId=@iRoleId";
                    var cmd = db.GetSqlStringCommand(sql);
                    db.AddInParameter(cmd, "iRoleId", DbType.Int32, model.iIden);
                    db.ExecuteNonQuery(cmd, trans);
                    //保存角色的权限
                    if (!iMenuIds.IsNullOrWhiteSpace())
                    {
                        foreach (var iMenuId in iMenuIds.Split(','))
                        {
                            StringBuilder rmsql = new StringBuilder();
                            rmsql.Append(" insert into saRoleMenu(iIden,iRoleId,iMenuId)");
                            rmsql.Append(" values (@iIden,@iRoleId,@iMenuId)");
                            DbCommand rmcmd = db.GetSqlStringCommand(rmsql.ToString());
                            db.AddInParameter(rmcmd, "iIden", DbType.Int32, new IdenGenerator().NewIden(saRoleMenuInfo.sTableName));
                            db.AddInParameter(rmcmd, "iRoleId", DbType.Int32, model.iIden);

                            db.AddInParameter(rmcmd, "iMenuId", DbType.Int32, int.Parse(iMenuId));
                            db.ExecuteScalar(rmcmd, trans);
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
        /// <param name="model"></param>
        /// <param name="iMenuIds"></param>
        public void Create(saRoleInfo model, string iMenuIds)
        {
            string errMessage = string.Empty;
            if (!CheckUQ.CheckUqBeforeInsert(saRoleInfo.sTableName, model, out errMessage))
                throw new Exception(errMessage);

            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trans = con.BeginTransaction();
                try
                {
                    string sql = @" insert into saRole(iIden,sName,iSort,sRemark, IsActive,bIsAdministrator)  values (@iIden,@sName,@iSort,@sRemark, @IsActive,0)";
                    DbCommand dbCommand = db.GetSqlStringCommand(sql.ToString());
                    db.AddInParameter(dbCommand, "iIden", DbType.Int32, model.iIden);
                    db.AddInParameter(dbCommand, "sName", DbType.String, model.sName);
                    db.AddInParameter(dbCommand, "iSort", DbType.Int32, model.iSort);

                    db.AddInParameter(dbCommand, "sRemark", DbType.String, model.sRemark);
                    db.AddInParameter(dbCommand, "IsActive", DbType.Boolean, model.IsActive);
                    db.ExecuteScalar(dbCommand, trans);

                    //删除角色的权限
                    sql = "delete saRoleMenu where iRoleId=@iRoleId";
                    var cmd = db.GetSqlStringCommand(sql);
                    db.AddInParameter(cmd, "iRoleId", DbType.Int32, model.iIden);
                    db.ExecuteNonQuery(cmd, trans);
                    //保存角色的权限
                    if (!iMenuIds.IsNullOrWhiteSpace())
                    {
                        foreach (var iMenuId in iMenuIds.Split(','))
                        {
                            StringBuilder rmsql = new StringBuilder();
                            rmsql.Append(" insert into saRoleMenu(iIden,iRoleId,iMenuId)");
                            rmsql.Append(" values (@iIden,@iRoleId,@iMenuId)");
                            DbCommand rmcmd = db.GetSqlStringCommand(rmsql.ToString());
                            db.AddInParameter(rmcmd, "iIden", DbType.Int32, new IdenGenerator().NewIden(saRoleMenuInfo.sTableName));
                            db.AddInParameter(rmcmd, "iRoleId", DbType.Int32, model.iIden);

                            db.AddInParameter(rmcmd, "iMenuId", DbType.Int32, int.Parse(iMenuId));
                            db.ExecuteScalar(rmcmd, trans);
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
        /// <param name="iRoleId"></param>
        /// <returns></returns>
        public IList<saMenuInfo> GetMenuByRoleId(int iRoleId)
        {
            string sql = @"
SELECT b.*
FROM [dbo].[saRoleMenu] a
JOIN [dbo].[saMenu] b ON [a].[iMenuId] = [b].[iIden]
WHERE a.[iRoleId]=@iRoleId";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "iRoleId", DbType.Int32, iRoleId);
            List<saMenuInfo> list = new List<saMenuInfo>();
            using (IDataReader dataReader = db.ExecuteReader(cmd))
            {
                while (dataReader.Read())
                {
                    list.Add(saMenu.ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public static myPortal.Model.saRoleInfo ReaderBind(IDataReader dataReader)
        {
            myPortal.Model.saRoleInfo model = new myPortal.Model.saRoleInfo();
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


            ojb = dataReader["IsActive"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsActive = (bool)ojb;
            }

            ojb = dataReader["bIsAdministrator"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bIsAdministrator = (bool)ojb;
            }

            model.sRemark = dataReader["sRemark"].ToString();
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iOrganizationId"></param>
        /// <returns></returns>
        public IList<saRoleInfo> GetParentOrgRole()
        {
            string sql = @"SELECT a.* 
FROM [dbo].[saRole] a with(nolock)

order by a.iSort";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);

            List<saRoleInfo> list = new List<saRoleInfo>();
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
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<saRoleInfo> GetPageList(QueryRoleParams param)
        {
            string fields = @" * ";
            string table = @" saRole A with(nolock) ";
            StringBuilder where = new StringBuilder();
            where.Append(" 1=1 ");

            if (!param.sRoleName.IsNullOrWhiteSpace())
            {
                where.Append(" and A.sName like '%{0}%'".FormatEx(param.sRoleName.Trim()));
            }

            string order = "A.iSort Asc ";

            int pages = 0;
            int records = 0;
            DataTable dt = new DbServer().PageQuery(table, fields.ToString(), order.ToString(), where.ToString(), string.Empty, string.Empty, param.PageControl.PageSize, param.PageControl.PageIndex, 0, out pages, out records);
            param.PageControl.TotalPageCount = pages;
            param.PageControl.TotalRecordCount = records;

            IList<saRoleInfo> list = new List<saRoleInfo>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(DataRowBind(row));
            }

            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static saRoleInfo DataRowBind(DataRow dataReader)
        {
            myPortal.Model.saRoleInfo model = new myPortal.Model.saRoleInfo();
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
 
            ojb = dataReader["IsActive"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsActive = (bool)ojb;
            }

            ojb = dataReader["bIsAdministrator"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bIsAdministrator = (bool)ojb;
            }
            model.sRemark = dataReader["sRemark"].ToString();
            return model;
        }
    }
}
