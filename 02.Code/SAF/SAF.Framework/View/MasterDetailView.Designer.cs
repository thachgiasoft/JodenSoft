﻿namespace SAF.Framework.View
{
    partial class MasterDetailView
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
            this.tcDtl = new DevExpress.XtraTab.XtraTabControl();
            this.pageDtl = new DevExpress.XtraTab.XtraTabPage();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.pmuImportDetail = new DevExpress.XtraBars.PopupMenu();
            this.bsDetail = new System.Windows.Forms.BindingSource();
            this.barDtl = new DevExpress.XtraBars.Bar();
            this.btnDtlAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDtlDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnDtlCopy = new DevExpress.XtraBars.BarButtonItem();
            this.bsiDtlImport = new DevExpress.XtraBars.BarSubItem();
            this.bbiDtlImport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).BeginInit();
            this.pnlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).BeginInit();
            this.pnlPageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).BeginInit();
            this.tcDtl.SuspendLayout();
            this.pageDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuImportDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(831, 145);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Size = new System.Drawing.Size(831, 272);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(831, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(0, 445);
            this.pnlPageControl.Size = new System.Drawing.Size(831, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(827, 26);
            // 
            // splitRight
            // 
            this.splitRight.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitRight.Panel2.Controls.Add(this.tcDtl);
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitRight.Size = new System.Drawing.Size(544, 268);
            this.splitRight.SplitterPosition = 130;
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(544, 130);
            // 
            // pageMain
            // 
            this.pageMain.Size = new System.Drawing.Size(538, 124);
            // 
            // bmMain
            // 
            this.bmMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDtl});
            this.bmMain.DockControls.Add(this.standaloneBarDockControl1);
            this.bmMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDtlAddNew,
            this.btnDtlDelete,
            this.btnDtlCopy,
            this.bsiDtlImport,
            this.bbiDtlImport});
            this.bmMain.MaxItemId = 5;
            // 
            // tcDtl
            // 
            this.tcDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDtl.Location = new System.Drawing.Point(0, 0);
            this.tcDtl.Name = "tcDtl";
            this.tcDtl.SelectedTabPage = this.pageDtl;
            this.tcDtl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcDtl.Size = new System.Drawing.Size(544, 133);
            this.tcDtl.TabIndex = 0;
            this.tcDtl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageDtl});
            // 
            // pageDtl
            // 
            this.pageDtl.Controls.Add(this.standaloneBarDockControl1);
            this.pageDtl.Name = "pageDtl";
            this.pageDtl.Size = new System.Drawing.Size(538, 127);
            this.pageDtl.Text = "明细数据";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(538, 29);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // pmuImportDetail
            // 
            this.pmuImportDetail.Name = "pmuImportDetail";
            this.pmuImportDetail.Ribbon = this.ribbonMain;
            // 
            // barDtl
            // 
            this.barDtl.BarName = "barDtl";
            this.barDtl.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.barDtl.DockCol = 0;
            this.barDtl.DockRow = 0;
            this.barDtl.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barDtl.FloatLocation = new System.Drawing.Point(489, 473);
            this.barDtl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDtlAddNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDtlDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDtlCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiDtlImport, true)});
            this.barDtl.OptionsBar.AllowQuickCustomization = false;
            this.barDtl.OptionsBar.UseWholeRow = true;
            this.barDtl.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.barDtl.Text = "barDtl";
            // 
            // btnDtlAddNew
            // 
            this.btnDtlAddNew.Caption = "新增";
            this.btnDtlAddNew.Glyph = global::SAF.Framework.Properties.Resources.Action_New_16x16;
            this.btnDtlAddNew.Id = 0;
            this.btnDtlAddNew.Name = "btnDtlAddNew";
            this.btnDtlAddNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDtlAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDtlAddNew_ItemClick);
            // 
            // btnDtlDelete
            // 
            this.btnDtlDelete.Caption = "复制";
            this.btnDtlDelete.Glyph = global::SAF.Framework.Properties.Resources.Action_Copy_16x16;
            this.btnDtlDelete.Id = 1;
            this.btnDtlDelete.Name = "btnDtlDelete";
            this.btnDtlDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDtlDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDtlDelete_ItemClick);
            // 
            // btnDtlCopy
            // 
            this.btnDtlCopy.Caption = "删除";
            this.btnDtlCopy.Glyph = global::SAF.Framework.Properties.Resources.Action_Delete_16x16;
            this.btnDtlCopy.Id = 2;
            this.btnDtlCopy.Name = "btnDtlCopy";
            this.btnDtlCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDtlCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDtlCopy_ItemClick);
            // 
            // bsiDtlImport
            // 
            this.bsiDtlImport.Caption = "导入数据";
            this.bsiDtlImport.Id = 3;
            this.bsiDtlImport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDtlImport)});
            this.bsiDtlImport.Name = "bsiDtlImport";
            // 
            // bbiDtlImport
            // 
            this.bbiDtlImport.Caption = "导入数据";
            this.bbiDtlImport.Glyph = global::SAF.Framework.Properties.Resources.Action_ImportData_16x16;
            this.bbiDtlImport.Id = 4;
            this.bbiDtlImport.Name = "bbiDtlImport";
            this.bbiDtlImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDtlImport_ItemClick);
            // 
            // MasterDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "MasterDetailView";
            this.Size = new System.Drawing.Size(831, 476);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).EndInit();
            this.pnlQueryControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).EndInit();
            this.pnlPageControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).EndInit();
            this.tcDtl.ResumeLayout(false);
            this.pageDtl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuImportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraTab.XtraTabControl tcDtl;
        protected DevExpress.XtraTab.XtraTabPage pageDtl;
        protected System.Windows.Forms.BindingSource bsDetail;
        private DevExpress.XtraBars.PopupMenu pmuImportDetail;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.Bar barDtl;
        private DevExpress.XtraBars.BarButtonItem btnDtlAddNew;
        private DevExpress.XtraBars.BarButtonItem btnDtlDelete;
        private DevExpress.XtraBars.BarButtonItem btnDtlCopy;
        private DevExpress.XtraBars.BarSubItem bsiDtlImport;
        private DevExpress.XtraBars.BarButtonItem bbiDtlImport;



    }
}
