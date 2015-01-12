using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 审批状态
    /// </summary>
    public enum BillState
    {
        /// <summary>
        /// 无状态
        /// </summary>
        None = 0,
        /// <summary>
        /// 草稿
        /// </summary>
        Draft = 1,
        /// <summary>
        /// 待审
        /// </summary>
        Unaudited = 2,
        /// <summary>
        /// 通过
        /// </summary>
        Approved = 4,
        /// <summary>
        /// 驳回
        /// </summary>
        Reject = 8
    }
}
