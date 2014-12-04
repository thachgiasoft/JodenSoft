using SAF.Framework.Component.Properties;
namespace SAF.Framework.Component
{
    partial class HelpControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpControl));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem1 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem2 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            DevExpress.XtraBars.Ribbon.GalleryItem galleryItem3 = new DevExpress.XtraBars.Ribbon.GalleryItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.galleryControl2 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient2 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.lblSetTool = new SAF.Framework.Controls.BackstageViewLabel();
            this.galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.backstageViewLabel1 = new SAF.Framework.Controls.BackstageViewLabel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblProductId = new DevExpress.XtraEditors.LabelControl();
            this.lblAboutBox = new DevExpress.XtraEditors.LabelControl();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.lblAbout = new SAF.Framework.Controls.BackstageViewLabel();
            this.lblProductKey = new DevExpress.XtraEditors.LabelControl();
            this.lblProductInclude = new SAF.Framework.Controls.AutoSizeLabelControl();
            this.lblProductName = new DevExpress.XtraEditors.LabelControl();
            this.backstageViewLabel3 = new SAF.Framework.Controls.BackstageViewLabel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.galleryControlClient3 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl2)).BeginInit();
            this.galleryControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).BeginInit();
            this.galleryControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.galleryControl2);
            this.splitContainer1.Panel1.Controls.Add(this.lblSetTool);
            this.splitContainer1.Panel1.Controls.Add(this.galleryControl1);
            this.splitContainer1.Panel1.Controls.Add(this.backstageViewLabel1);
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl4);
            // 
            // galleryControl2
            // 
            this.galleryControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.galleryControl2.Controls.Add(this.galleryControlClient2);
            this.galleryControl2.DesignGalleryGroupIndex = 0;
            this.galleryControl2.DesignGalleryItemIndex = 0;
            resources.ApplyResources(this.galleryControl2, "galleryControl2");
            // 
            // galleryControlGallery1
            // 
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font")));
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Disabled.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font")));
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Normal.Font")));
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font")));
            this.galleryControl2.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Font")));
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Font")));
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Normal.Font")));
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseFont = true;
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Font")));
            this.galleryControl2.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseFont = true;
            this.galleryControl2.Gallery.AutoFitColumns = false;
            this.galleryControl2.Gallery.AutoSize = DevExpress.XtraBars.Ribbon.GallerySizeMode.Vertical;
            this.galleryControl2.Gallery.BackColor = System.Drawing.Color.Transparent;
            this.galleryControl2.Gallery.ColumnCount = 1;
            this.galleryControl2.Gallery.DistanceItemImageToText = 20;
            this.galleryControl2.Gallery.DrawImageBackground = false;
            this.galleryControl2.Gallery.FixedImageSize = false;
            resources.ApplyResources(galleryItem1, "galleryItem1");
            galleryItem1.Image = global::SAF.Framework.Component.Properties.Resources.Action_Upgrade_32x32;
            galleryItem1.Tag = "LinkUpgrade";
            galleryItemGroup1.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem1});
            this.galleryControl2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.galleryControl2.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.galleryControl2.Gallery.RowCount = 1;
            this.galleryControl2.Gallery.ShowGroupCaption = false;
            this.galleryControl2.Gallery.ShowItemText = true;
            this.galleryControl2.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Hide;
            this.galleryControl2.Gallery.StretchItems = true;
            this.galleryControl2.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlGallery1_ItemClick_1);
            this.galleryControl2.Name = "galleryControl2";
            // 
            // galleryControlClient2
            // 
            this.galleryControlClient2.GalleryControl = this.galleryControl2;
            resources.ApplyResources(this.galleryControlClient2, "galleryControlClient2");
            // 
            // lblSetTool
            // 
            this.lblSetTool.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblSetTool.Appearance.Font")));
            resources.ApplyResources(this.lblSetTool, "lblSetTool");
            this.lblSetTool.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblSetTool.LineVisible = true;
            this.lblSetTool.Name = "lblSetTool";
            this.lblSetTool.ShowLineShadow = false;
            // 
            // galleryControl1
            // 
            this.galleryControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.galleryControl1.Controls.Add(this.galleryControlClient1);
            this.galleryControl1.DesignGalleryGroupIndex = 0;
            this.galleryControl1.DesignGalleryItemIndex = 0;
            resources.ApplyResources(this.galleryControl1, "galleryControl1");
            // 
            // galleryControlGallery2
            // 
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Disabled.Font")));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Disabled.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Hovered.Font")));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Normal.Font")));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Pressed.Font")));
            this.galleryControl1.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Font")));
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Disabled.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Font")));
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Normal.Font")));
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseFont = true;
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Font = ((System.Drawing.Font)(resources.GetObject("galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Font")));
            this.galleryControl1.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseFont = true;
            this.galleryControl1.Gallery.AutoFitColumns = false;
            this.galleryControl1.Gallery.AutoSize = DevExpress.XtraBars.Ribbon.GallerySizeMode.Vertical;
            this.galleryControl1.Gallery.BackColor = System.Drawing.Color.Transparent;
            this.galleryControl1.Gallery.ColumnCount = 1;
            this.galleryControl1.Gallery.DistanceItemImageToText = 20;
            this.galleryControl1.Gallery.DrawImageBackground = false;
            this.galleryControl1.Gallery.FixedImageSize = false;
            resources.ApplyResources(galleryItem2, "galleryItem2");
            galleryItem2.Image = global::SAF.Framework.Component.Properties.Resources.Action_Help_32x32;
            galleryItem2.Tag = "LinkHelp";
            resources.ApplyResources(galleryItem3, "galleryItem3");
            galleryItem3.Image = global::SAF.Framework.Component.Properties.Resources.Contact_Us;
            galleryItem3.Tag = "LinkGetSupport";
            galleryItemGroup2.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[] {
            galleryItem2,
            galleryItem3});
            this.galleryControl1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup2});
            this.galleryControl1.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.galleryControl1.Gallery.RowCount = 2;
            this.galleryControl1.Gallery.ShowGroupCaption = false;
            this.galleryControl1.Gallery.ShowItemText = true;
            this.galleryControl1.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Hide;
            this.galleryControl1.Gallery.StretchItems = true;
            this.galleryControl1.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.galleryControlGallery1_ItemClick);
            this.galleryControl1.Name = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControl1;
            resources.ApplyResources(this.galleryControlClient1, "galleryControlClient1");
            // 
            // backstageViewLabel1
            // 
            this.backstageViewLabel1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewLabel1.Appearance.Font")));
            resources.ApplyResources(this.backstageViewLabel1, "backstageViewLabel1");
            this.backstageViewLabel1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.backstageViewLabel1.LineVisible = true;
            this.backstageViewLabel1.Name = "backstageViewLabel1";
            this.backstageViewLabel1.ShowLineShadow = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.lblProductId);
            this.panelControl2.Controls.Add(this.lblAboutBox);
            this.panelControl2.Controls.Add(this.lblInfo);
            this.panelControl2.Controls.Add(this.lblAbout);
            this.panelControl2.Controls.Add(this.lblProductKey);
            this.panelControl2.Controls.Add(this.lblProductInclude);
            this.panelControl2.Controls.Add(this.lblProductName);
            this.panelControl2.Controls.Add(this.backstageViewLabel3);
            this.panelControl2.Controls.Add(this.panelControl1);
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Name = "panelControl2";
            // 
            // lblProductId
            // 
            this.lblProductId.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblProductId.Appearance.Font")));
            resources.ApplyResources(this.lblProductId, "lblProductId");
            this.lblProductId.Name = "lblProductId";
            // 
            // lblAboutBox
            // 
            this.lblAboutBox.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblAboutBox.Appearance.Font")));
            this.lblAboutBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblAboutBox, "lblAboutBox");
            this.lblAboutBox.Name = "lblAboutBox";
            this.lblAboutBox.Click += new System.EventHandler(this.lblAboutBox_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblInfo.Appearance.Font")));
            resources.ApplyResources(this.lblInfo, "lblInfo");
            this.lblInfo.Name = "lblInfo";
            // 
            // lblAbout
            // 
            this.lblAbout.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblAbout.Appearance.Font")));
            resources.ApplyResources(this.lblAbout, "lblAbout");
            this.lblAbout.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.lblAbout.LineVisible = true;
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.ShowLineShadow = false;
            // 
            // lblProductKey
            // 
            this.lblProductKey.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblProductKey.Appearance.Font")));
            this.lblProductKey.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lblProductKey, "lblProductKey");
            this.lblProductKey.Name = "lblProductKey";
            this.lblProductKey.Click += new System.EventHandler(this.lblProductKey_Click);
            // 
            // lblProductInclude
            // 
            resources.ApplyResources(this.lblProductInclude, "lblProductInclude");
            this.lblProductInclude.Name = "lblProductInclude";
            // 
            // lblProductName
            // 
            this.lblProductName.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblProductName.Appearance.Font")));
            resources.ApplyResources(this.lblProductName, "lblProductName");
            this.lblProductName.Name = "lblProductName";
            // 
            // backstageViewLabel3
            // 
            this.backstageViewLabel3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("backstageViewLabel3.Appearance.Font")));
            resources.ApplyResources(this.backstageViewLabel3, "backstageViewLabel3");
            this.backstageViewLabel3.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.backstageViewLabel3.LineVisible = true;
            this.backstageViewLabel3.Name = "backstageViewLabel3";
            this.backstageViewLabel3.ShowLineShadow = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.picLogo);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Name = "panelControl1";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // labelControl4
            // 
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Name = "labelControl4";
            // 
            // galleryControlClient3
            // 
            this.galleryControlClient3.GalleryControl = null;
            resources.ApplyResources(this.galleryControlClient3, "galleryControlClient3");
            // 
            // HelpControl
            // 
            this.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("HelpControl.Appearance.ForeColor")));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "HelpControl";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl2)).EndInit();
            this.galleryControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).EndInit();
            this.galleryControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SAF.Framework.Controls.BackstageViewLabel backstageViewLabel1;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private SAF.Framework.Controls.BackstageViewLabel lblSetTool;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl2;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private SAF.Framework.Controls.BackstageViewLabel backstageViewLabel3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblProductName;
        private DevExpress.XtraEditors.LabelControl lblProductKey;
        private SAF.Framework.Controls.BackstageViewLabel lblAbout;
        private DevExpress.XtraEditors.LabelControl lblProductId;
        private DevExpress.XtraEditors.LabelControl lblInfo;
        private DevExpress.XtraEditors.LabelControl lblAboutBox;
        private SAF.Framework.Controls.AutoSizeLabelControl lblProductInclude;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient3;
        private System.Windows.Forms.PictureBox picLogo;
    }
}
