namespace SAF.Framework.View
{
    partial class DetailDataView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ribbonDetail = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splMain = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonDetail
            // 
            this.ribbonDetail.ExpandCollapseItem.Id = 0;
            this.ribbonDetail.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonDetail.ExpandCollapseItem});
            this.ribbonDetail.Location = new System.Drawing.Point(1, 1);
            this.ribbonDetail.MaxItemId = 1;
            this.ribbonDetail.Name = "ribbonDetail";
            this.ribbonDetail.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonDetail.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonDetail.Size = new System.Drawing.Size(688, 120);
            this.ribbonDetail.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(1, 121);
            this.splMain.Name = "splMain";
            this.splMain.Panel1.Text = "Panel1";
            this.splMain.Panel2.Text = "Panel2";
            this.splMain.Size = new System.Drawing.Size(688, 289);
            this.splMain.SplitterPosition = 181;
            this.splMain.TabIndex = 1;
            this.splMain.Text = "splitContainerControl1";
            // 
            // DetailDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.ribbonDetail);
            this.Name = "DetailDataView";
            this.Size = new System.Drawing.Size(690, 411);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonDetail;
        protected DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        protected DevExpress.XtraEditors.SplitContainerControl splMain;
    }
}