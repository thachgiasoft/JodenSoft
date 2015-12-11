using System;
using System.Collections.Generic;
using System.Text;

namespace myPortal.Foundation
{
    /// <summary>
    /// 生成指定位数随机字符串,字符仅包括[0-9]和[A-Z]
    /// </summary>
    public static class RandomString
    {
        private static char[] charSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static Random rGen = new Random();
        /// <summary>
        /// 生成10位随机字符串
        /// </summary>
        /// <returns></returns>
        public static string Next()
        {
            return Next(10);
        }
        /// <summary>
        /// 生成指定位数的随机字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Next(int length)
        {
            byte[] rBytes = new byte[length];
            rGen.NextBytes(rBytes);

            char[] rName = new char[length];
            for (int i = 0; i < length; i++)
                rName[i] = charSet[rBytes[i] % charSet.Length];
            string rdstr = new string(rName);
            return rdstr.Trim();
        }
    }
}
