using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using SAF.Foundation.ServiceModel;
using System.Xml.Serialization;

namespace SAF.Foundation.ComponentModel
{

    /// <summary>
    /// 用户配置信息助手
    /// </summary>
    public class UserConfig
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool SavePassword { get; set; }

        [XmlIgnore]
        private static string UserConfigFileName = Path.Combine(ApplicationService.Current.ConfigFilePath, @"UserConfig.config");

        private UserConfig() { }

        private static UserConfig Load()
        {
            if (!File.Exists(UserConfigFileName)) return new UserConfig();
            string s = File.ReadAllText(UserConfigFileName, Encoding.UTF8);
            var obj = XmlSerializerHelper.Deserialize<UserConfig>(s);
            if (obj == null) return new UserConfig();
            return obj;
        }

        public void Save()
        {
            var s = XmlSerializerHelper.Serialize<UserConfig>(this);
            File.WriteAllText(UserConfigFileName, s, Encoding.UTF8);
        }

        [XmlIgnore]
        private static object lockObj = new object();
        [XmlIgnore]
        private static UserConfig _Current = null;
        [XmlIgnore]
        public static UserConfig Current
        {
            get
            {
                if (_Current == null)
                {
                    lock (lockObj)
                    {
                        if (_Current == null)
                        {
                            _Current = UserConfig.Load();
                        }
                    }
                }
                return _Current;
            }
        }
    }
}
