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
using DevExpress.XtraTreeList.Nodes;
using SAF.Foundation;
using SAF.Framework;
using SAF.Framework.Entity;

namespace SAF.SystemModule
{
    [BusinessObject("系统角色管理")]
    public partial class sysRoleView : SingleView
    {
        public sysRoleView()
        {
            InitializeComponent();

            this.treeMenu.BeforeCheckNode += treeMenu_BeforeCheckNode;
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysRoleViewViewModel();
        }

        protected new sysRoleViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysRoleViewViewModel;
            }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);

            this.AccessFocusControl = this.txtName;

        }

        void treeMenu_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            if (this.IsAddNew || this.IsEdit) return;
            e.CanCheck = false;
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.chkIsSystem, false);
            UIController.RefreshControl(this.chkIsAdministrator, false);

            UIController.SetupTreelist(this.treeMenu);
            this.treeMenu.Enabled = true;
            this.treeMenu.OptionsBehavior.Editable = false;

            this.grvIndex.BestFitColumns();
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            this.ViewModel.MenuEntitySet.SetBindingSource(this.bsMenu);
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.treeMenu.KeyFieldName = "Iden";
            this.treeMenu.ParentFieldName = "ParentId";
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();

            this.treeMenu.UncheckAll();
            foreach (var item in this.ViewModel.RoleMenuEntitySet)
            {
                var node = this.treeMenu.FindNodeByKeyID(item.MenuId);
                if (node != null)
                {
                    this.treeMenu.SetNodeCheckState(node, CheckState.Checked, true);
                }
            }
        }

        protected override bool OnSave()
        {
            var list = this.treeMenu.GetAllCheckedNodes();
            this.ViewModel.SaveCheckNodes(list);

            return base.OnSave();
        }

        private void treeMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = this.treeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (!drv.IsEmpty())
            {
                var menuType = (sysMenuType)Convert.ToInt32(drv["MenuType"]);
                if (menuType == sysMenuType.Menu)
                    e.NodeImageIndex = 2;
                else if (menuType == sysMenuType.ExternalForm)
                    e.NodeImageIndex = 3;
                else
                    e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }


    }
}
