using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 实体或实体集未标记Attribute引发的异常
    /// </summary>
    [Serializable()]
    public class NoMarkedException : Exception
    {
        public NoMarkedException() : base() { }
        public NoMarkedException(string message) : base(message) { }
        public NoMarkedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
