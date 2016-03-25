using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    /// <summary>
    /// Base class for all tools which create new graphic object
    /// </summary>
    abstract class ToolObject : Tool
    {
        /// <summary>
        /// Tool cursor.
        /// </summary>
        protected Cursor Cursor { get; set; }


        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea[0].Normalize();
            drawArea.AddCommandToHistory(new CommandAdd(drawArea[0]));
            drawArea.ActiveDrawTool = DrawToolType.Pointer;

            drawArea.Capture = false;
            drawArea.Refresh();
        }

        /// <summary>
        /// Add new object to draw area.
        /// Function is called when user left-clicks draw area,
        /// and one of ToolObject-derived tools is active.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="o"></param>
        protected void AddNewObject(DrawArea drawArea, DrawObject o)
        {
            drawArea.UnselectAll();

            o.Selected = true;
            drawArea.Add(o);

            drawArea.Capture = true;
            drawArea.Refresh();

            drawArea.SetDirty();
        }

        private static Point CalcScrollPoint(Point p, DrawArea drawArea)
        {
            var pt = new Point(p.X, p.Y);
            if (pt.X < drawArea.Left)
                pt.X = drawArea.Left;

            if (pt.Y < drawArea.Top)
                pt.Y = drawArea.Top;

            if (pt.X > drawArea.Left + drawArea.Width - drawArea.AutoScrollPosition.X - 5)
                pt.X = drawArea.Left + drawArea.Width - drawArea.AutoScrollPosition.X - 5;

            if (pt.Y > drawArea.Top + drawArea.Height - drawArea.AutoScrollPosition.Y - 5)
                pt.Y = drawArea.Top + drawArea.Height - drawArea.AutoScrollPosition.Y - 5;

            return pt;
        }


        public static Point TranslatePoint(DrawArea drawArea, Point p)
        {
            var point = new Point(p.X + Math.Abs(drawArea.AutoScrollPosition.X), p.Y + Math.Abs(drawArea.AutoScrollPosition.Y));
            return
                CalcScrollPoint(point, drawArea);
        }

        public static DrawObject GetHitDrawObject(DrawArea drawArea, Point p)
        {
            var point = ToolObject.TranslatePoint(drawArea, p);
            point = ToolObject.UnzoomPoint(point, drawArea.Zoom);
            for (int i = 0; i < drawArea.Count; i++)
            {
                int n = drawArea[i].HitTest(point);
                //TODO:///
                //if (n >= 0 && !(drawArea[i] is DrawLine))
                //{
                //    return drawArea[i];
                //}
            }

            return null;
        }

        /// <summary>
        /// Zooms given point.
        /// </summary>
        /// <param name="originalPt">Point to zoom</param>
        /// <returns>zoomed point.</returns>
        public static Point ZoomPoint(Point originalPt, float zoom)
        {
            Point newPt = new Point((int)(originalPt.X * zoom), (int)(originalPt.Y * zoom));
            return newPt;
        }

        /// <summary>
        /// Unzooms given point.
        /// </summary>
        /// <param name="originalPt">Point to unzoom</param>
        /// <returns>Unzoomed point.</returns>
        public static Point UnzoomPoint(Point originalPt, float zoom)
        {
            Point newPt = new Point((int)(originalPt.X / zoom), (int)(originalPt.Y / zoom));
            return newPt;
        }
    }
}
