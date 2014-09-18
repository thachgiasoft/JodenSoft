using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SAF.Foundation.Security
{
    public static class AESHelper
    {
        /// <summary>
        /// 默认的加密key
        /// </summary>
        private static string _Key = @"Libra_Co,_Ltd.{6B5B2F76-C883-4ECB-A4FD-33633AB2B517}";

        public static string Encrypt(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
                strSource = string.Empty;

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_Key.Substring(0, 32));
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(strSource);

            using (RijndaelManaged rDel = new RijndaelManaged())
            {
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                StringBuilder ret = new StringBuilder();
                foreach (byte b in resultArray)
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                return ret.ToString();
            }
        }

        public static string Decrypt(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
                strSource = string.Empty;

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_Key.Substring(0, 32));

            byte[] toEncryptArray = new byte[strSource.Length / 2];
            for (int x = 0; x < strSource.Length / 2; x++)
            {
                int i = (Convert.ToInt32(strSource.Substring(x * 2, 2), 16));
                toEncryptArray[x] = (byte)i;
            }

            using (RijndaelManaged rDel = new RijndaelManaged())
            {
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
        }
    }
}
