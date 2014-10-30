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

            this.treeMenu.GetSelectImage += treeList1_GetSelectImage;
            this.gseBusinessView.EditValueChanged += gseBusinessView_EditValueChanged;
        }

        void gseBusinessView_EditValueChanged(object sender, EventArgs e)
        {
            this.ViewModel.QueryMenuParam();
        }

        void treeList1_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var drv = this.treeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (drv.IsNotEmpty() && drv["BusinessView"].IsNotEmpty())
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }

        private void InitBusinessViewGridSearch()
        {
            this.gseBusinessView.Properties.CommandText = @"SELECT Iden,[ClassName],[IsDeleted]
FROM [dbo].[sysBusinessView] WITH(NOLOCK)
where {0}
ORDER BY [Iden]";
            this.gseBusinessView.Properties.DisplayMember = "ClassName";
            this.gseBusinessView.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.gseBusinessView.Properties.AutoFillFieldNames = "BusinessViewId=Iden,BusinessView=ClassName";
            this.gseBusinessView.Properties.ColumnHeaders = "Iden,业务类名,是否已删除";
            this.gseBusinessView.Properties.Query();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.txtName;

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

            this.grvParams.UnEditableAllColumns();
            if (this.IsAddNew || this.IsEdit)
            {
                this.grvParams.EditableColumns("Value");
            }
            this.grvParams.BestFitColumns();
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
    }
}
