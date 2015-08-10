namespace FSDProdPlan
{
    partial class jdRecourseView
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
            this.colInvCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecourse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCycle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.spCycle = new DevExpress.XtraEditors.SpinEdit();
            this.txtRecourse = new DevExpress.XtraEditors.TextEdit();
            this.txtInvName = new DevExpress.XtraEditors.TextEdit();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.txtInvCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.spCycle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecourse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.splitMain.SplitterPosition = 420;
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(FSDProdPlan.jdRecourse);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(FSDProdPlan.jdRecourse);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(357, 284);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(357, 284);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.layoutControl1);
            this.pageMain.Size = new System.Drawing.Size(351, 278);
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
            this.grdIndex.Size = new System.Drawing.Size(420, 284);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colInvCode,
            this.colInvName,
            this.colRecourse,
            this.colCycle});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
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
            this.colIden.Width = 61;
            // 
            // colInvCode
            // 
            this.colInvCode.Caption = "存货编码";
            this.colInvCode.FieldName = "InvCode";
            this.colInvCode.Name = "colInvCode";
            this.colInvCode.Visible = true;
            this.colInvCode.VisibleIndex = 1;
            this.colInvCode.Width = 104;
            // 
            // colInvName
            // 
            this.colInvName.Caption = "存货名称";
            this.colInvName.FieldName = "InvName";
            this.colInvName.Name = "colInvName";
            this.colInvName.Visible = true;
            this.colInvName.VisibleIndex = 2;
            this.colInvName.Width = 92;
            // 
            // colRecourse
            // 
            this.colRecourse.Caption = "机台";
            this.colRecourse.FieldName = "Recourse";
            this.colRecourse.Name = "colRecourse";
            this.colRecourse.Visible = true;
            this.colRecourse.VisibleIndex = 3;
            this.colRecourse.Width = 80;
            // 
            // colCycle
            // 
            this.colCycle.Caption = "周期";
            this.colCycle.FieldName = "Cycle";
            this.colCycle.Name = "colCycle";
            this.colCycle.Visible = true;
            this.colCycle.VisibleIndex = 4;
            this.colCycle.Width = 65;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.spCycle);
            this.layoutControl1.Controls.Add(this.txtRecourse);
            this.layoutControl1.Controls.Add(this.txtInvName);
            this.layoutControl1.Controls.Add(this.txtIden);
            this.layoutControl1.Controls.Add(this.txtInvCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(351, 278);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // spCycle
            // 
            this.spCycle.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Cycle", true));
            this.spCycle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spCycle.Location = new System.Drawing.Point(63, 84);
            this.spCycle.MenuManager = this.ribbonMain;
            this.spCycle.Name = "spCycle";
            this.spCycle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spCycle.Size = new System.Drawing.Size(276, 20);
            this.spCycle.StyleController = this.layoutControl1;
            this.spCycle.TabIndex = 8;
            // 
            // txtRecourse
            // 
            this.txtRecourse.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Recourse", true));
            this.txtRecourse.Location = new System.Drawing.Point(63, 60);
            this.txtRecourse.MenuManager = this.ribbonMain;
            this.txtRecourse.Name = "txtRecourse";
            this.txtRecourse.Size = new System.Drawing.Size(276, 20);
            this.txtRecourse.StyleController = this.layoutControl1;
            this.txtRecourse.TabIndex = 7;
            // 
            // txtInvName
            // 
            this.txtInvName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "InvName", true));
            this.txtInvName.Location = new System.Drawing.Point(63, 36);
            this.txtInvName.MenuManager = this.ribbonMain;
            this.txtInvName.Name = "txtInvName";
            this.txtInvName.Size = new System.Drawing.Size(276, 20);
            this.txtInvName.StyleController = this.layoutControl1;
            this.txtInvName.TabIndex = 6;
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Enabled = false;
            this.txtIden.Location = new System.Drawing.Point(289, 12);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(50, 20);
            this.txtIden.StyleController = this.layoutControl1;
            this.txtIden.TabIndex = 5;
            // 
            // txtInvCode
            // 
            this.txtInvCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "InvCode", true));
            this.txtInvCode.Location = new System.Drawing.Point(63, 12);
            this.txtInvCode.MenuManager = this.ribbonMain;
            this.txtInvCode.Name = "txtInvCode";
            this.txtInvCode.Size = new System.Drawing.Size(193, 20);
            this.txtInvCode.StyleController = this.layoutControl1;
            this.txtInvCode.TabIndex = 4;
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
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(351, 278);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtInvCode;
            this.layoutControlItem1.CustomizationFormText = "存货编码";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(248, 24);
            this.layoutControlItem1.Text = "存货编码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtIden;
            this.layoutControlItem2.CustomizationFormText = "序号";
            this.layoutControlItem2.Location = new System.Drawing.Point(248, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(83, 24);
            this.layoutControlItem2.Text = "序号";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtInvName;
            this.layoutControlItem3.CustomizationFormText = "存货名称";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(331, 24);
            this.layoutControlItem3.Text = "存货名称";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRecourse;
            this.layoutControlItem4.CustomizationFormText = "机台";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(331, 24);
            this.layoutControlItem4.Text = "机台";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spCycle;
            this.layoutControlItem5.CustomizationFormText = "周期";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(331, 186);
            this.layoutControlItem5.Text = "周期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // jdRecourseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "jdRecourseView";
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
            ((System.ComponentModel.ISupportInitialize)(this.spCycle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecourse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SpinEdit spCycle;
        private DevExpress.XtraEditors.TextEdit txtRecourse;
        private DevExpress.XtraEditors.TextEdit txtInvName;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraEditors.TextEdit txtInvCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colInvCode;
        private DevExpress.XtraGrid.Columns.GridColumn colInvName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecourse;
        private DevExpress.XtraGrid.Columns.GridColumn colCycle;
    }
}
