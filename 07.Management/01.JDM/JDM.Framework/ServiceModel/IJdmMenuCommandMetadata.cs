using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public interface IJdmMenuCommandMetadata
    {
        string Id { get; }
        string Header { get; }
        JdmMenuCategory Category { get; }
        double Order { get; }
    }
}
