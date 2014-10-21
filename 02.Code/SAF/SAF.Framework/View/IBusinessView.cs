using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.View
{
    public interface IBusinessView : IBaseView
    {
        /// <summary>
        /// 单据类型ID
        /// </summary>
        string BillTypeId { get; set; }
    }
}
