namespace SAF.Hardware.Controls.Test
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.electronicScalesControl1 = new SAF.Hardware.Controls.ElectronicScalesControl();
            this.stopwatchControl1 = new SAF.Hardware.Controls.StopwatchControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(94, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "电子称";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(94, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "码表";
            // 
            // electronicScalesControl1
            // 
            this.electronicScalesControl1.ElectronicScalesType = SAF.Hardware.Controls.ElectronicScales.ElectronicScalesType.None;
            this.electronicScalesControl1.Location = new System.Drawing.Point(177, 46);
            this.electronicScalesControl1.Name = "electronicScalesControl1";
            this.electronicScalesControl1.Size = new System.Drawing.Size(286, 78);
            this.electronicScalesControl1.TabIndex = 4;
            // 
            // stopwatchControl1
            // 
            this.stopwatchControl1.Location = new System.Drawing.Point(177, 161);
            this.stopwatchControl1.Name = "stopwatchControl1";
            this.stopwatchControl1.Size = new System.Drawing.Size(286, 78);
            this.stopwatchControl1.StopwatchType = SAF.Hardware.Controls.Stopwatch.StopwatchType.None;
            this.stopwatchControl1.StopwatchUnit = SAF.Hardware.Controls.Stopwatch.StopwatchUnit.M;
            this.stopwatchControl1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 329);
            this.Controls.Add(this.stopwatchControl1);
            this.Controls.Add(this.electronicScalesControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private StopwatchControl stopwatchControl1;
        private ElectronicScalesControl electronicScalesControl1;
    }
}

