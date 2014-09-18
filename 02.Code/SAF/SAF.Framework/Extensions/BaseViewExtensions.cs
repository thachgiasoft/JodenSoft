using DevExpress.XtraEditors;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Extensions
{
    public static class BaseViewExtensions
    {
        public static XtraForm CreateContainer(this BaseView ctl, Form owner = null)
        {
            var form = new XtraForm();
            form.Owner = owner;
            if (form.Owner == null)
                form.StartPosition = FormStartPosition.CenterScreen;
            else
                form.StartPosition = FormStartPosition.CenterParent;
            form.Width = ctl.Width + 10;
            form.Height = ctl.Height + 10;
            form.Text = ctl.Text;
            form.Controls.Add(ctl);
            ctl.Dock = DockStyle.Fill;
            return form;
        }
    }
}
