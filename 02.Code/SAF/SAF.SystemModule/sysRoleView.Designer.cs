namespace SAF.SystemModule
{
    partial class sysRoleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysRoleView));
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkIsAdministrator = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkIsSystem = new DevExpress.XtraEditors.CheckEdit();
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSystem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsAdministrator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.pageRoleMenu = new DevExpress.XtraTab.XtraTabPage();
            this.treeMenu = new DevExpress.XtraTreeList.TreeList();
            this.colName1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsMenu = new System.Windows.Forms.BindingSource();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdministrator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.pageRoleMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).BeginInit();
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
            this.bsIndex.DataSource = typeof(SAF.SystemEntities.sysRole);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.SystemEntities.sysRole);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(763, 26);
            // 
            // splitRight
            // 
            this.splitRight.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitRight.SplitterPosition = 114;
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(480, 114);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Size = new System.Drawing.Size(474, 108);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.chkIsSystem);
            this.lcMain.Controls.Add(this.chkIsAdministrator);
            this.lcMain.Controls.Add(this.txtRemark);
            this.lcMain.Controls.Add(this.txtIden);
            this.lcMain.Controls.Add(this.txtName);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(474, 108);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem4});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(474, 108);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.CustomizationFormText = "角色名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(474, 24);
            this.layoutControlItem1.Text = "角色名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Name", true));
            this.txtName.Location = new System.Drawing.Point(53, 2);
            this.txtName.MenuManager = this.ribbonMain;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(419, 20);
            this.txtName.StyleController = this.lcMain;
            this.txtName.TabIndex = 4;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRemark;
            this.layoutControlItem3.CustomizationFormText = "备注";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(474, 60);
            this.layoutControlItem3.Text = "备注";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtRemark
            // 
            this.txtRemark.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Remark", true));
            this.txtRemark.Location = new System.Drawing.Point(53, 50);
            this.txtRemark.MenuManager = this.ribbonMain;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(419, 56);
            this.txtRemark.StyleController = this.lcMain;
            this.txtRemark.TabIndex = 6;
            this.txtRemark.UseOptimizedRendering = true;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtIden;
            this.layoutControlItem2.CustomizationFormText = "角色ID";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(175, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(175, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(175, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "角色ID";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(53, 26);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(120, 20);
            this.txtIden.StyleController = this.lcMain;
            this.txtIden.TabIndex = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkIsAdministrator;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(175, 24);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(128, 23);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(128, 23);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(128, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // chkIsAdministrator
            // 
            this.chkIsAdministrator.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsAdministrator", true));
            this.chkIsAdministrator.Location = new System.Drawing.Point(177, 26);
            this.chkIsAdministrator.MenuManager = this.ribbonMain;
            this.chkIsAdministrator.Name = "chkIsAdministrator";
            this.chkIsAdministrator.Properties.Caption = "是否系统管理员";
            this.chkIsAdministrator.Size = new System.Drawing.Size(124, 19);
            this.chkIsAdministrator.StyleController = this.lcMain;
            this.chkIsAdministrator.TabIndex = 8;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkIsSystem;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(303, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(171, 24);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // chkIsSystem
            // 
            this.chkIsSystem.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsSystem", true));
            this.chkIsSystem.Location = new System.Drawing.Point(305, 26);
            this.chkIsSystem.MenuManager = this.ribbonMain;
            this.chkIsSystem.Name = "chkIsSystem";
            this.chkIsSystem.Properties.Caption = "是否系统角色";
            this.chkIsSystem.Size = new System.Drawing.Size(167, 19);
            this.chkIsSystem.StyleController = this.lcMain;
            this.chkIsSystem.TabIndex = 9;
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
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colName,
            this.colIsSystem,
            this.colIsAdministrator});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            this.grvIndex.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvIndex_FocusedRowChanged);
            // 
            // colIden
            // 
            this.colIden.Caption = "角色Id";
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "角色名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colIsSystem
            // 
            this.colIsSystem.Caption = "是否系统角色";
            this.colIsSystem.FieldName = "IsSystem";
            this.colIsSystem.Name = "colIsSystem";
            this.colIsSystem.Visible = true;
            this.colIsSystem.VisibleIndex = 2;
            this.colIsSystem.Width = 85;
            // 
            // colIsAdministrator
            // 
            this.colIsAdministrator.Caption = "是否系统管理员";
            this.colIsAdministrator.FieldName = "IsAdministrator";
            this.colIsAdministrator.Name = "colIsAdministrator";
            this.colIsAdministrator.Visible = true;
            this.colIsAdministrator.VisibleIndex = 3;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.pageRoleMenu;
            this.xtraTabControl1.Size = new System.Drawing.Size(480, 148);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageRoleMenu});
            // 
            // pageRoleMenu
            // 
            this.pageRoleMenu.Controls.Add(this.treeMenu);
            this.pageRoleMenu.Name = "pageRoleMenu";
            this.pageRoleMenu.Padding = new System.Windows.Forms.Padding(2);
            this.pageRoleMenu.Size = new System.Drawing.Size(474, 119);
            this.pageRoleMenu.Text = "角色菜单";
            // 
            // treeMenu
            // 
            this.treeMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName1});
            this.treeMenu.DataSource = this.bsMenu;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(2, 2);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeMenu.OptionsView.ShowCheckBoxes = true;
            this.treeMenu.OptionsView.ShowColumns = false;
            this.treeMenu.OptionsView.ShowHorzLines = false;
            this.treeMenu.OptionsView.ShowIndicator = false;
            this.treeMenu.OptionsView.ShowVertLines = false;
            this.treeMenu.SelectImageList = this.imageCollectionTreeList;
            this.treeMenu.Size = new System.Drawing.Size(470, 115);
            this.treeMenu.TabIndex = 0;
            this.treeMenu.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeMenu_GetSelectImage);
            // 
            // colName1
            // 
            this.colName1.Caption = "菜单名称";
            this.colName1.FieldName = "Name";
            this.colName1.MinWidth = 49;
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
            this.colName1.Width = 26;
            // 
            // bsMenu
            // 
            this.bsMenu.DataSource = typeof(SAF.SystemEntities.sysMenu);
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "forms.png");
            // 
            // sysRoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysRoleView";
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsAdministrator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.pageRoleMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSystem;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage pageRoleMenu;
        private DevExpress.XtraTreeList.TreeList treeMenu;
        private System.Windows.Forms.BindingSource bsMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName1;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
        private DevExpress.XtraEditors.CheckEdit chkIsAdministrator;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit chkIsSystem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAdministrator;
    }
}
