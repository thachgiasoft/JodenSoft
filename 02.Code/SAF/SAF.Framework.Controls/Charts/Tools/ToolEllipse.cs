using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Ellipse tool
    /// </summary>
    class ToolEllipse : ToolObject
    {
        public ToolEllipse()
        {
            Cursor = new Cursor(GetType(), "Cursors.Ellipse.cur");
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left && drawArea.IsPointer)
            {
                Point point = ToolObject.TranslatePoint(drawArea, e.Location);
                drawArea.GraphicsCollection[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new DrawEllipse(p.X, p.Y, 150, 80);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }
}
