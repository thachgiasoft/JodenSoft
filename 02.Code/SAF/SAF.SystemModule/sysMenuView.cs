using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using SAF.Framework.Controls;
using SAF.Foundation;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
using SAF.Framework.Entities;
using DevExpress.XtraLayout.Utils;

namespace SAF.SystemModule
{
    [BusinessObject("菜单管理")]
    public partial class sysMenuView : SingleView
    {
        public sysMenuView()
        {
            InitializeComponent();
        }

        protected new sysMenuViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysMenuViewViewModel;
            }
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysMenuViewViewModel();
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();
            this.pnlPageControl.Visible = false;
            this.pnlPageControl.Enabled = false;

            InitBusinessViewGridSearch();

            InitMenuType();

            this.treeMenu.GetSelectImage += treeList1_GetSelectImage;
            this.gseBusinessView.EditValueChanged += gseBusinessView_EditValueChanged;

        }

        protected override void OnAfterInit()
        {
            base.OnAfterInit();

            if (this.treeMenu.Nodes.Count > 0)
            {
                this.treeMenu.Nodes[0].Expanded = true;
            }
        }

        private void InitMenuType()
        {
            var list = typeof(sysMenuType).ToList<int>();
            this.gluMenuType.Properties.SetDataSource(list, "Key", "Value", "Value|菜单类型");
        }

        void gseBusinessView_EditValueChanged(object sender, EventArgs e)
        {
            this.ViewModel.QueryMenuParam();
        }

        void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = this.treeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (!drv.IsEmpty())
            {
                if (drv["MenuType"].IsEmpty())
                {
                    e.NodeImageIndex = 0;
                }
                else
                {
                    var menuType = (sysMenuType)Convert.ToInt32(drv["MenuType"]);
                    if (menuType.In(sysMenuType.Catalog))
                        e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
                    else if (menuType.In(sysMenuType.Menu))
                        e.NodeImageIndex = 2;
                    else
                        e.NodeImageIndex = 3;
                }
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }

        private void InitBusinessViewGridSearch()
        {
            this.gseBusinessView.Properties.CommandText = @"
SELECT Iden,[ClassName],[Description],[IsDeleted]
FROM [dbo].[sysBusinessView] WITH(NOLOCK)
where {0}
ORDER BY [Iden]";
            this.gseBusinessView.Properties.DisplayMember = "ClassName";
            this.gseBusinessView.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.gseBusinessView.Properties.AutoFillFieldNames = "BusinessViewId=Iden,BusinessView=ClassName,BusinessViewDescription=Description";
            this.gseBusinessView.Properties.ColumnHeaders = "Iden,业务类名,业务功能描述,是否已删除";
            this.gseBusinessView.Properties.Query();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.gluMenuType;

            UIController.SetupTreelist(this.treeMenu);
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            this.treeMenu.KeyFieldName = "Iden";
            this.treeMenu.ParentFieldName = "ParentId";

            this.ViewModel.MenuParamEntitySet.SetBindingSource(this.bsParams);
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.txtDescription, false);

            this.grvParams.UnEditableAllColumns();
            if (this.IsAddNew || this.IsEdit)
            {
                this.grvParams.EditableColumns("Value");
            }
            this.grvParams.BestFitColumns();

            var menuType = sysMenuType.Catalog;
            if (this.ViewModel.MainEntitySet.CurrentEntity == null || this.ViewModel.MainEntitySet.CurrentEntity.MenuType == 0)
                menuType = sysMenuType.Catalog;
            else
                menuType = (sysMenuType)this.ViewModel.MainEntitySet.CurrentEntity.MenuType;

            RefreshUIByMenuType(menuType);
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            IndexRowChange();
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();
            InitParentTreeList();

            this.grvParams.BestFitColumns();
        }

        private void InitParentTreeList()
        {
            this.tluParent.Properties.DataSource = this.ViewModel.ParentEntitySet.DefaultView;
            this.tluParent.Properties.ValueMember = "Iden";
            this.tluParent.Properties.DisplayMember = "Name";
            this.tluParent.Properties.TreeList.KeyFieldName = "Iden";
            this.tluParent.Properties.TreeList.ParentFieldName = "ParentId";
            this.tluParent.Properties.TreeList.OptionsView.ShowColumns = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowIndicator = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowHorzLines = false;
            this.tluParent.Properties.TreeList.OptionsView.ShowVertLines = false;
        }

        private void treeListLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                (sender as TreeListLookUpEdit).EditValue = -1;
            }
        }

        protected override void OnPostUIData()
        {
            this.grvParams.CloseEditor();
            this.grvParams.PostEditor();

            base.OnPostUIData();
        }

        private void gluMenuType_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as GridLookUpEdit;
            if (edit == null || edit.EditValue == null || edit.EditValue == DBNull.Value) return;

            var menuType = (sysMenuType)Convert.ToInt32(edit.EditValue);

            RefreshUIByMenuType(menuType);

        }

        private void RefreshUIByMenuType(sysMenuType menuType)
        {
            lciIsAutoOpen.Visibility = menuType.In(sysMenuType.Menu) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lciViewId.Visibility = menuType.In(sysMenuType.Menu) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lciDescription.Visibility = lciViewId.Visibility;
            lciFileName.Visibility = menuType.In(sysMenuType.ExternalForm) ? LayoutVisibility.Always : LayoutVisibility.Never;
            lciParameter.Visibility = menuType.In(sysMenuType.ExternalForm) ? LayoutVisibility.Always : LayoutVisibility.Never;

            if (menuType.In(sysMenuType.Menu))
                this.splitRight.PanelVisibility = SplitPanelVisibility.Both;
            else
                this.splitRight.PanelVisibility = SplitPanelVisibility.Panel1;

        }


    }
}
