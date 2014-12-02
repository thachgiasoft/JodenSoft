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
using SAF.SystemEntities;
using DevExpress.XtraTreeList;
using SAF.Framework;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using SAF.Foundation;

namespace SAF.SystemModule
{
    [BusinessObject("sysMenuSelector")]
    public partial class sysMenuSelector : SingleView
    {
        public sysMenuSelector()
        {
            InitializeComponent();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.pnlPageControl.Enabled = false;
            this.pnlPageControl.Visible = false;
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.treeMenu.KeyFieldName = "Iden";
            this.treeMenu.ParentFieldName = "ParentId";
            if (this.treeMenu.Columns.ColumnByFieldName("Name") == null)
            {
                var colName = this.treeMenu.Columns.Add();
                colName.Caption = "名称";
                colName.FieldName = "Name";
                colName.Name = "colName";
                colName.OptionsColumn.AllowEdit = false;
                colName.OptionsColumn.AllowMove = false;
                colName.OptionsColumn.AllowMoveToCustomizationForm = false;
                colName.OptionsColumn.AllowSort = false;
                colName.OptionsColumn.ReadOnly = true;
                colName.OptionsColumn.ShowInCustomizationForm = false;
                colName.OptionsColumn.ShowInExpressionEditor = false;
                colName.OptionsFilter.AllowAutoFilter = false;
                colName.OptionsFilter.AllowFilter = false;
                colName.Visible = true;
                colName.VisibleIndex = 0;
            }
            this.treeMenu.SelectImageList = this.imageCollectionTreeList;
            this.treeMenu.GetSelectImage += treeMenu_GetSelectImage;
        }

        void treeMenu_GetSelectImage(object sender, GetSelectImageEventArgs e)
        {
            var drv = this.treeMenu.GetDataRecordByNode(e.Node) as DataRowView;

            if (drv == null) return;

            if (drv["BusinessViewId"].IsNotEmpty())
            {
                e.NodeImageIndex = 2;
            }
            else
            {
                e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(treeMenu, true);

            UIController.HideMenu(groupData, groupCooperation, groupReport);
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysMenuSelectorViewModel();
        }

        public new sysMenuSelectorViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysMenuSelectorViewModel;
            }
        }

        public List<TreeListNode> Selection
        {
            get
            {
                return this.treeMenu.GetAllCheckedNodes();
            }
        }

        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();
            this.AddRibbonMenuCommand(new DefaultRibbonMenuCommand("选择", OnSelectMenu) { LargeGlyph = Properties.Resources.Action_Mark_32x32 });
        }

        private void OnSelectMenu(object obj)
        {
            var form = this.FindForm();
            if (form != null)
                form.DialogResult = DialogResult.OK;
        }
    }
}
