using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Chart
{
    public class MouseDoubleClickEventArgs : EventArgs
    {
        public IEnumerable<DrawObject> DrawObjects { get; private set; }

        public MouseDoubleClickEventArgs(IEnumerable<DrawObject> drawObjects)
        {
            this.DrawObjects = drawObjects;
        }
    }
}
