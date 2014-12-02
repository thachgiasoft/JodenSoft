namespace SAF.SystemModule
{
    partial class sysUserView
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
            this.chkIsSystem = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtMemo = new DevExpress.XtraEditors.MemoEdit();
            this.txtTelNo = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtUserFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtUserNo = new DevExpress.XtraEditors.TextEdit();
            this.txtUserId = new DevExpress.XtraEditors.TextEdit();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tcDtl = new DevExpress.XtraTab.XtraTabControl();
            this.pageUserRole = new DevExpress.XtraTab.XtraTabPage();
            this.treeRole = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsRole = new System.Windows.Forms.BindingSource(this.components);
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFullName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSystem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).BeginInit();
            this.tcDtl.SuspendLayout();
            this.pageUserRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Size = new System.Drawing.Size(898, 120);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            this.splitMain.Size = new System.Drawing.Size(898, 303);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.SystemEntities.sysUser);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(SAF.SystemEntities.sysUser);
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Size = new System.Drawing.Size(898, 28);
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Location = new System.Drawing.Point(1, 452);
            this.pnlPageControl.Size = new System.Drawing.Size(898, 31);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(894, 26);
            // 
            // splitRight
            // 
            this.splitRight.Panel2.Controls.Add(this.tcDtl);
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            this.splitRight.Size = new System.Drawing.Size(611, 299);
            this.splitRight.SplitterPosition = 119;
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(611, 119);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Size = new System.Drawing.Size(605, 113);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.chkIsSystem);
            this.lcMain.Controls.Add(this.chkIsActive);
            this.lcMain.Controls.Add(this.txtMemo);
            this.lcMain.Controls.Add(this.txtTelNo);
            this.lcMain.Controls.Add(this.txtEmail);
            this.lcMain.Controls.Add(this.txtUserFullName);
            this.lcMain.Controls.Add(this.txtUserNo);
            this.lcMain.Controls.Add(this.txtUserId);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(605, 113);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // chkIsSystem
            // 
            this.chkIsSystem.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsSystem", true));
            this.chkIsSystem.Location = new System.Drawing.Point(526, 26);
            this.chkIsSystem.MenuManager = this.ribbonMain;
            this.chkIsSystem.Name = "chkIsSystem";
            this.chkIsSystem.Properties.Caption = "系统用户";
            this.chkIsSystem.Size = new System.Drawing.Size(77, 19);
            this.chkIsSystem.StyleController = this.lcMain;
            this.chkIsSystem.TabIndex = 11;
            // 
            // chkIsActive
            // 
            this.chkIsActive.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "IsActive", true));
            this.chkIsActive.Location = new System.Drawing.Point(451, 26);
            this.chkIsActive.MenuManager = this.ribbonMain;
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "已激活";
            this.chkIsActive.Size = new System.Drawing.Size(71, 19);
            this.chkIsActive.StyleController = this.lcMain;
            this.chkIsActive.TabIndex = 10;
            // 
            // txtMemo
            // 
            this.txtMemo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Remark", true));
            this.txtMemo.Location = new System.Drawing.Point(53, 50);
            this.txtMemo.MenuManager = this.ribbonMain;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(550, 61);
            this.txtMemo.StyleController = this.lcMain;
            this.txtMemo.TabIndex = 9;
            this.txtMemo.UseOptimizedRendering = true;
            // 
            // txtTelNo
            // 
            this.txtTelNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "TelephoneNo", true));
            this.txtTelNo.Location = new System.Drawing.Point(276, 26);
            this.txtTelNo.MenuManager = this.ribbonMain;
            this.txtTelNo.Name = "txtTelNo";
            this.txtTelNo.Size = new System.Drawing.Size(171, 20);
            this.txtTelNo.StyleController = this.lcMain;
            this.txtTelNo.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Email", true));
            this.txtEmail.Location = new System.Drawing.Point(53, 26);
            this.txtEmail.MenuManager = this.ribbonMain;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(168, 20);
            this.txtEmail.StyleController = this.lcMain;
            this.txtEmail.TabIndex = 7;
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "UserFullName", true));
            this.txtUserFullName.Location = new System.Drawing.Point(276, 2);
            this.txtUserFullName.MenuManager = this.ribbonMain;
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(171, 20);
            this.txtUserFullName.StyleController = this.lcMain;
            this.txtUserFullName.TabIndex = 6;
            // 
            // txtUserNo
            // 
            this.txtUserNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "UserName", true));
            this.txtUserNo.Location = new System.Drawing.Point(53, 2);
            this.txtUserNo.MenuManager = this.ribbonMain;
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(168, 20);
            this.txtUserNo.StyleController = this.lcMain;
            this.txtUserNo.TabIndex = 5;
            // 
            // txtUserId
            // 
            this.txtUserId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtUserId.Location = new System.Drawing.Point(502, 2);
            this.txtUserId.MenuManager = this.ribbonMain;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(101, 20);
            this.txtUserId.StyleController = this.lcMain;
            this.txtUserId.TabIndex = 4;
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(605, 113);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtUserId;
            this.layoutControlItem1.CustomizationFormText = "用户Id";
            this.layoutControlItem1.Location = new System.Drawing.Point(449, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(156, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(156, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(156, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "用户Id";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUserNo;
            this.layoutControlItem2.CustomizationFormText = "用户名";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(223, 24);
            this.layoutControlItem2.Text = "用户名";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUserFullName;
            this.layoutControlItem3.CustomizationFormText = "用户姓名";
            this.layoutControlItem3.Location = new System.Drawing.Point(223, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(226, 24);
            this.layoutControlItem3.Text = "用户姓名";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEmail;
            this.layoutControlItem4.CustomizationFormText = "邮箱";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(223, 24);
            this.layoutControlItem4.Text = "邮箱";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtTelNo;
            this.layoutControlItem5.CustomizationFormText = "手机号";
            this.layoutControlItem5.Location = new System.Drawing.Point(223, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(226, 24);
            this.layoutControlItem5.Text = "手机号";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtMemo;
            this.layoutControlItem6.CustomizationFormText = "备注";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(605, 65);
            this.layoutControlItem6.Text = "备注";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkIsActive;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(449, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(75, 24);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkIsSystem;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(524, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(81, 24);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // tcDtl
            // 
            this.tcDtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDtl.Location = new System.Drawing.Point(0, 0);
            this.tcDtl.Name = "tcDtl";
            this.tcDtl.SelectedTabPage = this.pageUserRole;
            this.tcDtl.Size = new System.Drawing.Size(611, 175);
            this.tcDtl.TabIndex = 0;
            this.tcDtl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageUserRole});
            // 
            // pageUserRole
            // 
            this.pageUserRole.Controls.Add(this.treeRole);
            this.pageUserRole.Name = "pageUserRole";
            this.pageUserRole.Size = new System.Drawing.Size(605, 146);
            this.pageUserRole.Text = "用户所属系统角色";
            // 
            // treeRole
            // 
            this.treeRole.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.treeRole.DataSource = this.bsRole;
            this.treeRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRole.KeyFieldName = "Iden";
            this.treeRole.Location = new System.Drawing.Point(0, 0);
            this.treeRole.Name = "treeRole";
            this.treeRole.OptionsView.ShowCheckBoxes = true;
            this.treeRole.OptionsView.ShowColumns = false;
            this.treeRole.OptionsView.ShowHorzLines = false;
            this.treeRole.OptionsView.ShowIndicator = false;
            this.treeRole.OptionsView.ShowVertLines = false;
            this.treeRole.ParentFieldName = "ParentId";
            this.treeRole.Size = new System.Drawing.Size(605, 146);
            this.treeRole.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "角色名称";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 32;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 36;
            // 
            // bsRole
            // 
            this.bsRole.DataSource = typeof(SAF.SystemEntities.sysRole);
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
            this.grdIndex.Size = new System.Drawing.Size(282, 299);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIden,
            this.colUserName,
            this.colUserFullName});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            // 
            // colIden
            // 
            this.colIden.Caption = "用户Id";
            this.colIden.FieldName = "Iden";
            this.colIden.Name = "colIden";
            this.colIden.Visible = true;
            this.colIden.VisibleIndex = 0;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "用户名";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            // 
            // colUserFullName
            // 
            this.colUserFullName.Caption = "用户姓名";
            this.colUserFullName.FieldName = "UserFullName";
            this.colUserFullName.Name = "colUserFullName";
            this.colUserFullName.Visible = true;
            this.colUserFullName.VisibleIndex = 2;
            // 
            // sysUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysUserView";
            this.Size = new System.Drawing.Size(900, 484);
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
            ((System.ComponentModel.ISupportInitialize)(this.chkIsSystem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcDtl)).EndInit();
            this.tcDtl.ResumeLayout(false);
            this.pageUserRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraTab.XtraTabControl tcDtl;
        private DevExpress.XtraTab.XtraTabPage pageUserRole;
        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private System.Windows.Forms.BindingSource bsRole;
        private DevExpress.XtraTreeList.TreeList treeRole;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIden;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFullName;
        private DevExpress.XtraEditors.MemoEdit txtMemo;
        private DevExpress.XtraEditors.TextEdit txtTelNo;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtUserFullName;
        private DevExpress.XtraEditors.TextEdit txtUserNo;
        private DevExpress.XtraEditors.TextEdit txtUserId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.CheckEdit chkIsSystem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
