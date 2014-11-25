using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
namespace SAF.Framework.Controls.Charts
{
    partial class ChartControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartControl));
            this.dockManager = new DockManager(this.components);
            this.hideContainerLeft = new AutoHideContainer();
            this.dpToolbox = new DockPanel();
            this.dockPanel1_Container = new ControlContainer();
            this.navToolBox = new NavBarControl();
            this.nbgGraphics = new NavBarGroup();
            this.dpProperty = new DockPanel();
            this.controlContainer1 = new ControlContainer();
            this.cttPropertyGrid1 = new XtraPropertyGrid();
            this.barManager = new BarManager(this.components);
            this.barTools = new Bar();
            this.btnEdit = new BarButtonItem();
            this.bsiSave = new BarButtonItem();
            this.btnSaveAll = new BarButtonItem();
            this.btnRefresh = new BarButtonItem();
            this.bbiOpen = new BarButtonItem();
            this.btnSaveAs = new BarButtonItem();
            this.bbiExportJpg = new BarButtonItem();
            this.bsiBringToFront = new BarButtonItem();
            this.bsiSendToBack = new BarButtonItem();
            this.bsiUndo = new BarButtonItem();
            this.bsiRedo = new BarButtonItem();
            this.bsiZoomIn = new BarButtonItem();
            this.bsiZoomOut = new BarButtonItem();
            this.bsiToolboxWindow = new BarButtonItem();
            this.bsiPropertyWindow = new BarButtonItem();
            this.bsiDescriptionWindow = new BarButtonItem();
            this.bbiDrag = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.documentManager = new DocumentManager(this.components);
            this.imageCollection = new ImageCollection(this.components);
            this.tabbedView = new TabbedView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dpToolbox.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navToolBox)).BeginInit();
            this.dpProperty.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "BarDockControl",
            "StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "Ribbon.RibbonStatusBar",
            "Ribbon.RibbonControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.dpToolbox);
            this.hideContainerLeft.Controls.Add(this.dpProperty);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerLeft.Location = new System.Drawing.Point(808, 31);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(20, 415);
            // 
            // dpToolbox
            // 
            this.dpToolbox.Controls.Add(this.dockPanel1_Container);
            this.dpToolbox.Dock = DockingStyle.Right;
            this.dpToolbox.ID = new System.Guid("efb5af52-3b69-4924-a309-4b2ddaeea53d");
            this.dpToolbox.Location = new System.Drawing.Point(423, 36);
            this.dpToolbox.Name = "dpToolbox";
            this.dpToolbox.Options.AllowDockBottom = false;
            this.dpToolbox.Options.AllowDockFill = false;
            this.dpToolbox.Options.AllowDockRight = false;
            this.dpToolbox.Options.AllowDockTop = false;
            this.dpToolbox.Options.AllowFloating = false;
            this.dpToolbox.Options.FloatOnDblClick = false;
            this.dpToolbox.OriginalSize = new System.Drawing.Size(177, 200);
            this.dpToolbox.SavedDock = DockingStyle.Right;
            this.dpToolbox.SavedIndex = 0;
            this.dpToolbox.Size = new System.Drawing.Size(206, 409);
            this.dpToolbox.Text = "工具箱";
            this.dpToolbox.Visibility = DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navToolBox);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 27);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(197, 378);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navToolBox
            // 
            this.navToolBox.ActiveGroup = this.nbgGraphics;
            this.navToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navToolBox.Groups.AddRange(new NavBarGroup[] {
            this.nbgGraphics});
            this.navToolBox.Location = new System.Drawing.Point(0, 0);
            this.navToolBox.Name = "navToolBox";
            this.navToolBox.OptionsNavPane.ExpandButtonMode = ExpandButtonMode.Inverted;
            this.navToolBox.OptionsNavPane.ExpandedWidth = 197;
            this.navToolBox.OptionsNavPane.ShowExpandButton = false;
            this.navToolBox.OptionsNavPane.ShowOverflowButton = false;
            this.navToolBox.OptionsNavPane.ShowOverflowPanel = false;
            this.navToolBox.PaintStyleKind = NavBarViewKind.NavigationPane;
            this.navToolBox.Size = new System.Drawing.Size(197, 378);
            this.navToolBox.StoreDefaultPaintStyleName = true;
            this.navToolBox.TabIndex = 0;
            this.navToolBox.Text = "navToolBox";
            // 
            // nbgGraphics
            // 
            this.nbgGraphics.Caption = "图例";
            this.nbgGraphics.Expanded = true;
            this.nbgGraphics.Name = "nbgGraphics";
            // 
            // dpProperty
            // 
            this.dpProperty.Controls.Add(this.controlContainer1);
            this.dpProperty.Dock = DockingStyle.Right;
            this.dpProperty.ID = new System.Guid("1a3b6e4a-ff18-4f00-88cc-f5d96c86ffd4");
            this.dpProperty.Location = new System.Drawing.Point(413, 36);
            this.dpProperty.Name = "dpProperty";
            this.dpProperty.Options.AllowDockBottom = false;
            this.dpProperty.Options.AllowDockTop = false;
            this.dpProperty.Options.AllowFloating = false;
            this.dpProperty.Options.FloatOnDblClick = false;
            this.dpProperty.OriginalSize = new System.Drawing.Size(186, 253);
            this.dpProperty.SavedDock = DockingStyle.Right;
            this.dpProperty.SavedIndex = 0;
            this.dpProperty.Size = new System.Drawing.Size(217, 409);
            this.dpProperty.Text = "属性";
            this.dpProperty.Visibility = DockVisibility.AutoHide;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.cttPropertyGrid1);
            this.controlContainer1.Location = new System.Drawing.Point(5, 27);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(208, 378);
            this.controlContainer1.TabIndex = 0;
            // 
            // cttPropertyGrid1
            // 
            this.cttPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cttPropertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.cttPropertyGrid1.Name = "cttPropertyGrid1";
            this.cttPropertyGrid1.Size = new System.Drawing.Size(208, 378);
            this.cttPropertyGrid1.TabIndex = 0;
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new Bar[] {
            this.barTools});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new BarItem[] {
            this.bsiSave,
            this.bsiBringToFront,
            this.bsiSendToBack,
            this.bsiUndo,
            this.bsiRedo,
            this.bsiPropertyWindow,
            this.bsiToolboxWindow,
            this.bsiDescriptionWindow,
            this.bsiZoomIn,
            this.bsiZoomOut,
            this.bbiExportJpg,
            this.bbiOpen,
            this.bbiDrag,
            this.btnRefresh,
            this.btnSaveAs,
            this.btnSaveAll,
            this.btnEdit});
            this.barManager.MaxItemId = 19;
            // 
            // barTools
            // 
            this.barTools.BarName = "标准";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new LinkPersistInfo[] {
            new LinkPersistInfo(this.btnEdit),
            new LinkPersistInfo(this.bsiSave),
            new LinkPersistInfo(this.btnSaveAll),
            new LinkPersistInfo(this.btnRefresh, true),
            new LinkPersistInfo(this.bbiOpen, true),
            new LinkPersistInfo(this.btnSaveAs),
            new LinkPersistInfo(this.bbiExportJpg),
            new LinkPersistInfo(this.bsiBringToFront, true),
            new LinkPersistInfo(this.bsiSendToBack),
            new LinkPersistInfo(this.bsiUndo, true),
            new LinkPersistInfo(this.bsiRedo),
            new LinkPersistInfo(this.bsiZoomIn, true),
            new LinkPersistInfo(this.bsiZoomOut),
            new LinkPersistInfo(BarLinkUserDefines.Caption, this.bsiToolboxWindow, "工具箱", true),
            new LinkPersistInfo(this.bsiPropertyWindow),
            new LinkPersistInfo(this.bbiDrag, true)});
            this.barTools.Text = "标准";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "编辑";
            this.btnEdit.Glyph = Properties.Resources.Edit_16;
            this.btnEdit.Id = 18;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // bsiSave
            // 
            this.bsiSave.Caption = "保存";
            this.bsiSave.Glyph = Properties.Resources.Action_Save;
            this.bsiSave.Id = 0;
            this.bsiSave.Name = "bsiSave";
            this.bsiSave.ItemClick += new ItemClickEventHandler(this.bsiSave_ItemClick);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Caption = "全部保存";
            this.btnSaveAll.Glyph = Properties.Resources.SaveAll_16x16;
            this.btnSaveAll.Id = 17;
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.ItemClick += new ItemClickEventHandler(this.btnSaveAll_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "重新加载";
            this.btnRefresh.Glyph = Properties.Resources.Action_Reload;
            this.btnRefresh.Id = 15;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // bbiOpen
            // 
            this.bbiOpen.Caption = "打开文件";
            this.bbiOpen.Glyph = Properties.Resources.Action_Open;
            this.bbiOpen.Id = 13;
            this.bbiOpen.Name = "bbiOpen";
            this.bbiOpen.ItemClick += new ItemClickEventHandler(this.bbiOpen_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "另存为...";
            this.btnSaveAs.Glyph =Properties.Resources.Action_SaveAs;
            this.btnSaveAs.Id = 16;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // bbiExportJpg
            // 
            this.bbiExportJpg.Caption = "导出图片";
            this.bbiExportJpg.Glyph =Properties.Resources.Action_Export_ToImage;
            this.bbiExportJpg.Id = 12;
            this.bbiExportJpg.Name = "bbiExportJpg";
            this.bbiExportJpg.ItemClick += new ItemClickEventHandler(this.bbiExportJpg_ItemClick);
            // 
            // bsiBringToFront
            // 
            this.bsiBringToFront.Caption = "置于顶层";
            this.bsiBringToFront.Glyph = Properties.Resources.Action_BringToFront;
            this.bsiBringToFront.Id = 1;
            this.bsiBringToFront.Name = "bsiBringToFront";
            this.bsiBringToFront.ItemClick += new ItemClickEventHandler(this.bsiBringToFront_ItemClick);
            // 
            // bsiSendToBack
            // 
            this.bsiSendToBack.Caption = "置于底层";
            this.bsiSendToBack.Glyph = Properties.Resources.Action_SendToBack;
            this.bsiSendToBack.Id = 2;
            this.bsiSendToBack.Name = "bsiSendToBack";
            this.bsiSendToBack.ItemClick += new ItemClickEventHandler(this.bsiSendToBack_ItemClick);
            // 
            // bsiUndo
            // 
            this.bsiUndo.Caption = "撤消 (Ctrl+Z)";
            this.bsiUndo.Glyph = Properties.Resources.Action_Undo;
            this.bsiUndo.Id = 3;
            this.bsiUndo.Name = "bsiUndo";
            this.bsiUndo.ItemClick += new ItemClickEventHandler(this.bsiUndo_ItemClick);
            // 
            // bsiRedo
            // 
            this.bsiRedo.Caption = "重做 (Ctrl+Y)";
            this.bsiRedo.Glyph = Properties.Resources.Action_Redo;
            this.bsiRedo.Id = 4;
            this.bsiRedo.Name = "bsiRedo";
            this.bsiRedo.ItemClick += new ItemClickEventHandler(this.bsiRedo_ItemClick);
            // 
            // bsiZoomIn
            // 
            this.bsiZoomIn.Caption = "放大";
            this.bsiZoomIn.Glyph =Properties.Resources.ZoomIn_16x16;
            this.bsiZoomIn.Id = 8;
            this.bsiZoomIn.Name = "bsiZoomIn";
            this.bsiZoomIn.ItemClick += new ItemClickEventHandler(this.bsiZoomIn_ItemClick);
            // 
            // bsiZoomOut
            // 
            this.bsiZoomOut.Caption = "缩小";
            this.bsiZoomOut.Glyph =  Properties.Resources.ZoomOut_16x16;
            this.bsiZoomOut.Id = 9;
            this.bsiZoomOut.Name = "bsiZoomOut";
            this.bsiZoomOut.ItemClick += new ItemClickEventHandler(this.bsiZoomOut_ItemClick);
            // 
            // bsiToolboxWindow
            // 
            this.bsiToolboxWindow.Caption = "工具箱";
            this.bsiToolboxWindow.Glyph = Properties.Resources.Toolbox_16x16;
            this.bsiToolboxWindow.Id = 6;
            this.bsiToolboxWindow.Name = "bsiToolboxWindow";
            this.bsiToolboxWindow.ItemClick += new ItemClickEventHandler(this.bsiToolboxWindow_ItemClick);
            // 
            // bsiPropertyWindow
            // 
            this.bsiPropertyWindow.Caption = "属性窗口";
            this.bsiPropertyWindow.Glyph = Properties.Resources.Property_16x16;
            this.bsiPropertyWindow.Id = 5;
            this.bsiPropertyWindow.Name = "bsiPropertyWindow";
            this.bsiPropertyWindow.ItemClick += new ItemClickEventHandler(this.bsiPropertyWindow_ItemClick);
            // 
            // bbiDrag
            // 
            this.bbiDrag.Caption = "拖动";
            this.bbiDrag.Id = 14;
            this.bbiDrag.Name = "bbiDrag";
            this.bbiDrag.ItemClick += new ItemClickEventHandler(this.bbiDrag_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(828, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 446);
            this.barDockControlBottom.Size = new System.Drawing.Size(828, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 415);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(828, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 415);
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.Images = this.imageCollection;
            this.documentManager.MenuManager = this.barManager;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new BaseView[] {
            this.tabbedView});
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(Properties.Resources.None, "None", typeof(Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "None");
            this.imageCollection.InsertImage(Properties.Resources.UserCase, "UserCase", typeof(Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "UserCase");
            this.imageCollection.InsertImage(Properties.Resources.State, "State", typeof(Properties.Resources), 2);
            this.imageCollection.Images.SetKeyName(2, "State");
            this.imageCollection.InsertImage(Properties.Resources.Entity, "Entity", typeof(Properties.Resources), 3);
            this.imageCollection.Images.SetKeyName(3, "Entity");
            // 
            // tabbedView
            // 
            this.tabbedView.DocumentGroupProperties.ClosePageButtonShowMode = ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.tabbedView.DocumentGroupProperties.HeaderLocation =TabHeaderLocation.Bottom;
            this.tabbedView.DocumentProperties.AllowDock = false;
            this.tabbedView.DocumentProperties.AllowDockFill = false;
            this.tabbedView.DocumentProperties.AllowFloat = false;
            this.tabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;
            // 
            // ChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ChartControl";
            this.Size = new System.Drawing.Size(828, 446);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dpToolbox.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navToolBox)).EndInit();
            this.dpProperty.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private  DockManager dockManager;
        private  DockPanel dpToolbox;
        private  ControlContainer dockPanel1_Container;
        private  NavBarControl navToolBox;
        private  DockPanel dpProperty;
        private  ControlContainer controlContainer1;
        private  BarDockControl barDockControlLeft;
        private  BarDockControl barDockControlRight;
        private  BarDockControl barDockControlBottom;
        private  BarDockControl barDockControlTop;
        private  BarManager barManager;
        private  Bar barTools;
        private  BarButtonItem bsiSave;
        private  BarButtonItem bsiBringToFront;
        private  BarButtonItem bsiSendToBack;
        private  BarButtonItem bsiUndo;
        private  BarButtonItem bsiRedo;
        private  BarButtonItem bsiPropertyWindow;
        private  BarButtonItem bsiToolboxWindow;
        private  BarButtonItem bsiDescriptionWindow;
        private XtraPropertyGrid cttPropertyGrid1;
        private  NavBarGroup nbgGraphics;
        private  BarButtonItem bsiZoomIn;
        private  BarButtonItem bsiZoomOut;
        private  BarButtonItem bbiExportJpg;
        private  AutoHideContainer hideContainerLeft;
        private  BarButtonItem bbiOpen;
        private BarButtonItem bbiDrag;
        private DocumentManager documentManager;
        private TabbedView tabbedView;
        private BarButtonItem btnRefresh;
        private BarButtonItem btnSaveAs;
        private BarButtonItem btnSaveAll;
        private BarButtonItem btnEdit;
        private ImageCollection imageCollection;
    }
}
