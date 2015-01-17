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
            get { return "系统配置工具"; }
        }

        public override string Name
        {
            get { return "System Config Tools"; }
        }

        public override string Title
        {
            get { return "系统配置工具"; }
        }
    }
}
