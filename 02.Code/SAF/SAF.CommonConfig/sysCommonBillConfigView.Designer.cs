namespace SAF.CommonConfig
{
    partial class sysCommonBillConfigView
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
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdDtl = new DevExpress.XtraGrid.GridControl();
            this.grvDtl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedOn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedBy1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedOn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersionNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDbTableName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrimaryKeyName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataRowView1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntitySet1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntityState1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).BeginInit();
            this.tcDtl.SuspendLayout();
            this.pageDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDtlToolbar)).BeginInit();
            this.pnlDtlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDtl)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDtl
            // 
            this.tcDtl.Size = new System.Drawing.Size(544, 202);
            // 
            // pageDtl
            // 
            this.pageDtl.Controls.Add(this.grdDtl);
            this.pageDtl.Size = new System.Drawing.Size(538, 196);
            this.pageDtl.Controls.SetChildIndex(this.pnlDtlToolbar, 0);
            this.pageDtl.Controls.SetChildIndex(this.grdDtl, 0);
            // 
            // bsDetail
            // 
            this.bsDetail.DataSource = typeof(SAF.SystemEntities.sysCommonBillHdr);
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            this.splitMain.Size = new System.Drawing.Size(831, 341);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.SystemEntities.sysCommonBillHdr);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(0, 514);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(827, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(544, 337);
            // 
            // grdIndex
            // 
            this.grdIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdIndex.DataSource = this.bsIndex;
            this.grdIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIndex.Location = new System.Drawing.Point(0, 2);
            this.grdIndex.MainView = this.grvIndex;
            this.grdIndex.MenuManager = this.ribbonMain;
            this.grdIndex.Name = "grdIndex";
            this.grdIndex.Size = new System.Drawing.Size(282, 337);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            // 
            // colIden
            // 
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // grdDtl
            // 
            this.grdDtl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDtl.DataSource = this.bsDetail;
            this.grdDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDtl.Location = new System.Drawing.Point(0, 29);
            this.grdDtl.MainView = this.grvDtl;
            this.grdDtl.MenuManager = this.ribbonMain;
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.Size = new System.Drawing.Size(538, 167);
            this.grdDtl.TabIndex = 1;
            this.grdDtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDtl});
            // 
            // grvDtl
            // 
            this.grvDtl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden1,
            this.colCreatedBy1,
            this.colCreatedOn1,
            this.colModifiedBy1,
            this.colModifiedOn1,
            this.colVersionNumber1,
            this.colDbTableName1,
            this.colPrimaryKeyName1,
            this.colDataRowView1,
            this.colEntitySet1,
            this.colEntityState1});
            this.grvDtl.GridControl = this.grdDtl;
            this.grvDtl.Name = "grvDtl";
            // 
            // colIden1
            // 
            this.colIden1.FieldName = "Iden";
            this.colIden1.Name = "colIden1";
            this.colIden1.Visible = true;
            this.colIden1.VisibleIndex = 0;
            // 
            // colCreatedBy1
            // 
            this.colCreatedBy1.FieldName = "CreatedBy";
            this.colCreatedBy1.Name = "colCreatedBy1";
            this.colCreatedBy1.Visible = true;
            this.colCreatedBy1.VisibleIndex = 1;
            // 
            // colCreatedOn1
            // 
            this.colCreatedOn1.FieldName = "CreatedOn";
            this.colCreatedOn1.Name = "colCreatedOn1";
            this.colCreatedOn1.Visible = true;
            this.colCreatedOn1.VisibleIndex = 2;
            // 
            // colModifiedBy1
            // 
            this.colModifiedBy1.FieldName = "ModifiedBy";
            this.colModifiedBy1.Name = "colModifiedBy1";
            this.colModifiedBy1.Visible = true;
            this.colModifiedBy1.VisibleIndex = 3;
            // 
            // colModifiedOn1
            // 
            this.colModifiedOn1.FieldName = "ModifiedOn";
            this.colModifiedOn1.Name = "colModifiedOn1";
            this.colModifiedOn1.Visible = true;
            this.colModifiedOn1.VisibleIndex = 4;
            // 
            // colVersionNumber1
            // 
            this.colVersionNumber1.FieldName = "VersionNumber";
            this.colVersionNumber1.Name = "colVersionNumber1";
            this.colVersionNumber1.OptionsColumn.ReadOnly = true;
            this.colVersionNumber1.Visible = true;
            this.colVersionNumber1.VisibleIndex = 5;
            // 
            // colDbTableName1
            // 
            this.colDbTableName1.FieldName = "DbTableName";
            this.colDbTableName1.Name = "colDbTableName1";
            this.colDbTableName1.Visible = true;
            this.colDbTableName1.VisibleIndex = 6;
            // 
            // colPrimaryKeyName1
            // 
            this.colPrimaryKeyName1.FieldName = "PrimaryKeyName";
            this.colPrimaryKeyName1.Name = "colPrimaryKeyName1";
            this.colPrimaryKeyName1.Visible = true;
            this.colPrimaryKeyName1.VisibleIndex = 7;
            // 
            // colDataRowView1
            // 
            this.colDataRowView1.FieldName = "DataRowView";
            this.colDataRowView1.Name = "colDataRowView1";
            this.colDataRowView1.Visible = true;
            this.colDataRowView1.VisibleIndex = 8;
            // 
            // colEntitySet1
            // 
            this.colEntitySet1.FieldName = "EntitySet";
            this.colEntitySet1.Name = "colEntitySet1";
            this.colEntitySet1.OptionsColumn.ReadOnly = true;
            this.colEntitySet1.Visible = true;
            this.colEntitySet1.VisibleIndex = 9;
            // 
            // colEntityState1
            // 
            this.colEntityState1.FieldName = "EntityState";
            this.colEntityState1.Name = "colEntityState1";
            this.colEntityState1.OptionsColumn.ReadOnly = true;
            this.colEntityState1.Visible = true;
            this.colEntityState1.VisibleIndex = 10;
            // 
            // sysCommonBillConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysCommonBillConfigView";
            this.Size = new System.Drawing.Size(831, 545);
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).EndInit();
            this.tcDtl.ResumeLayout(false);
            this.pageDtl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDtlToolbar)).EndInit();
            this.pnlDtlToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDtl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDtl;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDtl;
        private DevExpress.XtraGrid.Columns.GridColumn colIden1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedOn1;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedBy1;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedOn1;
        private DevExpress.XtraGrid.Columns.GridColumn colVersionNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colDbTableName1;
        private DevExpress.XtraGrid.Columns.GridColumn colPrimaryKeyName1;
        private DevExpress.XtraGrid.Columns.GridColumn colDataRowView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEntitySet1;
        private DevExpress.XtraGrid.Columns.GridColumn colEntityState1;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
    }
}
