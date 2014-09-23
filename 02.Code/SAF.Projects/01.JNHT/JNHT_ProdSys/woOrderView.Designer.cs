namespace JNHT_ProdSys
{
    partial class woOrderView
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
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Iden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.woCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WoVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CParentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Qty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IsClose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtwocode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtwoversion = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.luparentid = new DevExpress.XtraEditors.LookUpEdit();
            this.bsProd = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtparentname = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.spdqty = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.cmbisclose = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwocode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwoversion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luparentid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtparentname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdqty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbisclose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(1108, 145);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            this.splitMain.Size = new System.Drawing.Size(1108, 271);
            this.splitMain.SplitterPosition = 729;
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(JNHT_ProdSys.woOrder);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(JNHT_ProdSys.woOrder);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(1108, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Size = new System.Drawing.Size(1108, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(1104, 26);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.cmbisclose);
            this.lcMain.Controls.Add(this.spdqty);
            this.lcMain.Controls.Add(this.txtparentname);
            this.lcMain.Controls.Add(this.luparentid);
            this.lcMain.Controls.Add(this.txtwoversion);
            this.lcMain.Controls.Add(this.txtwocode);
            this.lcMain.Size = new System.Drawing.Size(368, 261);
            // 
            // lcgMain
            // 
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem6});
            this.lcgMain.Size = new System.Drawing.Size(368, 261);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(374, 267);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(374, 267);
            // 
            // pageMain
            // 
            this.pageMain.Size = new System.Drawing.Size(368, 261);
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
            this.grdIndex.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdIndex.Size = new System.Drawing.Size(729, 267);
            this.grdIndex.TabIndex = 4;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Iden,
            this.woCode,
            this.WoVersion,
            this.CParentId,
            this.CParentName,
            this.Qty,
            this.IsClose});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            this.grvIndex.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvIndex_FocusedRowChanged);
            // 
            // Iden
            // 
            this.Iden.Caption = "序号";
            this.Iden.FieldName = "Iden";
            this.Iden.Name = "Iden";
            this.Iden.Visible = true;
            this.Iden.VisibleIndex = 0;
            this.Iden.Width = 69;
            // 
            // woCode
            // 
            this.woCode.Caption = "生产令号";
            this.woCode.FieldName = "WoCode";
            this.woCode.Name = "woCode";
            this.woCode.Visible = true;
            this.woCode.VisibleIndex = 1;
            this.woCode.Width = 144;
            // 
            // WoVersion
            // 
            this.WoVersion.Caption = "版本";
            this.WoVersion.FieldName = "WoVersion";
            this.WoVersion.Name = "WoVersion";
            this.WoVersion.Visible = true;
            this.WoVersion.VisibleIndex = 2;
            this.WoVersion.Width = 65;
            // 
            // CParentId
            // 
            this.CParentId.Caption = "产品代号";
            this.CParentId.FieldName = "CParentId";
            this.CParentId.Name = "CParentId";
            this.CParentId.Visible = true;
            this.CParentId.VisibleIndex = 3;
            this.CParentId.Width = 136;
            // 
            // CParentName
            // 
            this.CParentName.Caption = "产品名称";
            this.CParentName.FieldName = "CParentName";
            this.CParentName.Name = "CParentName";
            this.CParentName.Visible = true;
            this.CParentName.VisibleIndex = 4;
            this.CParentName.Width = 154;
            // 
            // Qty
            // 
            this.Qty.Caption = "数量";
            this.Qty.FieldName = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Visible = true;
            this.Qty.VisibleIndex = 5;
            this.Qty.Width = 74;
            // 
            // IsClose
            // 
            this.IsClose.Caption = "是否关闭";
            this.IsClose.FieldName = "Isclose";
            this.IsClose.Name = "IsClose";
            this.IsClose.Visible = true;
            this.IsClose.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.DisplayValueChecked = "1";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "0";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // txtwocode
            // 
            this.txtwocode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "WoCode", true));
            this.txtwocode.Location = new System.Drawing.Point(54, 2);
            this.txtwocode.MenuManager = this.ribbonMain;
            this.txtwocode.Name = "txtwocode";
            this.txtwocode.Size = new System.Drawing.Size(312, 20);
            this.txtwocode.StyleController = this.lcMain;
            this.txtwocode.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtwocode;
            this.layoutControlItem1.CustomizationFormText = "生产令单";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(368, 24);
            this.layoutControlItem1.Text = "生产令单";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtwoversion
            // 
            this.txtwoversion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "WoVersion", true));
            this.txtwoversion.Location = new System.Drawing.Point(54, 26);
            this.txtwoversion.MenuManager = this.ribbonMain;
            this.txtwoversion.Name = "txtwoversion";
            this.txtwoversion.Size = new System.Drawing.Size(312, 20);
            this.txtwoversion.StyleController = this.lcMain;
            this.txtwoversion.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtwoversion;
            this.layoutControlItem2.CustomizationFormText = "版本";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(368, 24);
            this.layoutControlItem2.Text = "版本";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // luparentid
            // 
            this.luparentid.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "CParentId", true));
            this.luparentid.EditValue = "";
            this.luparentid.Location = new System.Drawing.Point(54, 50);
            this.luparentid.MenuManager = this.ribbonMain;
            this.luparentid.Name = "luparentid";
            this.luparentid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.luparentid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luparentid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Iden", "Iden", 48, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("产品代号", "产品代号", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.luparentid.Properties.DataSource = this.bsProd;
            this.luparentid.Properties.DisplayMember = "产品代号";
            this.luparentid.Properties.DropDownRows = 100;
            this.luparentid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luparentid.Properties.ValueMember = "产品代号";
            this.luparentid.Size = new System.Drawing.Size(312, 20);
            this.luparentid.StyleController = this.lcMain;
            this.luparentid.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.luparentid;
            this.layoutControlItem3.CustomizationFormText = "产品代号";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(368, 24);
            this.layoutControlItem3.Text = "产品代号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtparentname
            // 
            this.txtparentname.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "CParentName", true));
            this.txtparentname.Location = new System.Drawing.Point(54, 74);
            this.txtparentname.MenuManager = this.ribbonMain;
            this.txtparentname.Name = "txtparentname";
            this.txtparentname.Size = new System.Drawing.Size(312, 20);
            this.txtparentname.StyleController = this.lcMain;
            this.txtparentname.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtparentname;
            this.layoutControlItem4.CustomizationFormText = "产品名称";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(368, 24);
            this.layoutControlItem4.Text = "产品名称";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // spdqty
            // 
            this.spdqty.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Qty", true));
            this.spdqty.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spdqty.Location = new System.Drawing.Point(54, 98);
            this.spdqty.MenuManager = this.ribbonMain;
            this.spdqty.Name = "spdqty";
            this.spdqty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spdqty.Size = new System.Drawing.Size(312, 20);
            this.spdqty.StyleController = this.lcMain;
            this.spdqty.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spdqty;
            this.layoutControlItem5.CustomizationFormText = "数量";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(368, 24);
            this.layoutControlItem5.Text = "数量";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // cmbisclose
            // 
            this.cmbisclose.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsClose", true));
            this.cmbisclose.Location = new System.Drawing.Point(54, 122);
            this.cmbisclose.MenuManager = this.ribbonMain;
            this.cmbisclose.Name = "cmbisclose";
            this.cmbisclose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbisclose.Properties.Items.AddRange(new object[] {
            "",
            "关闭"});
            this.cmbisclose.Size = new System.Drawing.Size(312, 20);
            this.cmbisclose.StyleController = this.lcMain;
            this.cmbisclose.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cmbisclose;
            this.layoutControlItem6.CustomizationFormText = "是否关闭";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(368, 141);
            this.layoutControlItem6.Text = "是否关闭";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // woOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "woOrderView";
            this.Size = new System.Drawing.Size(1108, 475);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwocode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtwoversion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luparentid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtparentname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdqty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbisclose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn Iden;
        private DevExpress.XtraGrid.Columns.GridColumn woCode;
        private DevExpress.XtraGrid.Columns.GridColumn CParentId;
        private DevExpress.XtraGrid.Columns.GridColumn CParentName;
        private DevExpress.XtraEditors.SpinEdit spdqty;
        private DevExpress.XtraEditors.TextEdit txtparentname;
        private DevExpress.XtraEditors.LookUpEdit luparentid;
        private DevExpress.XtraEditors.TextEdit txtwoversion;
        private DevExpress.XtraEditors.TextEdit txtwocode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn Qty;
        private DevExpress.XtraGrid.Columns.GridColumn WoVersion;
        private DevExpress.XtraGrid.Columns.GridColumn IsClose;
        private System.Windows.Forms.BindingSource bsProd;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbisclose;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
