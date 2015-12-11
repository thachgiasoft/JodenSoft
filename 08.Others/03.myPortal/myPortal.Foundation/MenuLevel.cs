using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myPortal.Foundation
{
    public enum MenuLevel
    {
        /// <summary>
        /// 顶级菜单
        /// </summary>
        [Display(Name = "顶级菜单")]
        Level1 = 1,
        /// <summary>
        /// 菜单组
        /// </summary>
        [Display(Name = "菜单组")]
        Level2 = 2,
        /// <summary>
        /// 菜单项
        /// </summary>
        [Display(Name = "菜单项")]
        Level3 = 3
    }
}
