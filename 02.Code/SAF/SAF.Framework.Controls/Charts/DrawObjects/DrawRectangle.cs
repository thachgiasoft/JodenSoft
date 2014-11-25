using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SAF.Framework.Controls.Charts
{
    [Serializable]
    public class DrawRectangle : DrawObject
    {
        private bool IsRoundedRectangle = false;

        public Rectangle Rectangle;

        public override int Left
        {
            get { return Rectangle.X; }
            set { Rectangle.X = value; }
        }
        public override int Top
        {
            get { return Rectangle.Y; }
            set { Rectangle.Y = value; }
        }

        public override int Width
        {
            get { return Rectangle.Width; }
            set { Rectangle.Width = value; }
        }
        public override int Height
        {
            get { return Rectangle.Height; }
            set { Rectangle.Height = value; }
        }

        [Browsable(false)]
        public bool AllowBestFit { get; set; }

        [Browsable(true), Category(Strings.Layout)]
        public virtual Color BackColor { get; set; }

        public static Color GetBackColor(int _iStatus)
        {
            if (_iStatus == 0)
            {
                return Color.FromArgb(-65536);
            }
            else if (_iStatus == 1)
            {
                return Color.FromArgb(-32768);
            }
            else if (_iStatus == 2)
            {
                return Color.FromArgb(-256);
            }
            else if (_iStatus == 3)
            {
                return Color.FromArgb(-16711936);
            }
            else if (_iStatus == 4)
            {
                return Color.Linen;
            }
            else if (_iStatus == 99)
            {
                return Color.FromArgb(-8355712);
            }
            else
            {
                return Color.Linen;
            }
        }

        protected override void SetiStatus(int _iStatus)
        {
            base.SetiStatus(_iStatus);

            if (this is UserCase || this is HSEntitySet)
                this.BackColor = DrawRectangle.GetBackColor(_iStatus);
        }

        [Browsable(false)]
        public virtual bool CanChangeBackColor
        {
            get { return true; }
        }

        public DrawRectangle()
            : this(0, 0, 1, 1, false)
        {

        }

        public DrawRectangle(int x, int y, int width, int height, bool isRoundedRectangle)
            : base()
        {
            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = width;
            Rectangle.Height = height;
            this.IsRoundedRectangle = isRoundedRectangle;

            this.BackColor = Color.Linen;
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Rectangle;
            }
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
            var drawRectangle = drawObject as DrawRectangle;
            drawRectangle.Rectangle = this.Rectangle;
            drawRectangle.IsRoundedRectangle = this.IsRoundedRectangle;
            drawRectangle.BackColor = this.BackColor;

            base.FillDrawObjectFields(drawObject);
        }


        private int minHeight = 0;
        private int minWidth = 0;

        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (this.AllowBestFit)
            {
                BestSize(g);
            }

            Pen pen = new Pen(PenColor, PenWidth);
            var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

            g.FillRectangle(Brushes.LightGray, rect.Left + 3, rect.Top + 3, rect.Width, rect.Height);

            using (var brush = DrawRectangle.GetBackgroundBrush(rect, this.BackColor))
            {
                if (IsRoundedRectangle)
                {
                    using (GraphicsPath path = GetRoundedRectPath(rect, Math.Min(rect.Width, rect.Height) / 10))
                    {
                        g.FillPath(brush, path);
                        g.DrawPath(pen, path);
                    }
                }
                else
                {
                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect);
                }
            }

            pen.Dispose();

            this.DrawObjectContent(g);

        }

        protected void BestSize(Graphics g)
        {
            var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);
            rect.Width = Math.Max(1, rect.Width);
            rect.Height = Math.Max(1, rect.Height);
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                int width = GetMaxStringLength(g);

                int textWidth = 0;
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    textWidth = (int)g.MeasureString(this.Text, this.Font).Width + 30;
                }

                width = width > 300 ? 300 : width;
                width = Math.Max(width, textWidth);

                var writeRect = new Rectangle(rect.Left, rect.Top, width, 0);
                this.minWidth = writeRect.Width;

                int height = 0;
                int count = 0;
                //写Text
                if (!this.Text.m_IsEmpty())
                {
                    using (Font font = new System.Drawing.Font(this.Font, FontStyle.Bold))
                    {
                        SizeF size = g.MeasureString("《" + this.Text + "》", font, writeRect.Width, sf);
                        writeRect.Height = (int)size.Height + 2;
                        height = writeRect.Height;
                        count++;
                    }
                }

                //写Name
                if (!this.Name.m_IsEmpty())
                {
                    SizeF size = g.MeasureString(this.Name, this.Font, writeRect.Width, sf);
                    writeRect.Height = (int)size.Height + 2;
                    height = writeRect.Height > height ? writeRect.Height : height;
                    count++;
                }

                //写Status
                if (!this.Status.m_IsEmpty())
                {
                    using (Font font = new System.Drawing.Font(this.Font, FontStyle.Underline))
                    {
                        SizeF size = g.MeasureString(this.Status, font, writeRect.Width, sf);
                        writeRect.Height = (int)size.Height + 2;
                        height = writeRect.Height > height ? writeRect.Height : height;
                        count++;
                    }
                }

                this.minHeight = height * count;
                if (minHeight == 0) minHeight = 50;
                if (minWidth == 0) minWidth = 100;
            }

            this.Width = Math.Max(100, this.minWidth);
            this.Height = Math.Max(50, this.minHeight);
        }

        /// <summary>
        /// 自动计算文本大小,全文本输出,输入出在图形的下方
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawObjectContentAutoSize(Graphics g)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);
                rect.Width = Math.Max(1, rect.Width);
                rect.Height = Math.Max(1, rect.Height);

                using (Pen pen = new Pen(PenColor, PenWidth))
                {
                    var writeRect = new Rectangle(rect.Left - rect.Width, rect.Top + rect.Height + 2, rect.Width * 3, 0);

                    //写Text
                    if (!this.Text.m_IsEmpty())
                    {
                        using (Font font = new System.Drawing.Font(this.Font, FontStyle.Bold))
                        {
                            SizeF size = g.MeasureString("《" + this.Text + "》", font, writeRect.Width, sf);
                            writeRect.Height = (int)size.Height + 2;

                            g.DrawString("《" + this.Text + "》", font, Brushes.Black, writeRect, sf);
                            writeRect = new Rectangle(writeRect.Left, writeRect.Top + writeRect.Height, writeRect.Width, 0);

                        }
                    }

                    //写Name
                    if (!this.Name.m_IsEmpty())
                    {
                        SizeF size = g.MeasureString(this.Name, this.Font, writeRect.Width, sf);
                        writeRect.Height = (int)size.Height + 2;

                        g.DrawString(this.Name, this.Font, Brushes.Black, writeRect, sf);
                        writeRect = new Rectangle(writeRect.Left, writeRect.Top + writeRect.Height, writeRect.Width, 0);
                    }

                    //写Status
                    if (!this.Status.m_IsEmpty())
                    {
                        using (Font font = new System.Drawing.Font(this.Font, FontStyle.Underline))
                        {
                            SizeF size = g.MeasureString(this.Status, font, writeRect.Width, sf);
                            writeRect.Height = (int)size.Height + 2;
                            g.DrawString(this.Status, font, Brushes.Black, writeRect, sf);
                        }

                    }
                }
            }

            this.AllowBestFit = false;
        }

        protected virtual void DrawObjectContent(Graphics g)
        {
            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                int Counter = 0;
                if (!this.Text.m_IsEmpty()) Counter++;
                if (!this.Name.m_IsEmpty()) Counter++;
                if (!this.Status.m_IsEmpty()) Counter++;
                #region
                if (Counter > 0)
                {
                    var writeRect = new Rectangle(rect.Location, new Size(rect.Width, rect.Height / Counter));

                    //写Text
                    if (!this.Text.m_IsEmpty())
                    {
                        if (writeRect.Width > 0 && writeRect.Height > 0)
                        {
                            g.DrawString("《" + this.Text + "》", this.Font, Brushes.Black, writeRect, DefaultStringFormat);
                            writeRect = new Rectangle(rect.Left, rect.Top + rect.Height / Counter, rect.Width, rect.Height / Counter);
                        }
                    }

                    //写Name
                    if (!this.Name.m_IsEmpty())
                    {
                        if (writeRect.Width > 0 && writeRect.Height > 0)
                        {
                            g.DrawString(this.Name, this.Font, Brushes.Black, writeRect, DefaultStringFormat);
                            writeRect = new Rectangle(rect.Left, rect.Top + rect.Height / Counter * (Counter - 1), rect.Width, rect.Height / Counter);
                        }
                    }

                    //写Status
                    if (!this.Status.m_IsEmpty())
                    {
                        if (writeRect.Width > 0 && writeRect.Height > 0)
                        {
                            using (Font font = new System.Drawing.Font(this.Font, FontStyle.Underline))
                            {
                                g.DrawString(this.Status, font, Brushes.Black, writeRect, DefaultStringFormat);
                            }
                        }
                    }
                }
                #endregion


            }

            this.AllowBestFit = false;
        }

        private int GetMaxStringLength(Graphics g)
        {
            string s = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.Name) && this.Name.Length + 2 > s.Length)
                s = this.Name;

            if (!string.IsNullOrWhiteSpace(this.Status) && this.Status.Length > s.Length)
                s = this.Status;

            return (int)g.MeasureString(s, this.Font).Width;
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

        protected void SetRectangle(int x, int y, int width, int height)
        {
            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = width;
            Rectangle.Height = height;
        }


        /// <summary>
        /// Get number of handles
        /// </summary>
        protected override int HandleCount
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
            return Rectangle.IntersectsWith(rectangle);
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

        /// <summary>
        /// Normalize rectangle
        /// </summary>
        public override void Normalize()
        {
            Rectangle = DrawRectangle.GetNormalizedRectangle(Rectangle);
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

        public static Brush GetBackgroundBrush(Rectangle rect, Color endColor)
        {
            rect.Width = Math.Max(1, rect.Width);
            rect.Height = Math.Max(1, rect.Height);
            return new LinearGradientBrush(rect, Color.White, endColor, LinearGradientMode.Vertical);
        }

        #endregion

        public override void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            int n = info.GetInt32(this.SerializationName(p => p.BackColor, orderNumber));
            BackColor = Color.FromArgb(n);

            this.IsRoundedRectangle = info.GetBoolean(this.SerializationName(p => p.IsRoundedRectangle, orderNumber));

            base.LoadFromStream(info, orderNumber);
        }

        public override void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(this.SerializationName(p => p.BackColor, orderNumber), BackColor.ToArgb());
            info.AddValue(this.SerializationName(p => p.IsRoundedRectangle, orderNumber), IsRoundedRectangle);

            base.SaveToStream(info, orderNumber);
        }


    }
}
