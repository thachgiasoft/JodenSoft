using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleQueryPortal.Foundation
{
    public class ScheduleQueryFieldInfo
    {
        public int iIden { get; set; }
        public int iQueryHdrId { get; set; }
        public string sFieldName { get; set; }
        public string sCaption { get; set; }
        public bool bShow { get; set; }
        public int iWidth { get; set; }
        public bool bAllowWarp { get; set; }
        public string sHorizontalAlignment { get; set; }
        public string sVerticalAlignment { get; set; }
        public int iSortIndex { get; set; }
    }
}
