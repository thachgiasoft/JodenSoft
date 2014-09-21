using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class AssemblyInfoHelper
    {
        /// <summary>
        /// 主产品名称
        /// </summary>
        public const string ProductName = "Simplified Application Framework";

#if DEBUG
        /// <summary>
        /// 程序集版权
        /// </summary>
        public const string Copyright = "Copyright (c) 2013-{0} 上海环思信息技术有限公司";
        /// <summary>
        /// 程序开发公司
        /// </summary>
        public const string Company = "上海环思信息技术有限公司";
#else
        /// <summary>
        /// 程序集版权
        /// </summary>
        public const string Copyright = "Copyright (c) 2013-{0} 苏州聚达信息服务咨询有限公司";
        /// <summary>
        /// 程序开发公司
        /// </summary>
        public const string Company = "苏州聚达信息服务咨询有限公司";
#endif

        /// <summary>
        /// 程序集版本号
        /// </summary>
        public const string Version = "1.0.0.0";
        /// <summary>
        /// 文件版本号
        /// </summary>
        public const string FileVersion = "1.0.0.0";

        /// <summary>
        /// 应用程序图片
        /// </summary>
        public static Image ApplicationImage
        {
            get
            {
                return SAF.Foundation.Properties.Resources.SAF_Png;
            }
        }
        /// <summary>
        /// 应用程序图标
        /// </summary>
        public static Icon ApplicationIcon
        {
            get
            {
                return SAF.Foundation.Properties.Resources.SAF_Icon;
            }
        }
        /// <summary>
        /// 用户默认头像
        /// </summary>
        public static Image UserDefaultImage
        {
            get
            {
                return SAF.Foundation.Properties.Resources.DefaultUserPicture;
            }
        }

        /// <summary>
        /// 版权警告
        /// </summary>
        public const string WarningMessage = "警告：本计算机程序受著作权法和国际条约保护。如未经授权而擅自复制或传播本程序（或其中任何部份），将受到严厉的民事和刑事制裁，并将在法律许可的最大限度内受到起诉。";
        /// <summary>
        /// 详细版权说明
        /// </summary>
        public static string AllVersionInfo
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ProductName);
                sb.AppendLine(string.Format("文件版本 {0}", FileVersion));
                sb.AppendLine(string.Format("程序集版本 {0}", Version));
                sb.AppendLine(string.Format("{0}", Copyright.FormatEx(DateTime.Now.Year)));
                sb.AppendLine(string.Format("保留所有权利"));
                return sb.ToString();
            }
        }
    }
}
