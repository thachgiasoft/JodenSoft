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
using SAF.Foundation.ServiceModel;

namespace SAF.SystemModule
{
    [BusinessObject("系统单据号规则")]
    public partial class sysBillNoFormulaView : SingleView
    {
        public sysBillNoFormulaView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysBillNoFormulaViewViewModel();
        }

        public new sysBillNoFormulaViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysBillNoFormulaViewViewModel;
            }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
            this.AccessFocusControl = this.txtBillNoType;
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.txtCurrentIden, false);

            this.grvIndex.BestFitColumns();
        }
    }
}
