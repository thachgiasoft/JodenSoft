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
            this.menuChartControl1 = new SAF.Framework.Controls.Charts.MenuChartControl();
            this.SuspendLayout();
            // 
            // menuChartControl1
            // 
            this.menuChartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuChartControl1.Location = new System.Drawing.Point(0, 0);
            this.menuChartControl1.Name = "menuChartControl1";
            this.menuChartControl1.Size = new System.Drawing.Size(703, 385);
            this.menuChartControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 385);
            this.Controls.Add(this.menuChartControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Charts.MenuChartControl menuChartControl1;





    }
}

