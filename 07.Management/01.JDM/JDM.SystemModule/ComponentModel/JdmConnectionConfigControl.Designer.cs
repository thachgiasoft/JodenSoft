namespace JDM.SystemModule.ComponentModel
{
    partial class JdmConnectionConfigControl
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
            this.lblDataConnection = new SAF.Framework.Controls.BackstageViewLabel();
            this.txtConnectionString = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectionString.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataConnection
            // 
            this.lblDataConnection.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDataConnection.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDataConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataConnection.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblDataConnection.LineVisible = true;
            this.lblDataConnection.Location = new System.Drawing.Point(20, 10);
            this.lblDataConnection.Name = "lblDataConnection";
            this.lblDataConnection.ShowLineShadow = false;
            this.lblDataConnection.Size = new System.Drawing.Size(480, 36);
            this.lblDataConnection.TabIndex = 0;
            this.lblDataConnection.Text = "数据连接";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtConnectionString.Location = new System.Drawing.Point(20, 46);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtConnectionString.Properties.ReadOnly = true;
            this.txtConnectionString.Size = new System.Drawing.Size(480, 20);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtConnectionString_ButtonClick);
            // 
            // JdmConnectionConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.lblDataConnection);
            this.Name = "JdmConnectionConfigControl";
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.Size = new System.Drawing.Size(520, 283);
            ((System.ComponentModel.ISupportInitialize)(this.txtConnectionString.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SAF.Framework.Controls.BackstageViewLabel lblDataConnection;
        private DevExpress.XtraEditors.ButtonEdit txtConnectionString;
    }
}
