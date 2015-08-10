using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public enum AuditAction
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 送审
        /// </summary>
        Send = 1,
        /// <summary>
        /// 通过
        /// </summary>
        Approved = 2,
        /// <summary>
        /// 驳回
        /// </summary>
        Reject = 4,
        /// <summary>
        /// 撤消
        /// </summary>
        Cancel = 8
    }
}
