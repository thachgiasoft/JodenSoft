using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 各子系统的产品信息接口
    /// </summary>
    public interface ISubProductInfo
    {
        /// <summary>
        /// 显示序号
        /// </summary>
        int OrderIndex { get; }
        /// <summary>
        /// 子系统简称或代号或英文缩写
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 子系统标题
        /// </summary>
        string Title { get; }
        /// <summary>
        /// 子系统描述信息
        /// </summary>
        string Description { get; }
        /// <summary>
        /// 用于绑定时显示信息
        /// </summary>
        string DisplayName { get; }
    }
    /// <summary>
    /// 各子系统的产品信息基类
    /// </summary>
    public abstract class AbstractSubProductInfo : ISubProductInfo
    {
        public virtual int OrderIndex { get { return 0; } }

        public abstract string Name { get; }

        public abstract string Title { get; }

        public abstract string Description { get; }

        public string DisplayName
        {
            get
            {
                return "{0} — {1}".FormatWith(Name, Title);
            }
        }
    }
}
