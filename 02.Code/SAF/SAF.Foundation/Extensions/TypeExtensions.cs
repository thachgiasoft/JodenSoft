using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class TypeExtensions
    {
        public static object DefaultValue(this Type targetType)
        {
            return targetType != null && targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }
    }
}
