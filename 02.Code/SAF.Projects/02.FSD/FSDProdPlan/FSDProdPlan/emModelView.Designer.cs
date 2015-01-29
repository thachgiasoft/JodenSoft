namespace FSDProdPlan
{
    partial class emModelView
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
            this.coluGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colssEquipmentModelNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtsEquipmentName = new DevExpress.XtraEditors.TextEdit();
            this.txtsEquipmentNo = new DevExpress.XtraEditors.TextEdit();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtsEquipmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsEquipmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.bsIndex.DataSource = typeof(FSDProdPlan.emModel);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(FSDProdPlan.emModel);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
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
            this.grdIndex.Size = new System.Drawing.Size(282, 284);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.coluGuid,
            this.colssEquipmentModelNo});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            this.grvIndex.OptionsView.ShowGroupPanel = false;
            this.grvIndex.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvIndex_FocusedRowChanged);
            // 
            // colIden
            // 
            this.colIden.Caption = "序号";
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // coluGuid
            // 
            this.coluGuid.FieldName = "uGuid";
            this.coluGuid.Name = "coluGuid";
            // 
            // colssEquipmentModelNo
            // 
            this.colssEquipmentModelNo.Caption = "机型编码";
            this.colssEquipmentModelNo.FieldName = "sEquipmentModelNo";
            this.colssEquipmentModelNo.Name = "colssEquipmentModelNo";
            this.colssEquipmentModelNo.Visible = true;
            this.colssEquipmentModelNo.VisibleIndex = 1;
            this.colssEquipmentModelNo.Width = 149;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtsEquipmentName);
            this.layoutControl1.Controls.Add(this.txtsEquipmentNo);
            this.layoutControl1.Controls.Add(this.txtIden);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(489, 278);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtsEquipmentName
            // 
            this.txtsEquipmentName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sEquipmentModelName", true));
            this.txtsEquipmentName.Location = new System.Drawing.Point(63, 60);
            this.txtsEquipmentName.MenuManager = this.ribbonMain;
            this.txtsEquipmentName.Name = "txtsEquipmentName";
            this.txtsEquipmentName.Size = new System.Drawing.Size(414, 20);
            this.txtsEquipmentName.StyleController = this.layoutControl1;
            this.txtsEquipmentName.TabIndex = 6;
            // 
            // txtsEquipmentNo
            // 
            this.txtsEquipmentNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sEquipmentModelNo", true));
            this.txtsEquipmentNo.Location = new System.Drawing.Point(63, 36);
            this.txtsEquipmentNo.MenuManager = this.ribbonMain;
            this.txtsEquipmentNo.Name = "txtsEquipmentNo";
            this.txtsEquipmentNo.Size = new System.Drawing.Size(414, 20);
            this.txtsEquipmentNo.StyleController = this.layoutControl1;
            this.txtsEquipmentNo.TabIndex = 5;
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Enabled = false;
            this.txtIden.Location = new System.Drawing.Point(63, 12);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(414, 20);
            this.txtIden.StyleController = this.layoutControl1;
            this.txtIden.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(489, 278);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtIden;
            this.layoutControlItem1.CustomizationFormText = "序号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem1.Text = "序号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtsEquipmentNo;
            this.layoutControlItem2.CustomizationFormText = "机器编码";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem2.Text = "机型编码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtsEquipmentName;
            this.layoutControlItem3.CustomizationFormText = "机器名称";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(469, 210);
            this.layoutControlItem3.Text = "机型名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "emModelView";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtsEquipmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtsEquipmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn coluGuid;
        private DevExpress.XtraGrid.Columns.GridColumn colssEquipmentModelNo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtsEquipmentName;
        private DevExpress.XtraEditors.TextEdit txtsEquipmentNo;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
