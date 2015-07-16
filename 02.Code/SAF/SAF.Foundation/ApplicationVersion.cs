using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 应用程序版本
    /// </summary>
    [Flags]
    public enum ApplicationVersion
    {
        /// <summary>
        /// 试用版
        /// </summary>
        [Description("试用版")]
        Trial=1,
        /// <summary>
        /// 专业版
        /// </summary>
        [Description("专业版")]
        Professional=2,
        /// <summary>
        /// 旗舰版
        /// </summary>
        [Description("旗舰版")]
        Ultimate=4
    }
}
