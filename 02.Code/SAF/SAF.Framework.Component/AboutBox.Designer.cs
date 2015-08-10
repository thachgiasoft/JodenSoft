namespace SAF.Framework.Component
{
    public partial class AboutBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtVersionInfo = new SAF.Framework.Controls.AutoSizeLabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.listBoxProducts = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductDetailInfo = new DevExpress.XtraEditors.MemoEdit();
            this.txtWarningMessage = new SAF.Framework.Controls.AutoSizeLabelControl();
            this.btnEnter = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopyVersionInfo = new DevExpress.XtraEditors.SimpleButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDetailInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel.Controls.Add(this.txtVersionInfo, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelControl1, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.listBoxProducts, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.labelControl2, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.txtProductDetailInfo, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.txtWarningMessage, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.btnEnter, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.btnCopyVersionInfo, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.picLogo, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(606, 399);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // txtVersionInfo
            // 
            this.txtVersionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVersionInfo.Location = new System.Drawing.Point(3, 73);
            this.txtVersionInfo.Name = "txtVersionInfo";
            this.txtVersionInfo.Size = new System.Drawing.Size(503, 14);
            this.txtVersionInfo.TabIndex = 1;
            this.txtVersionInfo.Text = "autoSizeLabelControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 90);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "已安装的产品：";
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxProducts.Location = new System.Drawing.Point(3, 110);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(503, 79);
            this.listBoxProducts.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(3, 195);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "产品详细信息：";
            // 
            // txtProductDetailInfo
            // 
            this.txtProductDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductDetailInfo.EditValue = "";
            this.txtProductDetailInfo.Location = new System.Drawing.Point(3, 215);
            this.txtProductDetailInfo.Name = "txtProductDetailInfo";
            this.txtProductDetailInfo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtProductDetailInfo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtProductDetailInfo.Properties.Appearance.Options.UseBackColor = true;
            this.txtProductDetailInfo.Properties.Appearance.Options.UseForeColor = true;
            this.txtProductDetailInfo.Properties.ReadOnly = true;
            this.txtProductDetailInfo.Size = new System.Drawing.Size(503, 152);
            this.txtProductDetailInfo.TabIndex = 5;
            this.txtProductDetailInfo.UseOptimizedRendering = true;
            // 
            // txtWarningMessage
            // 
            this.txtWarningMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWarningMessage.Location = new System.Drawing.Point(3, 370);
            this.txtWarningMessage.Name = "txtWarningMessage";
            this.txtWarningMessage.Size = new System.Drawing.Size(503, 16);
            this.txtWarningMessage.TabIndex = 6;
            this.txtWarningMessage.Text = "autoSizeLabelControl2";
            // 
            // btnEnter
            // 
            this.btnEnter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEnter.Location = new System.Drawing.Point(512, 373);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(91, 23);
            this.btnEnter.TabIndex = 7;
            this.btnEnter.Text = "确定";
            // 
            // btnCopyVersionInfo
            // 
            this.btnCopyVersionInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCopyVersionInfo.Location = new System.Drawing.Point(512, 110);
            this.btnCopyVersionInfo.Name = "btnCopyVersionInfo";
            this.btnCopyVersionInfo.Size = new System.Drawing.Size(91, 23);
            this.btnCopyVersionInfo.TabIndex = 8;
            this.btnCopyVersionInfo.Text = "复制信息(&C)";
            this.btnCopyVersionInfo.Click += new System.EventHandler(this.btnCopyVersionInfo_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Location = new System.Drawing.Point(512, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(91, 67);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLogo.TabIndex = 9;
            this.picLogo.TabStop = false;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnEnter;
            this.ClientSize = new System.Drawing.Size(610, 403);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDetailInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private SAF.Framework.Controls.AutoSizeLabelControl txtVersionInfo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxProducts;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtProductDetailInfo;
        private SAF.Framework.Controls.AutoSizeLabelControl txtWarningMessage;
        private DevExpress.XtraEditors.SimpleButton btnEnter;
        private DevExpress.XtraEditors.SimpleButton btnCopyVersionInfo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.BindingSource bsMain;

    }
}
