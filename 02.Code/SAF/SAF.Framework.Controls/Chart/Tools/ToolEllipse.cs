using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    class ToolEllipse : ToolRectangle
    {
        public ToolEllipse()
        {
            Cursor = new Cursor(GetType(), "Cursors.Ellipse.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawEllipse(e.X, e.Y, 1, 1));
        }
    }
}
