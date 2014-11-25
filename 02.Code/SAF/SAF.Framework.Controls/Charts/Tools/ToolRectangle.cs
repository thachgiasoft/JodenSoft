using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Rectangle tool
    /// </summary>
    class ToolRectangle : ToolObject
    {
        private bool IsRoundedRectangle = false;

        public ToolRectangle(bool isRoundedRectangle)
        {
            this.IsRoundedRectangle = isRoundedRectangle;

            if (!isRoundedRectangle)
            {
                Cursor = new Cursor(GetType(), "Cursors.Rectangle.cur");
            }
            else
            {
                Cursor = new Cursor(GetType(), "Cursors.RoundedRectangle.cur");
            }
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
            var obj=new DrawRectangle(p.X, p.Y, 150, 80, this.IsRoundedRectangle);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);

            base.OnMouseUp(drawArea, e);
        }

    }
}
