using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;

namespace SAF.CommonConfig
{
    public partial class sysCommonBillView : MasterDetailView
    {
        public sysCommonBillView()
        {
            InitializeComponent();
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillViewViewModel();
        }

        public new sysCommonBillViewViewModel ViewModel
        {
            get { return this.ViewModel as sysCommonBillViewViewModel; }
        }

    }
}
