using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Base class for all tools which create new graphic object
    /// </summary>
    internal abstract class ToolObject : Tool
    {
        /// <summary>
        /// Tool cursor.
        /// </summary>
        protected Cursor Cursor
        {
            get;
            set;
        }
        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            if (drawArea.GraphicsCollection.Count > 0 && !drawArea.ReadOnly)
            {
                drawArea.GraphicsCollection[0].Normalize();
                drawArea.AddCommandToHistory(new CommandAdd(drawArea.GraphicsCollection[0]));
            }
            drawArea.CurrentGraphicsType = GraphicsType.Pointer;

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
            drawArea.GraphicsCollection.UnselectAll();

            drawArea.GraphicsCollection.Add(o);

            drawArea.Capture = true;
            drawArea.Refresh();

            o.Selected = true;

            drawArea.SetDirty();
        }

        public static Point TranslatePoint(DrawArea drawArea, Point p)
        {
            return new Point(p.X + Math.Abs(drawArea.AutoScrollPosition.X), p.Y + Math.Abs(drawArea.AutoScrollPosition.Y));
        }

        public static DrawObject GetHitDrawObject(DrawArea drawArea, Point p)
        {
            var point = ToolObject.TranslatePoint(drawArea, p);
            point = ToolObject.UnzoomPoint(point, drawArea.Zoom);
            for (int i = 0; i < drawArea.GraphicsCollection.Count; i++)
            {
                int n = drawArea.GraphicsCollection[i].HitTest(point);

                if (n >= 0 && !(drawArea.GraphicsCollection[i] is DrawLine))
                {
                    return drawArea.GraphicsCollection[i];
                }
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
