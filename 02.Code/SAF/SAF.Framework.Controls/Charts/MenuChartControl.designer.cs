using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;

using DevExpress.XtraNavBar;
using DevExpress.XtraTab;

namespace SAF.Framework.Controls.Charts
{
    partial class MenuChartControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuChartControl));
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
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
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bsiSave,
            this.bsiBringToFront,
            this.bsiSendToBack,
            this.bsiUndo,
            this.bsiRedo,
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiZoomOut)});
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
            this.btnRefresh.Caption = "刷新";
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
            // MenuChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MenuChartControl";
            this.Size = new System.Drawing.Size(828, 478);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private BarButtonItem bsiRedo;
        private  BarButtonItem bsiZoomIn;
        private  BarButtonItem bsiZoomOut;
        private BarButtonItem bbiExportJpg;
        private  BarButtonItem bbiOpen;
        private BarButtonItem btnRefresh;
        private BarButtonItem btnSaveAs;
        private BarButtonItem btnEdit;
        private ImageCollection imageCollection;
    }
}
