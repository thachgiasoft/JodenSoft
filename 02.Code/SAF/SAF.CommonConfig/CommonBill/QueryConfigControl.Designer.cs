namespace SAF.CommonConfig.CommonBill
{
    partial class QueryConfigControl
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
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.grdField = new DevExpress.XtraGrid.GridControl();
            this.bsQuickQueryFields = new System.Windows.Forms.BindingSource(this.components);
            this.grvFields = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFieldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCaption = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkIsDefault = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cbxQuickQueryType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.bsQuickQuery = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tcQueryConfig = new DevExpress.XtraTab.XtraTabControl();
            this.pageQuickQuery = new DevExpress.XtraTab.XtraTabPage();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnDown = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQuickQueryFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxQuickQueryType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQuickQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcQueryConfig)).BeginInit();
            this.tcQueryConfig.SuspendLayout();
            this.pageQuickQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.standaloneBarDockControl1);
            this.lcMain.Controls.Add(this.grdField);
            this.lcMain.Controls.Add(this.cbxQuickQueryType);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(477, 334);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(7, 54);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(463, 36);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // grdField
            // 
            this.grdField.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdField.DataSource = this.bsQuickQueryFields;
            this.grdField.Location = new System.Drawing.Point(7, 94);
            this.grdField.MainView = this.grvFields;
            this.grdField.Name = "grdField";
            this.grdField.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkIsDefault});
            this.grdField.Size = new System.Drawing.Size(463, 233);
            this.grdField.TabIndex = 5;
            this.grdField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFields});
            // 
            // grvFields
            // 
            this.grvFields.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFieldName,
            this.colCaption,
            this.colIsDefault});
            this.grvFields.GridControl = this.grdField;
            this.grvFields.Name = "grvFields";
            this.grvFields.OptionsView.ColumnAutoWidth = false;
            this.grvFields.OptionsView.ShowGroupPanel = false;
            // 
            // colFieldName
            // 
            this.colFieldName.Caption = "字段名";
            this.colFieldName.FieldName = "FieldName";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.Visible = true;
            this.colFieldName.VisibleIndex = 0;
            // 
            // colCaption
            // 
            this.colCaption.Caption = "字段标题";
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 1;
            // 
            // colIsDefault
            // 
            this.colIsDefault.Caption = "默认字段";
            this.colIsDefault.ColumnEdit = this.chkIsDefault;
            this.colIsDefault.FieldName = "IsDefault";
            this.colIsDefault.Name = "colIsDefault";
            this.colIsDefault.Visible = true;
            this.colIsDefault.VisibleIndex = 2;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoHeight = false;
            this.chkIsDefault.Caption = "Check";
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkIsDefault.ValueGrayed = false;
            // 
            // cbxQuickQueryType
            // 
            this.cbxQuickQueryType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsQuickQuery, "QuickQueryType", true));
            this.cbxQuickQueryType.Location = new System.Drawing.Point(54, 3);
            this.cbxQuickQueryType.Name = "cbxQuickQueryType";
            this.cbxQuickQueryType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxQuickQueryType.Size = new System.Drawing.Size(420, 20);
            this.cbxQuickQueryType.StyleController = this.lcMain;
            this.cbxQuickQueryType.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(477, 334);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbxQuickQueryType;
            this.layoutControlItem1.CustomizationFormText = "速查类型";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(475, 24);
            this.layoutControlItem1.Text = "速查类型";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "速查字段";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 24);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(475, 308);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.tabbedControlGroup1.Text = "速查字段";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "速查字段";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(467, 277);
            this.layoutControlGroup2.Text = "速查字段";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdField;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(467, 237);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.standaloneBarDockControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(467, 40);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // tcQueryConfig
            // 
            this.tcQueryConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcQueryConfig.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tcQueryConfig.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tcQueryConfig.Location = new System.Drawing.Point(0, 0);
            this.tcQueryConfig.Name = "tcQueryConfig";
            this.tcQueryConfig.SelectedTabPage = this.pageQuickQuery;
            this.tcQueryConfig.Size = new System.Drawing.Size(545, 340);
            this.tcQueryConfig.TabIndex = 1;
            this.tcQueryConfig.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageQuickQuery});
            // 
            // pageQuickQuery
            // 
            this.pageQuickQuery.Controls.Add(this.lcMain);
            this.pageQuickQuery.Name = "pageQuickQuery";
            this.pageQuickQuery.Size = new System.Drawing.Size(477, 334);
            this.pageQuickQuery.Text = "速查配置";
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnUp,
            this.btnDown});
            this.barManager.MaxItemId = 4;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(346, 197);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDown)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "新增";
            this.btnAdd.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_New_16x16;
            this.btnAdd.Id = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Delete_16x16;
            this.btnDelete.Id = 1;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnUp
            // 
            this.btnUp.Caption = "上移";
            this.btnUp.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Up_16x16;
            this.btnUp.Id = 2;
            this.btnUp.Name = "btnUp";
            this.btnUp.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUp_ItemClick);
            // 
            // btnDown
            // 
            this.btnDown.Caption = "下移";
            this.btnDown.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Down_16x16;
            this.btnDown.Id = 3;
            this.btnDown.Name = "btnDown";
            this.btnDown.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDown_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(545, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 340);
            this.barDockControlBottom.Size = new System.Drawing.Size(545, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 340);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(545, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 340);
            // 
            // QueryConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcQueryConfig);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "QueryConfigControl";
            this.Size = new System.Drawing.Size(545, 340);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQuickQueryFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxQuickQueryType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQuickQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcQueryConfig)).EndInit();
            this.tcQueryConfig.ResumeLayout(false);
            this.pageQuickQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraTab.XtraTabControl tcQueryConfig;
        private DevExpress.XtraTab.XtraTabPage pageQuickQuery;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxQuickQueryType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grdField;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFields;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource bsQuickQueryFields;
        private DevExpress.XtraGrid.Columns.GridColumn colFieldName;
        private DevExpress.XtraGrid.Columns.GridColumn colCaption;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDefault;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkIsDefault;
        private System.Windows.Forms.BindingSource bsQuickQuery;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnUp;
        private DevExpress.XtraBars.BarButtonItem btnDown;
    }
}
