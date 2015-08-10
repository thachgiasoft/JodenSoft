using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SAF.CommonConfig
{
    [Export(typeof(ISubProductInfo))]
    public class CommonConfigInfo : AbstractSubProductInfo
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
            get { return "系统通用配置，包括通用单据，查询平台，报表中心"; }
        }

        public override string Name
        {
            get { return "System Common Config"; }
        }

        public override string Title
        {
            get { return "系统通用配置"; }
        }
    }
}
