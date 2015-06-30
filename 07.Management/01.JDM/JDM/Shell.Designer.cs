namespace JDM
{
    partial class Shell
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.pageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiHomepage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.statusMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.navMainMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupSystemMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.TreeMenu = new DevExpress.XtraTreeList.TreeList();
            this.splitterMain = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).BeginInit();
            this.navMainMenu.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 1;
            this.ribbonMain.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageSystem});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(729, 147);
            this.ribbonMain.StatusBar = this.statusMain;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // pageSystem
            // 
            this.pageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupHelp});
            this.pageSystem.Name = "pageSystem";
            this.pageSystem.Text = "系统";
            // 
            // groupHelp
            // 
            this.groupHelp.AllowMinimize = false;
            this.groupHelp.AllowTextClipping = false;
            this.groupHelp.ItemLinks.Add(this.bbiHomepage);
            this.groupHelp.ItemLinks.Add(this.bbiAbout);
            this.groupHelp.ItemLinks.Add(this.bbiHelp);
            this.groupHelp.MergeOrder = 100000;
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "帮助";
            // 
            // bbiHomepage
            // 
            this.bbiHomepage.Caption = "主页";
            this.bbiHomepage.Description = "公司主页";
            this.bbiHomepage.Id = 5;
            this.bbiHomepage.LargeGlyph = global::JDM.Properties.Resources.Home_32x32;
            this.bbiHomepage.Name = "bbiHomepage";
            // 
            // bbiAbout
            // 
            this.bbiAbout.Caption = "关于";
            this.bbiAbout.Description = "关于系统";
            this.bbiAbout.Id = 3;
            this.bbiAbout.LargeGlyph = global::JDM.Properties.Resources.Action_About_32x32;
            this.bbiAbout.Name = "bbiAbout";
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "帮助";
            this.bbiHelp.Id = 4;
            this.bbiHelp.LargeGlyph = global::JDM.Properties.Resources.Action_Help_32x32;
            this.bbiHelp.Name = "bbiHelp";
            // 
            // statusMain
            // 
            this.statusMain.Location = new System.Drawing.Point(0, 457);
            this.statusMain.Name = "statusMain";
            this.statusMain.Ribbon = this.ribbonMain;
            this.statusMain.Size = new System.Drawing.Size(729, 31);
            // 
            // documentManager
            // 
            this.documentManager.MdiParent = this;
            this.documentManager.MenuManager = this.ribbonMain;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});
            // 
            // navMainMenu
            // 
            this.navMainMenu.ActiveGroup = this.navGroupSystemMenu;
            this.navMainMenu.Controls.Add(this.navBarGroupControlContainer1);
            this.navMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.navMainMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGroupSystemMenu});
            this.navMainMenu.Location = new System.Drawing.Point(0, 147);
            this.navMainMenu.Name = "navMainMenu";
            this.navMainMenu.NavigationPaneMaxVisibleGroups = 0;
            this.navMainMenu.OptionsNavPane.ExpandedWidth = 193;
            this.navMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navMainMenu.Size = new System.Drawing.Size(193, 310);
            this.navMainMenu.TabIndex = 3;
            this.navMainMenu.Text = "navBarControl";
            // 
            // navGroupSystemMenu
            // 
            this.navGroupSystemMenu.Caption = "系统菜单";
            this.navGroupSystemMenu.ControlContainer = this.navBarGroupControlContainer1;
            this.navGroupSystemMenu.Expanded = true;
            this.navGroupSystemMenu.GroupClientHeight = 80;
            this.navGroupSystemMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navGroupSystemMenu.Name = "navGroupSystemMenu";
            this.navGroupSystemMenu.SmallImage = global::JDM.Properties.Resources.Icon_Tree_16x16;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.TreeMenu);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(193, 235);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeMenu.Location = new System.Drawing.Point(1, 0);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.OptionsSelection.InvertSelection = true;
            this.TreeMenu.OptionsView.ShowColumns = false;
            this.TreeMenu.OptionsView.ShowHorzLines = false;
            this.TreeMenu.OptionsView.ShowIndicator = false;
            this.TreeMenu.OptionsView.ShowVertLines = false;
            this.TreeMenu.Size = new System.Drawing.Size(192, 235);
            this.TreeMenu.TabIndex = 0;
            // 
            // splitterMain
            // 
            this.splitterMain.Location = new System.Drawing.Point(193, 147);
            this.splitterMain.Name = "splitterMain";
            this.splitterMain.Size = new System.Drawing.Size(5, 310);
            this.splitterMain.TabIndex = 4;
            this.splitterMain.TabStop = false;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 488);
            this.Controls.Add(this.splitterMain);
            this.Controls.Add(this.navMainMenu);
            this.Controls.Add(this.statusMain);
            this.Controls.Add(this.ribbonMain);
            this.IsMdiContainer = true;
            this.Name = "Shell";
            this.Ribbon = this.ribbonMain;
            this.StatusBar = this.statusMain;
            this.Text = "JDM";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).EndInit();
            this.navMainMenu.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHelp;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar statusMain;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraNavBar.NavBarControl navMainMenu;
        private DevExpress.XtraNavBar.NavBarGroup navGroupSystemMenu;
        private DevExpress.XtraEditors.SplitterControl splitterMain;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraTreeList.TreeList TreeMenu;
        protected DevExpress.XtraBars.BarButtonItem bbiAbout;
        protected DevExpress.XtraBars.BarButtonItem bbiHelp;
        protected DevExpress.XtraBars.BarButtonItem bbiHomepage;
    }
}

