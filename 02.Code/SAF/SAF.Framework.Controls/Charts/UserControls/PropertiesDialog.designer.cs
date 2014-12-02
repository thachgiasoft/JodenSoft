using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
namespace SAF.Framework.Controls.Charts
{
    partial class PropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesDialog));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.descriptionControl1 = new SAF.Framework.Controls.Charts.DescriptionControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtText = new DevExpress.XtraEditors.TextEdit();
            this.colorEditBackColor = new DevExpress.XtraEditors.ColorEdit();
            this.lcgRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tcgGeneral = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciColor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciText = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditBackColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.descriptionControl1);
            this.layoutControl1.Controls.Add(this.btnOK);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtText);
            this.layoutControl1.Controls.Add(this.colorEditBackColor);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.lcgRoot;
            this.layoutControl1.Size = new System.Drawing.Size(476, 411);
            this.layoutControl1.TabIndex = 8;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // descriptionControl1
            // 
            this.descriptionControl1.Location = new System.Drawing.Point(15, 127);
            this.descriptionControl1.Name = "descriptionControl1";
            this.descriptionControl1.ReadOnly = false;
            this.descriptionControl1.RtfText = resources.GetString("descriptionControl1.RtfText");
            this.descriptionControl1.Size = new System.Drawing.Size(446, 240);
            this.descriptionControl1.TabIndex = 15;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(315, 379);
            this.btnOK.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnOK.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.StyleController = this.layoutControl1;
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 379);
            this.btnCancel.MaximumSize = new System.Drawing.Size(75, 25);
            this.btnCancel.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(54, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(407, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 11;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(54, 62);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(407, 20);
            this.txtText.StyleController = this.layoutControl1;
            this.txtText.TabIndex = 10;
            // 
            // colorEditBackColor
            // 
            this.colorEditBackColor.EditValue = System.Drawing.Color.Empty;
            this.colorEditBackColor.Location = new System.Drawing.Point(54, 86);
            this.colorEditBackColor.Name = "colorEditBackColor";
            this.colorEditBackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEditBackColor.Size = new System.Drawing.Size(407, 20);
            this.colorEditBackColor.StyleController = this.layoutControl1;
            this.colorEditBackColor.TabIndex = 9;
            // 
            // lcgRoot
            // 
            this.lcgRoot.CustomizationFormText = "layoutControlGroup1";
            this.lcgRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgRoot.GroupBordersVisible = false;
            this.lcgRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.tcgGeneral,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.lcgRoot.Location = new System.Drawing.Point(0, 0);
            this.lcgRoot.Name = "lcgRoot";
            this.lcgRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lcgRoot.Size = new System.Drawing.Size(476, 411);
            this.lcgRoot.Text = "lcgRoot";
            this.lcgRoot.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 372);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(308, 29);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tcgGeneral
            // 
            this.tcgGeneral.CustomizationFormText = "tcgGeneral";
            this.tcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.tcgGeneral.Name = "tcgGeneral";
            this.tcgGeneral.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.tcgGeneral.SelectedTabPage = this.lcgGeneral;
            this.tcgGeneral.SelectedTabPageIndex = 0;
            this.tcgGeneral.Size = new System.Drawing.Size(466, 372);
            this.tcgGeneral.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgGeneral});
            this.tcgGeneral.Text = "tcgGeneral";
            // 
            // lcgGeneral
            // 
            this.lcgGeneral.CustomizationFormText = "General";
            this.lcgGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciColor,
            this.lciText,
            this.lciName,
            this.layoutControlItem1});
            this.lcgGeneral.Location = new System.Drawing.Point(0, 0);
            this.lcgGeneral.Name = "lcgGeneral";
            this.lcgGeneral.Size = new System.Drawing.Size(450, 333);
            this.lcgGeneral.Text = "常规";
            // 
            // lciColor
            // 
            this.lciColor.Control = this.colorEditBackColor;
            this.lciColor.CustomizationFormText = "颜色";
            this.lciColor.Location = new System.Drawing.Point(0, 48);
            this.lciColor.Name = "lciColor";
            this.lciColor.Size = new System.Drawing.Size(450, 24);
            this.lciColor.Text = "背景色";
            this.lciColor.TextSize = new System.Drawing.Size(36, 14);
            // 
            // lciText
            // 
            this.lciText.Control = this.txtText;
            this.lciText.CustomizationFormText = "Text";
            this.lciText.Location = new System.Drawing.Point(0, 24);
            this.lciText.Name = "lciText";
            this.lciText.Size = new System.Drawing.Size(450, 24);
            this.lciText.Text = "文本";
            this.lciText.TextSize = new System.Drawing.Size(36, 14);
            // 
            // lciName
            // 
            this.lciName.Control = this.txtName;
            this.lciName.CustomizationFormText = "名称";
            this.lciName.Location = new System.Drawing.Point(0, 0);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(450, 24);
            this.lciName.Text = "名称";
            this.lciName.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.descriptionControl1;
            this.layoutControlItem1.CustomizationFormText = "描述";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(450, 261);
            this.layoutControlItem1.Text = "描述";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnCancel;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(387, 372);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(79, 29);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOK;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(308, 372);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(79, 29);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // PropertiesDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 411);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性";
            this.Load += new System.EventHandler(this.PropertiesDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditBackColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LayoutControl layoutControl1;
        private LayoutControlGroup lcgRoot;
        private EmptySpaceItem emptySpaceItem2;
        private ColorEdit colorEditBackColor;
        private TabbedControlGroup tcgGeneral;
        private LayoutControlGroup lcgGeneral;
        private LayoutControlItem lciColor;
        private TextEdit txtText;
        private LayoutControlItem lciText;
        private TextEdit txtName;
        private LayoutControlItem lciName;
        private SimpleButton btnOK;
        private SimpleButton btnCancel;
        private LayoutControlItem layoutControlItem3;
        private LayoutControlItem layoutControlItem5;
        private DescriptionControl descriptionControl1;
        private LayoutControlItem layoutControlItem1;
    }
}