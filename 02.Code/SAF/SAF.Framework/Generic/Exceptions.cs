using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    [Serializable()]
    public class SaveException : Exception
    {
        public SaveException() : base() { }
        public SaveException(string message) : base(message) { }
        public SaveException(string message, Exception innerException) : base(message, innerException) { }
    }
}
