using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    [ToolboxItem(true)]
    public class AutoSizeLabelControl : Label
    {
        public AutoSizeLabelControl()
        {
            this.AutoSize = false;
        }

        public override bool AutoSize
        {
            get
            {
                return false;
            }
            set
            {
                base.AutoSize = false;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            OnResize(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CalcClientSize();
        }

        private void CalcClientSize()
        {
            var font = this.Font;
            int width = Math.Max(10, this.Width - this.Padding.Left);

            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;
                SizeF size = this.CreateGraphics().MeasureString(this.Text, font, width, sf);

                this.Height = (int)Math.Ceiling(size.Height) + this.Padding.Top;
            }
        }
    }
}
