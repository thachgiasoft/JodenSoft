using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public interface IMenuCommandMetadata
    {
        string MenuId { get; }
        string Menu { get; }
        MenuCategory MenuCategory { get; }
        double MenuOrder { get; }
    }
}
