using DevExpress.XtraTreeList;
using JDM.Framework.ServiceModel;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SAF.Framework;
using DevExpress.XtraBars.Ribbon;

namespace JDM
{
    public partial class Shell : DevExpress.XtraBars.Ribbon.RibbonForm, IJdmShell
    {
        BackstageViewControl backstageViewControl = new BackstageViewControl();

        public Shell()
        {
            InitializeComponent();

            ApplicationService.Current.MainForm = this;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = Properties.Resources.SAF_Icon;

            CompositionHelper.Current.ComposeParts(this);

            this.ribbonMain.ApplicationButtonDropDownControl = this.backstageViewControl;

            InitMainMenu();

            InitBackstageView();

        }

        [ImportMany(typeof(IJdmBackstageTabItem))]
        protected IEnumerable<Lazy<IJdmBackstageTabItem>> BackstageViewTabItems { get; private set; }

        [ImportMany(typeof(IJdmBackstageCommand))]
        protected IEnumerable<Lazy<IJdmBackstageCommand>> BackstageViewCommands { get; private set; }

        [ImportMany("MainMenuCommand", typeof(IJdmMenuCommand))]
        protected IEnumerable<Lazy<IJdmMenuCommand, IJdmMenuCommandMetadata>> mainMenuCommands { get; private set; }

        void InitMainMenu()
        {
            Dictionary<JdmMenuCategory, string> RootIds = new Dictionary<JdmMenuCategory, string>();
            RootIds.Add(JdmMenuCategory.SystemManagement, Guid.NewGuid().ToString("D"));

            var _MenuList = new List<JdmMenuInfo>();
            var id = Guid.NewGuid();
            _MenuList.Add(new JdmMenuInfo() { Id = RootIds[JdmMenuCategory.SystemManagement], MenuHeader = "系统管理", ParentId = string.Empty, MenuOrder = 1, Command = null });
            if (mainMenuCommands != null)
            {
                foreach (var item in mainMenuCommands.OrderBy(p => p.Metadata.Order))
                {
                    var menu = new JdmMenuInfo();
                    menu.Id = item.Metadata.Id;
                    menu.MenuHeader = item.Metadata.Header;
                    menu.ParentId = RootIds[item.Metadata.Category];
                    menu.MenuOrder = item.Metadata.Order;
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

        private void InitBackstageView()
        {
            backstageViewControl.Items.Clear();

            if (this.BackstageViewTabItems != null)
            {
                var list = BackstageViewTabItems.OrderBy(p => p.Value.Index);
                foreach (var item in list)
                {
                    item.Value.Init();

                    if (item.Value.BeginGroup)
                    {
                        BackstageViewItemSeparator sp = new BackstageViewItemSeparator();
                        backstageViewControl.Items.Add(sp);
                    }

                    BackstageViewTabItem tab = new BackstageViewTabItem();
                    tab.Caption = item.Value.Caption;
                    tab.ContentControl.Controls.Add(item.Value.View);
                    item.Value.View.Dock = DockStyle.Fill;
                    backstageViewControl.Items.Add(tab);

                    tab.Selected = item.Value.IsSelected;
                    tab.SelectedChanged += (sender, args) =>
                    {
                        item.Value.RefreshUI();
                    };
                }
            }

            if (this.BackstageViewCommands != null)
            {
                var list = BackstageViewCommands.OrderBy(p => p.Value.Index);
                foreach (var item in list)
                {
                    if (item.Value.BeginGroup)
                    {
                        BackstageViewItemSeparator sp = new BackstageViewItemSeparator();
                        backstageViewControl.Items.Add(sp);
                    }
                    BackstageViewButtonItem btn = new BackstageViewButtonItem();
                    btn.Caption = item.Value.Caption;
                    btn.Glyph = item.Value.m_Glyph;
                    btn.ItemClick += item.Value.ItemClick;
                    backstageViewControl.Items.Add(btn);
                }
            }
        }

        private void ShowView(TreeList tree)
        {
            if (tree.FocusedNode != null)
            {
                var menu = tree.GetDataRecordByNode(tree.FocusedNode) as JdmMenuInfo;
                if (menu != null)
                {
                    if (menu.Command != null && menu.Command.CanExecute(menu))
                    {
                        menu.Command.Execute(menu);
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

        private Form FindForm(string menuId)
        {
            foreach (var item in this.MdiChildren)
            {
                if (item.Tag != null && item.Tag.ToString() == menuId)
                    return item;
            }
            return null;
        }

        public void ShowForm<T>(string menuId, string menuHeader) where T : BaseView
        {
            var doc = this.FindForm(menuId);
            if (doc != null)
                this.tabbedView.ActivateDocument(doc);
            else
            {
                Application.DoEvents();
                ProgressService.Show("正在创建业务窗口");
                try
                {
                    object obj = Activator.CreateInstance(typeof(T));
                    if (obj == null)
                        throw new Exception("业务窗口'{0}'类型错误,无法创建.".FormatEx(typeof(T).FullName));

                    var ctl = obj as SAF.Framework.View.BaseView;
                    if (ctl != null)
                    {
                        ctl.UniqueId = menuId;
                        ctl.Init();
                        ctl.Text = menuHeader;

                        var frm = ctl.CreateRibbonContainer();
                        frm.Icon = Icon.FromHandle(Properties.Resources.Icon_Form_16x16.GetHicon());
                        frm.MdiParent = this;
                        frm.Tag = menuId;
                        frm.Show();
                    }
                    else
                        throw new Exception("业务窗口'{0}'不是UserControl,无法加载显示.".FormatEx(typeof(T).FullName));

                    ProgressService.Close(ApplicationService.Current.MainForm);
                }
                catch
                {
                    ProgressService.Abort(ApplicationService.Current.MainForm);
                    throw;
                }
            }
        }
    }
}
