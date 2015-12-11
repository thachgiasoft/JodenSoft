using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace myPortal.DAL.SqlServer
{
    /// <summary>
    /// 数据库通用方法
    /// </summary>
    public class DbServer : IDbServer
    {
        /// <summary>
        /// 服务器时间
        /// </summary>
        public DateTime ServerDateTime
        {
            get
            {
                string strsql = "SELECT GETDATE()";
                Database db = DatabaseFactory.CreateDatabase();
                object obj = db.ExecuteScalar(CommandType.Text, strsql);
                if (obj != null && obj != DBNull.Value)
                {
                    return DateTime.Parse(obj.ToString());
                }
                return DateTime.Now;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fields">字段名(全部字段为*)</param>
        /// <param name="orderField">排序字段(必须!支持多字段)</param>
        /// <param name="sqlWhere">条件语句(不用加where)</param>
        /// <param name="groupBy">分组语句</param>
        /// <param name="having">分组条件语句</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="pageIndex">指定当前为第几页</param>
        /// <param name="recordCount">指定总记录数</param>
        /// <param name="totalPage">返回总页数</param>
        /// <param name="totalRecord">返回总记录数</param>
        /// <returns></returns>
        public DataTable PageQuery(string tableName, string fields, string orderField, string sqlWhere, string groupBy, string having,
            int pageSize, int pageIndex, int recordCount, out int totalPage, out int totalRecord)
        {
            var db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand("sppbPageQuery");
            db.AddInParameter(cmd, "@TableName", DbType.String, tableName);
            db.AddInParameter(cmd, "@Fields", DbType.String, fields);
            db.AddInParameter(cmd, "@OrderField", DbType.String, orderField);
            db.AddInParameter(cmd, "@SqlWhere", DbType.String, sqlWhere);
            db.AddInParameter(cmd, "@GroupBy", DbType.String, groupBy);
            db.AddInParameter(cmd, "@Having", DbType.String, having);
            db.AddInParameter(cmd, "@PageSize", DbType.Int32, pageSize);
            db.AddInParameter(cmd, "@PageIndex", DbType.Int32, pageIndex);
            db.AddOutParameter(cmd, "@TotalPage", DbType.Int32, 4);
            db.AddOutParameter(cmd, "@TotalRecord", DbType.Int32, 4);
            DataSet ds = db.ExecuteDataSet(cmd);
            totalPage = (int)db.GetParameterValue(cmd, "@TotalPage");
            totalRecord = (int)db.GetParameterValue(cmd, "@TotalRecord");
            return ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }
    }
}
