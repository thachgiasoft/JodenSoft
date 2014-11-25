using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraRichEdit.Services;

namespace SAF.Framework.Controls.Charts
{
    public partial class DescriptionControl : XtraUserControl
    {
        public DescriptionControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            SetDocumentFont();

            this.richEditControl.RtfTextChanged += new EventHandler(richEditControl_RtfTextChanged);
        }

        private void SetDocumentFont()
        {
            this.richEditControl.Document.DefaultCharacterProperties.FontName = "宋体";
            this.richEditControl.Document.DefaultCharacterProperties.FontSize = 9;
        }

        public event EventHandler RtfTextChanged;

        void richEditControl_RtfTextChanged(object sender, EventArgs e)
        {
            if (RtfTextChanged != null)
            {
                RtfTextChanged(sender, e);
            }
        }

        public string RtfText
        {
            get { return richEditControl.RtfText; }
            set
            {
                if (value.m_IsEmpty()) value = string.Empty;
                using (Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                {
                    this.richEditControl.LoadDocument(stream, DocumentFormat.Rtf);
                    SetDocumentFont();
                }
            }
        }

        public bool ReadOnly
        {
            get { return richEditControl.ReadOnly; }
            set
            {
                this.richEditControl.ReadOnly = value;
                this.richEditControl.ActiveView.BackColor = value ? SystemColors.Control : SystemColors.Window;
            }
        }

    }
}
