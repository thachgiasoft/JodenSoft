using DevExpress.XtraTreeList;
using JDM.Framework.ServiceModel;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM
{
    public partial class Shell : DevExpress.XtraBars.Ribbon.RibbonForm, IJDMShell
    {
        public Shell()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = Properties.Resources.SAF_Icon;

            CompositionHelper.Current.ComposeParts(this);

            InitMainMenu();
        }

        [ImportMany("MainMenuCommand", typeof(IMenuCommand))]
        Lazy<IMenuCommand, IMenuCommandMetadata>[] mainMenuCommands = null;

        void InitMainMenu()
        {
            Dictionary<MenuCategory, string> RootIds = new Dictionary<MenuCategory, string>();
            RootIds.Add(MenuCategory.SystemManagement, Guid.NewGuid().ToString("D"));

            var _MenuList = new List<MenuInfo>();
            var id = Guid.NewGuid();
            _MenuList.Add(new MenuInfo() { Id = RootIds[MenuCategory.SystemManagement], MenuHeader = "系统管理", ParentId = string.Empty, MenuOrder = 1, Command = null });
            if (mainMenuCommands != null)
            {
                foreach (var item in mainMenuCommands.OrderBy(p => p.Metadata.MenuOrder))
                {
                    var menu = new MenuInfo();
                    menu.Id = item.Metadata.MenuId;
                    menu.MenuHeader = item.Metadata.Menu;
                    menu.ParentId = RootIds[item.Metadata.MenuCategory];
                    menu.MenuOrder = item.Metadata.MenuOrder;
                    menu.Command = item.Value;
                    _MenuList.Add(menu);
                }
            }

            var colName = this.TreeMenu.Columns.Add();
            colName.Caption = "名称";
            colName.FieldName = "MenuHeader";
            colName.Name = "colMenuHeader";
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

            this.TreeMenu.DataSource = new BindingSource() { DataSource = _MenuList };
            this.TreeMenu.KeyFieldName = "Id";
            this.TreeMenu.ParentFieldName = "ParentId";
            if (this.TreeMenu.Nodes.Count > 0)
            {
                this.TreeMenu.Nodes[0].Expanded = true;
            }

            this.TreeMenu.MouseDoubleClick += TreeMenu_MouseDoubleClick;
        }

        void TreeMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var tree = (sender as TreeList);
            if (tree == null) return;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            switch (hitInfo.HitInfoType)
            {
                case HitInfoType.Cell:
                case HitInfoType.SelectImage:
                    ShowView(tree);
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void ShowView(TreeList tree)
        {
            if (tree.FocusedNode != null)
            {
                var menu = tree.GetDataRecordByNode(tree.FocusedNode) as MenuInfo;
                if (menu != null)
                {
                    if (menu.Command != null && menu.Command.CanExecute(this))
                    {
                        menu.Command.Execute(this);
                    }
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                this.Activate();
            }
            finally
            {
                SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
            }
        }

        public Form View
        {
            get { return this; }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl RibbonControl
        {
            get { return this.ribbonMain; }
        }
    }
}
