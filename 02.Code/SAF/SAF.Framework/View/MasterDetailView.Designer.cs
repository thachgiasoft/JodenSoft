namespace SAF.Framework.View
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
            this.components = new System.ComponentModel.Container();
            this.tcDtl = new DevExpress.XtraTab.XtraTabControl();
            this.pageDtl = new DevExpress.XtraTab.XtraTabPage();
            this.pnlDtlToolbar = new DevExpress.XtraEditors.PanelControl();
            this.btnDtlImport = new DevExpress.XtraEditors.DropDownButton();
            this.pmuImportDetail = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDtlCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnDtlDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnDtlAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.bsDetail = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).BeginInit();
            this.pnlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).BeginInit();
            this.pnlPageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).BeginInit();
            this.tcDtl.SuspendLayout();
            this.pageDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDtlToolbar)).BeginInit();
            this.pnlDtlToolbar.SuspendLayout();
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
            // lcMain
            // 
            this.lcMain.Size = new System.Drawing.Size(538, 124);
            // 
            // lcgMain
            // 
            this.lcgMain.Size = new System.Drawing.Size(538, 124);
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
            this.pageDtl.Controls.Add(this.pnlDtlToolbar);
            this.pageDtl.Name = "pageDtl";
            this.pageDtl.Size = new System.Drawing.Size(538, 127);
            this.pageDtl.Text = "明细数据";
            // 
            // pnlDtlToolbar
            // 
            this.pnlDtlToolbar.Controls.Add(this.btnDtlImport);
            this.pnlDtlToolbar.Controls.Add(this.btnDtlCopy);
            this.pnlDtlToolbar.Controls.Add(this.btnDtlDelete);
            this.pnlDtlToolbar.Controls.Add(this.btnDtlAddNew);
            this.pnlDtlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDtlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlDtlToolbar.Name = "pnlDtlToolbar";
            this.pnlDtlToolbar.Size = new System.Drawing.Size(538, 29);
            this.pnlDtlToolbar.TabIndex = 0;
            // 
            // btnDtlImport
            // 
            this.btnDtlImport.DropDownControl = this.pmuImportDetail;
            this.btnDtlImport.Image = global::SAF.Framework.Properties.Resources.Action_ImportData_16x16;
            this.btnDtlImport.Location = new System.Drawing.Point(215, 3);
            this.btnDtlImport.MenuManager = this.ribbonMain;
            this.btnDtlImport.Name = "btnDtlImport";
            this.btnDtlImport.Size = new System.Drawing.Size(81, 23);
            this.btnDtlImport.TabIndex = 4;
            this.btnDtlImport.Text = "导入";
            this.btnDtlImport.Click += new System.EventHandler(this.btnDtlImport_Click);
            // 
            // pmuImportDetail
            // 
            this.pmuImportDetail.Name = "pmuImportDetail";
            this.pmuImportDetail.Ribbon = this.ribbonMain;
            // 
            // btnDtlCopy
            // 
            this.btnDtlCopy.Image = global::SAF.Framework.Properties.Resources.Action_Copy_16x16;
            this.btnDtlCopy.Location = new System.Drawing.Point(70, 3);
            this.btnDtlCopy.Name = "btnDtlCopy";
            this.btnDtlCopy.Size = new System.Drawing.Size(62, 23);
            this.btnDtlCopy.TabIndex = 3;
            this.btnDtlCopy.Text = "复制";
            this.btnDtlCopy.Click += new System.EventHandler(this.btnDtlCopy_Click);
            // 
            // btnDtlDelete
            // 
            this.btnDtlDelete.Image = global::SAF.Framework.Properties.Resources.Action_Delete_16x16;
            this.btnDtlDelete.Location = new System.Drawing.Point(137, 3);
            this.btnDtlDelete.Name = "btnDtlDelete";
            this.btnDtlDelete.Size = new System.Drawing.Size(62, 23);
            this.btnDtlDelete.TabIndex = 2;
            this.btnDtlDelete.Text = "删除";
            this.btnDtlDelete.Click += new System.EventHandler(this.btnDtlDelete_Click);
            // 
            // btnDtlAddNew
            // 
            this.btnDtlAddNew.Image = global::SAF.Framework.Properties.Resources.Action_New_16x16;
            this.btnDtlAddNew.Location = new System.Drawing.Point(4, 3);
            this.btnDtlAddNew.Name = "btnDtlAddNew";
            this.btnDtlAddNew.Size = new System.Drawing.Size(62, 23);
            this.btnDtlAddNew.TabIndex = 0;
            this.btnDtlAddNew.Text = "新增";
            this.btnDtlAddNew.Click += new System.EventHandler(this.btnDtlAddNew_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).EndInit();
            this.tcDtl.ResumeLayout(false);
            this.pageDtl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDtlToolbar)).EndInit();
            this.pnlDtlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuImportDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraTab.XtraTabControl tcDtl;
        protected DevExpress.XtraTab.XtraTabPage pageDtl;
        protected DevExpress.XtraEditors.PanelControl pnlDtlToolbar;
        protected DevExpress.XtraEditors.SimpleButton btnDtlDelete;
        protected DevExpress.XtraEditors.SimpleButton btnDtlAddNew;
        protected System.Windows.Forms.BindingSource bsDetail;
        protected DevExpress.XtraEditors.SimpleButton btnDtlCopy;
        private DevExpress.XtraEditors.DropDownButton btnDtlImport;
        private DevExpress.XtraBars.PopupMenu pmuImportDetail;



    }
}
