using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Chart
{
    class DrawRhombus : DrawRectangle
    {
        public DrawRhombus()
            : this(0, 0, 1, 1)
        {
        }

        public DrawRhombus(int x, int y, int width, int height)
            : base(false, x, y, width, height)
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            this.Text = "Rhombus";
        }

        public override DrawObject Clone()
        {
            DrawRhombus obj = new DrawRhombus();
            FillDrawObjectFields(obj);
            return obj;
        }

        protected override void DrawGraph(System.Drawing.Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                Rectangle.Width = Math.Max(50, Rectangle.Width);
                Rectangle.Height = Math.Max(50, Rectangle.Height);

                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                PointF[] p = new PointF[4];
                p[0] = new PointF(rect.Left + rect.Width / 2.0F, rect.Top);
                p[1] = new PointF(rect.Left, rect.Top + rect.Height / 2.0F);
                p[2] = new PointF(rect.Left + rect.Width / 2.0F, rect.Bottom);
                p[3] = new PointF(rect.Right, rect.Top + rect.Height / 2.0F);

                PointF[] p2 = new PointF[4];
                for (int i = 0; i < 4; i++)
                {
                    p2[i] = new PointF(p[i].X + 3, p[i].Y + 3);
                }
                g.FillPolygon(Brushes.LightGray, p2);

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    g.FillPolygon(brush, p);
                }
                g.DrawPolygon(pen, p);

            }
        }

    }
}
