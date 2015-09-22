using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Chart
{
    class DrawLane : DrawRectangle
    {
        public DrawLane()
            : this(0, 0, 1, 1)
        {
        }

        public DrawLane(int x, int y, int width, int height)
            : base(false, x, y, width, height)
        {

        }

        protected override void Initialize()
        {
            base.Initialize();

            this.Text = "Lane";
        }

        public override DrawObject Clone()
        {
            DrawLane obj = new DrawLane();
            FillDrawObjectFields(obj);
            return obj;
        }

        private Brush GetBrush(Rectangle rect)
        {
            rect.Width = Math.Max(1, rect.Width);
            rect.Height = Math.Max(1, rect.Height);
            return new LinearGradientBrush(rect, Color.White,Color.White, LinearGradientMode.Vertical);
        }

        protected override void DrawGraph(System.Drawing.Graphics g)
        {
            Rectangle.Height = Math.Max(80, Rectangle.Height);
            Rectangle.Width = Math.Max(40, Rectangle.Width);
            var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var backRect = new Rectangle(rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);
                g.FillRectangle(Brushes.LightGray, backRect);

                using (var brush = GetBrush(rect))
                {
                    var fillRect = new Rectangle(rect.Left, rect.Top, rect.Width, 20);
                    g.FillRectangle(brush, fillRect);
                }

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    var fillRect = new Rectangle(rect.Left, rect.Top + 20, rect.Width, rect.Height - 20);
                    g.FillRectangle(brush, fillRect);
                }

                var startPoint = new Point(Rectangle.Left, Rectangle.Top + 20);
                var endPoint = new Point(Rectangle.Right, Rectangle.Top + 20);
                g.DrawLine(pen, startPoint, endPoint);

                g.DrawRectangle(pen, rect);
            }
        }

        protected override void DrawContent(Graphics g)
        {
            var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

            var str = string.IsNullOrWhiteSpace(this.Caption) ? this.Text : "《" + this.Caption + "》 " + this.Text;

            var writeRect = new Rectangle(rect.Left + rect.Width / 10, rect.Top, rect.Width / 10 * 8, 20);
            g.DrawString(str, this.Font, Brushes.Black, writeRect, StringFormat);

        }
    }
}
