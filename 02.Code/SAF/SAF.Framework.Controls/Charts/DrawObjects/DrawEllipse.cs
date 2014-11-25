using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Ellipse graphic object
    /// </summary>
    [Serializable]
    public class DrawEllipse : DrawRectangle
    {
        public DrawEllipse()
            : this(0, 0, 1, 1)
        {
        }

        public DrawEllipse(int x, int y, int width, int height)
            : base(x, y, width, height, false)
        {

        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Ellipse;
            }
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

                g.FillEllipse(Brushes.LightGray, rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    g.FillEllipse(brush, rect);
                }

                g.DrawEllipse(pen, rect);

                DrawObjectContent(g);
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawEllipse obj = new DrawEllipse();
            FillDrawObjectFields(obj);
            return obj;
        }


    }
}
