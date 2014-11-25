using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// MD5 Hash方法帮助类
    /// </summary>
    public static class MD5Helper
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Hash(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
            {
                strSource = string.Empty;
            }
            string retValue = string.Empty;
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] retByte = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strSource));
                StringBuilder ret = new StringBuilder();
                for (int i = 0; i < retByte.Length; i++)
                {
                    ret.AppendFormat("{0:X2}", retByte[i]);
                }
                return ret.ToString();
            }
        }

        public static Guid Guid(string strSource)
        {
            return new Guid(Hash(strSource));
        }
    }
}
