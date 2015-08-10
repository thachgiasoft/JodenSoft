using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SAF.Foundation
{
    public static class ByteExtensions
    {
        /// <summary>
        /// 将字节数据格式为16进制字符串输出
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToStreamString(this byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return string.Empty;
            StringBuilder sBuilder = new StringBuilder(bytes.Length * 2);
            foreach (var item in bytes)
            {
                sBuilder.Append(item.ToString("X").PadLeft(2, '0'));
            }
            return sBuilder.ToString();
        }

        #region ToHex
        public static string ToHex(this byte b)
        {
            return b.ToString("X2");
        }

        public static string ToHex(this IEnumerable<byte> bytes)
        {
            if (bytes == null || bytes.Count() <= 0) return string.Empty;
            var sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
        #endregion

        #region ToBase64String

        public static string ToBase64String(byte[] bytes)
        {
            if (bytes == null || bytes.Length <= 0) return string.Empty;
            else return Convert.ToBase64String(bytes);
        }

        #endregion

        public static string Decode(this byte[] data, Encoding encoding)
        {
            if (data == null || data.Length <= 0) return string.Empty;
            else return encoding.GetString(data);
        }

        public static void Save(this byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }

        public static MemoryStream ToMemoryStream(this byte[] data)
        {
            return new MemoryStream(data);
        }
    }
}
