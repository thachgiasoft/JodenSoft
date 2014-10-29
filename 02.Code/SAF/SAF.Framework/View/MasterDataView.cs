using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.View
{
    public partial class MasterDataView : BusinessView
    {
        public MasterDataView()
        {
            InitializeComponent();
        }

        public override DevExpress.XtraBars.Ribbon.RibbonControl Ribbon
        {
            get
            {
                return this.ribbonMaster;
            }
        }
    }
}
