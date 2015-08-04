using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    class DrawEllipse : DrawRectangle
    {
        public DrawEllipse()
            : this(0, 0, 1, 1)
        {
        }

        public DrawEllipse(int x, int y, int width, int height)
            : base()
        {
            Rectangle = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawEllipse drawEllipse = new DrawEllipse();
            drawEllipse.Rectangle = this.Rectangle;

            FillDrawObjectFields(drawEllipse);
            return drawEllipse;
        }

        protected override void DrawGraph(Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);
                g.FillEllipse(Brushes.LightGray, rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    g.FillEllipse(brush, rect);
                }

                g.DrawEllipse(pen, rect);
            }

        }

    }
}
