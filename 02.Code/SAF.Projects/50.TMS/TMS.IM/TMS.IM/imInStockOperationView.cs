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
using SAF.Framework;
using SAF.Foundation.MetaAttributes;
namespace TMS.IM
{
    [BusinessObject("imInStockOperationView")]
    public partial class imInStockOperationView : MasterDetailView
    {

        [ViewParam("InOutStoreParam")]
        public int iStoreID
        {
            get { return Convert.ToInt32(this.GetViewParam("iStoreID")); }
            set { this.SetViewParam("iStoreID", value.ToString()); }
        }

        public imInStockOperationView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            var viewModel = new imInStockOperationViewViewModel();
            viewModel.View = this;
            return viewModel;
        }

        public new imInStockOperationViewViewModel ViewModel
        {
            get { return base.ViewModel as imInStockOperationViewViewModel; }
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();
            InitShearchInOutType();
        }


        private void InitShearchInOutType()
        {
            this.ShearchInOutType.Properties.CommandText = @"SELECT sStoreInOutName,sStoreInOutType,Iden 
FROM dbo.imStoreInOutType A WITH(NOLOCK)
WHERE bUsable=1 AND {0}
ORDER BY [Iden]";
            this.ShearchInOutType.Properties.DisplayMember = "sStoreInOutName";
            this.ShearchInOutType.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.ShearchInOutType.Properties.AutoFillFieldNames = " iStoreInOutType=Iden";
            this.ShearchInOutType.Properties.ColumnHeaders = "操作类型,方向标识,流水编号";
            this.ShearchInOutType.Properties.Query();
        }

        private void grdIndex_Click(object sender, EventArgs e)
        {

        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IndexRowChange();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mmoRemark_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}
