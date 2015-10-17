namespace SAF.TaskCenter
{
    partial class Shell
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.dgvTaskView = new System.Windows.Forms.DataGridView();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.mgSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mgHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.PopMenu.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskView)).BeginInit();
            this.MenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.PopMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "任务调度中心";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // PopMenu
            // 
            this.PopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.PopMenu.Name = "PopMenu";
            this.PopMenu.Size = new System.Drawing.Size(117, 26);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(116, 22);
            this.miExit.Text = "退出[&X]";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart});
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(442, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // btnStart
            // 
            this.btnStart.Image = global::SAF.TaskCenter.Properties.Resources.ServiceStart;
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(52, 22);
            this.btnStart.Text = "启动";
            this.btnStart.ToolTipText = "启动任务";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvTaskView
            // 
            this.dgvTaskView.AllowUserToAddRows = false;
            this.dgvTaskView.AllowUserToDeleteRows = false;
            this.dgvTaskView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaskView.Location = new System.Drawing.Point(0, 50);
            this.dgvTaskView.Name = "dgvTaskView";
            this.dgvTaskView.ReadOnly = true;
            this.dgvTaskView.RowTemplate.Height = 23;
            this.dgvTaskView.Size = new System.Drawing.Size(442, 175);
            this.dgvTaskView.TabIndex = 2;
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mgSystem,
            this.mgHelp});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(442, 25);
            this.MenuMain.TabIndex = 3;
            this.MenuMain.Text = "menuStrip1";
            // 
            // mgSystem
            // 
            this.mgSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExitSystem});
            this.mgSystem.Name = "mgSystem";
            this.mgSystem.Size = new System.Drawing.Size(59, 21);
            this.mgSystem.Text = "系统(&S)";
            // 
            // miExitSystem
            // 
            this.miExitSystem.Name = "miExitSystem";
            this.miExitSystem.Size = new System.Drawing.Size(152, 22);
            this.miExitSystem.Text = "退出(&X)";
            this.miExitSystem.Click += new System.EventHandler(this.miExit_Click);
            // 
            // mgHelp
            // 
            this.mgHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.mgHelp.Name = "mgHelp";
            this.mgHelp.Size = new System.Drawing.Size(61, 21);
            this.mgHelp.Text = "帮助(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(125, 22);
            this.miAbout.Text = "关于...(&A)";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 225);
            this.Controls.Add(this.dgvTaskView);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.MenuMain);
            this.MainMenuStrip = this.MenuMain;
            this.Name = "Shell";
            this.Text = "任务调度中心";
            this.PopMenu.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskView)).EndInit();
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.DataGridView dgvTaskView;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ContextMenuStrip PopMenu;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem mgHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem mgSystem;
        private System.Windows.Forms.ToolStripMenuItem miExitSystem;

    }
}

