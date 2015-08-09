using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SAF.Framework.Controls.GanttChart
{
    public class GanttControlProperties
    {
        public int ScalceWidth { get; set; }
        public int TaskCenterHeight { get; set; }
        public bool ShowNowLine { get; set; }
        public bool ShowTooltip { get; set; }
        public bool ShowHorizontalLine { get; set; }
        public bool ShowPercent { get; set; }

        public Color SelectionTaskColor { get; set; }

        public bool IsReadOnly { get; private set; }

        public GanttControlProperties(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
        }

    }
}
