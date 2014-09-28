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

        private void grdIndex_Click(object sender, EventArgs e)
        {

        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IndexRowChange();
        }


    }
}
