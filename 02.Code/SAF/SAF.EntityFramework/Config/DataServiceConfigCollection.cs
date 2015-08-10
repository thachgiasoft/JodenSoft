using SAF.Foundation.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SAF.EntityFramework.Config
{
    [XmlRoot(ElementName = "DataServiceConfigs")]
    [Serializable]
    public class DataServiceConfigCollection : Collection<DataServiceConfig>
    {
        [XmlIgnore]
        private static string ConfigFileName
        {
            get
            {
                var fileName = Path.Combine(Application.StartupPath, @"DataServiceConfig\DataServiceConfig.config");
                var filePath = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                return fileName;
            }
        }

        public void Save()
        {
            var xml = XmlSerializerHelper.Serialize<DataServiceConfigCollection>(this);
            File.WriteAllText(ConfigFileName, xml, Encoding.UTF8);
        }

        private static DataServiceConfigCollection Load()
        {
            if (!File.Exists(ConfigFileName))
                return new DataServiceConfigCollection();

            var obj = XmlSerializerHelper.Deserialize<DataServiceConfigCollection>(File.ReadAllText(ConfigFileName, Encoding.UTF8));
            if (obj == null || (obj as DataServiceConfigCollection) == null)
                return new DataServiceConfigCollection();
            return obj as DataServiceConfigCollection;
        }

        private static object lockObj = new object();
        private static DataServiceConfigCollection _current = null;
        [XmlIgnore]
        public static DataServiceConfigCollection Current
        {
            get
            {
                if (_current == null)
                {
                    lock (lockObj)
                    {
                        if (_current == null)
                            _current = Load();
                    }
                }
                return _current;
            }
        }
    }
}
