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
using SAF.Framework;

namespace FSDProdPlan
{
    [BusinessObject("jdProdetailView")]
    public partial class jdProdetailView : SingleView
    {
        public jdProdetailView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new jdProdetailViewViewModel();
        }

        public new jdProdetailViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as jdProdetailViewViewModel;
            }
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            if (this.ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

                this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
            }
        }
        protected override void OnInitConfig()
        {
            //base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

    }
}
