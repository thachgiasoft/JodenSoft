using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    public static class EditExtensions
    {
        public static void Clear(this TextEdit edit)
        {
            if (edit == null) return;
            edit.Text = string.Empty;
        }

        public static void Clear(this CheckEdit edit)
        {
            if (edit == null) return;
            edit.Checked = false;
        }
    }
}
