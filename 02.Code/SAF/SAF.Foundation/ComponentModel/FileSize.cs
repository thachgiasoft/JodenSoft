using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    public static class FileSize
    {
        /// <summary>
        /// 计算文件大小函数(保留两位小数),Size为字节大小
        /// </summary>
        /// <param name="Size">初始文件大小</param>
        /// <returns></returns>
        public static string GetSize(string fileName)
        {
            if (!File.Exists(fileName)) return "0 B";

            FileInfo fileInfo = new FileInfo(fileName);
            string strSize = "";
            long FactSize = fileInfo.Length;
            if (FactSize < 1024.00)
                strSize = FactSize.ToString("F2") + " B";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                strSize = (FactSize / 1024.00).ToString("F2") + " KB";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                strSize = (FactSize / 1048576).ToString("F2") + " MB";
            else if (FactSize >= 1073741824)
                strSize = (FactSize / 1073741824).ToString("F2") + " GB";
            return strSize;
        }
    }
}
