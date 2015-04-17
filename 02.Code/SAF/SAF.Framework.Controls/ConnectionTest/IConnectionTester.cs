using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls
{
    public interface IConnectionTester
    {
        bool TryConnect();
        string ConnectionString { get; }
    }
}
