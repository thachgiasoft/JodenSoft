namespace SAF.Client
{
    partial class Shell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiMessage = new DevExpress.XtraBars.BarStaticItem();
            this.bbiAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHomepage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiWelcomePage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNavigation = new DevExpress.XtraBars.BarButtonItem();
            this.SystemPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusBarMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.navMainMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.systemMenuGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.TreeMenu = new DevExpress.XtraTreeList.TreeList();
            this.pnlMenu = new DevExpress.XtraEditors.PanelControl();
            this.txtFind = new DevExpress.XtraEditors.TextEdit();
            this.btnRefreshMenu = new DevExpress.XtraEditors.SimpleButton();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeMyMenu = new DevExpress.XtraTreeList.TreeList();
            this.pnlWorkspace = new DevExpress.XtraEditors.PanelControl();
            this.btnRefreshMyFavorite = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyMenuDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyMenuDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpMyMenu = new DevExpress.XtraEditors.SimpleButton();
            this.sysMyWorkspace = new DevExpress.XtraNavBar.NavBarGroup();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection();
            this.splMenu = new DevExpress.XtraEditors.SplitterControl();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).BeginInit();
            this.navMainMenu.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).BeginInit();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMyMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkspace)).BeginInit();
            this.pnlWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.bsiMessage,
            this.bbiAbout,
            this.bbiHelp,
            this.bbiHomepage,
            this.bbiWelcomePage,
            this.bbiNavigation});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 8;
            this.ribbonMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.SystemPage});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(673, 147);
            this.ribbonMain.StatusBar = this.statusBarMain;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            this.ribbonMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bsiMessage
            // 
            this.bsiMessage.Caption = "就绪...";
            this.bsiMessage.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiMessage.Id = 1;
            this.bsiMessage.Name = "bsiMessage";
            this.bsiMessage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiAbout
            // 
            this.bbiAbout.Caption = "关于";
            this.bbiAbout.Description = "关于系统";
            this.bbiAbout.Id = 3;
            this.bbiAbout.LargeGlyph = global::SAF.Client.Properties.Resources.Action_About_32x32;
            this.bbiAbout.Name = "bbiAbout";
            this.bbiAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAbout_ItemClick);
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "帮助";
            this.bbiHelp.Id = 4;
            this.bbiHelp.LargeGlyph = global::SAF.Client.Properties.Resources.Action_Help_32x32;
            this.bbiHelp.Name = "bbiHelp";
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHelp_ItemClick);
            // 
            // bbiHomepage
            // 
            this.bbiHomepage.Caption = "主页";
            this.bbiHomepage.Description = "公司主页";
            this.bbiHomepage.Id = 5;
            this.bbiHomepage.LargeGlyph = global::SAF.Client.Properties.Resources.Home_32x32;
            this.bbiHomepage.Name = "bbiHomepage";
            this.bbiHomepage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHomepage_ItemClick);
            // 
            // bbiWelcomePage
            // 
            this.bbiWelcomePage.Caption = "起始页";
            this.bbiWelcomePage.Id = 6;
            this.bbiWelcomePage.LargeGlyph = global::SAF.Client.Properties.Resources.Action_Welcome_32x32;
            this.bbiWelcomePage.Name = "bbiWelcomePage";
            this.bbiWelcomePage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiWelcomePage_ItemClick);
            // 
            // bbiNavigation
            // 
            this.bbiNavigation.Caption = "导航图";
            this.bbiNavigation.Id = 7;
            this.bbiNavigation.LargeGlyph = global::SAF.Client.Properties.Resources.Action_NavigationPage_32x32;
            this.bbiNavigation.Name = "bbiNavigation";
            this.bbiNavigation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNavigation_ItemClick);
            // 
            // SystemPage
            // 
            this.SystemPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupHelp});
            this.SystemPage.Name = "SystemPage";
            this.SystemPage.Text = "系统";
            // 
            // groupHelp
            // 
            this.groupHelp.AllowTextClipping = false;
            this.groupHelp.ItemLinks.Add(this.bbiWelcomePage);
            this.groupHelp.ItemLinks.Add(this.bbiNavigation);
            this.groupHelp.ItemLinks.Add(this.bbiHomepage, true);
            this.groupHelp.ItemLinks.Add(this.bbiAbout);
            this.groupHelp.ItemLinks.Add(this.bbiHelp);
            this.groupHelp.MergeOrder = 9000;
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "帮助";
            // 
            // statusBarMain
            // 
            this.statusBarMain.ItemLinks.Add(this.bsiMessage);
            this.statusBarMain.Location = new System.Drawing.Point(0, 436);
            this.statusBarMain.Name = "statusBarMain";
            this.statusBarMain.Ribbon = this.ribbonMain;
            this.statusBarMain.Size = new System.Drawing.Size(673, 31);
            // 
            // navMainMenu
            // 
            this.navMainMenu.ActiveGroup = this.systemMenuGroup;
            this.navMainMenu.Controls.Add(this.navBarGroupControlContainer1);
            this.navMainMenu.Controls.Add(this.navBarGroupControlContainer2);
            this.navMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMainMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.sysMyWorkspace,
            this.systemMenuGroup});
            this.navMainMenu.Location = new System.Drawing.Point(0, 147);
            this.navMainMenu.Name = "navMainMenu";
            this.navMainMenu.NavigationPaneMaxVisibleGroups = 1;
            this.navMainMenu.OptionsNavPane.ExpandedWidth = 181;
            this.navMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navMainMenu.Size = new System.Drawing.Size(181, 289);
            this.navMainMenu.TabIndex = 2;
            this.navMainMenu.Text = "navBarControl1";
            // 
            // systemMenuGroup
            // 
            this.systemMenuGroup.Caption = "系统菜单";
            this.systemMenuGroup.ControlContainer = this.navBarGroupControlContainer1;
            this.systemMenuGroup.Expanded = true;
            this.systemMenuGroup.GroupClientHeight = 80;
            this.systemMenuGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.systemMenuGroup.Name = "systemMenuGroup";
            this.systemMenuGroup.SmallImage = global::SAF.Client.Properties.Resources.Icon_Tree_16x16;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.TreeMenu);
            this.navBarGroupControlContainer1.Controls.Add(this.pnlMenu);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(181, 184);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeMenu.Location = new System.Drawing.Point(1, 27);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.OptionsBehavior.Editable = false;
            this.TreeMenu.OptionsSelection.InvertSelection = true;
            this.TreeMenu.OptionsView.ShowColumns = false;
            this.TreeMenu.OptionsView.ShowHorzLines = false;
            this.TreeMenu.OptionsView.ShowIndicator = false;
            this.TreeMenu.OptionsView.ShowVertLines = false;
            this.TreeMenu.Size = new System.Drawing.Size(180, 157);
            this.TreeMenu.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMenu.Controls.Add(this.txtFind);
            this.pnlMenu.Controls.Add(this.btnRefreshMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(1, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(180, 27);
            this.pnlMenu.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(1, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Properties.NullText = "快速启动 (Ctrl+Q)";
            this.txtFind.Size = new System.Drawing.Size(156, 20);
            this.txtFind.TabIndex = 1;
            // 
            // btnRefreshMenu
            // 
            this.btnRefreshMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMenu.Image = global::SAF.Client.Properties.Resources.Action_Refresh_16x16;
            this.btnRefreshMenu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefreshMenu.Location = new System.Drawing.Point(158, 3);
            this.btnRefreshMenu.Name = "btnRefreshMenu";
            this.btnRefreshMenu.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshMenu.TabIndex = 0;
            this.btnRefreshMenu.ToolTip = "刷新菜单";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.treeMyMenu);
            this.navBarGroupControlContainer2.Controls.Add(this.pnlWorkspace);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(181, 184);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // treeMyMenu
            // 
            this.treeMyMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMyMenu.Location = new System.Drawing.Point(1, 27);
            this.treeMyMenu.Name = "treeMyMenu";
            this.treeMyMenu.OptionsSelection.InvertSelection = true;
            this.treeMyMenu.OptionsView.ShowColumns = false;
            this.treeMyMenu.OptionsView.ShowHorzLines = false;
            this.treeMyMenu.OptionsView.ShowIndicator = false;
            this.treeMyMenu.OptionsView.ShowVertLines = false;
            this.treeMyMenu.Size = new System.Drawing.Size(180, 157);
            this.treeMyMenu.TabIndex = 0;
            // 
            // pnlWorkspace
            // 
            this.pnlWorkspace.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlWorkspace.Controls.Add(this.btnRefreshMyFavorite);
            this.pnlWorkspace.Controls.Add(this.btnMyMenuDelete);
            this.pnlWorkspace.Controls.Add(this.btnMyMenuDown);
            this.pnlWorkspace.Controls.Add(this.btnUpMyMenu);
            this.pnlWorkspace.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWorkspace.Location = new System.Drawing.Point(1, 0);
            this.pnlWorkspace.Name = "pnlWorkspace";
            this.pnlWorkspace.Size = new System.Drawing.Size(180, 27);
            this.pnlWorkspace.TabIndex = 1;
            // 
            // btnRefreshMyFavorite
            // 
            this.btnRefreshMyFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMyFavorite.Image = global::SAF.Client.Properties.Resources.Action_Refresh_16x16;
            this.btnRefreshMyFavorite.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefreshMyFavorite.Location = new System.Drawing.Point(77, 3);
            this.btnRefreshMyFavorite.Name = "btnRefreshMyFavorite";
            this.btnRefreshMyFavorite.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshMyFavorite.TabIndex = 4;
            this.btnRefreshMyFavorite.ToolTip = "刷新菜单";
            this.btnRefreshMyFavorite.Click += new System.EventHandler(this.btnRefreshMyFavorite_Click);
            // 
            // btnMyMenuDelete
            // 
            this.btnMyMenuDelete.Image = global::SAF.Client.Properties.Resources.Action_Delete_16x16;
            this.btnMyMenuDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMyMenuDelete.Location = new System.Drawing.Point(2, 3);
            this.btnMyMenuDelete.Name = "btnMyMenuDelete";
            this.btnMyMenuDelete.Size = new System.Drawing.Size(20, 20);
            this.btnMyMenuDelete.TabIndex = 3;
            this.btnMyMenuDelete.Text = "删除菜单";
            this.btnMyMenuDelete.Click += new System.EventHandler(this.btnMyMenuDelete_Click);
            // 
            // btnMyMenuDown
            // 
            this.btnMyMenuDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMyMenuDown.Image = global::SAF.Client.Properties.Resources.Action_Down_16x16;
            this.btnMyMenuDown.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMyMenuDown.Location = new System.Drawing.Point(50, 3);
            this.btnMyMenuDown.Name = "btnMyMenuDown";
            this.btnMyMenuDown.Size = new System.Drawing.Size(20, 20);
            this.btnMyMenuDown.TabIndex = 2;
            this.btnMyMenuDown.Text = "下移";
            this.btnMyMenuDown.Click += new System.EventHandler(this.btnMyMenuDown_Click);
            // 
            // btnUpMyMenu
            // 
            this.btnUpMyMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpMyMenu.Image = global::SAF.Client.Properties.Resources.Action_Up_16x16;
            this.btnUpMyMenu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnUpMyMenu.Location = new System.Drawing.Point(28, 3);
            this.btnUpMyMenu.Name = "btnUpMyMenu";
            this.btnUpMyMenu.Size = new System.Drawing.Size(20, 20);
            this.btnUpMyMenu.TabIndex = 1;
            this.btnUpMyMenu.Text = "上移";
            this.btnUpMyMenu.Click += new System.EventHandler(this.btnUpMyMenu_Click);
            // 
            // sysMyWorkspace
            // 
            this.sysMyWorkspace.Caption = "我的工作台";
            this.sysMyWorkspace.ControlContainer = this.navBarGroupControlContainer2;
            this.sysMyWorkspace.GroupClientHeight = 80;
            this.sysMyWorkspace.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.sysMyWorkspace.Name = "sysMyWorkspace";
            this.sysMyWorkspace.SmallImage = global::SAF.Client.Properties.Resources.Icon_Workplace_16x16;
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "Icon_Form_16x16.png");
            this.imageCollectionTreeList.Images.SetKeyName(3, "Form_Out_16x16.png");
            // 
            // splMenu
            // 
            this.splMenu.Location = new System.Drawing.Point(181, 147);
            this.splMenu.Name = "splMenu";
            this.splMenu.Size = new System.Drawing.Size(5, 289);
            this.splMenu.TabIndex = 5;
            this.splMenu.TabStop = false;
            // 
            // documentManager
            // 
            this.documentManager.MdiParent = this;
            this.documentManager.MenuManager = this.ribbonMain;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});
            // 
            // tabbedView
            // 
            this.tabbedView.DocumentGroupProperties.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.tabbedView.DocumentGroupProperties.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.tabbedView.DocumentProperties.AllowDock = false;
            this.tabbedView.DocumentProperties.AllowDockFill = false;
            this.tabbedView.DocumentProperties.AllowFloat = false;
            this.tabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.tabbedView.DocumentProperties.AllowPin = true;
            this.tabbedView.DocumentProperties.UseFormIconAsDocumentImage = true;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 467);
            this.Controls.Add(this.splMenu);
            this.Controls.Add(this.navMainMenu);
            this.Controls.Add(this.statusBarMain);
            this.Controls.Add(this.ribbonMain);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "Shell";
            this.Ribbon = this.ribbonMain;
            this.StatusBar = this.statusBarMain;
            this.Text = "SAF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Shell_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).EndInit();
            this.navMainMenu.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).EndInit();
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMyMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWorkspace)).EndInit();
            this.pnlWorkspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        protected DevExpress.XtraBars.Ribbon.RibbonPage SystemPage;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar statusBarMain;
        protected DevExpress.XtraBars.BarStaticItem bsiMessage;
        protected DevExpress.XtraBars.BarButtonItem bbiAbout;
        protected DevExpress.XtraBars.BarButtonItem bbiHelp;
        protected DevExpress.XtraBars.BarButtonItem bbiHomepage;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHelp;
        private DevExpress.XtraNavBar.NavBarControl navMainMenu;
        private DevExpress.XtraNavBar.NavBarGroup systemMenuGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraTreeList.TreeList TreeMenu;
        private DevExpress.XtraEditors.PanelControl pnlMenu;
        private DevExpress.XtraEditors.TextEdit txtFind;
        private DevExpress.XtraEditors.SimpleButton btnRefreshMenu;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
        private DevExpress.XtraEditors.SplitterControl splMenu;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraNavBar.NavBarGroup sysMyWorkspace;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private DevExpress.XtraTreeList.TreeList treeMyMenu;
        private DevExpress.XtraEditors.PanelControl pnlWorkspace;
        private DevExpress.XtraEditors.SimpleButton btnMyMenuDelete;
        private DevExpress.XtraEditors.SimpleButton btnMyMenuDown;
        private DevExpress.XtraEditors.SimpleButton btnUpMyMenu;
        private DevExpress.XtraEditors.SimpleButton btnRefreshMyFavorite;
        private DevExpress.XtraBars.BarButtonItem bbiWelcomePage;
        private DevExpress.XtraBars.BarButtonItem bbiNavigation;

    }
}
