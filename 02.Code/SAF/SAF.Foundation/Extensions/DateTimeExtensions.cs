using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 当前月的第一天
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime now)
        {
            DateTime first = now.AddDays(1 - now.Day);
            return first;
        }
        /// <summary>
        /// 当前月的最后一天
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime now)
        {
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);

            DateTime last = now.FirstDayOfMonth().AddDays(daysInMonth - 1);
            return last;
        }
    }
}
