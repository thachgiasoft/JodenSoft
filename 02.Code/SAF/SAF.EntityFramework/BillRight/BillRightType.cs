using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 单据权限类型
    /// </summary>
    [Flags]
    public enum BillRightType
    {
        /// <summary>
        /// 无权限
        /// </summary>
        [Display(Name = "无权限")]
        None = 0,
        /// <summary>
        /// 仅本人
        /// </summary>
        [Display(Name = "仅本人")]
        OnlyOwner = 1,
        /// <summary>
        /// 仅本部门
        /// </summary>
        [Display(Name = "仅本部门")]
        OnlyDepartment = 2,
        /// <summary>
        /// 本部门及下属部门
        /// </summary>
        [Display(Name = "本部门及下属部门")]
        DepartmentAndChild = 4,
        /// <summary>
        /// 所有
        /// </summary>
        [Display(Name = "所有")]
        All = 8,
    }
}
