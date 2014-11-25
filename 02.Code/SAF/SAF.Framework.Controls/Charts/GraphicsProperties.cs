using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SAF.Framework.Controls.Charts
{
    public class GraphicsProperties
    {
        public GraphicsProperties()
        {
            this.ReadOnly = false;
            BackColor = null;
            this.Name = string.Empty;
            this.Text = string.Empty;
            this.Status = string.Empty;
            this.iStatus = -1;
            this.Description = string.Empty;
            this.ShowiStatus = true;
        }

        public bool ReadOnly { get; set; }
        public bool ShowiStatus { get; set; }

        public Color? BackColor { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public int iStatus { get; set; }
        public string Description { get; set; }

        public bool IsColorObject { get; set; }
    }
}
