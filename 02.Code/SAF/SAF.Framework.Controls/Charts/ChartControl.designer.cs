﻿using DevExpress.Utils;
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
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dpToolbox = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.navToolBox = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgGraphics = new DevExpress.XtraNavBar.NavBarGroup();
            this.dpProperty = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.cttPropertyGrid1 = new SAF.Framework.Controls.Charts.XtraPropertyGrid();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barTools = new DevExpress.XtraBars.Bar();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportJpg = new DevExpress.XtraBars.BarButtonItem();
            this.bsiBringToFront = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSendToBack = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUndo = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRedo = new DevExpress.XtraBars.BarButtonItem();
            this.bsiZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bsiZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.bsiToolboxWindow = new DevExpress.XtraBars.BarButtonItem();
            this.bsiPropertyWindow = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bsiDescriptionWindow = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dpToolbox.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navToolBox)).BeginInit();
            this.dpProperty.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager.Form = this;
            this.dockManager.MenuManager = this.barManager;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "BarDockControl",
            "StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "Ribbon.RibbonStatusBar",
            "Ribbon.RibbonControl"});
            // 
            // dpToolbox
            // 
            this.dpToolbox.Controls.Add(this.dockPanel1_Container);
            this.dpToolbox.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpToolbox.ID = new System.Guid("efb5af52-3b69-4924-a309-4b2ddaeea53d");
            this.dpToolbox.Location = new System.Drawing.Point(0, 0);
            this.dpToolbox.Name = "dpToolbox";
            this.dpToolbox.Options.AllowDockBottom = false;
            this.dpToolbox.Options.AllowDockFill = false;
            this.dpToolbox.Options.AllowDockRight = false;
            this.dpToolbox.Options.AllowDockTop = false;
            this.dpToolbox.Options.AllowFloating = false;
            this.dpToolbox.Options.FloatOnDblClick = false;
            this.dpToolbox.OriginalSize = new System.Drawing.Size(177, 200);
            this.dpToolbox.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpToolbox.SavedIndex = 0;
            this.dpToolbox.Size = new System.Drawing.Size(177, 478);
            this.dpToolbox.Text = "工具箱";
            this.dpToolbox.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.navToolBox);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(169, 451);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // navToolBox
            // 
            this.navToolBox.ActiveGroup = this.nbgGraphics;
            this.navToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navToolBox.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgGraphics});
            this.navToolBox.Location = new System.Drawing.Point(0, 0);
            this.navToolBox.Name = "navToolBox";
            this.navToolBox.OptionsNavPane.ExpandButtonMode = DevExpress.Utils.Controls.ExpandButtonMode.Inverted;
            this.navToolBox.OptionsNavPane.ExpandedWidth = 169;
            this.navToolBox.OptionsNavPane.ShowExpandButton = false;
            this.navToolBox.OptionsNavPane.ShowOverflowButton = false;
            this.navToolBox.OptionsNavPane.ShowOverflowPanel = false;
            this.navToolBox.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navToolBox.Size = new System.Drawing.Size(169, 451);
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
            this.dpProperty.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpProperty.ID = new System.Guid("1a3b6e4a-ff18-4f00-88cc-f5d96c86ffd4");
            this.dpProperty.Location = new System.Drawing.Point(0, 0);
            this.dpProperty.Name = "dpProperty";
            this.dpProperty.Options.AllowDockBottom = false;
            this.dpProperty.Options.AllowDockTop = false;
            this.dpProperty.Options.AllowFloating = false;
            this.dpProperty.Options.FloatOnDblClick = false;
            this.dpProperty.OriginalSize = new System.Drawing.Size(186, 253);
            this.dpProperty.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dpProperty.SavedIndex = 0;
            this.dpProperty.Size = new System.Drawing.Size(186, 478);
            this.dpProperty.Text = "属性";
            this.dpProperty.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.cttPropertyGrid1);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(178, 451);
            this.controlContainer1.TabIndex = 0;
            // 
            // cttPropertyGrid1
            // 
            this.cttPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cttPropertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.cttPropertyGrid1.Name = "cttPropertyGrid1";
            this.cttPropertyGrid1.Size = new System.Drawing.Size(178, 451);
            this.cttPropertyGrid1.TabIndex = 0;
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTools});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager;
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
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
            this.btnRefresh,
            this.btnSaveAs,
            this.btnEdit});
            this.barManager.MaxItemId = 21;
            // 
            // barTools
            // 
            this.barTools.BarName = "标准";
            this.barTools.DockCol = 0;
            this.barTools.DockRow = 0;
            this.barTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiOpen, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportJpg),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiBringToFront, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSendToBack),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiUndo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiRedo),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.bsiToolboxWindow, "工具箱", true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiPropertyWindow)});
            this.barTools.Text = "标准";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "编辑";
            this.btnEdit.Glyph = global::SAF.Framework.Controls.Properties.Resources.Edit_16;
            this.btnEdit.Id = 18;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // bsiSave
            // 
            this.bsiSave.Caption = "保存";
            this.bsiSave.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Save;
            this.bsiSave.Id = 0;
            this.bsiSave.Name = "bsiSave";
            this.bsiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiSave_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "重新加载";
            this.btnRefresh.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Reload;
            this.btnRefresh.Id = 15;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // bbiOpen
            // 
            this.bbiOpen.Caption = "打开文件";
            this.bbiOpen.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Open;
            this.bbiOpen.Id = 13;
            this.bbiOpen.Name = "bbiOpen";
            this.bbiOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiOpen_ItemClick);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Caption = "另存为...";
            this.btnSaveAs.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_SaveAs;
            this.btnSaveAs.Id = 16;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAs_ItemClick);
            // 
            // bbiExportJpg
            // 
            this.bbiExportJpg.Caption = "导出图片";
            this.bbiExportJpg.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Export_ToImage;
            this.bbiExportJpg.Id = 12;
            this.bbiExportJpg.Name = "bbiExportJpg";
            this.bbiExportJpg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportJpg_ItemClick);
            // 
            // bsiBringToFront
            // 
            this.bsiBringToFront.Caption = "置于顶层";
            this.bsiBringToFront.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_BringToFront;
            this.bsiBringToFront.Id = 1;
            this.bsiBringToFront.Name = "bsiBringToFront";
            this.bsiBringToFront.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiBringToFront_ItemClick);
            // 
            // bsiSendToBack
            // 
            this.bsiSendToBack.Caption = "置于底层";
            this.bsiSendToBack.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_SendToBack;
            this.bsiSendToBack.Id = 2;
            this.bsiSendToBack.Name = "bsiSendToBack";
            this.bsiSendToBack.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiSendToBack_ItemClick);
            // 
            // bsiUndo
            // 
            this.bsiUndo.Caption = "撤消 (Ctrl+Z)";
            this.bsiUndo.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Undo;
            this.bsiUndo.Id = 3;
            this.bsiUndo.Name = "bsiUndo";
            this.bsiUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiUndo_ItemClick);
            // 
            // bsiRedo
            // 
            this.bsiRedo.Caption = "重做 (Ctrl+Y)";
            this.bsiRedo.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Redo;
            this.bsiRedo.Id = 4;
            this.bsiRedo.Name = "bsiRedo";
            this.bsiRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiRedo_ItemClick);
            // 
            // bsiZoomIn
            // 
            this.bsiZoomIn.Caption = "放大";
            this.bsiZoomIn.Glyph = global::SAF.Framework.Controls.Properties.Resources.ZoomIn_16x16;
            this.bsiZoomIn.Id = 8;
            this.bsiZoomIn.Name = "bsiZoomIn";
            this.bsiZoomIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiZoomIn_ItemClick);
            // 
            // bsiZoomOut
            // 
            this.bsiZoomOut.Caption = "缩小";
            this.bsiZoomOut.Glyph = global::SAF.Framework.Controls.Properties.Resources.ZoomOut_16x16;
            this.bsiZoomOut.Id = 9;
            this.bsiZoomOut.Name = "bsiZoomOut";
            this.bsiZoomOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiZoomOut_ItemClick);
            // 
            // bsiToolboxWindow
            // 
            this.bsiToolboxWindow.Caption = "工具箱";
            this.bsiToolboxWindow.Glyph = global::SAF.Framework.Controls.Properties.Resources.Toolbox_16x16;
            this.bsiToolboxWindow.Id = 6;
            this.bsiToolboxWindow.Name = "bsiToolboxWindow";
            this.bsiToolboxWindow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiToolboxWindow_ItemClick);
            // 
            // bsiPropertyWindow
            // 
            this.bsiPropertyWindow.Caption = "属性窗口";
            this.bsiPropertyWindow.Glyph = global::SAF.Framework.Controls.Properties.Resources.Property_16x16;
            this.bsiPropertyWindow.Id = 5;
            this.bsiPropertyWindow.Name = "bsiPropertyWindow";
            this.bsiPropertyWindow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiPropertyWindow_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 478);
            this.barDockControlBottom.Size = new System.Drawing.Size(828, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 447);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(828, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 447);
            // 
            // bsiDescriptionWindow
            // 
            this.bsiDescriptionWindow.Id = 19;
            this.bsiDescriptionWindow.Name = "bsiDescriptionWindow";
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::SAF.Framework.Controls.Properties.Resources.None, "None", typeof(global::SAF.Framework.Controls.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "None");
            this.imageCollection.InsertImage(global::SAF.Framework.Controls.Properties.Resources.UserCase, "UserCase", typeof(global::SAF.Framework.Controls.Properties.Resources), 1);
            this.imageCollection.Images.SetKeyName(1, "UserCase");
            this.imageCollection.InsertImage(global::SAF.Framework.Controls.Properties.Resources.State, "State", typeof(global::SAF.Framework.Controls.Properties.Resources), 2);
            this.imageCollection.Images.SetKeyName(2, "State");
            this.imageCollection.InsertImage(global::SAF.Framework.Controls.Properties.Resources.Entity, "Entity", typeof(global::SAF.Framework.Controls.Properties.Resources), 3);
            this.imageCollection.Images.SetKeyName(3, "Entity");
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dpToolbox);
            this.hideContainerRight.Controls.Add(this.dpProperty);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(808, 31);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(20, 447);
            // 
            // ChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ChartControl";
            this.Size = new System.Drawing.Size(828, 478);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dpToolbox.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navToolBox)).EndInit();
            this.dpProperty.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
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
        private BarButtonItem bbiExportJpg;
        private  BarButtonItem bbiOpen;
        private BarButtonItem btnRefresh;
        private BarButtonItem btnSaveAs;
        private BarButtonItem btnEdit;
        private ImageCollection imageCollection;
        private AutoHideContainer hideContainerRight;
    }
}
