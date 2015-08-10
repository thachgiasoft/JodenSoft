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

        #region IsEmpty

        public static bool IsEmpty<T>(this T? value) where T : struct
        {
            return value == null;
        }

        public static bool IsEmpty<T>(this T[] array)
        {
            return array == null || array.Length <= 0;
        }

        public static bool IsEmpty(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return value == null || value.Count() <= 0;
        }

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        #endregion
    }
}
