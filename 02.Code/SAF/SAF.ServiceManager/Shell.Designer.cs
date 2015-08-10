namespace SAF.ServiceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageService = new DevExpress.XtraTab.XtraTabPage();
            this.dataServiceConfigControl = new SAF.ServiceManager.DataServiceConfigControl();
            this.pageLog = new DevExpress.XtraTab.XtraTabPage();
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.lblRight = new DevExpress.XtraBars.BarStaticItem();
            this.bbiStartService = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStopService = new DevExpress.XtraBars.BarButtonItem();
            this.bsiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.lblMessage = new DevExpress.XtraBars.BarStaticItem();
            this.bbiAddNewService = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteService = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditService = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExitApplication = new DevExpress.XtraBars.BarButtonItem();
            this.pageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupServiceConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupServiceManage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tcServiceList = new DevExpress.XtraTab.XtraTabControl();
            this.pageServiceList = new DevExpress.XtraTab.XtraTabPage();
            this.treeService = new DevExpress.XtraTreeList.TreeList();
            this.colServiceName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsService = new System.Windows.Forms.BindingSource(this.components);
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcServiceList)).BeginInit();
            this.tcServiceList.SuspendLayout();
            this.pageServiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.pageService;
            this.tcMain.Size = new System.Drawing.Size(543, 284);
            this.tcMain.TabIndex = 0;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageService,
            this.pageLog});
            // 
            // pageService
            // 
            this.pageService.Controls.Add(this.dataServiceConfigControl);
            this.pageService.Name = "pageService";
            this.pageService.Padding = new System.Windows.Forms.Padding(1);
            this.pageService.Size = new System.Drawing.Size(537, 255);
            this.pageService.Text = "数据服务配置";
            // 
            // dataServiceConfigControl
            // 
            this.dataServiceConfigControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataServiceConfigControl.IsPreviewModel = false;
            this.dataServiceConfigControl.Location = new System.Drawing.Point(1, 1);
            this.dataServiceConfigControl.Name = "dataServiceConfigControl";
            this.dataServiceConfigControl.Size = new System.Drawing.Size(535, 253);
            this.dataServiceConfigControl.TabIndex = 0;
            // 
            // pageLog
            // 
            this.pageLog.Name = "pageLog";
            this.pageLog.Size = new System.Drawing.Size(537, 255);
            this.pageLog.Text = "日志";
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.lblRight,
            this.bbiStartService,
            this.bbiStopService,
            this.bsiHelp,
            this.lblMessage,
            this.bbiAddNewService,
            this.bbiDeleteService,
            this.bbiEditService,
            this.bbiExitApplication});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 7;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pageSystem});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.Size = new System.Drawing.Size(769, 147);
            this.ribbonMain.StatusBar = this.ribbonStatusBar1;
            this.ribbonMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // lblRight
            // 
            this.lblRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.lblRight.Id = 5;
            this.lblRight.Name = "lblRight";
            this.lblRight.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiStartService
            // 
            this.bbiStartService.Caption = "启动服务";
            this.bbiStartService.Id = 6;
            this.bbiStartService.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_Run_32x32;
            this.bbiStartService.Name = "bbiStartService";
            this.bbiStartService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStartService_ItemClick);
            // 
            // bbiStopService
            // 
            this.bbiStopService.Caption = "停止服务";
            this.bbiStopService.Id = 7;
            this.bbiStopService.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_Stop_32x32;
            this.bbiStopService.Name = "bbiStopService";
            this.bbiStopService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStopService_ItemClick);
            // 
            // bsiHelp
            // 
            this.bsiHelp.Caption = "关于";
            this.bsiHelp.Id = 9;
            this.bsiHelp.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_AboutInfo_32x32;
            this.bsiHelp.Name = "bsiHelp";
            // 
            // lblMessage
            // 
            this.lblMessage.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.lblMessage.Id = 1;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiAddNewService
            // 
            this.bbiAddNewService.Caption = "添加服务";
            this.bbiAddNewService.Id = 2;
            this.bbiAddNewService.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_New_32x32;
            this.bbiAddNewService.Name = "bbiAddNewService";
            this.bbiAddNewService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddNewService_ItemClick);
            // 
            // bbiDeleteService
            // 
            this.bbiDeleteService.Caption = "移除服务";
            this.bbiDeleteService.Id = 3;
            this.bbiDeleteService.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_Delete_32x32;
            this.bbiDeleteService.Name = "bbiDeleteService";
            this.bbiDeleteService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteService_ItemClick);
            // 
            // bbiEditService
            // 
            this.bbiEditService.Caption = "配置服务";
            this.bbiEditService.Id = 5;
            this.bbiEditService.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_Edit_32x32;
            this.bbiEditService.Name = "bbiEditService";
            this.bbiEditService.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditService_ItemClick);
            // 
            // bbiExitApplication
            // 
            this.bbiExitApplication.Caption = "退出";
            this.bbiExitApplication.Id = 6;
            this.bbiExitApplication.LargeGlyph = global::SAF.ServiceManager.Properties.Resources.Action_Exit_32x32;
            this.bbiExitApplication.Name = "bbiExitApplication";
            this.bbiExitApplication.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExitApplication_ItemClick);
            // 
            // pageSystem
            // 
            this.pageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupServiceConfig,
            this.groupServiceManage,
            this.groupHelp});
            this.pageSystem.Name = "pageSystem";
            this.pageSystem.Text = "系统";
            // 
            // groupServiceConfig
            // 
            this.groupServiceConfig.AllowTextClipping = false;
            this.groupServiceConfig.ItemLinks.Add(this.bbiAddNewService);
            this.groupServiceConfig.ItemLinks.Add(this.bbiEditService);
            this.groupServiceConfig.ItemLinks.Add(this.bbiDeleteService);
            this.groupServiceConfig.Name = "groupServiceConfig";
            this.groupServiceConfig.ShowCaptionButton = false;
            this.groupServiceConfig.Text = "服务配置";
            // 
            // groupServiceManage
            // 
            this.groupServiceManage.AllowTextClipping = false;
            this.groupServiceManage.ItemLinks.Add(this.bbiStartService);
            this.groupServiceManage.ItemLinks.Add(this.bbiStopService);
            this.groupServiceManage.Name = "groupServiceManage";
            this.groupServiceManage.ShowCaptionButton = false;
            this.groupServiceManage.Text = "服务管理";
            // 
            // groupHelp
            // 
            this.groupHelp.AllowTextClipping = false;
            this.groupHelp.ItemLinks.Add(this.bsiHelp);
            this.groupHelp.ItemLinks.Add(this.bbiExitApplication);
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "系统";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.lblMessage);
            this.ribbonStatusBar1.ItemLinks.Add(this.lblRight);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 435);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonMain;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(769, 31);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 147);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tcServiceList);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tcMain);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(769, 288);
            this.splitContainerControl1.SplitterPosition = 219;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tcServiceList
            // 
            this.tcServiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcServiceList.Location = new System.Drawing.Point(2, 2);
            this.tcServiceList.Name = "tcServiceList";
            this.tcServiceList.SelectedTabPage = this.pageServiceList;
            this.tcServiceList.Size = new System.Drawing.Size(217, 284);
            this.tcServiceList.TabIndex = 1;
            this.tcServiceList.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageServiceList});
            // 
            // pageServiceList
            // 
            this.pageServiceList.Controls.Add(this.treeService);
            this.pageServiceList.Name = "pageServiceList";
            this.pageServiceList.Padding = new System.Windows.Forms.Padding(2);
            this.pageServiceList.Size = new System.Drawing.Size(211, 255);
            this.pageServiceList.Text = "数据服务列表";
            // 
            // treeService
            // 
            this.treeService.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeService.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colServiceName});
            this.treeService.DataSource = this.bsService;
            this.treeService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeService.Location = new System.Drawing.Point(2, 2);
            this.treeService.Name = "treeService";
            this.treeService.OptionsBehavior.Editable = false;
            this.treeService.OptionsSelection.InvertSelection = true;
            this.treeService.OptionsView.ShowColumns = false;
            this.treeService.OptionsView.ShowHorzLines = false;
            this.treeService.OptionsView.ShowIndicator = false;
            this.treeService.OptionsView.ShowVertLines = false;
            this.treeService.SelectImageList = this.imageCollection;
            this.treeService.Size = new System.Drawing.Size(207, 251);
            this.treeService.TabIndex = 0;
            this.treeService.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeService_FocusedNodeChanged);
            // 
            // colServiceName
            // 
            this.colServiceName.Caption = "服务";
            this.colServiceName.FieldName = "ServiceName";
            this.colServiceName.MinWidth = 33;
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.Visible = true;
            this.colServiceName.VisibleIndex = 0;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::SAF.ServiceManager.Properties.Resources.Action_Run_16x16, "Action_Run_16x16", typeof(global::SAF.ServiceManager.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "Action_Run_16x16");
            this.imageCollection.InsertImage(global::SAF.ServiceManager.Properties.Resources.Action_Stop_16x16, "Action_Stop_16x16", typeof(global::SAF.ServiceManager.Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "Action_Stop_16x16");
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 466);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonMain);
            this.Name = "Shell";
            this.Ribbon = this.ribbonMain;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "SAF 服务管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.Shell_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcServiceList)).EndInit();
            this.tcServiceList.ResumeLayout(false);
            this.pageServiceList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tcMain;
        private DevExpress.XtraTab.XtraTabPage pageService;
        private DevExpress.XtraBars.BarStaticItem lblRight;
        private DevExpress.XtraBars.BarButtonItem bbiStartService;
        private DevExpress.XtraBars.BarButtonItem bbiStopService;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarButtonItem bsiHelp;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupServiceConfig;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHelp;
        private DevExpress.XtraBars.BarStaticItem lblMessage;
        private DevExpress.XtraBars.BarButtonItem bbiAddNewService;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteService;
        private System.Windows.Forms.BindingSource bsService;
        private DataServiceConfigControl dataServiceConfigControl;
        private DevExpress.XtraBars.BarButtonItem bbiEditService;
        private DevExpress.XtraTab.XtraTabPage pageLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupServiceManage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private DevExpress.XtraTreeList.TreeList treeService;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colServiceName;
        private DevExpress.XtraTab.XtraTabControl tcServiceList;
        private DevExpress.XtraTab.XtraTabPage pageServiceList;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.BarButtonItem bbiExitApplication;

    }
}

