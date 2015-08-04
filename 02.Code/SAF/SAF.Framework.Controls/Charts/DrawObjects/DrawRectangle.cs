using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Rectangle graphic object
    /// </summary>
    class DrawRectangle : DrawObject
    {
        private const string entryRectangle = "Rectangle";

        protected Rectangle Rectangle;

        private bool isRoundedRectangle = false;

        /// <summary>
        /// 
        /// </summary>
        public Color BackColor { get; set; }

        public DrawRectangle()
            : this(false, 0, 0, 1, 1)
        {
        }

        protected override void Initialize()
        {
            base.Initialize();
            this.BackColor = Color.Linen;
        }

        public DrawRectangle(bool isRoundedRectangle, int x, int y, int width, int height)
            : base()
        {
            this.Caption = string.Empty;
            this.Text = "Rectangle";

            this.isRoundedRectangle = isRoundedRectangle;

            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = width;
            Rectangle.Height = height;

        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawRectangle drawRectangle = new DrawRectangle();
            FillDrawObjectFields(drawRectangle);
            return drawRectangle;
        }

        protected override void FillDrawObjectFields(DrawObject drawObject)
        {
            base.FillDrawObjectFields(drawObject);
            var drawRectangle = drawObject as DrawRectangle;
            drawRectangle.Rectangle = this.Rectangle;
            drawRectangle.BackColor = this.BackColor;
        }

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
        protected override void DrawGraph(Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                this.Rectangle.Width = Math.Max(5, Rectangle.Width);
                this.Rectangle.Height = Math.Max(5, Rectangle.Height);

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
                {
                    if (isRoundedRectangle)
                    {
                        var backRect = new Rectangle(rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);

                        using (GraphicsPath path = GetRoundedRectPath(backRect, Math.Min(rect.Width, rect.Height) / 10))
                        {
                            g.FillPath(Brushes.LightGray, path);
                        }

                        using (GraphicsPath path = GetRoundedRectPath(rect, Math.Min(rect.Width, rect.Height) / 10))
                        {
                            g.FillPath(brush, path);
                            g.DrawPath(pen, path);
                        }
                    }
                    else
                    {
                        g.FillRectangle(Brushes.LightGray, rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);

                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                    }
                }
            }
        }

        protected override void DrawContent(Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);
                int Counter = 0;
                if (!this.Caption.IsEmpty()) Counter++;
                if (!this.Text.IsEmpty()) Counter++;

                if (Counter > 0)
                {
                    var writeRect = new Rectangle(rect.Location, new Size(rect.Width, rect.Height / Counter));

                    //写标题
                    if (!this.Caption.IsEmpty())
                    {
                        if (writeRect.Width > 0 && writeRect.Height > 0)
                        {
                            g.DrawString("《" + this.Caption + "》", this.Font, Brushes.Black, writeRect, StringFormat);
                            writeRect = new Rectangle(rect.Left, rect.Top + rect.Height / Counter, rect.Width, rect.Height / Counter);
                        }
                    }

                    //写文本
                    if (!this.Text.IsEmpty())
                    {
                        if (writeRect.Width > 0 && writeRect.Height > 0)
                        {
                            g.DrawString(this.Text, this.Font, Brushes.Black, writeRect, StringFormat);
                            //writeRect = new Rectangle(rect.Left, rect.Top + rect.Height / Counter * (Counter - 1), rect.Width, rect.Height / Counter);
                        }
                    }
                }
            }
        }


        protected void SetRectangle(int x, int y, int width, int height)
        {
            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = width;
            Rectangle.Height = height;
        }

        public static Brush GetBackgroundBrush(Rectangle rect, Color endColor)
        {
            rect.Width = Math.Max(1, rect.Width);
            rect.Height = Math.Max(1, rect.Height);
            return new LinearGradientBrush(rect, Color.White, endColor, LinearGradientMode.Vertical);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            diameter = diameter == 0 ? 1 : diameter;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            arcRect = DrawRectangle.GetNormalizedRectangle(arcRect);

            GraphicsPath path = new GraphicsPath();
            //左上
            path.AddArc(arcRect, 180, 90);

            //右上
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            //右下
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            //左下
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;

        }

        /// <summary>
        /// Get number of handles
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 8;
            }
        }


        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            int x, y, xCenter, yCenter;

            xCenter = Rectangle.X + Rectangle.Width / 2;
            yCenter = Rectangle.Y + Rectangle.Height / 2;
            x = Rectangle.X;
            y = Rectangle.Y;

            switch (handleNumber)
            {
                case 1:
                    x = Rectangle.X;
                    y = Rectangle.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = Rectangle.Y;
                    break;
                case 3:
                    x = Rectangle.Right;
                    y = Rectangle.Y;
                    break;
                case 4:
                    x = Rectangle.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = Rectangle.Right;
                    y = Rectangle.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = Rectangle.Bottom;
                    break;
                case 7:
                    x = Rectangle.X;
                    y = Rectangle.Bottom;
                    break;
                case 8:
                    x = Rectangle.X;
                    y = yCenter;
                    break;
            }

            return new Point(x, y);

        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {
            if (Selected)
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    if (GetHandleRectangle(i).Contains(point))
                        return i;
                }
            }

            if (PointInObject(point))
                return 0;

            return -1;
        }


        protected override bool PointInObject(Point point)
        {
            return Rectangle.Contains(point);
        }



        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                    return Cursors.SizeNWSE;
                case 2:
                    return Cursors.SizeNS;
                case 3:
                    return Cursors.SizeNESW;
                case 4:
                    return Cursors.SizeWE;
                case 5:
                    return Cursors.SizeNWSE;
                case 6:
                    return Cursors.SizeNS;
                case 7:
                    return Cursors.SizeNESW;
                case 8:
                    return Cursors.SizeWE;
                default:
                    return Cursors.Default;
            }
        }

        /// <summary>
        /// Move handle to new point (resizing)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            int left = Rectangle.Left;
            int top = Rectangle.Top;
            int right = Rectangle.Right;
            int bottom = Rectangle.Bottom;

            switch (handleNumber)
            {
                case 1:
                    left = point.X;
                    top = point.Y;
                    break;
                case 2:
                    top = point.Y;
                    break;
                case 3:
                    right = point.X;
                    top = point.Y;
                    break;
                case 4:
                    right = point.X;
                    break;
                case 5:
                    right = point.X;
                    bottom = point.Y;
                    break;
                case 6:
                    bottom = point.Y;
                    break;
                case 7:
                    left = point.X;
                    bottom = point.Y;
                    break;
                case 8:
                    left = point.X;
                    break;
            }

            SetRectangle(left, top, right - left, bottom - top);
        }


        public override bool IntersectsWith(Rectangle rectangle)
        {
            return this.Rectangle.IntersectsWith(rectangle);
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(int deltaX, int deltaY)
        {
            Rectangle.X += deltaX;
            Rectangle.Y += deltaY;
        }

        public override void Dump()
        {
            base.Dump();

            Trace.WriteLine("rectangle.X = " + Rectangle.X.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Y = " + Rectangle.Y.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Width = " + Rectangle.Width.ToString(CultureInfo.InvariantCulture));
            Trace.WriteLine("rectangle.Height = " + Rectangle.Height.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Normalize rectangle
        /// </summary>
        public override void Normalize()
        {
            Rectangle = DrawRectangle.GetNormalizedRectangle(Rectangle);
        }

        /// <summary>
        /// Save objevt to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public override void SaveToStream(System.Runtime.Serialization.SerializationInfo info, int orderNumber)
        {
            info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryRectangle, orderNumber), Rectangle);

            base.SaveToStream(info, orderNumber);
        }

        /// <summary>
        /// LOad object from serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public override void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            Rectangle = (Rectangle)info.GetValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryRectangle, orderNumber), typeof(Rectangle));

            base.LoadFromStream(info, orderNumber);
        }


        #region Helper Functions

        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static Rectangle GetNormalizedRectangle(Rectangle r)
        {
            return GetNormalizedRectangle(r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        }

        #endregion

    }
}
