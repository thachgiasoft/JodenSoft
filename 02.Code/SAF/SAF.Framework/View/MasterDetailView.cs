using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;
using SAF.Framework.Controls;
using SAF.Framework.ViewModel;

namespace SAF.Framework.View
{
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public partial class MasterDetailView : SingleView
    {
        public MasterDetailView()
        {
            InitializeComponent();
        }

        protected new IMasterDetailViewViewModel ViewModel
        {
            get { return base.ViewModel as IMasterDetailViewViewModel; }
        }

        protected override void OnRefreshDetailToolBar()
        {
            base.OnRefreshDetailToolBar();

            if (this.ViewModel == null) return;

            var count = this.ViewModel.DetailEntitySet.Count;

            UIController.RefreshControl(this.btnDtlAddNew, this.IsEdit || this.IsAddNew);
            UIController.RefreshControl(this.btnDtlDelete, (this.IsEdit || this.IsAddNew) && count > 0);
            UIController.RefreshControl(this.btnDtlCopy, (this.IsEdit || this.IsAddNew) && count > 0);
            UIController.RefreshControl(this.btnDtlImport, (this.IsEdit || this.IsAddNew));
        }

        #region dtl button Actions

        private void btnDtlAddNew_Click(object sender, EventArgs e)
        {
            OnDetailAddNew();
            OnRefreshDetailToolBar();
        }

        private void btnDtlDelete_Click(object sender, EventArgs e)
        {
            OnDetailDelete();
            OnRefreshDetailToolBar();
        }

        private void btnDtlCopy_Click(object sender, EventArgs e)
        {
            OnDetailCopy();
            OnRefreshDetailToolBar();
        }

        #endregion


        #region Dtl Actions

        protected virtual void OnDetailAddNew()
        {
            this.ViewModel.DetailAddNew();
        }

        protected virtual void OnDetailDelete()
        {
            this.ViewModel.DetailDelete();
        }

        protected virtual void OnDetailCopy()
        {
            this.ViewModel.DetailCopy();
        }

        #endregion



    }
}
