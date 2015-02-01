namespace JNHT_ProdSys
{
    partial class woBomParentView
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grdwo = new DevExpress.XtraGrid.GridControl();
            this.bswo = new System.Windows.Forms.BindingSource(this.components);
            this.grvwo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBomId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCParentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeBom = new System.Windows.Forms.TreeView();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bswo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(1039, 120);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.splitContainerControl1);
            this.splitMain.Size = new System.Drawing.Size(1039, 302);
            this.splitMain.SplitterPosition = 522;
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(1039, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(1, 451);
            this.pnlPageControl.Size = new System.Drawing.Size(1039, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(1035, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(512, 298);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(512, 298);
            // 
            // pageMain
            // 
            this.pageMain.Size = new System.Drawing.Size(506, 292);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grdwo);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.treeBom);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(522, 298);
            this.splitContainerControl1.SplitterPosition = 234;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grdwo
            // 
            this.grdwo.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdwo.DataSource = this.bswo;
            this.grdwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdwo.Location = new System.Drawing.Point(0, 0);
            this.grdwo.MainView = this.grvwo;
            this.grdwo.MenuManager = this.ribbonMain;
            this.grdwo.Name = "grdwo";
            this.grdwo.Size = new System.Drawing.Size(234, 298);
            this.grdwo.TabIndex = 0;
            this.grdwo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvwo});
            // 
            // bswo
            // 
            this.bswo.DataSource = typeof(JNHT_ProdSys.woOrder);
            // 
            // grvwo
            // 
            this.grvwo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colBomId,
            this.colWoCode,
            this.colWoVersion,
            this.colCParentId,
            this.colCParentName,
            this.colQty,
            this.colIsClose});
            this.grvwo.GridControl = this.grdwo;
            this.grvwo.Name = "grvwo";
            this.grvwo.OptionsBehavior.Editable = false;
            this.grvwo.OptionsView.ColumnAutoWidth = false;
            this.grvwo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grvwo_RowClick);
            this.grvwo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvwo_FocusedRowChanged);
            // 
            // colIden
            // 
            this.colIden.Caption = "序号";
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            this.colIden.Width = 55;
            // 
            // colBomId
            // 
            this.colBomId.Caption = "区分号";
            this.colBomId.FieldName = "BomId";
            this.colBomId.Name = "colBomId";
            this.colBomId.Visible = true;
            this.colBomId.VisibleIndex = 1;
            this.colBomId.Width = 53;
            // 
            // colWoCode
            // 
            this.colWoCode.Caption = "生产令单";
            this.colWoCode.FieldName = "WoCode";
            this.colWoCode.Name = "colWoCode";
            this.colWoCode.Visible = true;
            this.colWoCode.VisibleIndex = 2;
            this.colWoCode.Width = 97;
            // 
            // colWoVersion
            // 
            this.colWoVersion.Caption = "版本";
            this.colWoVersion.FieldName = "WoVersion";
            this.colWoVersion.Name = "colWoVersion";
            this.colWoVersion.Visible = true;
            this.colWoVersion.VisibleIndex = 3;
            this.colWoVersion.Width = 32;
            // 
            // colCParentId
            // 
            this.colCParentId.Caption = "产品代号";
            this.colCParentId.FieldName = "CParentId";
            this.colCParentId.Name = "colCParentId";
            this.colCParentId.Visible = true;
            this.colCParentId.VisibleIndex = 4;
            this.colCParentId.Width = 89;
            // 
            // colCParentName
            // 
            this.colCParentName.Caption = "产品名称";
            this.colCParentName.FieldName = "CParentName";
            this.colCParentName.Name = "colCParentName";
            this.colCParentName.Visible = true;
            this.colCParentName.VisibleIndex = 5;
            this.colCParentName.Width = 81;
            // 
            // colQty
            // 
            this.colQty.Caption = "数量";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 6;
            this.colQty.Width = 52;
            // 
            // colIsClose
            // 
            this.colIsClose.Caption = "状态";
            this.colIsClose.FieldName = "IsClose";
            this.colIsClose.Name = "colIsClose";
            this.colIsClose.Visible = true;
            this.colIsClose.VisibleIndex = 7;
            this.colIsClose.Width = 38;
            // 
            // treeBom
            // 
            this.treeBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBom.Location = new System.Drawing.Point(0, 0);
            this.treeBom.Name = "treeBom";
            this.treeBom.Size = new System.Drawing.Size(283, 298);
            this.treeBom.TabIndex = 0;
            this.treeBom.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeBom_AfterSelect);
            // 
            // woBomParentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "woBomParentView";
            this.Size = new System.Drawing.Size(1041, 483);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bswo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl grdwo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvwo;
        private System.Windows.Forms.TreeView treeBom;
        private System.Windows.Forms.BindingSource bswo;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colBomId;
        private DevExpress.XtraGrid.Columns.GridColumn colWoCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWoVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colCParentId;
        private DevExpress.XtraGrid.Columns.GridColumn colCParentName;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colIsClose;
    }
}
