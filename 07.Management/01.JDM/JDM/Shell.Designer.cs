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
            this.statusMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.navMainMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupSystemMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.splitterMain = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).BeginInit();
            this.navMainMenu.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 1;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageSystem});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.Size = new System.Drawing.Size(729, 147);
            this.ribbonMain.StatusBar = this.statusMain;
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
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "帮助";
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
            this.documentManager.ContainerControl = this;
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
            this.navMainMenu.OptionsNavPane.ExpandedWidth = 140;
            this.navMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navMainMenu.Size = new System.Drawing.Size(140, 310);
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
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.treeList1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(140, 206);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.InvertSelection = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(140, 206);
            this.treeList1.TabIndex = 0;
            // 
            // splitterMain
            // 
            this.splitterMain.Location = new System.Drawing.Point(140, 147);
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
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
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
        private DevExpress.XtraTreeList.TreeList treeList1;
    }
}

