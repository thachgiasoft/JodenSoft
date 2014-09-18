using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SAF.SystemModule
{
    [Export(typeof(ISubProductInfo))]
    public class SystemModuleInfo : AbstractSubProductInfo
    {
        public override string Description
        {
            get { return "系统管理工具"; }
        }

        public override string Name
        {
            get { return "System Management Tools"; }
        }

        public override string Title
        {
            get { return "系统管理工具"; }
        }
    }
}
