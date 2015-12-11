using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace myPortal.IDAL
{
    /// <summary>
    /// 数据库通用方法接口
    /// </summary>
    public interface IDbServer
    {
        /// <summary>
        /// 服务器时间
        /// </summary>
        DateTime ServerDateTime { get; }
        /// <summary>
        /// 分页查询的存储过程
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
        /// <returns>分页查询的结果数据集</returns>
        DataTable PageQuery(string tableName, string fields, string orderField, string sqlWhere, string groupBy,
            string having, int pageSize, int pageIndex, int recordCount, out int totalPage, out int totalRecord);
      
    }
}
