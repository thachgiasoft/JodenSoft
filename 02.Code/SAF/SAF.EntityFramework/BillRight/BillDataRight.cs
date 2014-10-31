
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 单据数据权限
    /// </summary>
    [Flags]
    public enum BillDataRight
    {
        None = 0,
        Update = 1,
        Delete = 2,
        Audit = 4,
        Print = 8,
        Extend1 = 16,
        Extend2 = 32,
        Extend3 = 64,
        Extend4 = 128,
        Extend5 = 256,
        Extend6 = 512,
        Extend7 = 1024,
        Extend8 = 2048,
        Extend9 = 4096,
        Extend10 = 8192,
        All = 65535
    }
}
