namespace SAF.Hardware.Controls
{
    partial class ElectronicScalesControl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ledLabel1 = new SAF.Hardware.Controls.LedControl();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ledLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // ledLabel1
            // 
            this.ledLabel1.BackColor = System.Drawing.Color.Transparent;
            this.ledLabel1.BackColor_1 = System.Drawing.Color.Navy;
            this.ledLabel1.BackColor_2 = System.Drawing.Color.Navy;
            this.ledLabel1.BevelRate = 0.5F;
            this.ledLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ledLabel1.FadedColor = System.Drawing.Color.Transparent;
            this.ledLabel1.FocusedBorderColor = System.Drawing.Color.Navy;
            this.ledLabel1.ForeColor = System.Drawing.Color.Yellow;
            this.ledLabel1.HighlightOpaque = ((byte)(50));
            this.ledLabel1.Location = new System.Drawing.Point(0, 0);
            this.ledLabel1.Name = "ledLabel1";
            this.ledLabel1.RoundCorner = true;
            this.ledLabel1.Size = new System.Drawing.Size(286, 78);
            this.ledLabel1.TabIndex = 0;
            this.ledLabel1.Text = "0.00";
            this.ledLabel1.TextAlignment = LedControl.Alignment.Right;
            // 
            // StopwatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ledLabel1);
            this.Name = "StopwatchControl";
            this.Size = new System.Drawing.Size(286, 78);
            ((System.ComponentModel.ISupportInitialize)(this.ledLabel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SAF.Hardware.Controls.LedControl ledLabel1;
        private System.IO.Ports.SerialPort serialPort;
    }
}
