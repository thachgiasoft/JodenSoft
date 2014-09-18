namespace SAF.Framework.Controls
{
    partial class WorkSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSpace));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.navMainMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.systemMenuGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.TreeMenu = new DevExpress.XtraTreeList.TreeList();
            this.pnlMenu = new DevExpress.XtraEditors.PanelControl();
            this.txtFind = new DevExpress.XtraEditors.TextEdit();
            this.btnRefreshMenu = new DevExpress.XtraEditors.SimpleButton();
            this.documentController = new SAF.Framework.Controls.DocumentController();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).BeginInit();
            this.navMainMenu.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.navMainMenu);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.documentController);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(592, 305);
            this.splitContainerControl.SplitterPosition = 181;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // navMainMenu
            // 
            this.navMainMenu.ActiveGroup = this.systemMenuGroup;
            this.navMainMenu.Controls.Add(this.navBarGroupControlContainer1);
            this.navMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navMainMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.systemMenuGroup});
            this.navMainMenu.Location = new System.Drawing.Point(0, 0);
            this.navMainMenu.Name = "navMainMenu";
            this.navMainMenu.NavigationPaneMaxVisibleGroups = 0;
            this.navMainMenu.OptionsNavPane.ExpandedWidth = 181;
            this.navMainMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navMainMenu.Size = new System.Drawing.Size(181, 305);
            this.navMainMenu.TabIndex = 0;
            this.navMainMenu.Text = "navBarControl1";
            // 
            // systemMenuGroup
            // 
            this.systemMenuGroup.Caption = "系统菜单";
            this.systemMenuGroup.ControlContainer = this.navBarGroupControlContainer1;
            this.systemMenuGroup.Expanded = true;
            this.systemMenuGroup.GroupClientHeight = 80;
            this.systemMenuGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.systemMenuGroup.Name = "systemMenuGroup";
            this.systemMenuGroup.SmallImage = global::SAF.Framework.Properties.Resources.Icon_Tree_16x16;
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.TreeMenu);
            this.navBarGroupControlContainer1.Controls.Add(this.pnlMenu);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(181, 230);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // TreeMenu
            // 
            this.TreeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeMenu.Location = new System.Drawing.Point(0, 27);
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.OptionsBehavior.Editable = false;
            this.TreeMenu.OptionsSelection.InvertSelection = true;
            this.TreeMenu.OptionsView.ShowColumns = false;
            this.TreeMenu.OptionsView.ShowHorzLines = false;
            this.TreeMenu.OptionsView.ShowIndicator = false;
            this.TreeMenu.OptionsView.ShowVertLines = false;
            this.TreeMenu.Size = new System.Drawing.Size(181, 203);
            this.TreeMenu.TabIndex = 0;
            this.TreeMenu.DoubleClick += new System.EventHandler(this.TreeMenu_DoubleClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMenu.Controls.Add(this.txtFind);
            this.pnlMenu.Controls.Add(this.btnRefreshMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(181, 27);
            this.pnlMenu.TabIndex = 1;
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(3, 3);
            this.txtFind.Name = "txtFind";
            this.txtFind.Properties.NullText = "菜单筛选";
            this.txtFind.Size = new System.Drawing.Size(155, 20);
            this.txtFind.TabIndex = 1;
            this.txtFind.EditValueChanged += new System.EventHandler(this.txtFind_EditValueChanged);
            // 
            // btnRefreshMenu
            // 
            this.btnRefreshMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMenu.Image = global::SAF.Framework.Properties.Resources.Action_Refresh_16x16;
            this.btnRefreshMenu.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnRefreshMenu.Location = new System.Drawing.Point(159, 3);
            this.btnRefreshMenu.Name = "btnRefreshMenu";
            this.btnRefreshMenu.Size = new System.Drawing.Size(20, 20);
            this.btnRefreshMenu.TabIndex = 0;
            this.btnRefreshMenu.ToolTip = "刷新菜单";
            this.btnRefreshMenu.Click += new System.EventHandler(this.btnRefreshMenu_Click);
            // 
            // documentController
            // 
            this.documentController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentController.Location = new System.Drawing.Point(0, 0);
            this.documentController.Name = "documentController";
            this.documentController.Size = new System.Drawing.Size(406, 305);
            this.documentController.TabIndex = 0;
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "Icon_Form_16x16.png");
            // 
            // WorkSpace
            // 
            this.Controls.Add(this.splitContainerControl);
            this.Name = "WorkSpace";
            this.Size = new System.Drawing.Size(592, 305);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navMainMenu)).EndInit();
            this.navMainMenu.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraNavBar.NavBarControl navMainMenu;
        private DevExpress.XtraNavBar.NavBarGroup systemMenuGroup;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraTreeList.TreeList TreeMenu;
        private DocumentController documentController;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
        private DevExpress.XtraEditors.PanelControl pnlMenu;
        private DevExpress.XtraEditors.SimpleButton btnRefreshMenu;
        private DevExpress.XtraEditors.TextEdit txtFind;

    }
}
