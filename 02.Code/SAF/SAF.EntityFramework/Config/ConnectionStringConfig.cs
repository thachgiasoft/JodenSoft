using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Xml.Serialization;

namespace SAF.EntityFramework.Config
{
    [Serializable]
    public class ConnectionStringConfig
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ConnectionString { get; set; }
        [XmlAttribute]
        public string Provider { get; set; }
        [XmlAttribute]
        public Guid UniqueId { get; set; }

        public ConnectionStringConfig()
        {
            Name = "Default";
            Provider = "System.Data.SqlClient";
            UniqueId = Guid.NewGuid();
        }
    }

}
