using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    class ToolRectangle : ToolObject
    {
        public ToolRectangle()
        {
            Cursor = new Cursor(GetType(), "Cursors.Rectangle.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            AddNewObject(drawArea, new DrawRectangle(true, e.X, e.Y, 1, 1));
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left)
            {
                Point point = new Point(e.X, e.Y);
                drawArea[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }
    }
}
