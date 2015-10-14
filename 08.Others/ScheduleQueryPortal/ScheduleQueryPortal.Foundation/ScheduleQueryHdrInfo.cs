using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleQueryPortal.Foundation
{
    public class ScheduleQueryHdrInfo
    {
        public int iIden { get; set; }
        public string sName { get; set; }
        public int iQueryId { get; set; }
        public string sSql { get; set; }
        public int iPageSize { get; set; }
        public int iFontSize { get; set; }
    }
}
