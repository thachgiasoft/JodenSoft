using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SAF.Foundation
{
    [Serializable()]
    public class OutOfRangeException : CoreException
    {
        public OutOfRangeException()
            : base()
        {
        }

        public OutOfRangeException(int index, int min, int max)
            : base("value must between {0} and {1}.current value is {2}".FormatEx(index, min, max))
        {
        }

        public OutOfRangeException(string message)
            : base(message)
        {
        }

        public OutOfRangeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected OutOfRangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
