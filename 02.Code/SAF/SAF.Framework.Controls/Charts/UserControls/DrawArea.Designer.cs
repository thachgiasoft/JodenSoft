namespace SAF.Framework.Controls.Charts
{
    partial class DrawArea
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
            this.m_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.BringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spCancelMoveToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.AutoDrawLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ContextMenu
            // 
            this.m_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertyToolStripMenuItem,
            this.DeleteSelectionToolStripMenuItem,
            this.spPropertyToolStripMenuItem,
            this.BringToFrontToolStripMenuItem,
            this.SendToBackToolStripMenuItem,
            this.spCancelMoveToolStripMenuItem,
            this.AutoDrawLineToolStripMenuItem,
            this.AutoSizeToolStripMenuItem,
            this.iStatusToolStripMenuItem});
            this.m_ContextMenu.Name = "contextMenuStrip1";
            this.m_ContextMenu.Size = new System.Drawing.Size(192, 192);
            // 
            // PropertyToolStripMenuItem
            // 
            this.PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem";
            this.PropertyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.PropertyToolStripMenuItem.Text = "属性";
            this.PropertyToolStripMenuItem.Click += new System.EventHandler(this.PropertyToolStripMenuItem_Click);
            // 
            // DeleteSelectionToolStripMenuItem
            // 
            this.DeleteSelectionToolStripMenuItem.Name = "DeleteSelectionToolStripMenuItem";
            this.DeleteSelectionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.DeleteSelectionToolStripMenuItem.Text = "删除";
            this.DeleteSelectionToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelectionToolStripMenuItem_Click);
            // 
            // spPropertyToolStripMenuItem
            // 
            this.spPropertyToolStripMenuItem.Name = "spPropertyToolStripMenuItem";
            this.spPropertyToolStripMenuItem.Size = new System.Drawing.Size(188, 6);
            // 
            // BringToFrontToolStripMenuItem
            // 
            this.BringToFrontToolStripMenuItem.Name = "BringToFrontToolStripMenuItem";
            this.BringToFrontToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.BringToFrontToolStripMenuItem.Text = "置为顶层";
            this.BringToFrontToolStripMenuItem.Click += new System.EventHandler(this.BringToFrontToolStripMenuItem_Click);
            // 
            // SendToBackToolStripMenuItem
            // 
            this.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem";
            this.SendToBackToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.SendToBackToolStripMenuItem.Text = "置为底层";
            this.SendToBackToolStripMenuItem.Click += new System.EventHandler(this.SendToBackToolStripMenuItem_Click);
            // 
            // spCancelMoveToolStripMenuItem
            // 
            this.spCancelMoveToolStripMenuItem.Name = "spCancelMoveToolStripMenuItem";
            this.spCancelMoveToolStripMenuItem.Size = new System.Drawing.Size(188, 6);
            // 
            // AutoDrawLineToolStripMenuItem
            // 
            this.AutoDrawLineToolStripMenuItem.Name = "AutoDrawLineToolStripMenuItem";
            this.AutoDrawLineToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AutoDrawLineToolStripMenuItem.Text = "自动连线 (Alt+X)";
            this.AutoDrawLineToolStripMenuItem.Click += new System.EventHandler(this.CancelMoveToolStripMenuItem_Click);
            // 
            // AutoSizeToolStripMenuItem
            // 
            this.AutoSizeToolStripMenuItem.Name = "AutoSizeToolStripMenuItem";
            this.AutoSizeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AutoSizeToolStripMenuItem.Text = "自动调整大小 (Alt+Z)";
            this.AutoSizeToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeToolStripMenuItem_Click);
            // 
            // iStatusToolStripMenuItem
            // 
            this.iStatusToolStripMenuItem.Name = "iStatusToolStripMenuItem";
            this.iStatusToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.iStatusToolStripMenuItem.Text = "修改状态";
            // 
            // DrawArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DrawArea";
            this.Size = new System.Drawing.Size(175, 175);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DrawArea_Scroll);
            this.m_ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem BringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator spPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator spCancelMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoDrawLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iStatusToolStripMenuItem;
    }
}
