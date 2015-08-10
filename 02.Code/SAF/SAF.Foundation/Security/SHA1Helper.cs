using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.Security
{
    public static class SHA1Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSource">需要加密的明文</param>
        /// <returns>返回32位加密结果</returns>
        public static string Hash(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
            {
                strSource = string.Empty;
            }
            string strResult = string.Empty;
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            byte[] bytResult = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strSource));
            //字节类型的数组转换为字符串
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < bytResult.Length; i++)
            {
                ret.AppendFormat("{0:X2}", bytResult[i]);
            }
            return ret.ToString();
        }
    }
}
