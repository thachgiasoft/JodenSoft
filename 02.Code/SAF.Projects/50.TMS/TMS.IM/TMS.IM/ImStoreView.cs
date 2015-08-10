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
    [BusinessObject("ImStoreView")]
    public partial class ImStoreView : SingleView
    {
        public ImStoreView()
        {
            InitializeComponent();
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.AccessFocusControl = this.txtName;
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new ImStoreViewViewModel();
        }

        public new ImStoreViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as ImStoreViewViewModel;
            }
        }


        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);

        }



        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
    }
}
