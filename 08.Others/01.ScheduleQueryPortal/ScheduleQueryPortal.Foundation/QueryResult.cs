using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ScheduleQueryPortal.Foundation
{
    public class QueryResult
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRowCount { get; set; }
        /// <summary>
        /// 返回的数据集
        /// </summary>
        public DataTable Data { get; set; }
        /// <summary>
        /// 查询是否成功
        /// </summary>
        public bool IsSucess { get; set; }

        public string Message { get; set; }

        public QueryResult()
        {
            IsSucess = true;
            Message = "查询成功!";
        }

    }
}
