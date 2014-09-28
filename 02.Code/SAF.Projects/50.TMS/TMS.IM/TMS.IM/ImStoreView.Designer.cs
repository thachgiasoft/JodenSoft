namespace TMS.IM
{
    partial class ImStoreView
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
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
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
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(TMS.Entities.imStore);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(TMS.Entities.imStore);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(763, 26);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.txtNo);
            this.lcMain.Controls.Add(this.txtName);
            this.lcMain.Controls.Add(this.txtIden);
            // 
            // lcgMain
            // 
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
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
            this.grdIndex.Size = new System.Drawing.Size(282, 267);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colName,
            this.colNo});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            this.grvIndex.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvIndex_FocusedRowChanged);
            // 
            // colIden
            // 
            this.colIden.Caption = "流水编号";
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "仓库名称";
            this.colName.FieldName = "sStoreName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colNo
            // 
            this.colNo.Caption = "仓库编号";
            this.colNo.FieldName = "sStoreNo";
            this.colNo.Name = "colNo";
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 2;
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(54, 2);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(418, 20);
            this.txtIden.StyleController = this.lcMain;
            this.txtIden.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtIden;
            this.layoutControlItem1.CustomizationFormText = "Iden";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem1.Text = "流水编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sStoreName", true));
            this.txtName.Location = new System.Drawing.Point(54, 50);
            this.txtName.MenuManager = this.ribbonMain;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(418, 20);
            this.txtName.StyleController = this.lcMain;
            this.txtName.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.CustomizationFormText = "Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(474, 213);
            this.layoutControlItem2.Text = "仓库名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtNo
            // 
            this.txtNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sStoreNo", true));
            this.txtNo.Location = new System.Drawing.Point(54, 26);
            this.txtNo.MenuManager = this.ribbonMain;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(418, 20);
            this.txtNo.StyleController = this.lcMain;
            this.txtNo.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtNo;
            this.layoutControlItem4.CustomizationFormText = "仓库编号";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem4.Text = "仓库编号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // ImStoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ImStoreView";
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
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
    }
}
