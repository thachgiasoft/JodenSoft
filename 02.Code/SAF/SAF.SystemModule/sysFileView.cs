using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Foundation.ServiceModel;
using SAF.Framework;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using System.IO;
using SAF.Framework.Controls;
using SAF.Foundation.MetaAttributes;

namespace SAF.SystemModule
{
    [BusinessObject("文件管理")]
    public partial class sysFileView : SingleView
    {
        public sysFileView()
        {
            InitializeComponent();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            var fileDragDropManager = new FileDragDropManager(this, false);
            fileDragDropManager.FileDropped += fileDragDropManager_FileDroppedEvent;

            this.AccessFocusControl = txtFileName;
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            this.txtFileName.Properties.ReadOnly = true;

            UIController.RefreshControl(this.txtName, false);
            UIController.RefreshControl(this.txtLastTime, false);
            UIController.RefreshControl(this.txtFileVersion, false);
            UIController.RefreshControl(this.txtFileSize, false);
            UIController.RefreshControl(this.txtId, false);

            this.grvIndex.BestFitColumns();
        }

        void fileDragDropManager_FileDroppedEvent(object sender, FileDroppedEventArgs e)
        {
            this.ViewModel.UpdateFiles(e.Files);
        }

        protected new sysFileViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysFileViewViewModel;
            }
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysFileViewViewModel();
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        private void txtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.ViewModel.SelectFile();
        }

        private void txtFileName_DoubleClick(object sender, EventArgs e)
        {
            this.ViewModel.SelectFile();
        }
    }
}
