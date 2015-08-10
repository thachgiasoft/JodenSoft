using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    class ToolRhombus : ToolRectangle
    {
        public ToolRhombus()
        {
            Cursor = new Cursor(GetType(), "Cursors.Rhombus.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawRhombus(e.X, e.Y, 1, 1));
        }

    }
}
