using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// 
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static bool NextBool(this Random random)
        {
            return random.NextDouble() > 0.5;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random"></param>
        /// <returns></returns>
        public static T NextEnum<T>(this Random random) where T : struct
        {
            Type type = typeof(T);
            if (type.IsEnum == false) throw new InvalidOperationException();

            var array = Enum.GetValues(type);
            var index = random.Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (T)array.GetValue(index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] NextBytes(this Random random, int length)
        {
            var data = new byte[length];
            random.NextBytes(data);
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            var ticks = minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * random.NextDouble());
            return new DateTime(ticks);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this Random random)
        {
            return NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);
        }

    }
}
