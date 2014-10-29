using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    [Flags]
    public enum BillOperateRight
    {
        None = 0,
        Insert = 1,
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
