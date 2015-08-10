using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.MetaAttributes
{
    /// <summary>
    /// 标记程序集是否是业务模块,如果不是业务模块将不拼装到容器内
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class IsComposeModuleAttribute : Attribute
    {
        /// <summary>
        /// 程序集描述,将显示在进度窗口中
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="description">程序集描述,将显示在进度窗口中</param>
        public IsComposeModuleAttribute(string description)
        {
            this.Description = description;
        }
    }
}
