using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleQueryPortal.Foundation
{
    public class PageBase : System.Web.UI.Page
    {
        protected bool hasError = false;
        protected string errorMsg = string.Empty;

        /// <summary>
        /// 判断当前页面是否是修改操作
        /// <para>"m".Equals(Request["Action"]);</para>
        /// </summary>
        protected bool IsModifyAction
        {
            get
            {
                return "m".Equals(Request["Action"]);
            }
        }
    }
}
