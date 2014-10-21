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
            this.MdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection();
            this.splMenu = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).BeginInit();
            this.navMainMenu.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).BeginInit();
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
            this.bbiHomepage});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 6;
            this.ribbonMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.SystemPage});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(673, 147);
            this.ribbonMain.StatusBar = this.statusBarMain;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // bsiMessage
            // 
            this.bsiMessage.Caption = "准备就绪...";
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
            this.groupHelp.ItemLinks.Add(this.bbiHomepage);
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
            this.statusBarMain.Location = new System.Drawing.Point(0, 385);
            this.statusBarMain.Name = "statusBarMain";
            this.statusBarMain.Ribbon = this.ribbonMain;
            this.statusBarMain.Size = new System.Drawing.Size(673, 31);
            // 
            // navMainMenu
            // 
            this.navMainMenu.ActiveGroup = this.systemMenuGroup;
            this.navMainMenu.Controls.Add(this.navBarGroupControlContainer1);
            this.navMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMainMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.systemMenuGroup});
            this.navMainMenu.Location = new System.Drawing.Point(0, 147);
            this.navMainMenu.Name = "navMainMenu";
            this.navMainMenu.NavigationPaneMaxVisibleGroups = 0;
            this.navMainMenu.OptionsNavPane.ExpandedWidth = 181;
            this.navMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navMainMenu.Size = new System.Drawing.Size(181, 238);
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
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(181, 163);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeMenu.Location = new System.Drawing.Point(0, 27);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.OptionsBehavior.Editable = false;
            this.TreeMenu.OptionsSelection.InvertSelection = true;
            this.TreeMenu.OptionsView.ShowColumns = false;
            this.TreeMenu.OptionsView.ShowHorzLines = false;
            this.TreeMenu.OptionsView.ShowIndicator = false;
            this.TreeMenu.OptionsView.ShowVertLines = false;
            this.TreeMenu.Size = new System.Drawing.Size(181, 136);
            this.TreeMenu.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMenu.Controls.Add(this.txtFind);
            this.pnlMenu.Controls.Add(this.btnRefreshMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(181, 27);
            this.pnlMenu.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(3, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Properties.NullText = "菜单筛选";
            this.txtFind.Size = new System.Drawing.Size(155, 20);
            this.txtFind.TabIndex = 1;
            // 
            // btnRefreshMenu
            // 
            this.btnRefreshMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMenu.Image = global::SAF.Client.Properties.Resources.Action_Refresh_16x16;
            this.btnRefreshMenu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefreshMenu.Location = new System.Drawing.Point(159, 3);
            this.btnRefreshMenu.Name = "btnRefreshMenu";
            this.btnRefreshMenu.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshMenu.TabIndex = 0;
            this.btnRefreshMenu.ToolTip = "刷新菜单";
            // 
            // MdiManager
            // 
            this.MdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.MdiManager.HeaderButtons = ((DevExpress.XtraTab.TabButtons)(((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.MdiManager.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded;
            this.MdiManager.MdiParent = this;
            this.MdiManager.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.True;
            this.MdiManager.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "Icon_Form_16x16.png");
            // 
            // splMenu
            // 
            this.splMenu.Location = new System.Drawing.Point(181, 147);
            this.splMenu.Name = "splMenu";
            this.splMenu.Size = new System.Drawing.Size(5, 238);
            this.splMenu.TabIndex = 5;
            this.splMenu.TabStop = false;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 416);
            this.Controls.Add(this.splMenu);
            this.Controls.Add(this.navMainMenu);
            this.Controls.Add(this.statusBarMain);
            this.Controls.Add(this.ribbonMain);
            this.IsMdiContainer = true;
            this.Name = "Shell";
            this.Ribbon = this.ribbonMain;
            this.StatusBar = this.statusBarMain;
            this.Text = "SAF";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).EndInit();
            this.navMainMenu.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
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
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager MdiManager;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
        private DevExpress.XtraEditors.SplitterControl splMenu;

    }
}
