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
            this.pageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupServiceConfig = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupServiceManage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdService = new DevExpress.XtraGrid.GridControl();
            this.bsService = new System.Windows.Forms.BindingSource(this.components);
            this.grvService = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvService)).BeginInit();
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
            this.bbiEditService});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 6;
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
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "帮助";
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
            this.splitContainerControl1.Panel1.Controls.Add(this.grdService);
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
            // grdService
            // 
            this.grdService.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdService.DataSource = this.bsService;
            this.grdService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdService.Location = new System.Drawing.Point(2, 2);
            this.grdService.MainView = this.grvService;
            this.grdService.Name = "grdService";
            this.grdService.Size = new System.Drawing.Size(217, 284);
            this.grdService.TabIndex = 0;
            this.grdService.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvService});
            // 
            // grvService
            // 
            this.grvService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServiceName});
            this.grvService.GridControl = this.grdService;
            this.grvService.Name = "grvService";
            this.grvService.OptionsBehavior.Editable = false;
            this.grvService.OptionsCustomization.AllowColumnMoving = false;
            this.grvService.OptionsCustomization.AllowFilter = false;
            this.grvService.OptionsCustomization.AllowGroup = false;
            this.grvService.OptionsCustomization.AllowQuickHideColumns = false;
            this.grvService.OptionsCustomization.AllowSort = false;
            this.grvService.OptionsDetail.EnableMasterViewMode = false;
            this.grvService.OptionsView.ColumnAutoWidth = false;
            this.grvService.OptionsView.ShowGroupPanel = false;
            this.grvService.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvService_FocusedRowChanged);
            // 
            // colServiceName
            // 
            this.colServiceName.Caption = "服务名称";
            this.colServiceName.FieldName = "ServiceName";
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.Visible = true;
            this.colServiceName.VisibleIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvService)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdService;
        private DevExpress.XtraGrid.Views.Grid.GridView grvService;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupServiceConfig;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHelp;
        private DevExpress.XtraBars.BarStaticItem lblMessage;
        private DevExpress.XtraBars.BarButtonItem bbiAddNewService;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteService;
        private System.Windows.Forms.BindingSource bsService;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
        private DataServiceConfigControl dataServiceConfigControl;
        private DevExpress.XtraBars.BarButtonItem bbiEditService;
        private DevExpress.XtraTab.XtraTabPage pageLog;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup groupServiceManage;

    }
}

