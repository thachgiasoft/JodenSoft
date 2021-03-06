﻿using System;
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

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            if (this.ViewModel != null)
            {
                this.ViewModel.DetailEntitySet.SetBindingSource(this.bsDetail);
            }
        }

        protected override void OnRefreshDetailToolBar()
        {
            base.OnRefreshDetailToolBar();

            if (this.ViewModel == null) return;

            var count = this.ViewModel.DetailEntitySet.Count;

            UIController.RefreshControl(this.btnDtlAddNew, this.IsEdit || this.IsAddNew);
            UIController.RefreshControl(this.btnDtlDelete, (this.IsEdit || this.IsAddNew) && count > 0);
            UIController.RefreshControl(this.btnDtlCopy, (this.IsEdit || this.IsAddNew) && count > 0);
            UIController.RefreshControl(this.bsiDtlImport, (this.IsEdit || this.IsAddNew));
        }

        #region dtl button Actions

        private void btnDtlAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDetailAddNew();
            OnRefreshDetailToolBar();
        }

        private void btnDtlDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDetailDelete();
            OnRefreshDetailToolBar();
        }

        private void btnDtlCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDetailCopy();
            OnRefreshDetailToolBar();
        }

        private void bbiDtlImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnDetailImport();
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

        protected virtual void OnDetailImport()
        {

        }
        #endregion


    }
}
