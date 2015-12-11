using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace myPortal.Foundation.Utils
{
    /// <summary>
    /// MD5加密方法帮助类
    /// </summary>
    public static class MD5Helper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Encrypt(string value)
        {
            string retValue = string.Empty;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] retByte = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            for (int i = 0; i < retByte.Length; i++)
            {
                retValue += retByte[i].ToString("X").PadLeft(2, '0');
            }
            md5 = null;
            return retValue;
        }
    }
}
