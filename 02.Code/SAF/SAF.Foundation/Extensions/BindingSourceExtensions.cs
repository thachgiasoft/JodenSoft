using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Foundation
{
    public static class BindingSourceExtensions
    {
        public static void MoveCurrentDown(this BindingSource bs)
        {
            if (bs == null || bs.DataSource == null || bs.Count <= 1) return;
            bs.EndEdit();
            var curr = bs.Current;
            var index = bs.IndexOf(curr);
            if (index == bs.Count - 1) return;
            bs.RemoveCurrent();
            bs.Insert(index + 1, curr);
            bs.Position = index + 1;
        }

        public static void MoveCurrentUp(this BindingSource bs)
        {
            if (bs == null || bs.DataSource == null || bs.Count <= 1) return;
            bs.EndEdit();
            var curr = bs.Current;
            var index = bs.IndexOf(curr);
            if (index == 0) return;
            bs.RemoveCurrent();
            bs.Insert(index - 1, curr);
            bs.Position = index - 1;
        }

    }
}
