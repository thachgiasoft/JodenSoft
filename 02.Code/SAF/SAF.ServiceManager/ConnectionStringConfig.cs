using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.Xml.Serialization;

namespace SAF.ServiceManager
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

    [Serializable]
    public class ConnectionStringConfigCollection : Collection<ConnectionStringConfig>
    {
        protected override void InsertItem(int index, ConnectionStringConfig item)
        {
            if (item.Name.IsEmpty())
            {
                MessageService.ShowError("连接配置名称为空.");
                return;
            }

            if (this.Any(p => p.Name == item.Name))
            {
                MessageService.ShowError("连接配置[{0}]已经存在.".FormatEx(item.Name));
                return;
            }

            base.InsertItem(index, item);
        }
    }
}
