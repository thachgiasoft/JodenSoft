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

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            if (this.ViewModel != null)
            {
                this.ViewModel.DetailEntitySet.SetBindingSource(this.bsDetail);
            }
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillConfigViewViewModel();
        }

        public new sysCommonBillConfigViewViewModel ViewModel
        {
            get { return base.ViewModel as sysCommonBillConfigViewViewModel; }
        }

    }
}
