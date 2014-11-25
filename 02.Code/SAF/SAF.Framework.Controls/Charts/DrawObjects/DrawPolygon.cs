using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SAF.Framework.Controls.Charts
{
    [Serializable]
    public class DrawPolygon : DrawRectangle
    {
        public DrawPolygon()
            : this(0, 0, 1, 1)
        {
        }

        public DrawPolygon(int x, int y, int width, int height)
            : base(x, y, width, height, false)
        {

        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Polygon;
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawPolygon obj = new DrawPolygon();

            FillDrawObjectFields(obj);
            return obj;
        }


        public override void Draw(Graphics g)
        {
            if (AllowBestFit)
            {
                BestSize(g);
            }
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                Point[] p = new Point[8];
                p[0] = new Point(rect.Right - 15, rect.Top);
                p[1] = new Point(rect.Left, rect.Top);
                p[2] = new Point(rect.Left, rect.Bottom);
                p[3] = new Point(rect.Right, rect.Bottom);

                p[4] = new Point(rect.Right, rect.Top + 15);
                p[5] = new Point(rect.Right - 15, rect.Top);
                p[6] = new Point(rect.Right - 15, rect.Top + 15);
                p[7] = new Point(rect.Right, rect.Top + 15);

                //画阴影
                g.FillRectangle(Brushes.LightGray, rect.Left + 3, rect.Top + 18, rect.Width, rect.Height - 15);
                //填充颜色
                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    g.FillPolygon(brush, p);
                }
                //画线
                g.DrawPolygon(pen, p);

                DrawObjectContent(g);
            }
        }


    }
}
