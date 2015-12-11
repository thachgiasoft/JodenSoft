using System;
using System.Collections.Generic;
using System.Text;

namespace myPortal.Foundation
{
    /// <summary>
    /// ����ָ��λ������ַ���,�ַ�������[0-9]��[A-Z]
    /// </summary>
    public static class RandomString
    {
        private static char[] charSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static Random rGen = new Random();
        /// <summary>
        /// ����10λ����ַ���
        /// </summary>
        /// <returns></returns>
        public static string Next()
        {
            return Next(10);
        }
        /// <summary>
        /// ����ָ��λ��������ַ���
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
