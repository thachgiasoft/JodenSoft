using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public interface IMenuCommandMetadata
    {
        Guid MenuId { get; }
        string Menu { get; }
        string MenuCategory { get; }
        double MenuOrder { get; }
        Type MenuType { get; }
    }
}
