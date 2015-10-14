using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ScheduleQueryPortal.Foundation
{
    public static class QueryHelper
    {
        public static QueryResult ExecutePageQuery(string commandText, QueryParam param)
        {
            var result = new QueryResult();
            try
            {
                var connectionString = WebConfig.GetConnectionString();

                SqlParameter[] arParms = new SqlParameter[3];
                arParms[0] = new SqlParameter() { ParameterName = "@sql", Value = commandText, SqlDbType = SqlDbType.NVarChar, Size = 4000, Direction = ParameterDirection.Input };
                arParms[1] = new SqlParameter() { ParameterName = "@iPageSize", Value = param.PageSize, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };
                arParms[2] = new SqlParameter() { ParameterName = "@iCurrPage", Value = param.PageIndex, SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input };

                var ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "sppbQuerySplitPage", arParms);

                result.TotalPage = Convert.ToInt32(ds.Tables[1].Rows[0]["iTotalPage"]);
                result.TotalRowCount = Convert.ToInt32(ds.Tables[1].Rows[0]["iTotalRowCount"]);
                result.PageIndex = param.PageIndex;

                result.Data = ds.Tables[2];
                result.IsSucess = true;
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static DataTable GetScheduleQuery()
        {
            var connectionString = WebConfig.GetConnectionString();
            var sql = @"
SELECT a.*,
sChildName=(
	SELECT  dbo.ConcatString('<a href=''AddScheduleQueryHdr.aspx?Action=m&Iden='+CAST(a1.iIden AS nvarchar)+'''>'+a1.sName+'</a>','<br> ')
	FROM dbo.smScheduleQueryHdr a1  WITH(nolock) 
	WHERE a1.iQueryId=a.iIden
)
FROM dbo.smScheduleQuery a WITH(nolock)";
            var ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);
            return ds.Tables[0];
        }


        public static DataTable GetScheduleQuery(int Iden)
        {
            var connectionString = WebConfig.GetConnectionString();
            var sql = @"
SELECT a.*
FROM dbo.smScheduleQuery a WITH(nolock) where a.iIden={0}";
            var ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, string.Format(sql, Iden));
            return ds.Tables[0];
        }

        public static void DeleteScheduleQuery(string[] iIdens)
        {
            string ids = string.Empty;
            string message = string.Empty;
            foreach (var item in iIdens)
            {
                ids += "'" + item + "',";
            }
            ids += "'-1'";

            var sql = string.Format("delete smScheduleQuery where iIden in ({0})", ids);
            var connectionString = WebConfig.GetConnectionString();

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
        }

        public static int NewIden(string groupName)
        {
            var connectionString = WebConfig.GetConnectionString();
            string sql = string.Format("exec sppbGenerateIden '{0}',1,0,0,1,1,1", groupName);
            var obj = SqlHelper.ExecuteScalar(connectionString, CommandType.Text, sql);
            return Convert.ToInt32(obj);
        }

        public static void ModifyScheduleQuery(ScheduleQueryInfo scheduleQueryInfo)
        {
            var connectionString = WebConfig.GetConnectionString();
            string sql = "update smScheduleQuery set sName='{1}', iTimeInterval={2} where iIden={0}";
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, string.Format(sql, scheduleQueryInfo.iIden, scheduleQueryInfo.sName, scheduleQueryInfo.iTimeInterval));
        }

        public static void AddScheduleQuery(ScheduleQueryInfo scheduleQueryInfo)
        {
            var connectionString = WebConfig.GetConnectionString();
            string sql = "insert smScheduleQuery(iIden, sName, iTimeInterval) values({0},'{1}',{2})";
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, string.Format(sql, scheduleQueryInfo.iIden, scheduleQueryInfo.sName, scheduleQueryInfo.iTimeInterval));
        }

        public static DataTable GetScheduleQueryHdr(int iScheduleQueryHdrId)
        {
            var connectionString = WebConfig.GetConnectionString();

            string sql = string.Format(@"SELECT * FROM dbo.smScheduleQueryHdr WHERE iIden={0}", iScheduleQueryHdrId);

            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];

        }

        public static DataTable GetScheduleQueryHdrByQueryId(int iQueryId)
        {
            var connectionString = WebConfig.GetConnectionString();

            string sql = string.Format(@"SELECT * FROM dbo.smScheduleQueryHdr WHERE iQueryId={0}", iQueryId);

            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];
        }

        public static DataTable GetScheduleQueryField(int iScheduleQueryHdrId)
        {
            var connectionString = WebConfig.GetConnectionString();

            string sql = string.Format("SELECT * FROM dbo.smScheduleQueryField WHERE iQueryHdrId={0} order by iSortIndex", iScheduleQueryHdrId);

            return SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql).Tables[0];

        }


        public static void ModifyScheduleQueryHdr(ScheduleQueryHdrInfo scheduleQueryHdrInfo)
        {
            var sql = @"
update smScheduleQueryHdr
set sName=@sName, iQueryId=@iQueryId, sSql=@sSql, iPageSize=@iPageSize, iFontSize=@iFontSize
where iIden=@iIden";
            var connectionString = WebConfig.GetConnectionString();
            var param = new SqlParameter[6];
            param[0] = new SqlParameter("@iIden", scheduleQueryHdrInfo.iIden);
            param[1] = new SqlParameter("@sName", scheduleQueryHdrInfo.sName);
            param[2] = new SqlParameter("@iQueryId", scheduleQueryHdrInfo.iQueryId);
            param[3] = new SqlParameter("@sSql", scheduleQueryHdrInfo.sSql);
            param[4] = new SqlParameter("@iPageSize", scheduleQueryHdrInfo.iPageSize);
            param[5] = new SqlParameter("@iFontSize", scheduleQueryHdrInfo.iFontSize);
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, param);
        }

        public static void AddScheduleQueryHdr(ScheduleQueryHdrInfo scheduleQueryHdrInfo)
        {
            var sql = "INSERT dbo.smScheduleQueryHdr(iIden, sName, iQueryId, sSql, iPageSize, iFontSize) values(@iIden, @sName, @iQueryId, @sSql, @iPageSize, @iFontSize)";
            var connectionString = WebConfig.GetConnectionString();
            var param = new SqlParameter[6];
            param[0] = new SqlParameter("@iIden", scheduleQueryHdrInfo.iIden);
            param[1] = new SqlParameter("@sName", scheduleQueryHdrInfo.sName);
            param[2] = new SqlParameter("@iQueryId", scheduleQueryHdrInfo.iQueryId);
            param[3] = new SqlParameter("@sSql", scheduleQueryHdrInfo.sSql);
            param[4] = new SqlParameter("@iPageSize", scheduleQueryHdrInfo.iPageSize);
            param[5] = new SqlParameter("@iFontSize", scheduleQueryHdrInfo.iFontSize);
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, param);
        }

        public static void ModifyScheduleQueryField(ScheduleQueryFieldInfo scheduleQueryFieldInfo)
        {
            var sql = @"
update smScheduleQueryField
set 
    sCaption=@sCaption, 
    bShow=@bShow, 
    iWidth=@iWidth, 
    bAllowWarp=@bAllowWarp, 
    sHorizontalAlignment=@sHorizontalAlignment, 
    sVerticalAlignment=@sVerticalAlignment, 
    iSortIndex=@iSortIndex
where iIden=@iIden";
            var connectionString = WebConfig.GetConnectionString();
            var param = new SqlParameter[8];
            param[0] = new SqlParameter("@iIden", scheduleQueryFieldInfo.iIden);
            param[1] = new SqlParameter("@sCaption", scheduleQueryFieldInfo.sCaption);
            param[2] = new SqlParameter("@bShow", scheduleQueryFieldInfo.bShow) { SqlDbType = SqlDbType.Bit };
            param[3] = new SqlParameter("@iWidth", scheduleQueryFieldInfo.iWidth);
            param[4] = new SqlParameter("@bAllowWarp", scheduleQueryFieldInfo.bAllowWarp) { SqlDbType = SqlDbType.Bit };
            param[5] = new SqlParameter("@sHorizontalAlignment", scheduleQueryFieldInfo.sHorizontalAlignment);
            param[6] = new SqlParameter("@sVerticalAlignment", scheduleQueryFieldInfo.sVerticalAlignment);
            param[7] = new SqlParameter("@iSortIndex", scheduleQueryFieldInfo.iSortIndex);
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, param);
        }

        public static void DeleteScheduleQueryHdr(int id)
        {
            var connectionString = WebConfig.GetConnectionString();

            string sql = string.Format("delete smScheduleQueryHdr WHERE iIden={0}", id);

            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
        }

        public static void AddScheduleQueryField(List<ScheduleQueryFieldInfo> fields)
        {
            var sql = @"
INSERT smScheduleQueryField(iIden, iQueryHdrId, sFieldName, sCaption, bShow, iWidth, bAllowWarp, sHorizontalAlignment, sVerticalAlignment, iSortIndex)
VALUES(@iIden, @iQueryHdrId, @sFieldName, @sCaption, @bShow, @iWidth, @bAllowWarp, @sHorizontalAlignment, @sVerticalAlignment, @iSortIndex)";

            var columns = string.Empty;

            foreach (var item in fields)
            {
                columns += "'" + item.sFieldName + "',";
            }

            columns = columns.Substring(0, columns.Length - 1);

            var connectionString = WebConfig.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var tran = con.BeginTransaction();
                try
                {
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text,
                        string.Format("delete smScheduleQueryField where iQueryHdrId={0} and sFieldName not in ({1})", fields[0].iQueryHdrId, columns));

                    foreach (var item in fields)
                    {
                        var s = string.Format("select * from smScheduleQueryField  where iQueryHdrId={0} and sFieldName='{1}'", item.iQueryHdrId, item.sFieldName);
                        var obj = SqlHelper.ExecuteDataset(tran, CommandType.Text, s);

                        if (obj.Tables[0].Rows.Count <= 0)
                        {
                            var param = new SqlParameter[10];
                            param[0] = new SqlParameter("@iIden", item.iIden);
                            param[1] = new SqlParameter("@iQueryHdrId", item.iQueryHdrId);
                            param[2] = new SqlParameter("@sFieldName", item.sFieldName);
                            param[3] = new SqlParameter("@sCaption", item.sCaption);
                            param[4] = new SqlParameter("@bShow", item.bShow) { SqlDbType = SqlDbType.Bit };
                            param[5] = new SqlParameter("@iWidth", item.iWidth);
                            param[6] = new SqlParameter("@bAllowWarp", item.bAllowWarp) { SqlDbType = SqlDbType.Bit };
                            param[7] = new SqlParameter("@sHorizontalAlignment", item.sHorizontalAlignment);
                            param[8] = new SqlParameter("@sVerticalAlignment", item.sVerticalAlignment);
                            param[9] = new SqlParameter("@iSortIndex", item.iSortIndex);
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sql, param);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
        }

        public static void DeleteScheduleQueryFields(int id)
        {
            string sql = "delete smScheduleQueryField WHERE iQueryHdrId=" + id;
            var connectionString = WebConfig.GetConnectionString();
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
        }
    }
}
