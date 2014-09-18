using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 用户配置信息助手
    /// </summary>
    public static class UserConfigHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string ConfigPath = @".\Config";
        /// <summary>
        /// 
        /// </summary>
        public static string UserConfigFileName = ConfigPath + @"\UserConfig.config";
        /// <summary>
        /// 
        /// </summary>
        public static string LogPath = @".\Log";

        private static string RootSection = "UserConfig";
        private static string UserLoginInfoSection = "UserLoginInfo";
        private static string UserSection = "User";

        private static void CreateConfigFile(string fileName)
        {
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }
            if (!File.Exists(fileName))
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement(RootSection));
                doc.Save(fileName);
            }
        }

        private static XElement CreateUserElement(string userName)
        {
            return new XElement(UserSection,
                            new XAttribute("UserName", userName),
                            new XAttribute("LoginTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
                    );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="div"></param>
        /// <param name="userName"></param>
        public static void SaveUser(string userName)
        {
            CreateConfigFile(UserConfigFileName);
            XElement root = XElement.Load(UserConfigFileName);

            XElement user = CreateUserElement(userName);

            var loginInfo = root.Elements(UserLoginInfoSection).FirstOrDefault();
            if (loginInfo == null)
            {
                XElement ele = new XElement(UserLoginInfoSection, user);
                root.Add(ele);
            }
            else
            {
                var users = loginInfo.Elements(UserSection).FirstOrDefault();
                if (users == null)
                {
                    loginInfo.Add(user);
                }
                else
                {
                    loginInfo.Element(UserSection).SetAttributeValue("UserName", userName);
                    loginInfo.Element(UserSection).SetAttributeValue("LoginTime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                }
            }
            root.Save(UserConfigFileName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="div"></param>
        /// <param name="userName"></param>
        public static void GetUser(out string userName)
        {
            if (!File.Exists(UserConfigFileName))
            {
                userName = string.Empty;
                return;
            }

            XElement root = XElement.Load(UserConfigFileName);
            var loginInfo = root.Elements(UserLoginInfoSection).FirstOrDefault();
            if (loginInfo == null)
            {
                userName = string.Empty;
                return;
            }
            else
            {
                var user = loginInfo.Elements(UserSection).FirstOrDefault();
                if (user == null)
                {
                    userName = string.Empty;
                    return;
                }
                else
                {
                    userName = user.Attribute("UserName") == null ? string.Empty : user.Attribute("UserName").Value;
                    return;
                }
            }
        }
    }
}
