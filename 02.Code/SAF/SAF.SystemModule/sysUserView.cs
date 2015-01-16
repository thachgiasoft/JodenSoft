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
using SAF.Framework.Controls;
using SAF.Framework;
using SAF.Foundation.ServiceModel;
using SAF.EntityFramework;
using SAF.Foundation;

namespace SAF.SystemModule
{
    [BusinessObject("用户管理")]
    public partial class sysUserView : SingleView
    {
        public sysUserView()
        {
            InitializeComponent();

            this.treeRole.BeforeCheckNode += treeRole_BeforeCheckNode;
            this.grvIndex.FocusedRowChanged += grvIndex_FocusedRowChanged;

            this.AccessFocusControl = this.txtUserNo;
        }

        void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();

            this.treeRole.UncheckAll();
            foreach (var item in this.ViewModel.UserRoleEntitySet)
            {
                var node = this.treeRole.FindNodeByKeyID(item.RoleId);
                if (node != null)
                {
                    this.treeRole.SetNodeCheckState(node, CheckState.Checked, true);
                }
            }
        }

        void treeRole_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (this.IsAddNew || this.IsEdit) return;
            e.CanCheck = false;
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysUserViewViewModel();
        }

        public new sysUserViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysUserViewViewModel;
            }
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            this.ViewModel.RoleEntitySet.SetBindingSource(this.bsRole);
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(chkIsSystem, false);
            UIController.RefreshControl(txtUserId, false);

            UIController.SetupTreelist(this.treeRole);
            UIController.RefreshControl(treeRole, true);

        }

        protected override bool OnSave()
        {
            var list = this.treeRole.GetAllCheckedNodes();
            this.ViewModel.SaveRoles(list);

            return base.OnSave();
        }

        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();

            this.AddRibbonMenuCommand(new DefaultRibbonMenuCommand("重置密码", ResetPassword, ResetPassowrdCanExceute) { LargeGlyph = Properties.Resources.Action_ResetPassword_32x32 });
        }

        private bool ResetPassowrdCanExceute(object obj)
        {
            return this.ViewModel.MainEntitySet.CurrentEntity != null && !this.IsEdit && !this.IsAddNew;
        }

        private void ResetPassword(object obj)
        {
            if (this.ViewModel.MainEntitySet.CurrentEntity == null)
            {
                return;
            }

            if (this.ViewModel.MainEntitySet.CurrentEntity.IsSystem)
            {
                MessageService.ShowWarning("用户\"{0}\"是系统预定义的用户,无法重置密码!".FormatEx(this.ViewModel.MainEntitySet.CurrentEntity.UserName));
                return;
            }

            var dr = MessageService.AskQuestion("确定要重置密码吗?");

            if (dr)
            {
                this.ViewModel.ResetPassword();
                MessageService.ShowMessage("重置密码成功.");
            }
        }
    }
}
