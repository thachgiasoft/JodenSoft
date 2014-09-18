namespace SAF.Framework.Controls.Test
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.autoSizeLabelControl1 = new SAF.Framework.Controls.AutoSizeLabelControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // autoSizeLabelControl1
            // 
            this.autoSizeLabelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoSizeLabelControl1.Location = new System.Drawing.Point(0, 0);
            this.autoSizeLabelControl1.Name = "autoSizeLabelControl1";
            this.autoSizeLabelControl1.Size = new System.Drawing.Size(580, 16);
            this.autoSizeLabelControl1.TabIndex = 2;
            this.autoSizeLabelControl1.Text = "autoSizeLabelControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 213);
            this.Controls.Add(this.autoSizeLabelControl1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private AutoSizeLabelControl autoSizeLabelControl1;



    }
}

