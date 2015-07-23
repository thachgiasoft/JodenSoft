using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 注册请求文档
    /// </summary>
    public sealed class ActivationRequest
    {
        /// <summary>
        /// 机器码
        /// </summary>
        public string MachineCode { get; set; }
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; set; }
    }
    /// <summary>
    /// 注册回复文档
    /// </summary>
    public sealed class ActivationResponse
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 机器码
        /// </summary>
        public string MachineCode { get; set; }
        /// <summary>
        /// 软件版本
        /// </summary>
        public ApplicationVersion Version { get; set; }
        /// <summary>
        /// 在线人数上限
        /// </summary>
        public int OnLineLimit { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime RegsterationDate { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime ExpiredDate { get; set; }

    }
}
