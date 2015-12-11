using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace myPortal.Web
{
    /// <summary>
    /// 网站配置访问类
    /// </summary>
    public static class WebConfig
    {
        /// <summary>
        /// Email后缀
        /// </summary>
        public static string EmailSuffix
        {
            get
            {
                if (ConfigurationManager.AppSettings["EmailSuffix"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    string str = ConfigurationManager.AppSettings["EmailSuffix"].ToString().Trim();
                    if (!str.StartsWith("@"))
                    {
                        str = "@" + str;
                    }
                    return str;
                }
            }
        }
    }
}
