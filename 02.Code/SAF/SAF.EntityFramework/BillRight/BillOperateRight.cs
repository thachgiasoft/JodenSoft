using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 单据操作权限
    /// </summary>
    [Flags]
    public enum BillOperateRight
    {
        None = 0,
        AddNew = 1,
        Extend1 = 2,
        Extend2 = 4,
        Extend3 = 8,
        Extend4 = 16,
        Extend5 = 32,
        Extend6 = 64,
        Extend7 = 128,
        Extend8 = 256,
        Extend9 = 512,
        Extend10 = 1024,
        All = 65535,
    }
}
