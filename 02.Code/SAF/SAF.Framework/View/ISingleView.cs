using SAF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.View
{
    public interface ISingleView : IBusinessView, IDataEdit, IDataAdvancedSearch, IDataSelect, IDataCooperation
    {
        void IndexRowChange();
    }
}
