using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public interface IChartControl
    {
        UserControl View { get; }

        DrawArea ActiveDrawArea { get; }

        void ContextMenuBeforePopExecute();
        void SetAllowExportImage(bool value);
        void SetStateOfMenuItem();
        ContextMenuStrip ContextMenuStrip { get; }
    }
}
