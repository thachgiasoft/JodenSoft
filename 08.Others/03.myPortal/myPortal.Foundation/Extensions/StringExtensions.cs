using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Foundation.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string FormatEx(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
