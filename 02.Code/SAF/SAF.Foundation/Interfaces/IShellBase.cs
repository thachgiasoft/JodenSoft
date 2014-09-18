using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public interface IShellBase
    {
        IEnumerable<ISubProductInfo> SubProductInfos { get; }
    }
}
