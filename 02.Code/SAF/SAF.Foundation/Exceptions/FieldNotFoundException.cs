using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 表示字段没有找到时发生的错误
    /// </summary>
    [Serializable()]
    public class FieldNotFoundException : Exception
    {
        public FieldNotFoundException() : base() { }
        public FieldNotFoundException(string message) : base(message) { }
        public FieldNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
