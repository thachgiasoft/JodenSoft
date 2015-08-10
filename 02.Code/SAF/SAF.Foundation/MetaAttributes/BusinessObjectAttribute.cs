using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.MetaAttributes
{
    /// <summary>
    /// 标记窗口是否为业务窗口
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class BusinessObjectAttribute : Attribute
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="description"></param>
        public BusinessObjectAttribute(string description)
        {
            this.Description = string.IsNullOrWhiteSpace(description) ? string.Empty : description.Trim();
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description { set; get; }

    }
}
