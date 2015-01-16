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

namespace FSDProdPlan
{
    [BusinessObject("sysBillNoFormulaView[系统管理]")]
    public partial class sysBillNoFormulaView : SingleView
    {
        public sysBillNoFormulaView()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.groupCooperation.Visible = false;
            this.groupReport.Visible = false;
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
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (string.IsNullOrEmpty(this.txtBillNoType.Text))
            {
                MessageService.ShowMessage("请输入单据号类型");
                return ;

            }
            
        }
        
       
    }
}
