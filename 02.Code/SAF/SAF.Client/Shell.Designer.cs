namespace SAF.Client
{
    partial class Shell
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
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiMessage = new DevExpress.XtraBars.BarStaticItem();
            this.bbiAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHomepage = new DevExpress.XtraBars.BarButtonItem();
            this.SystemPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusBarMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.bsiMessage,
            this.bbiAbout,
            this.bbiHelp,
            this.bbiHomepage});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 6;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.SystemPage});
            this.ribbonMain.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(673, 147);
            this.ribbonMain.StatusBar = this.statusBarMain;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // bsiMessage
            // 
            this.bsiMessage.Caption = "准备就绪...";
            this.bsiMessage.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bsiMessage.Id = 1;
            this.bsiMessage.Name = "bsiMessage";
            this.bsiMessage.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiAbout
            // 
            this.bbiAbout.Caption = "关于";
            this.bbiAbout.Description = "关于系统";
            this.bbiAbout.Id = 3;
            this.bbiAbout.LargeGlyph = global::SAF.Client.Properties.Resources.Action_About_32x32;
            this.bbiAbout.Name = "bbiAbout";
            this.bbiAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAbout_ItemClick);
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "帮助";
            this.bbiHelp.Id = 4;
            this.bbiHelp.LargeGlyph = global::SAF.Client.Properties.Resources.Action_Help_32x32;
            this.bbiHelp.Name = "bbiHelp";
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHelp_ItemClick);
            // 
            // bbiHomepage
            // 
            this.bbiHomepage.Caption = "主页";
            this.bbiHomepage.Description = "公司主页";
            this.bbiHomepage.Id = 5;
            this.bbiHomepage.LargeGlyph = global::SAF.Client.Properties.Resources.Home_32x32;
            this.bbiHomepage.Name = "bbiHomepage";
            this.bbiHomepage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHomepage_ItemClick);
            // 
            // SystemPage
            // 
            this.SystemPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupHelp});
            this.SystemPage.Name = "SystemPage";
            this.SystemPage.Text = "系统";
            // 
            // groupHelp
            // 
            this.groupHelp.AllowTextClipping = false;
            this.groupHelp.ItemLinks.Add(this.bbiHomepage);
            this.groupHelp.ItemLinks.Add(this.bbiAbout);
            this.groupHelp.ItemLinks.Add(this.bbiHelp);
            this.groupHelp.MergeOrder = 9000;
            this.groupHelp.Name = "groupHelp";
            this.groupHelp.ShowCaptionButton = false;
            this.groupHelp.Text = "帮助";
            // 
            // statusBarMain
            // 
            this.statusBarMain.ItemLinks.Add(this.bsiMessage);
            this.statusBarMain.Location = new System.Drawing.Point(0, 385);
            this.statusBarMain.Name = "statusBarMain";
            this.statusBarMain.Ribbon = this.ribbonMain;
            this.statusBarMain.Size = new System.Drawing.Size(673, 31);
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 416);
            this.Controls.Add(this.statusBarMain);
            this.Controls.Add(this.ribbonMain);
            this.Name = "Shell";
            this.Ribbon = this.ribbonMain;
            this.StatusBar = this.statusBarMain;
            this.Text = "SAF";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        protected DevExpress.XtraBars.Ribbon.RibbonPage SystemPage;
        protected DevExpress.XtraBars.Ribbon.RibbonStatusBar statusBarMain;
        protected DevExpress.XtraBars.BarStaticItem bsiMessage;
        protected DevExpress.XtraBars.BarButtonItem bbiAbout;
        protected DevExpress.XtraBars.BarButtonItem bbiHelp;
        protected DevExpress.XtraBars.BarButtonItem bbiHomepage;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupHelp;

    }
}
