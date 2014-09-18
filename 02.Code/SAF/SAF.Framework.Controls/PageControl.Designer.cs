namespace SAF.Framework.Controls
{
    partial class PageControl
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
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.txtGotoPageIndex = new DevExpress.XtraEditors.SpinEdit();
            this.btnGoto = new DevExpress.XtraEditors.SimpleButton();
            this.btnLastPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirstPage = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtGotoPageIndex.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblMessage.Location = new System.Drawing.Point(142, 6);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0, 6, 0, 1);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(145, 14);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "当前第{0}页 共{1}页{2}行";
            // 
            // txtGotoPageIndex
            // 
            this.txtGotoPageIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGotoPageIndex.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGotoPageIndex.EnterMoveNextControl = true;
            this.txtGotoPageIndex.Location = new System.Drawing.Point(319, 3);
            this.txtGotoPageIndex.Margin = new System.Windows.Forms.Padding(0, 3, 0, 1);
            this.txtGotoPageIndex.Name = "txtGotoPageIndex";
            this.txtGotoPageIndex.Properties.AllowMouseWheel = false;
            this.txtGotoPageIndex.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtGotoPageIndex.Properties.IsFloatValue = false;
            this.txtGotoPageIndex.Size = new System.Drawing.Size(50, 20);
            this.txtGotoPageIndex.TabIndex = 10;
            // 
            // btnGoto
            // 
            this.btnGoto.Image = global::SAF.Framework.Controls.Properties.Resources.GoToPage;
            this.btnGoto.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGoto.Location = new System.Drawing.Point(381, 1);
            this.btnGoto.Margin = new System.Windows.Forms.Padding(0, 1, 3, 1);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(26, 23);
            this.btnGoto.TabIndex = 9;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Image = global::SAF.Framework.Controls.Properties.Resources.BtnLastPage;
            this.btnLastPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLastPage.Location = new System.Drawing.Point(90, 1);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(26, 23);
            this.btnLastPage.TabIndex = 7;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::SAF.Framework.Controls.Properties.Resources.BtnNextPage;
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNext.Location = new System.Drawing.Point(61, 1);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Image = global::SAF.Framework.Controls.Properties.Resources.BtnPrevPage;
            this.btnPrevPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrevPage.Location = new System.Drawing.Point(32, 1);
            this.btnPrevPage.Margin = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(26, 23);
            this.btnPrevPage.TabIndex = 5;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Image = global::SAF.Framework.Controls.Properties.Resources.BtnFirstPage;
            this.btnFirstPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFirstPage.Location = new System.Drawing.Point(3, 1);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(26, 23);
            this.btnFirstPage.TabIndex = 4;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnFirstPage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevPage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLastPage, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGoto, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGotoPageIndex, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 9, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 26);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(295, 6);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "转至";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(369, 6);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "页";
            // 
            // PageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(0, 26);
            this.MinimumSize = new System.Drawing.Size(410, 26);
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(410, 26);
            ((System.ComponentModel.ISupportInitialize)(this.txtGotoPageIndex.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrevPage;
        private DevExpress.XtraEditors.SimpleButton btnFirstPage;
        private DevExpress.XtraEditors.SpinEdit txtGotoPageIndex;
        private DevExpress.XtraEditors.SimpleButton btnGoto;
        private DevExpress.XtraEditors.SimpleButton btnLastPage;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
