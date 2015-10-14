using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleQueryPortal.Foundation
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryParam
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public QueryParam()
        {
            PageSize = 10;
        }
    }
}
