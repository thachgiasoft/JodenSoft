using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SAF.Framework
{
    [Flags]
    public enum BillRightType
    {
        /// <summary>
        /// 无权限
        /// </summary>
        [Description("无权限")]
        None = 0,
        /// <summary>
        /// 仅本人
        /// </summary>
        [Description("仅本人")]
        OnlyOwner = 1,
        /// <summary>
        /// 仅本部门
        /// </summary>
        [Description("仅本部门")]
        OnlyDepartment = 2,
        /// <summary>
        /// 本部门及下属部门
        /// </summary>
        [Description("本部门及下属部门")]
        DepartmentAndChild = 4,
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        All = 8,
    }
}
