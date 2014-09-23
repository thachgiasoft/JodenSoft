using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    /// <summary>
    /// 数据审批接口
    /// </summary>
    public interface IDataCooperation
    {
        /// <summary>
        /// 送审
        /// </summary>
        void SendToAudit();
        /// <summary>
        /// 通过
        /// </summary>
        void Approval();
        /// <summary>
        /// 驳回
        /// </summary>
        void Reject();
    }
}
