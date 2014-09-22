using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.Controls;
using SAF.Foundation.MetaAttributes;

namespace SAF.SystemModule
{
    [BusinessObject("数据角色管理")]
    public partial class sysDataRoleView : SingleView
    {
        public sysDataRoleView()
        {
            InitializeComponent();
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysDataRoleViewViewModel();
        }

        public new sysDataRoleViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysDataRoleViewViewModel;
            }
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.chkIsSystem, false);
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.txtName;
        }
    }
}
