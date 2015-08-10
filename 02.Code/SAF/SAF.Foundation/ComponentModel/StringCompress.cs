using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 字符串压缩/解压
    /// </summary>
    public static class StringCompress
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Compress(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
                strSource = string.Empty;
            byte[] base64 = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(strSource)));
            return Convert.ToBase64String(Compress(base64));
        }
        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string Decompress(string strSource)
        {
            if (string.IsNullOrWhiteSpace(strSource))
                strSource = string.Empty;
            return Encoding.UTF8.GetString(Decompress(Convert.FromBase64String(strSource)));
        }

        private static byte[] Compress(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                GZipStream Compress = new GZipStream(ms, CompressionMode.Compress);
                Compress.Write(bytes, 0, bytes.Length);
                Compress.Close();
                return ms.ToArray();
            }
        }

        private static byte[] Decompress(Byte[] bytes)
        {
            using (MemoryStream tempMs = new MemoryStream())
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    GZipStream Decompress = new GZipStream(ms, CompressionMode.Decompress);
                    Decompress.CopyTo(tempMs);
                    Decompress.Close();
                    return tempMs.ToArray();
                }
            }
        }
    }
}
