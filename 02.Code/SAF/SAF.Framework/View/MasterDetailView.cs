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

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();
            if (this.ViewModel == null) return;

            var isBrowse = ViewModel.EditStatus == EditStatus.Browse;

            var isEditing = ViewModel.EditStatus.In(EditStatus.AddNew, EditStatus.Edit);

            var count = this.ViewModel.DetailEntitySet.Count;

            UIController.RefreshControl(this.btnDtlAddNew, isEditing);
            UIController.RefreshControl(this.btnDtlDelete, isEditing && count > 0);
            UIController.RefreshControl(this.btnDtlCancel, isEditing && count > 0);
        }

        #region button Actions

        private void btnDtlAddNew_Click(object sender, EventArgs e)
        {
            OnDtlAddNew();
        }

        private void btnDtlDelete_Click(object sender, EventArgs e)
        {
            OnDtlDelete();
        }

        private void btnDtlCancel_Click(object sender, EventArgs e)
        {
            OnDtlCancel();
        }

        #endregion


        #region Actions

        protected virtual void OnDtlAddNew()
        {

        }

        protected virtual void OnDtlDelete()
        {

        }

        protected virtual void OnDtlCancel()
        {

        }

        #endregion

    }
}
