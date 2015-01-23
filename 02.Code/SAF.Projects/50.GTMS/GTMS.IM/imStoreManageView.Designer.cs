namespace GTMS.IM
{
    partial class imStoreManageView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridIndexView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsStoreNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsStoreType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.StoreNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForStoreName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.StoreNoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForStoreNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.StoreTypeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForStoreType = new DevExpress.XtraLayout.LayoutControlItem();
            this.UsabledCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.ItemForUsabled = new DevExpress.XtraLayout.LayoutControlItem();
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
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndexView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreNoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreTypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsabledCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUsabled)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.gridControl1);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(GTMS.EntitySet.imStore);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(GTMS.EntitySet.imStore);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.dataLayoutControl1);
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.DataSource = this.bsIndex;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 2);
            this.gridControl1.MainView = this.gridIndexView;
            this.gridControl1.MenuManager = this.ribbonMain;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(282, 284);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridIndexView});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridIndexView
            // 
            this.gridIndexView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsIden,
            this.colsStoreNo,
            this.colsStoreName,
            this.colsStoreType});
            this.gridIndexView.GridControl = this.gridControl1;
            this.gridIndexView.Name = "gridIndexView";
            // 
            // colsIden
            // 
            this.colsIden.Caption = "流水编号";
            this.colsIden.FieldName = "Iden";
            this.colsIden.Name = "colsIden";
            // 
            // colsStoreNo
            // 
            this.colsStoreNo.Caption = "仓库编号";
            this.colsStoreNo.FieldName = "StoreNo";
            this.colsStoreNo.Name = "colsStoreNo";
            this.colsStoreNo.OptionsColumn.AllowEdit = false;
            this.colsStoreNo.OptionsColumn.ReadOnly = true;
            this.colsStoreNo.Visible = true;
            this.colsStoreNo.VisibleIndex = 0;
            // 
            // colsStoreName
            // 
            this.colsStoreName.Caption = "仓库名称";
            this.colsStoreName.FieldName = "StoreName";
            this.colsStoreName.Name = "colsStoreName";
            this.colsStoreName.OptionsColumn.AllowEdit = false;
            this.colsStoreName.OptionsColumn.ReadOnly = true;
            this.colsStoreName.Visible = true;
            this.colsStoreName.VisibleIndex = 1;
            // 
            // colsStoreType
            // 
            this.colsStoreType.Caption = "仓库类别";
            this.colsStoreType.FieldName = "StoreType";
            this.colsStoreType.Name = "colsStoreType";
            this.colsStoreType.OptionsColumn.AllowEdit = false;
            this.colsStoreType.OptionsColumn.ReadOnly = true;
            this.colsStoreType.Visible = true;
            this.colsStoreType.VisibleIndex = 2;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.StoreNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StoreNoTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StoreTypeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UsabledCheckEdit);
            this.dataLayoutControl1.DataSource = this.bsMain;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(489, 278);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(489, 278);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // StoreNameTextEdit
            // 
            this.StoreNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "StoreName", true));
            this.StoreNameTextEdit.Location = new System.Drawing.Point(64, 36);
            this.StoreNameTextEdit.MenuManager = this.ribbonMain;
            this.StoreNameTextEdit.Name = "StoreNameTextEdit";
            this.StoreNameTextEdit.Size = new System.Drawing.Size(413, 20);
            this.StoreNameTextEdit.StyleController = this.dataLayoutControl1;
            this.StoreNameTextEdit.TabIndex = 4;
            // 
            // ItemForStoreName
            // 
            this.ItemForStoreName.Control = this.StoreNameTextEdit;
            this.ItemForStoreName.CustomizationFormText = "仓库名称";
            this.ItemForStoreName.Location = new System.Drawing.Point(0, 24);
            this.ItemForStoreName.Name = "ItemForStoreName";
            this.ItemForStoreName.Size = new System.Drawing.Size(469, 24);
            this.ItemForStoreName.Text = "仓库名称";
            this.ItemForStoreName.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForStoreName,
            this.ItemForStoreNo,
            this.ItemForStoreType,
            this.ItemForUsabled});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(469, 258);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // StoreNoTextEdit
            // 
            this.StoreNoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "StoreNo", true));
            this.StoreNoTextEdit.Location = new System.Drawing.Point(64, 12);
            this.StoreNoTextEdit.MenuManager = this.ribbonMain;
            this.StoreNoTextEdit.Name = "StoreNoTextEdit";
            this.StoreNoTextEdit.Size = new System.Drawing.Size(413, 20);
            this.StoreNoTextEdit.StyleController = this.dataLayoutControl1;
            this.StoreNoTextEdit.TabIndex = 5;
            // 
            // ItemForStoreNo
            // 
            this.ItemForStoreNo.Control = this.StoreNoTextEdit;
            this.ItemForStoreNo.CustomizationFormText = "仓库编号";
            this.ItemForStoreNo.Location = new System.Drawing.Point(0, 0);
            this.ItemForStoreNo.Name = "ItemForStoreNo";
            this.ItemForStoreNo.Size = new System.Drawing.Size(469, 24);
            this.ItemForStoreNo.Text = "仓库编号";
            this.ItemForStoreNo.TextSize = new System.Drawing.Size(48, 14);
            // 
            // StoreTypeTextEdit
            // 
            this.StoreTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "StoreType", true));
            this.StoreTypeTextEdit.Location = new System.Drawing.Point(64, 60);
            this.StoreTypeTextEdit.MenuManager = this.ribbonMain;
            this.StoreTypeTextEdit.Name = "StoreTypeTextEdit";
            this.StoreTypeTextEdit.Size = new System.Drawing.Size(413, 20);
            this.StoreTypeTextEdit.StyleController = this.dataLayoutControl1;
            this.StoreTypeTextEdit.TabIndex = 6;
            // 
            // ItemForStoreType
            // 
            this.ItemForStoreType.Control = this.StoreTypeTextEdit;
            this.ItemForStoreType.CustomizationFormText = "仓库类型";
            this.ItemForStoreType.Location = new System.Drawing.Point(0, 48);
            this.ItemForStoreType.Name = "ItemForStoreType";
            this.ItemForStoreType.Size = new System.Drawing.Size(469, 24);
            this.ItemForStoreType.Text = "仓库类型";
            this.ItemForStoreType.TextSize = new System.Drawing.Size(48, 14);
            // 
            // UsabledCheckEdit
            // 
            this.UsabledCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Usabled", true));
            this.UsabledCheckEdit.Location = new System.Drawing.Point(64, 84);
            this.UsabledCheckEdit.MenuManager = this.ribbonMain;
            this.UsabledCheckEdit.Name = "UsabledCheckEdit";
            this.UsabledCheckEdit.Properties.Caption = "";
            this.UsabledCheckEdit.Size = new System.Drawing.Size(413, 19);
            this.UsabledCheckEdit.StyleController = this.dataLayoutControl1;
            this.UsabledCheckEdit.TabIndex = 7;
            // 
            // ItemForUsabled
            // 
            this.ItemForUsabled.Control = this.UsabledCheckEdit;
            this.ItemForUsabled.CustomizationFormText = "是否可以";
            this.ItemForUsabled.Location = new System.Drawing.Point(0, 72);
            this.ItemForUsabled.Name = "ItemForUsabled";
            this.ItemForUsabled.Size = new System.Drawing.Size(469, 186);
            this.ItemForUsabled.Text = "是否可以";
            this.ItemForUsabled.TextSize = new System.Drawing.Size(48, 14);
            // 
            // imStoreManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "imStoreManageView";
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
            this.pageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndexView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreNoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StoreTypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStoreType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsabledCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUsabled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridIndexView;
        private DevExpress.XtraGrid.Columns.GridColumn colsIden;
        private DevExpress.XtraGrid.Columns.GridColumn colsStoreNo;
        private DevExpress.XtraGrid.Columns.GridColumn colsStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn colsStoreType;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit StoreNameTextEdit;
        private DevExpress.XtraEditors.TextEdit StoreNoTextEdit;
        private DevExpress.XtraEditors.TextEdit StoreTypeTextEdit;
        private DevExpress.XtraEditors.CheckEdit UsabledCheckEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreNo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStoreType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUsabled;
    }
}
