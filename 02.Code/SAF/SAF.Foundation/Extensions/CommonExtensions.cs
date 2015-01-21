using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class CommonExtensions
    {
        /// <summary>
        /// 获取可空类型的安全返回值
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }
    }
}
