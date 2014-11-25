using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Line tool
    /// </summary>
    class ToolLine : ToolObject
    {
        private bool isDotLine = false;
        private bool canMove = true;
        private ArrowType drawArrowType = ArrowType.Fill;

        public ToolLine(bool isDotLine, bool canMove, ArrowType drawArrowType)
        {
            this.isDotLine = isDotLine;
            this.canMove = canMove;
            this.drawArrowType = drawArrowType;


            if (!isDotLine)
            {
                Cursor = new Cursor(GetType(), "Cursors.Line.cur");
            }
            else
            {
                Cursor = new Cursor(GetType(), "Cursors.DotLine.cur");
            }

        }

        protected DrawLine line = null;

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            base.OnMouseDown(drawArea, e);
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            var obj = ToolObject.GetHitDrawObject(drawArea, e.Location);

            line = new DrawLine(p.X, p.Y, p.X + 1, p.Y, this.isDotLine, this.canMove, this.drawArrowType);
            line.CurrentDrawArea = drawArea;
            if (obj != null)
            {
                line.StartDrawObjectID = obj.GUID;
            }
            AddNewObject(drawArea, line);
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left && !drawArea.IsPointer)
            {
                Point point = ToolObject.TranslatePoint(drawArea, e.Location);
                drawArea.GraphicsCollection[0].MoveHandleTo(point, 2);
                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var obj = ToolObject.GetHitDrawObject(drawArea, e.Location);
            if (obj != null)
            {
                line.EndDrawObjectID = obj.GUID;
            }

            if (line.StartDrawObjectID == Guid.Empty || line.EndDrawObjectID == Guid.Empty || line.StartDrawObjectID == line.EndDrawObjectID)
            {
                drawArea.GraphicsCollection.RemoveAt(0);
            }

            base.OnMouseUp(drawArea, e);
        }


    }
}
