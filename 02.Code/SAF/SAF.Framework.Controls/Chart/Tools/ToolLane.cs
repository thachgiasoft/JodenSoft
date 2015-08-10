using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    class ToolLane : ToolRectangle
    {
        public ToolLane()
        {
            Cursor = new Cursor(GetType(), "Cursors.Lane.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawLane(e.X, e.Y, 1, 1));
        }
    }
}
