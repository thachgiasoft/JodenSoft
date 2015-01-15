namespace SAF.Test
{
    partial class sdOrderView
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
            this.colOrderNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.gseOrg = new SAF.Framework.Controls.GridSearchEdit();
            this.txtOrderNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdDtl = new DevExpress.XtraGrid.GridControl();
            this.grvDtl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).BeginInit();
            this.tcDtl.SuspendLayout();
            this.pageDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmuImportDetail)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gseOrg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDtl)).BeginInit();
            this.SuspendLayout();
            // 
            // pageDtl
            // 
            this.pageDtl.Controls.Add(this.grdDtl);
            this.pageDtl.Controls.SetChildIndex(this.standaloneDtl, 0);
            this.pageDtl.Controls.SetChildIndex(this.grdDtl, 0);
            // 
            // bsDetail
            // 
            this.bsDetail.DataSource = typeof(SAF.Test.sdOrderDtl);
            // 
            // barDtl
            // 
            this.barDtl.OptionsBar.AllowQuickCustomization = false;
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
            this.bsIndex.DataSource = typeof(SAF.Test.sdOrder);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.Test.sdOrder);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(815, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(532, 286);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.layoutControl1);
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
            this.grdIndex.Size = new System.Drawing.Size(282, 286);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colOrderNo});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            // 
            // colIden
            // 
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // colOrderNo
            // 
            this.colOrderNo.FieldName = "OrderNo";
            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.Visible = true;
            this.colOrderNo.VisibleIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtIden);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.gseOrg);
            this.layoutControl1.Controls.Add(this.txtOrderNo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(526, 124);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(428, 12);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(86, 20);
            this.txtIden.StyleController = this.layoutControl1;
            this.txtIden.TabIndex = 7;
            // 
            // txtRemark
            // 
            this.txtRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Remark", true));
            this.txtRemark.Location = new System.Drawing.Point(51, 60);
            this.txtRemark.MenuManager = this.ribbonMain;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(463, 52);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 6;
            this.txtRemark.UseOptimizedRendering = true;
            // 
            // gseOrg
            // 
            this.gseOrg.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "OrganiaztionName", true));
            this.gseOrg.Location = new System.Drawing.Point(51, 36);
            this.gseOrg.MenuManager = this.ribbonMain;
            this.gseOrg.Name = "gseOrg";
            this.gseOrg.Properties.AutoClearSearchFiledsValue = true;
            this.gseOrg.Properties.AutoFillEntitySet = null;
            this.gseOrg.Properties.AutoFillFieldNames = null;
            this.gseOrg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.gseOrg.Properties.ColumnHeaders = null;
            this.gseOrg.Properties.CommandText = null;
            this.gseOrg.Properties.ConnectionName = "Default";
            this.gseOrg.Properties.DisplayMember = null;
            this.gseOrg.Properties.PageSize = 50;
            this.gseOrg.Properties.PopupFormMinSize = new System.Drawing.Size(420, 380);
            this.gseOrg.Properties.SearchFileds = "";
            this.gseOrg.Properties.ShowPageControl = true;
            this.gseOrg.Properties.ShowPopupCloseButton = false;
            this.gseOrg.Size = new System.Drawing.Size(463, 20);
            this.gseOrg.StyleController = this.layoutControl1;
            this.gseOrg.TabIndex = 5;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "OrderNo", true));
            this.txtOrderNo.Location = new System.Drawing.Point(51, 12);
            this.txtOrderNo.MenuManager = this.ribbonMain;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(334, 20);
            this.txtOrderNo.StyleController = this.layoutControl1;
            this.txtOrderNo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(526, 124);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtOrderNo;
            this.layoutControlItem1.CustomizationFormText = "订单号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(377, 24);
            this.layoutControlItem1.Text = "订单号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gseOrg;
            this.layoutControlItem2.CustomizationFormText = "组织";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem2.Text = "组织";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRemark;
            this.layoutControlItem3.CustomizationFormText = "备注";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(506, 56);
            this.layoutControlItem3.Text = "备注";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtIden;
            this.layoutControlItem4.CustomizationFormText = "序号";
            this.layoutControlItem4.Location = new System.Drawing.Point(377, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 24);
            this.layoutControlItem4.Text = "序号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(36, 14);
            // 
            // grdDtl
            // 
            this.grdDtl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDtl.DataSource = this.bsDetail;
            this.grdDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDtl.Location = new System.Drawing.Point(0, 23);
            this.grdDtl.MainView = this.grvDtl;
            this.grdDtl.MenuManager = this.ribbonMain;
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.Size = new System.Drawing.Size(526, 122);
            this.grdDtl.TabIndex = 1;
            this.grdDtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDtl});
            // 
            // grvDtl
            // 
            this.grvDtl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQty});
            this.grvDtl.GridControl = this.grdDtl;
            this.grvDtl.Name = "grvDtl";
            this.grvDtl.OptionsView.ColumnAutoWidth = false;
            // 
            // colQty
            // 
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 0;
            // 
            // sdOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sdOrderView";
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).EndInit();
            this.tcDtl.ResumeLayout(false);
            this.pageDtl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmuImportDetail)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gseOrg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDtl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDtl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDtl;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDtl;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtOrderNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNo;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private Framework.Controls.GridSearchEdit gseOrg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
