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
using SAF.Foundation;

namespace SAF.SystemModule
{
    [BusinessObject("用户数据权限")]
    public partial class sysUserDataRoleView : SingleView
    {
        public sysUserDataRoleView()
        {
            InitializeComponent();
        }
        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            UIController.SetupGridControl(this.grdIndex);
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.lueUser.SetDataSource(ViewModel.GetUser(), "Iden", "UserFullName", "Iden|用户编号,UserName|用户名,UserFullName|用户姓名");
            this.tlueOrg.SetDataSource(ViewModel.GetOrganization(), "Iden", "Name", "ParentId");
            this.lueDataRole.SetDataSource(ViewModel.GetDataRole(), "Iden", "Name", "Iden|角色编号,Name|角色名称");
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysUserDataRoleViewModel();
        }

        public new sysUserDataRoleViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysUserDataRoleViewModel;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            this.colUserId.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.AllowEdit = this.IsAddNew || this.IsEdit;
            this.colOrganizationId.OptionsColumn.AllowEdit = this.IsAddNew || this.IsEdit;

            this.grvMain.BestFitColumns();

            if (this.ViewModel.IndexEntitySet.IsEmpty())
            {
                this.bbiAddNew.Enabled = false;
                this.bbiEdit.Enabled = false;
                this.bbiCancel.Enabled = false;
                this.bbiDelete.Enabled = false;
                this.bbiPreview.Enabled = false;
                this.bbiSave.Enabled = false;
                this.bbiSend.Enabled = false;
            }
        }

        protected override void OnPostUIData()
        {
            base.OnPostUIData();
            this.grvMain.PostEditor();
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
    }
}
