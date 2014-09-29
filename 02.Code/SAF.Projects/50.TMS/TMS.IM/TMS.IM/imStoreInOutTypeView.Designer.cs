namespace TMS.IM
{
    partial class imStoreInOutTypeView
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
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtType = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUp = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpAuto = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAuto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.bsIndex.DataSource = typeof(TMS.Entities.imStoreInOutType);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(TMS.Entities.imStoreInOutType);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(763, 26);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.checkBox);
            this.lcMain.Controls.Add(this.lookUpAuto);
            this.lcMain.Controls.Add(this.lookUpType);
            this.lcMain.Controls.Add(this.lookUp);
            this.lcMain.Controls.Add(this.txtType);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(474, 261);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(474, 261);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtType;
            this.layoutControlItem3.CustomizationFormText = "出库类型";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem3.Text = "操作类型";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtType
            // 
            this.txtType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sStoreInOutName", true));
            this.txtType.Location = new System.Drawing.Point(53, 2);
            this.txtType.MenuManager = this.ribbonMain;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(419, 20);
            this.txtType.StyleController = this.lcMain;
            this.txtType.TabIndex = 4;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookUp;
            this.layoutControlItem6.CustomizationFormText = "方向标号";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem6.Text = "方向标号";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // lookUp
            // 
            this.lookUp.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sStoreInOutType", true));
            this.lookUp.EditValue = "+";
            this.lookUp.Location = new System.Drawing.Point(53, 26);
            this.lookUp.MenuManager = this.ribbonMain;
            this.lookUp.Name = "lookUp";
            this.lookUp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name1", "Name1"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name2", "Name2")});
            this.lookUp.Properties.DataSource = this.bsMain;
            this.lookUp.Size = new System.Drawing.Size(419, 20);
            this.lookUp.StyleController = this.lcMain;
            this.lookUp.TabIndex = 6;
            this.lookUp.EditValueChanged += new System.EventHandler(this.lookUp_EditValueChanged);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lookUpType;
            this.layoutControlItem5.CustomizationFormText = "收付类型";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem5.Text = "收付类型";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // lookUpType
            // 
            this.lookUpType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "iReceivePayType", true));
            this.lookUpType.EditValue = ((short)(0));
            this.lookUpType.Location = new System.Drawing.Point(53, 50);
            this.lookUpType.MenuManager = this.ribbonMain;
            this.lookUpType.Name = "lookUpType";
            this.lookUpType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpType.Size = new System.Drawing.Size(419, 20);
            this.lookUpType.StyleController = this.lcMain;
            this.lookUpType.TabIndex = 7;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lookUpAuto;
            this.layoutControlItem7.CustomizationFormText = "自动产生";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem7.Text = "自动产生";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // lookUpAuto
            // 
            this.lookUpAuto.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "iAutoCreateType", true));
            this.lookUpAuto.EditValue = "0";
            this.lookUpAuto.Location = new System.Drawing.Point(53, 74);
            this.lookUpAuto.MenuManager = this.ribbonMain;
            this.lookUpAuto.Name = "lookUpAuto";
            this.lookUpAuto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpAuto.Size = new System.Drawing.Size(419, 20);
            this.lookUpAuto.StyleController = this.lcMain;
            this.lookUpAuto.TabIndex = 8;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkBox;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(474, 165);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // checkBox
            // 
            this.checkBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckAlign", this.bsMain, "bUsable", true));
            this.checkBox.Location = new System.Drawing.Point(2, 98);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(470, 20);
            this.checkBox.TabIndex = 9;
            this.checkBox.Text = "是否启用";
            this.checkBox.UseVisualStyleBackColor = true;
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
            this.grdIndex.TabIndex = 1;
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
            this.colName.Caption = "操作类型";
            this.colName.FieldName = "sStoreInOutName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 88;
            // 
            // colNo
            // 
            this.colNo.Caption = "方向标识";
            this.colNo.FieldName = "sStoreInOutType";
            this.colNo.Name = "colNo";
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 2;
            this.colNo.Width = 88;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.CustomizationFormText = "Iden";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem1.Text = "流水编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.CustomizationFormText = "仓库编号";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem4.Text = "仓库编号";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.CustomizationFormText = "Name";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(474, 213);
            this.layoutControlItem2.Text = "仓库名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // imStoreInOutTypeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "imStoreInOutTypeView";
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpAuto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit lookUp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.CheckBox checkBox;
        private DevExpress.XtraEditors.LookUpEdit lookUpAuto;
        private DevExpress.XtraEditors.LookUpEdit lookUpType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
