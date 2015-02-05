namespace SAF.CommonBill
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tcConfig = new DevExpress.XtraTab.XtraTabControl();
            this.pageIndexConfig = new DevExpress.XtraTab.XtraTabPage();
            this.indexConfig = new SAF.CommonBill.EntitySetConfigControl();
            this.pageMainConfig = new DevExpress.XtraTab.XtraTabPage();
            this.mainConfig = new SAF.CommonBill.EntitySetConfigControl();
            this.pageDetailConfig = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlDetailEntityConfig = new DevExpress.XtraEditors.PanelControl();
            this.listDetailEntitySet = new DevExpress.XtraEditors.ListBoxControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.detailConfig = new SAF.CommonBill.EntitySetConfigControl();
            this.pageQueryConfig = new DevExpress.XtraTab.XtraTabPage();
            this.queryConfig = new SAF.CommonBill.QueryConfigControl();
            this.barDetailEntitySet = new DevExpress.XtraBars.Bar();
            this.btnDetailEntitySetConfigAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDetailEntitySetConfigDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bsDetailEntitySetConfig = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcConfig)).BeginInit();
            this.tcConfig.SuspendLayout();
            this.pageIndexConfig.SuspendLayout();
            this.pageMainConfig.SuspendLayout();
            this.pageDetailConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailEntityConfig)).BeginInit();
            this.pnlDetailEntityConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDetailEntitySet)).BeginInit();
            this.pageQueryConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetailEntitySetConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(1041, 120);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            this.splitMain.Size = new System.Drawing.Size(1041, 460);
            this.splitMain.SplitterPosition = 233;
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.CommonBill.Entities.sysCommonBillConfig);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.CommonBill.Entities.sysCommonBillConfig);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(1041, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(1, 609);
            this.pnlPageControl.Size = new System.Drawing.Size(1041, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(1037, 26);
            // 
            // splitRight
            // 
            this.splitRight.Panel2.Controls.Add(this.tcConfig);
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitRight.Size = new System.Drawing.Size(803, 456);
            this.splitRight.SplitterPosition = 39;
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(803, 39);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.layoutControl1);
            this.pageMain.Size = new System.Drawing.Size(797, 33);
            // 
            // bmMain
            // 
            this.bmMain.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDetailEntitySet});
            this.bmMain.DockControls.Add(this.standaloneBarDockControl1);
            this.bmMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDetailEntitySetConfigAdd,
            this.btnDetailEntitySetConfigDelete});
            this.bmMain.MaxItemId = 8;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtIden);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(797, 33);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(709, 3);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(85, 20);
            this.txtIden.StyleController = this.layoutControl1;
            this.txtIden.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Name", true));
            this.txtName.Location = new System.Drawing.Point(30, 3);
            this.txtName.MenuManager = this.ribbonMain;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(648, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(797, 33);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.CustomizationFormText = "名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(679, 31);
            this.layoutControlItem1.Text = "名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(24, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtIden;
            this.layoutControlItem2.CustomizationFormText = "序号";
            this.layoutControlItem2.Location = new System.Drawing.Point(679, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(116, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(116, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "序号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
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
            this.grdIndex.Size = new System.Drawing.Size(233, 456);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colName});
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
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(1, 1);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.layoutControl2);
            this.splitContainerControl3.Size = new System.Drawing.Size(1041, 639);
            this.splitContainerControl3.SplitterPosition = 95;
            this.splitContainerControl3.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup5;
            this.layoutControl2.Size = new System.Drawing.Size(1041, 95);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "lcIndexEntitySet";
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup2";
            this.layoutControlGroup5.Size = new System.Drawing.Size(1041, 95);
            this.layoutControlGroup5.Text = "layoutControlGroup2";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // tcConfig
            // 
            this.tcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConfig.Location = new System.Drawing.Point(0, 0);
            this.tcConfig.Name = "tcConfig";
            this.tcConfig.SelectedTabPage = this.pageIndexConfig;
            this.tcConfig.Size = new System.Drawing.Size(803, 412);
            this.tcConfig.TabIndex = 0;
            this.tcConfig.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageIndexConfig,
            this.pageMainConfig,
            this.pageDetailConfig,
            this.pageQueryConfig});
            // 
            // pageIndexConfig
            // 
            this.pageIndexConfig.Controls.Add(this.indexConfig);
            this.pageIndexConfig.Name = "pageIndexConfig";
            this.pageIndexConfig.Size = new System.Drawing.Size(797, 383);
            this.pageIndexConfig.Text = "索引配置";
            // 
            // indexConfig
            // 
            this.indexConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexConfig.Location = new System.Drawing.Point(0, 0);
            this.indexConfig.Name = "indexConfig";
            this.indexConfig.Size = new System.Drawing.Size(797, 383);
            this.indexConfig.TabIndex = 0;
            // 
            // pageMainConfig
            // 
            this.pageMainConfig.Controls.Add(this.mainConfig);
            this.pageMainConfig.Name = "pageMainConfig";
            this.pageMainConfig.Size = new System.Drawing.Size(538, 211);
            this.pageMainConfig.Text = "主数据配置";
            // 
            // mainConfig
            // 
            this.mainConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainConfig.Location = new System.Drawing.Point(0, 0);
            this.mainConfig.Name = "mainConfig";
            this.mainConfig.Size = new System.Drawing.Size(538, 211);
            this.mainConfig.TabIndex = 0;
            // 
            // pageDetailConfig
            // 
            this.pageDetailConfig.Controls.Add(this.splitContainerControl1);
            this.pageDetailConfig.Name = "pageDetailConfig";
            this.pageDetailConfig.Size = new System.Drawing.Size(538, 211);
            this.pageDetailConfig.Text = "明细数据配置";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pnlDetailEntityConfig);
            this.splitContainerControl1.Panel1.Controls.Add(this.standaloneBarDockControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.detailConfig);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(538, 211);
            this.splitContainerControl1.SplitterPosition = 149;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pnlDetailEntityConfig
            // 
            this.pnlDetailEntityConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDetailEntityConfig.Controls.Add(this.listDetailEntitySet);
            this.pnlDetailEntityConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetailEntityConfig.Location = new System.Drawing.Point(0, 28);
            this.pnlDetailEntityConfig.Name = "pnlDetailEntityConfig";
            this.pnlDetailEntityConfig.Padding = new System.Windows.Forms.Padding(1);
            this.pnlDetailEntityConfig.Size = new System.Drawing.Size(149, 183);
            this.pnlDetailEntityConfig.TabIndex = 2;
            // 
            // listDetailEntitySet
            // 
            this.listDetailEntitySet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDetailEntitySet.Location = new System.Drawing.Point(1, 1);
            this.listDetailEntitySet.Name = "listDetailEntitySet";
            this.listDetailEntitySet.Size = new System.Drawing.Size(147, 181);
            this.listDetailEntitySet.TabIndex = 0;
            this.listDetailEntitySet.SelectedValueChanged += new System.EventHandler(this.listDetailEntitySet_SelectedValueChanged);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(149, 28);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // detailConfig
            // 
            this.detailConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailConfig.Location = new System.Drawing.Point(0, 0);
            this.detailConfig.Name = "detailConfig";
            this.detailConfig.Size = new System.Drawing.Size(384, 211);
            this.detailConfig.TabIndex = 1;
            // 
            // pageQueryConfig
            // 
            this.pageQueryConfig.Controls.Add(this.queryConfig);
            this.pageQueryConfig.Name = "pageQueryConfig";
            this.pageQueryConfig.Padding = new System.Windows.Forms.Padding(1);
            this.pageQueryConfig.Size = new System.Drawing.Size(538, 211);
            this.pageQueryConfig.Text = "查询配置";
            // 
            // queryConfig
            // 
            this.queryConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryConfig.Location = new System.Drawing.Point(1, 1);
            this.queryConfig.Name = "queryConfig";
            this.queryConfig.Size = new System.Drawing.Size(536, 209);
            this.queryConfig.TabIndex = 0;
            // 
            // barDetailEntitySet
            // 
            this.barDetailEntitySet.BarName = "barDetailEntitySet";
            this.barDetailEntitySet.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.barDetailEntitySet.DockCol = 0;
            this.barDetailEntitySet.DockRow = 0;
            this.barDetailEntitySet.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barDetailEntitySet.FloatLocation = new System.Drawing.Point(455, 357);
            this.barDetailEntitySet.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetailEntitySetConfigAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetailEntitySetConfigDelete)});
            this.barDetailEntitySet.OptionsBar.AllowQuickCustomization = false;
            this.barDetailEntitySet.OptionsBar.DrawDragBorder = false;
            this.barDetailEntitySet.OptionsBar.UseWholeRow = true;
            this.barDetailEntitySet.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.barDetailEntitySet.Text = "barDetailEntitySet";
            // 
            // btnDetailEntitySetConfigAdd
            // 
            this.btnDetailEntitySetConfigAdd.Caption = "新增";
            this.btnDetailEntitySetConfigAdd.Glyph = global::SAF.CommonBill.Properties.Resources.Action_New_16x16;
            this.btnDetailEntitySetConfigAdd.Id = 6;
            this.btnDetailEntitySetConfigAdd.Name = "btnDetailEntitySetConfigAdd";
            this.btnDetailEntitySetConfigAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDetailEntitySetConfigAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailEntitySetConfigAdd_ItemClick);
            // 
            // btnDetailEntitySetConfigDelete
            // 
            this.btnDetailEntitySetConfigDelete.Caption = "删除";
            this.btnDetailEntitySetConfigDelete.Glyph = global::SAF.CommonBill.Properties.Resources.Action_Delete_16x16;
            this.btnDetailEntitySetConfigDelete.Id = 7;
            this.btnDetailEntitySetConfigDelete.Name = "btnDetailEntitySetConfigDelete";
            this.btnDetailEntitySetConfigDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDetailEntitySetConfigDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailEntitySetConfigDelete_ItemClick);
            // 
            // sysCommonBillConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl3);
            this.Name = "sysCommonBillConfigView";
            this.Size = new System.Drawing.Size(1043, 641);
            this.Controls.SetChildIndex(this.splitContainerControl3, 0);
            this.Controls.SetChildIndex(this.ribbonMain, 0);
            this.Controls.SetChildIndex(this.pnlQueryControl, 0);
            this.Controls.SetChildIndex(this.pnlPageControl, 0);
            this.Controls.SetChildIndex(this.splitMain, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcConfig)).EndInit();
            this.tcConfig.ResumeLayout(false);
            this.pageIndexConfig.ResumeLayout(false);
            this.pageMainConfig.ResumeLayout(false);
            this.pageDetailConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetailEntityConfig)).EndInit();
            this.pnlDetailEntityConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDetailEntitySet)).EndInit();
            this.pageQueryConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDetailEntitySetConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraTab.XtraTabControl tcConfig;
        private DevExpress.XtraTab.XtraTabPage pageIndexConfig;
        private DevExpress.XtraTab.XtraTabPage pageMainConfig;
        private DevExpress.XtraTab.XtraTabPage pageDetailConfig;
        private DevExpress.XtraTab.XtraTabPage pageQueryConfig;
        private EntitySetConfigControl indexConfig;
        private EntitySetConfigControl mainConfig;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.Bar barDetailEntitySet;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ListBoxControl listDetailEntitySet;
        private DevExpress.XtraBars.BarButtonItem btnDetailEntitySetConfigAdd;
        private DevExpress.XtraBars.BarButtonItem btnDetailEntitySetConfigDelete;
        private EntitySetConfigControl detailConfig;
        private System.Windows.Forms.BindingSource bsDetailEntitySetConfig;
        private QueryConfigControl queryConfig;
        private DevExpress.XtraEditors.PanelControl pnlDetailEntityConfig;
    }
}
