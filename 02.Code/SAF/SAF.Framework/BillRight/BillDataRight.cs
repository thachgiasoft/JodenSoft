
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    [Flags]
    public enum BillDataRight
    {
        None = 0,
        Update = 1,
        Delete = 2,
        Extend1 = 4,
        Extend2 = 8,
        Extend3 = 16,
        Extend4 = 32,
        Extend5 = 64,
        Extend6 = 128,
        Extend7 = 256,
        Extend8 = 512,
        Extend9 = 1024,
        Extend10 = 2048,
        All = 65535
    }
}
