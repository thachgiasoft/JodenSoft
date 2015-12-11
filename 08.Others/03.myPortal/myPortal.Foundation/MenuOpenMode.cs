using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myPortal.Foundation
{
    public enum MenuOpenMode
    {
        /// <summary>
        /// 普通导航
        /// </summary>
        [Display(Name = "普通导航")]
        None = 0,
        /// <summary>
        /// 固定标签页
        /// </summary>
        [Display(Name = "固定标签页")]
        FixedTab = 1,
        /// <summary>
        /// 新建标签页
        /// </summary>
        [Display(Name = "新建标签页")]
        NewTab = 2
    }
}
