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
        void SetAllowSave(bool value);
        void SetReadOnly(bool value);
        void SetStateOfMenuItem();
        ContextMenuStrip ContextMenuStrip { get; }

        void CommandSave();
        void CommandEdit();
    }
}
