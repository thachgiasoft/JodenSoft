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

        private IEnumerable<KeyValuePair<int, string>> iStatusSource;

        public PropertiesDialog(GraphicsProperties properties, IEnumerable<KeyValuePair<int, string>> list)
            : this()
        {
            this.properties = properties;
            iStatusSource = list;
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

            this.txtStatus.Text = properties.Status;
            this.txtStatus.Properties.ReadOnly = properties.ReadOnly;
            if (properties.ReadOnly)
            {
                txtStatus.BackColor = SystemColors.ControlLight;
            }

            lciiStatus.Visibility = properties.ShowiStatus ? LayoutVisibility.Always : LayoutVisibility.Never;

            this.glediStatus.Properties.DataSource = this.iStatusSource;
            this.glediStatus.Properties.DisplayMember = "Value";
            this.glediStatus.Properties.ValueMember = "Key";
            this.glediStatus.Properties.View.OptionsView.ColumnAutoWidth = true;
            this.glediStatus.Properties.View.BestFitColumns();
            this.glediStatus.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.glediStatus.Properties.ShowFooter = false;
            this.glediStatus.Properties.NullText = "";
            this.glediStatus.Properties.PopupFormSize = new Size(this.glediStatus.Width, 50);
            this.glediStatus.Properties.View.OptionsView.ShowColumnHeaders = false;
            this.glediStatus.Properties.View.OptionsView.ShowIndicator = false;
            this.glediStatus.Properties.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            this.glediStatus.Properties.View.OptionsView.ShowVerticalLines = DefaultBoolean.False;
            this.glediStatus.Properties.QueryPopUp += (sender, args) =>
            {
                if (this.glediStatus.Properties.View.Columns["Key"] != null)
                    this.glediStatus.Properties.View.Columns["Key"].Visible = false;
            };

            this.glediStatus.Properties.EditValueChanged += (sender, args) =>
            {
                if (properties.IsColorObject)
                {
                    int istatus = this.glediStatus.EditValue == null ? -1 : Convert.ToInt32(this.glediStatus.EditValue);
                    this.colorEditBackColor.Color = DrawRectangle.GetBackColor(istatus);
                }
            };

            if (!properties.ReadOnly)
            {
                this.glediStatus.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
                this.glediStatus.Properties.ButtonClick += Properties_ButtonClick;
            }


            this.glediStatus.EditValue = properties.iStatus;
            this.glediStatus.Properties.ReadOnly = properties.ReadOnly;
            if (properties.ReadOnly)
            {
                glediStatus.BackColor = SystemColors.ControlLight;
            }

            this.descriptionControl1.RtfText = properties.Description;
            this.descriptionControl1.ReadOnly = properties.ReadOnly;
        }

        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.glediStatus.EditValue = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lciColor.Visible)
            {
                properties.BackColor = colorEditBackColor.Color;
            }

            properties.Name = this.txtName.Text;
            properties.Text = this.txtText.Text;
            properties.Status = this.txtStatus.Text;
            properties.Description = this.descriptionControl1.RtfText;
            properties.iStatus = this.glediStatus.EditValue == null ? -1 : Convert.ToInt32(this.glediStatus.EditValue);

            this.DialogResult = DialogResult.OK;
        }

    }
}