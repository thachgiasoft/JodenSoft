using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;


namespace SAF.Framework.Controls.Charts
{
    partial class PropertiesDialog : Form
    {
        private PropertiesDialog()
        {
            InitializeComponent();
            this.KeyPreview = true;

            this.KeyDown += PropertiesDialog_KeyDown;
        }

        void PropertiesDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.properties.ReadOnly)
            {
                e.Handled = true;
                this.btnOK.PerformClick();
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.btnCancel.PerformClick();
            }

            if (e.Control && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.S))
            {
                e.Handled = true;
                this.btnOK.PerformClick();
            }
        }

        public PropertiesDialog(GraphicsProperties properties)
            : this()
        {
            this.properties = properties;
        }

        private GraphicsProperties properties;

        public GraphicsProperties Properties
        {
            get
            {
                return properties;
            }
        }

        private void PropertiesDialog_Load(object sender, EventArgs e)
        {
            InitControls();

            SendKeys.Send("{Tab}");
            this.txtName.Focus();
            this.txtName.SelectAll();
        }

        private void InitControls()
        {
            if (!properties.BackColor.HasValue)
            {
                lciColor.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lciColor.Visibility = LayoutVisibility.Always;
                colorEditBackColor.Color = properties.BackColor.Value;
            }

            colorEditBackColor.Properties.ReadOnly = properties.ReadOnly;
            if (properties.ReadOnly)
            {
                colorEditBackColor.BackColor = SystemColors.ControlLight;
            }

            this.txtName.Text = properties.Name;
            this.txtName.Properties.ReadOnly = properties.ReadOnly;
            if (properties.ReadOnly)
            {
                txtName.BackColor = SystemColors.ControlLight;
            }

            this.txtText.Text = properties.Text;
            this.txtText.Properties.ReadOnly = properties.ReadOnly;
            if (properties.ReadOnly)
            {
                txtText.BackColor = SystemColors.ControlLight;
            }

            

            this.descriptionControl1.RtfText = properties.Description;
            this.descriptionControl1.ReadOnly = properties.ReadOnly;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lciColor.Visible)
            {
                properties.BackColor = colorEditBackColor.Color;
            }

            properties.Name = this.txtName.Text;
            properties.Text = this.txtText.Text;
            properties.Description = this.descriptionControl1.RtfText;

            this.DialogResult = DialogResult.OK;
        }

    }
}