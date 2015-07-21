using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.EntityFramework.Config
{
    [Serializable]
    public class ConnectionStringConfigCollection : Collection<ConnectionStringConfig>
    {
        protected override void InsertItem(int index, ConnectionStringConfig item)
        {
            if (item.Name.IsEmpty())
                throw new Exception("连接配置名称为空.");

            if (this.Any(p => p.Name == item.Name))
                throw new Exception("连接配置[{0}]已经存在.".FormatWith(item.Name));

            base.InsertItem(index, item);
        }
    }
}
