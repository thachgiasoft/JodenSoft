using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SAF.Framework.Entities
{
    /// <summary>
    /// 系统菜单类型
    /// </summary>
    public enum sysMenuType
    {
        /// <summary>
        /// 目录
        /// </summary>
        [Display(Name="目录")]
        Catalog = 0,
        /// <summary>
        /// 常规菜单
        /// </summary>
        [Display(Name = "常规菜单")]
        Menu = 1,
        /// <summary>
        /// 外部界面,打开时主界面不响应操作,类似ShowDialog
        /// </summary>
        [Display(Name = "外部界面")]
        ExternalForm = 2,
        /// <summary>
        /// 外部程序,单纯调用
        /// </summary>
        [Display(Name = "外部程序")]
        ExternalProgram = 3
    }
}
