namespace SAF.Keygen
{
    partial class MainForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtPollCode = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.lblPollCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(351, 149);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "注册";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(57, 12);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(369, 21);
            this.txtProductId.TabIndex = 1;
            // 
            // txtPollCode
            // 
            this.txtPollCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtPollCode.Location = new System.Drawing.Point(57, 39);
            this.txtPollCode.Multiline = true;
            this.txtPollCode.Name = "txtPollCode";
            this.txtPollCode.ReadOnly = true;
            this.txtPollCode.Size = new System.Drawing.Size(369, 104);
            this.txtPollCode.TabIndex = 2;
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(8, 17);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(41, 12);
            this.lblProductId.TabIndex = 3;
            this.lblProductId.Text = "产品码";
            // 
            // lblPollCode
            // 
            this.lblPollCode.AutoSize = true;
            this.lblPollCode.Location = new System.Drawing.Point(8, 42);
            this.lblPollCode.Name = "lblPollCode";
            this.lblPollCode.Size = new System.Drawing.Size(41, 12);
            this.lblPollCode.TabIndex = 4;
            this.lblPollCode.Text = "注册码";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 181);
            this.Controls.Add(this.lblPollCode);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.txtPollCode);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 220);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SAF 算号器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtPollCode;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.Label lblPollCode;

    }
}

