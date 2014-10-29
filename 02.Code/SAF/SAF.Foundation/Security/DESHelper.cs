using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SAF.Foundation.Security
{
    /// <summary>
    /// DES加密方法帮助类
    /// </summary>
    public static class DESHelper
    {
        /// <summary>
        /// 默认的加密key
        /// </summary>
        private static string _Key = @"Libra_Co,_Ltd.{6B5B2F76-C883-4ECB-A4FD-33633AB2B517}";
        /// <summary>
        /// 用给定的Key进行加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="encryptString">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string encryptString, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = _Key;
            else
                key += _Key;

            if (string.IsNullOrWhiteSpace(encryptString))
                encryptString = string.Empty;

            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();

                //Get the data back from the memory stream, and into a string
                StringBuilder ret = new StringBuilder();
                foreach (byte b in mStream.ToArray())
                {
                    //Format as hex
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
        }
        /// <summary>
        /// 用给定的Key进行解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="decryptString">要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string decryptString, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = _Key;
            else
                key += _Key;

            if (string.IsNullOrWhiteSpace(decryptString))
                decryptString = string.Empty;

            byte[] keyBytes = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            byte[] keyIV = keyBytes;

            byte[] inputByteArray = new byte[decryptString.Length / 2];
            for (int x = 0; x < decryptString.Length / 2; x++)
            {
                int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
        }
        /// <summary>
        /// 用系统默认的Key加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            return Encrypt(_Key, encryptString.Reverse());
        }
        /// <summary>
        /// 用系统默认的Key解密
        /// </summary>
        /// <param name="decryptString"></param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            return Decrypt(_Key, decryptString).Reverse();
        }
    }
}
