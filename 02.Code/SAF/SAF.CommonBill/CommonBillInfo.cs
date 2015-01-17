using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SAF.CommonBill
{
    [Export(typeof(ISubProductInfo))]
    public class CommonBillInfo : AbstractSubProductInfo
    {
        public override int OrderIndex
        {
            get
            {
                return -9000;
            }
        }
        public override string Description
        {
            get { return "系统通用单据"; }
        }

        public override string Name
        {
            get { return "System Common Bill"; }
        }

        public override string Title
        {
            get { return "系统通用单据"; }
        }
    }
}
