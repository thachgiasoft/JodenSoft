
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
        Edit = 1,
        Delete = 2,
        SendToAudit = 4,
        Audit = 8,
        Print = 16,
        Extend1 = 32,
        Extend2 = 64,
        Extend3 = 128,
        Extend4 = 256,
        Extend5 = 512,
        Extend6 = 1024,
        Extend7 = 2048,
        Extend8 = 4096,
        Extend9 = 8192,
        Extend10 = 16384,
        All = 65535
    }
}
