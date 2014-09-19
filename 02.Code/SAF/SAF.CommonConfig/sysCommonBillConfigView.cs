using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;

namespace SAF.CommonConfig
{
    [BusinessObject("sysCommonBillConfigView")]
    public partial class sysCommonBillConfigView : MasterDetailView
    {
        public sysCommonBillConfigView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillConfigViewViewModel();
        }

        public new sysCommonBillConfigViewViewModel ViewModel
        {
            get { return this.ViewModel as sysCommonBillConfigViewViewModel; }
        }

    }
}
