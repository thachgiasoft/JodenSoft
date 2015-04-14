using SAF.Foundation.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SAF.EntityFramework.Config
{
    [Serializable]
    public class DataServiceConfig
    {
        [XmlAttribute]
        public string ServiceName { get; set; }
        [XmlAttribute]
        public Guid UniqueId { get; set; }
        [XmlAttribute]
        public string BaseAddress { get; set; }

        public ConnectionStringConfigCollection ConnectionStringConfigs { get; set; }

        public DataServiceConfig()
        {
            ConnectionStringConfigs = new ConnectionStringConfigCollection();
            UniqueId = Guid.NewGuid();
        }
    }
}
