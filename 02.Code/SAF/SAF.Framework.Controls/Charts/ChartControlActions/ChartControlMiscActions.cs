using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts.ChartControlActions
{
    public class SaveAction : AbstractChartControlEditAction
    {
        public override void m_Execute(IChartControl chartControl)
        {
            if (chartControl == null || chartControl.ActiveDrawArea == null || chartControl.ActiveDrawArea.ReadOnly) return;

            chartControl.CommandSave();
        }
    }

    public class EditAction : AbstractChartControlEditAction
    {
        public override void m_Execute(IChartControl chartControl)
        {
            if (chartControl == null || chartControl.ActiveDrawArea == null) return;

            chartControl.CommandEdit();
        }
    }
}
