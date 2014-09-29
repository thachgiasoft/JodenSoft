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
            this.gluUsers = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.gluUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcDtl
            // 
            this.tcDtl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcDtl.Size = new System.Drawing.Size(685, 298);
            // 
            // pageDtl
            // 
            this.pageDtl.Controls.Add(this.grdDtl);
            this.pageDtl.Controls.Add(this.panelControl1);
            this.pageDtl.Size = new System.Drawing.Size(679, 292);
            this.pageDtl.Controls.SetChildIndex(this.pnlDtlToolbar, 0);
            this.pageDtl.Controls.SetChildIndex(this.panelControl1, 0);
            this.pageDtl.Controls.SetChildIndex(this.grdDtl, 0);
            // 
            // pnlDtlToolbar
            // 
            this.pnlDtlToolbar.Size = new System.Drawing.Size(679, 29);
            // 
            // bsDetail
            // 
            this.bsDetail.DataSource = typeof(SAF.CommonConfig.sdOrderDtl);
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(972, 145);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            this.splitMain.Size = new System.Drawing.Size(972, 437);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.CommonConfig.sdOrder);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.CommonConfig.sdOrder);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(972, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(0, 610);
            this.pnlPageControl.Size = new System.Drawing.Size(972, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(968, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(685, 433);
            // 
            // tcMain
            // 
            this.tcMain.Size = new System.Drawing.Size(685, 130);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Size = new System.Drawing.Size(679, 124);
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
            this.grdIndex.Size = new System.Drawing.Size(282, 433);
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
            // grdDtl
            // 
            this.grdDtl.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDtl.DataSource = this.bsDetail;
            this.grdDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDtl.Location = new System.Drawing.Point(0, 125);
            this.grdDtl.MainView = this.grvDtl;
            this.grdDtl.MenuManager = this.ribbonMain;
            this.grdDtl.Name = "grdDtl";
            this.grdDtl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gluUsers});
            this.grdDtl.Size = new System.Drawing.Size(679, 167);
            this.grdDtl.TabIndex = 1;
            this.grdDtl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDtl});
            // 
            // grvDtl
            // 
            this.grvDtl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden1});
            this.grvDtl.GridControl = this.grdDtl;
            this.grvDtl.Name = "grvDtl";
            this.grvDtl.OptionsView.ColumnAutoWidth = false;
            // 
            // colIden1
            // 
            this.colIden1.FieldName = "Iden";
            this.colIden1.Name = "colIden1";
            this.colIden1.Visible = true;
            this.colIden1.VisibleIndex = 0;
            this.colIden1.Width = 134;
            // 
            // gluUsers
            // 
            this.gluUsers.AutoHeight = false;
            this.gluUsers.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gluUsers.Name = "gluUsers";
            this.gluUsers.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 29);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(679, 96);
            this.panelControl1.TabIndex = 2;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.textEdit2.Location = new System.Drawing.Point(30, 2);
            this.textEdit2.MenuManager = this.ribbonMain;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(647, 20);
            this.textEdit2.StyleController = this.lcMain;
            this.textEdit2.TabIndex = 4;
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.textEdit2);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(679, 124);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(679, 124);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit2;
            this.layoutControlItem1.CustomizationFormText = "Iden";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(679, 124);
            this.layoutControlItem1.Text = "Iden";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(25, 14);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(675, 92);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(675, 92);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsDetail, "Iden", true));
            this.textEdit1.Location = new System.Drawing.Point(56, 12);
            this.textEdit1.MenuManager = this.ribbonMain;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(607, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 4;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit1;
            this.layoutControlItem2.CustomizationFormText = "DtlIden";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(655, 72);
            this.layoutControlItem2.Text = "DtlIden";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 14);
            // 
            // sysCommonBillConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysCommonBillConfigView";
            this.Size = new System.Drawing.Size(972, 641);
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
            ((System.ComponentModel.ISupportInitialize)(this.gluUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion




        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;

        private DevExpress.XtraGrid.GridControl grdDtl;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDtl;
        private DevExpress.XtraGrid.Columns.GridColumn colIden1;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit gluUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
