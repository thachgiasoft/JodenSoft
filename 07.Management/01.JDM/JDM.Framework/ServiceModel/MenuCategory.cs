using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public enum MenuCategory
    {
        SystemManagement = 0
    }

    public class MenuInfo
    {
        public string Id { get; set; }
        public string MenuHeader { get; set; }
        public string ParentId { get; set; }
        public double MenuOrder { get; set; }
        public IMenuCommand Command { get; set; }
    }
}
