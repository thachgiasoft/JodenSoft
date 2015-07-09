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
            this.simpleButton1 = new HuanSi.XtraEditors.SimpleButton();
            this.textEdit1 = new HuanSi.XtraEditors.TextEdit();
            this.memoEdit1 = new HuanSi.XtraEditors.MemoEdit();
            this.toggleSwitch1 = new HuanSi.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(392, 134);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.RefCondition = null;
            this.simpleButton1.RefId = 0;
            this.simpleButton1.refreshMode = HuanSi.Data.RefreshMode.Normal;
            this.simpleButton1.Size = new System.Drawing.Size(100, 26);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.FirstFoucsAutoSelectAll = false;
            this.textEdit1.Location = new System.Drawing.Point(357, 234);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.RefCondition = null;
            this.textEdit1.RefId = 0;
            this.textEdit1.refreshMode = HuanSi.Data.RefreshMode.Normal;
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // memoEdit1
            // 
            this.memoEdit1.FirstFoucsAutoSelectAll = false;
            this.memoEdit1.Location = new System.Drawing.Point(64, 56);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.RefCondition = null;
            this.memoEdit1.RefId = 0;
            this.memoEdit1.refreshMode = HuanSi.Data.RefreshMode.Normal;
            this.memoEdit1.Size = new System.Drawing.Size(238, 104);
            this.memoEdit1.TabIndex = 2;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.FirstFoucsAutoSelectAll = false;
            this.toggleSwitch1.Location = new System.Drawing.Point(403, 56);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.RefCondition = null;
            this.toggleSwitch1.RefId = 0;
            this.toggleSwitch1.refreshMode = HuanSi.Data.RefreshMode.Normal;
            this.toggleSwitch1.Size = new System.Drawing.Size(108, 25);
            this.toggleSwitch1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 385);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private HuanSi.XtraEditors.SimpleButton simpleButton1;
        private HuanSi.XtraEditors.TextEdit textEdit1;
        private HuanSi.XtraEditors.MemoEdit memoEdit1;
        private HuanSi.XtraEditors.ToggleSwitch toggleSwitch1;








    }
}

