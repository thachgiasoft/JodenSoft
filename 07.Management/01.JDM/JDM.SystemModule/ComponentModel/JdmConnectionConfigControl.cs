using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDM.Framework.ServiceModel;
using System.ComponentModel.Composition;

namespace JDM.SystemModule.ComponentModel
{
    [Export(typeof(IJdmBackstageTabItem))]
    public partial class JdmConnectionConfigControl : JdmBaseBackstageTabItem
    {
        public JdmConnectionConfigControl()
        {
            InitializeComponent();
        }

        public override string Caption
        {
            get { return "连接配置"; }
        }

        public override bool IsSelected
        {
            get
            {
                return true;
            }
        }
    }
}
