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

namespace SAF.Test
{
    [BusinessObject("sdOrderView")]
    public partial class sdOrderView : MasterDetailView
    {
        public sdOrderView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sdOrderViewViewModel();
        }

        public new sdOrderViewViewModel ViewModel
        {
            get { return base.ViewModel as sdOrderViewViewModel; }
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            InitOrgGridSearch();

            this.AccessFocusControl = this.txtOrderNo;
        }

        private void InitOrgGridSearch()
        {
            this.gseOrg.Properties.CommandText = @"
SELECT Iden,Name 
FROM dbo.sysOrganization a WITH(NOLOCK)
where {0}
ORDER BY [Iden]";
            this.gseOrg.Properties.DisplayMember = "Name";
            this.gseOrg.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.gseOrg.Properties.AutoFillFieldNames = "OrganizationId=Iden,OrganizationName=Name";
            this.gseOrg.Properties.ColumnHeaders = "组织序号,组织名称";
            this.gseOrg.Properties.Query();
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();
            this.grvIndex.FocusedRowChanged += grvIndex_FocusedRowChanged;
        }

        void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
    }
}
