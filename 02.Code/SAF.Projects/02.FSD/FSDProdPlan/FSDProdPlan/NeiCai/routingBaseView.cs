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

namespace FSDProdPlan.NeiCai
{
    [BusinessObject("routingBaseView")]
    public partial class routingBaseView : SingleView
    {
        public routingBaseView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new routingBaseViewViewModel();
        }

        public new routingBaseViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as routingBaseViewViewModel;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            groupCooperation.Visible = false;
            groupReport.Visible = false;
        }
        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
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
        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

    }
}
