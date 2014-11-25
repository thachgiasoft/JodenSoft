using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    class ToolDrag : Tool
    {
        private Point startPoint = new Point(0, 0);

        public override void OnMouseDown(DrawArea drawArea, System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(drawArea, e);

            Point p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            startPoint.X = p.X;
            startPoint.Y = p.Y;

        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            base.OnMouseUp(drawArea, e);

            if (e.Button != MouseButtons.Left) return;

            drawArea.AutoScrollPosition = startPoint;
        }
    }
}
