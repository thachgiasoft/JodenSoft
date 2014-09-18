using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// 获取相对路径
        /// </summary>
        /// <param name="sToPath">带文件名的全路径</param>
        /// <param name="sFromPath">带文件名的全路径</param>
        /// <returns>相对路径</returns>
        public static string GetRelativePath(string sToPath, string sFromPath)
        {
            string s1 = sFromPath.Substring(sFromPath.IndexOf(":") + 1).Replace("\\", "/");
            if (!s1.StartsWith("/")) s1 = "/" + s1;
            string s2 = sToPath.Substring(sToPath.IndexOf(":") + 1).Replace("\\", "/");
            if (!s2.StartsWith("/")) s2 = "/" + s2;
            return System.Web.VirtualPathUtility.MakeRelative(s1, s2).Replace("/", "\\");
        }
    }
}
