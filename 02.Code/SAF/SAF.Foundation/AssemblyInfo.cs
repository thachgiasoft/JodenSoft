using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SAF.Foundation
{
    /// <summary>
    /// 程序集特性
    /// </summary>
    public sealed class AssemblyInfo
    {
        private Assembly _assembly = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssemblyInfo()
        {
            _assembly = this.GetType().Assembly;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="part">类型</param>
        public AssemblyInfo(object part)
        {
            if (part == null) throw new ArgumentNullException("part");
            _assembly = part.GetType().Assembly;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="assembly">程序集</param>
        public AssemblyInfo(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            _assembly = assembly;
        }

        /// <summary>
        /// 程序集标题
        /// </summary>
        public string Title
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(this._assembly.CodeBase);
            }
        }
        /// <summary>
        /// 程序集版本号
        /// </summary>
        public string Version
        {
            get
            {
                return this._assembly.GetName().Version.ToString();
            }
        }
        /// <summary>
        /// 程序集文件版本号
        /// </summary>
        public string FileVersion
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyFileVersionAttribute)attributes[0]).Version.ToString(); ;
            }
        }
        /// <summary>
        /// 程序集描述
        /// </summary>
        public string Description
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        /// <summary>
        /// 程序集产品名称
        /// </summary>
        public string Product
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        /// <summary>
        /// 程序集版权
        /// </summary>
        public string Copyright
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        /// <summary>
        /// 程序集公司名称
        /// </summary>
        public string Company
        {
            get
            {
                object[] attributes = this._assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
    }
}
