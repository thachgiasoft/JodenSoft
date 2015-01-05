namespace SAF.SystemModule
{
    partial class sysMenuSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sysMenuSelector));
            this.treeMenu = new DevExpress.XtraTreeList.TreeList();
            this.imageCollectionTreeList = new DevExpress.Utils.ImageCollection(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
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
            this.splitMain.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(SAF.Framework.Entities.sysMenu);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // splitRight
            // 
            this.splitRight.Size = new System.Drawing.Size(782, 284);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.Size = new System.Drawing.Size(782, 284);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.treeMenu);
            this.pageMain.Size = new System.Drawing.Size(776, 278);
            // 
            // treeMenu
            // 
            this.treeMenu.DataSource = this.bsIndex;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.Location = new System.Drawing.Point(0, 0);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.OptionsSelection.InvertSelection = true;
            this.treeMenu.OptionsSelection.MultiSelect = true;
            this.treeMenu.OptionsView.ShowCheckBoxes = true;
            this.treeMenu.OptionsView.ShowColumns = false;
            this.treeMenu.OptionsView.ShowHorzLines = false;
            this.treeMenu.OptionsView.ShowIndicator = false;
            this.treeMenu.OptionsView.ShowVertLines = false;
            this.treeMenu.Size = new System.Drawing.Size(776, 278);
            this.treeMenu.TabIndex = 0;
            // 
            // imageCollectionTreeList
            // 
            this.imageCollectionTreeList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionTreeList.ImageStream")));
            this.imageCollectionTreeList.Images.SetKeyName(0, "BO_Folder_Closed.png");
            this.imageCollectionTreeList.Images.SetKeyName(1, "BO_Folder_Opened.png");
            this.imageCollectionTreeList.Images.SetKeyName(2, "Icon_Form_16x16.png");
            // 
            // sysMenuSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "sysMenuSelector";
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
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionTreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeMenu;
        private DevExpress.Utils.ImageCollection imageCollectionTreeList;
    }
}
