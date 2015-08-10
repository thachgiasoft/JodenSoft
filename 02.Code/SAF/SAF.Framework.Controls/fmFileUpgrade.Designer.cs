namespace SAF.Framework.Controls
{
    partial class fmFileUpgrade
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
            this.progress = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnUpgrade = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.EditValue = 0;
            this.progress.Location = new System.Drawing.Point(24, 36);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(479, 18);
            this.progress.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMessage.Location = new System.Drawing.Point(27, 16);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(476, 14);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "正在计算需要更新的文件...";
            // 
            // btnUpgrade
            // 
            this.btnUpgrade.Location = new System.Drawing.Point(428, 71);
            this.btnUpgrade.Name = "btnUpgrade";
            this.btnUpgrade.Size = new System.Drawing.Size(75, 23);
            this.btnUpgrade.TabIndex = 2;
            this.btnUpgrade.Text = "更新(&U)";
            this.btnUpgrade.Click += new System.EventHandler(this.btnUpgrade_Click);
            // 
            // FileUpdaterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 106);
            this.Controls.Add(this.btnUpgrade);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.progress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileUpdaterControl";
            ((System.ComponentModel.ISupportInitialize)(this.progress.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progress;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnUpgrade;
    }
}
