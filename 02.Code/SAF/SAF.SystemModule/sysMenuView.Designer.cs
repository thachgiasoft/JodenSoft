namespace SAF.SystemModule
{
    partial class sysMenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysMenuView));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.chkIsAutoOpen = new DevExpress.XtraEditors.CheckEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtMenuOrder = new DevExpress.XtraEditors.TextEdit();
            this.gseBusinessView = new SAF.Framework.Controls.GridSearchEdit();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.tluParent = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.treeMenu = new DevExpress.XtraTreeList.TreeList();
            this.colKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection();
            this.tcParams = new DevExpress.XtraTab.XtraTabControl();
            this.pageParams = new DevExpress.XtraTab.XtraTabPage();
            this.grdParams = new DevExpress.XtraGrid.GridControl();
            this.bsParams = new System.Windows.Forms.BindingSource();
            this.grvParams = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAutoOpen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gseBusinessView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tluParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcParams)).BeginInit();
            this.tcParams.SuspendLayout();
            this.pageParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParams)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(792, 120);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.treeMenu);
            this.splitMain.Size = new System.Drawing.Size(792, 321);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.SystemEntities.sysMenu);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.SystemEntities.sysMenu);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(792, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(1, 470);
            this.pnlPageControl.Size = new System.Drawing.Size(792, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(788, 26);
            // 
            // splitRight
            // 
            this.splitRight.Panel2.Controls.Add(this.tcParams);
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitRight.Size = new System.Drawing.Size(505, 317);
            this.splitRight.SplitterPosition = 120;
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(505, 120);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Size = new System.Drawing.Size(499, 114);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.chkIsAutoOpen);
            this.lcMain.Controls.Add(this.txtName);
            this.lcMain.Controls.Add(this.txtMenuOrder);
            this.lcMain.Controls.Add(this.gseBusinessView);
            this.lcMain.Controls.Add(this.txtRemark);
            this.lcMain.Controls.Add(this.tluParent);
            this.lcMain.Controls.Add(this.txtIden);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(499, 114);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // chkIsAutoOpen
            // 
            this.chkIsAutoOpen.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsAutoOpen", true));
            this.chkIsAutoOpen.Location = new System.Drawing.Point(363, 26);
            this.chkIsAutoOpen.MenuManager = this.ribbonMain;
            this.chkIsAutoOpen.Name = "chkIsAutoOpen";
            this.chkIsAutoOpen.Properties.Caption = "默认打开";
            this.chkIsAutoOpen.Size = new System.Drawing.Size(134, 19);
            this.chkIsAutoOpen.StyleController = this.lcMain;
            this.chkIsAutoOpen.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Name", true));
            this.txtName.Location = new System.Drawing.Point(53, 2);
            this.txtName.MenuManager = this.ribbonMain;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 20);
            this.txtName.StyleController = this.lcMain;
            this.txtName.TabIndex = 5;
            // 
            // txtMenuOrder
            // 
            this.txtMenuOrder.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MenuOrder", true));
            this.txtMenuOrder.Location = new System.Drawing.Point(276, 2);
            this.txtMenuOrder.MenuManager = this.ribbonMain;
            this.txtMenuOrder.Name = "txtMenuOrder";
            this.txtMenuOrder.Size = new System.Drawing.Size(83, 20);
            this.txtMenuOrder.StyleController = this.lcMain;
            this.txtMenuOrder.TabIndex = 10;
            // 
            // gseBusinessView
            // 
            this.gseBusinessView.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "BusinessView", true));
            this.gseBusinessView.Location = new System.Drawing.Point(53, 50);
            this.gseBusinessView.MenuManager = this.ribbonMain;
            this.gseBusinessView.Name = "gseBusinessView";
            this.gseBusinessView.Properties.AutoClearSearchFiledsValue = true;
            this.gseBusinessView.Properties.AutoFillEntitySet = null;
            this.gseBusinessView.Properties.AutoFillFieldNames = null;
            this.gseBusinessView.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.gseBusinessView.Properties.ColumnHeaders = null;
            this.gseBusinessView.Properties.CommandText = null;
            this.gseBusinessView.Properties.ConnectionName = "Default";
            this.gseBusinessView.Properties.DisplayMember = null;
            this.gseBusinessView.Properties.PageSize = 50;
            this.gseBusinessView.Properties.SearchFileds = "";
            this.gseBusinessView.Properties.ShowPageControl = true;
            this.gseBusinessView.Size = new System.Drawing.Size(444, 20);
            this.gseBusinessView.StyleController = this.lcMain;
            this.gseBusinessView.TabIndex = 7;
            // 
            // txtRemark
            // 
            this.txtRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Remark", true));
            this.txtRemark.Location = new System.Drawing.Point(53, 74);
            this.txtRemark.MenuManager = this.ribbonMain;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(444, 38);
            this.txtRemark.StyleController = this.lcMain;
            this.txtRemark.TabIndex = 9;
            this.txtRemark.UseOptimizedRendering = true;
            // 
            // tluParent
            // 
            this.tluParent.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "ParentId", true));
            this.tluParent.EditValue = "";
            this.tluParent.Location = new System.Drawing.Point(53, 26);
            this.tluParent.MenuManager = this.ribbonMain;
            this.tluParent.Name = "tluParent";
            this.tluParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.tluParent.Properties.NullText = "";
            this.tluParent.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.tluParent.Size = new System.Drawing.Size(306, 20);
            this.tluParent.StyleController = this.lcMain;
            this.tluParent.TabIndex = 6;
            this.tluParent.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.treeListLookUpEdit1_ButtonClick);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(414, 2);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(83, 20);
            this.txtIden.StyleController = this.lcMain;
            this.txtIden.TabIndex = 4;
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem7});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(499, 114);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.CustomizationFormText = "菜单名称";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(223, 24);
            this.layoutControlItem2.Text = "菜单名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtIden;
            this.layoutControlItem1.CustomizationFormText = "菜单ID";
            this.layoutControlItem1.Location = new System.Drawing.Point(361, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(138, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "菜单ID";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtMenuOrder;
            this.layoutControlItem5.CustomizationFormText = "菜单序号";
            this.layoutControlItem5.Location = new System.Drawing.Point(223, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(138, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(138, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "菜单序号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gseBusinessView;
            this.layoutControlItem4.CustomizationFormText = "业务界面";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(499, 24);
            this.layoutControlItem4.Text = "业务界面";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRemark;
            this.layoutControlItem6.CustomizationFormText = "备注";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(499, 42);
            this.layoutControlItem6.Text = "备注";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.tluParent;
            this.layoutControlItem3.CustomizationFormText = "上级菜单";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(361, 24);
            this.layoutControlItem3.Text = "上级菜单";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkIsAutoOpen;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(361, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(138, 24);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // treeMenu
            // 
            this.treeMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colKey});
            this.treeMenu.DataSource = this.bsIndex;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(0, 2);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.OptionsBehavior.AutoChangeParent = false;
            this.treeMenu.OptionsBehavior.AutoNodeHeight = false;
            this.treeMenu.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeMenu.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeMenu.OptionsBehavior.Editable = false;
            this.treeMenu.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeMenu.OptionsBehavior.ResizeNodes = false;
            this.treeMenu.OptionsBehavior.SmartMouseHover = false;
            this.treeMenu.OptionsMenu.EnableFooterMenu = false;
            this.treeMenu.OptionsPrint.PrintHorzLines = false;
            this.treeMenu.OptionsPrint.PrintVertLines = false;
            this.treeMenu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeMenu.OptionsView.ShowColumns = false;
            this.treeMenu.OptionsView.ShowFocusedFrame = false;
            this.treeMenu.OptionsView.ShowHorzLines = false;
            this.treeMenu.OptionsView.ShowIndicator = false;
            this.treeMenu.OptionsView.ShowVertLines = false;
            this.treeMenu.SelectImageList = this.imageCollectionTreeList;
            this.treeMenu.Size = new System.Drawing.Size(282, 317);
            this.treeMenu.TabIndex = 1;
            this.treeMenu.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colKey
            // 
            this.colKey.Caption = "Name";
            this.colKey.FieldName = "Name";
            this.colKey.MinWidth = 33;
            this.colKey.Name = "colKey";
            this.colKey.SummaryFooterStrFormat = "";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "forms.png");
            // 
            // tcParams
            // 
            this.tcParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcParams.Location = new System.Drawing.Point(0, 0);
            this.tcParams.Name = "tcParams";
            this.tcParams.SelectedTabPage = this.pageParams;
            this.tcParams.Size = new System.Drawing.Size(505, 192);
            this.tcParams.TabIndex = 0;
            this.tcParams.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageParams});
            // 
            // pageParams
            // 
            this.pageParams.Controls.Add(this.grdParams);
            this.pageParams.Name = "pageParams";
            this.pageParams.Padding = new System.Windows.Forms.Padding(2);
            this.pageParams.Size = new System.Drawing.Size(499, 163);
            this.pageParams.Text = "菜单参数";
            // 
            // grdParams
            // 
            this.grdParams.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdParams.DataSource = this.bsParams;
            this.grdParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdParams.Location = new System.Drawing.Point(2, 2);
            this.grdParams.MainView = this.grvParams;
            this.grdParams.MenuManager = this.ribbonMain;
            this.grdParams.Name = "grdParams";
            this.grdParams.Size = new System.Drawing.Size(495, 159);
            this.grdParams.TabIndex = 0;
            this.grdParams.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParams});
            // 
            // bsParams
            // 
            this.bsParams.DataSource = typeof(SAF.SystemEntities.sysMenuParam);
            // 
            // grvParams
            // 
            this.grvParams.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colValue,
            this.colDescription});
            this.grvParams.GridControl = this.grdParams;
            this.grvParams.Name = "grvParams";
            this.grvParams.OptionsView.ColumnAutoWidth = false;
            this.grvParams.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "参数名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colValue
            // 
            this.colValue.Caption = "参数值";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "参数描述";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            // 
            // sysMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysMenuView";
            this.Size = new System.Drawing.Size(794, 502);
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
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAutoOpen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMenuOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gseBusinessView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tluParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcParams)).EndInit();
            this.tcParams.ResumeLayout(false);
            this.pageParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraEditors.TreeListLookUpEdit tluParent;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private Framework.Controls.GridSearchEdit gseBusinessView;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraTreeList.TreeList treeMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKey;
        private DevExpress.XtraEditors.TextEdit txtMenuOrder;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraTab.XtraTabControl tcParams;
        private DevExpress.XtraTab.XtraTabPage pageParams;
        private DevExpress.XtraGrid.GridControl grdParams;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParams;
        private System.Windows.Forms.BindingSource bsParams;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.CheckEdit chkIsAutoOpen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
