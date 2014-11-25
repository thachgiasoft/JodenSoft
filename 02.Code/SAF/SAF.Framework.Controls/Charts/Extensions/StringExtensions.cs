using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    internal static class StringExtensions
    {
        internal static string FormatEx2(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
