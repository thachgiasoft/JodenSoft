using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Foundation.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToStringEx(this object obj)
        {
            return obj == null || obj.Equals(DBNull.Value) ? string.Empty : obj.ToString();
        }
    }
}
