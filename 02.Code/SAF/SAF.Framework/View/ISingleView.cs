using SAF.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.View
{
    public interface ISingleView : IBusinessView, IDataEdit, IDataAdvancedSearch, IDataSelect, IDataCooperation
    {
        /// <summary>
        /// 索引行改变
        /// </summary>
        void IndexRowChange();

        string InitCondition { get; }
    }
}
