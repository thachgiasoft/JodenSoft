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
    [BusinessObject("jdRecourseView")]
    public partial class jdRecourseView : SingleView
    {
        public jdRecourseView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new jdRecourseViewViewModel();
        }

        public new jdRecourseViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as jdRecourseViewViewModel;
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
            UIController.SetupGridControl(this.grdIndex);
        }
        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

    }
}
