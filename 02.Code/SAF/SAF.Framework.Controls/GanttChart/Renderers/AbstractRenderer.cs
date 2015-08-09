using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SAF.Framework.Controls.GanttChart
{
    public abstract class AbstractRenderer
    {
        public virtual Color BackColor
        {
            get { return Color.White; }
        }

        public virtual Color HeaderBackColor
        {
            get { return SystemColors.Control; }
        }

        public virtual Color ResourceBackColor
        {
            get { return SystemColors.Control; }
        }

        public virtual Font Font
        {
            get { return Control.DefaultFont; }
        }

        public virtual Color NowLineColor
        {
            get
            {
                return Color.DarkBlue;
            }
        }

        public virtual Color DeliveryTimeLineColor
        {
            get
            {
                return Color.Red;
            }
        }

        private Color _SelectionTaskColor = Color.Red;
        public virtual Color SelectionTaskColor
        {
            get
            {
                return _SelectionTaskColor;
            }
            set
            {
                _SelectionTaskColor = value;
            }
        }

        private Font _scaleFont;

        public virtual Font ScaleFont
        {
            get
            {
                if (_scaleFont == null)
                {
                    _scaleFont = new Font(this.Font.FontFamily, 12, FontStyle.Regular);
                }
                return _scaleFont;
            }
        }

        public virtual Color ScaleSeperatorColor
        {
            get
            {
                return System.Drawing.Color.FromArgb(234, 208, 152);
            }
        }

        public virtual void DrawNowLine(Graphics g, Rectangle rect, int nowX)
        {
            using (Pen pen = new Pen(NowLineColor, 1.5f))
            {
                g.DrawLine(pen, nowX, rect.Top, nowX, rect.Height);
            }
        }

        public abstract void DrawScaleHeader(Graphics graphics, Rectangle rect);

        public abstract void DrawScaleHeaderLabel(Graphics g, Rectangle rect, DateTime startTime, int scale, GanttView view);

        public abstract void DrawScaleLabel(Graphics graphics, Rectangle hourRectangle, DateTime dateTime, int hour, bool drawContent, GanttView view, int scaleWidth);

        public abstract void DrawResourceLabels(Graphics g, Rectangle rect, int headerHeight, int resourceWidth);

        public abstract void DrawSelectionTaskCenterHeader(Graphics g, Rectangle rect, int leftWidth, string title);

        public abstract void DrawTaskCenterHeader(Graphics g, Rectangle rect, int leftWidth, string title, bool showHorizontalLine, bool newGroup);

        public abstract void DrawTask(Graphics graphics, Rectangle taskRect, Task task, bool isSelected, bool drawPercent);

        public static Color InterpolateColors(Color color1, Color color2, float percentage)
        {
            int num1 = ((int)color1.R);
            int num2 = ((int)color1.G);
            int num3 = ((int)color1.B);
            int num4 = ((int)color2.R);
            int num5 = ((int)color2.G);
            int num6 = ((int)color2.B);
            byte num7 = Convert.ToByte(((float)(((float)num1) + (((float)(num4 - num1)) * percentage))));
            byte num8 = Convert.ToByte(((float)(((float)num2) + (((float)(num5 - num2)) * percentage))));
            byte num9 = Convert.ToByte(((float)(((float)num3) + (((float)(num6 - num3)) * percentage))));
            return Color.FromArgb(num7, num8, num9);
        }


        internal void DrawDeliveryTimeLine(Graphics g, Rectangle rect, int deliveryX)
        {
            using (Pen pen = new Pen(this.DeliveryTimeLineColor, 1.5f))
            {
                g.DrawLine(pen, deliveryX, rect.Top, deliveryX, rect.Height);
            }
        }

        /// <summary>
        /// Draw tracker for selected object
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g, Rectangle rect)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int i = 1; i <= 8; i++)
                {
                    g.FillRectangle(brush, GetHandleRectangle(rect, i));
                }
            }
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(Rectangle rect, int handleNumber)
        {
            Point point = GetHandle(rect, handleNumber);

            return new Rectangle(point.X - 1, point.Y - 1, 3, 3);
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(Rectangle rect, int handleNumber)
        {
            int x, y, xCenter, yCenter;

            xCenter = rect.X + rect.Width / 2;
            yCenter = rect.Y + rect.Height / 2;
            x = rect.X;
            y = rect.Y;

            switch (handleNumber)
            {
                case 1:
                    x = rect.X;
                    y = rect.Y;
                    break;
                case 2:
                    x = xCenter;
                    y = rect.Y;
                    break;
                case 3:
                    x = rect.Right;
                    y = rect.Y;
                    break;
                case 4:
                    x = rect.Right;
                    y = yCenter;
                    break;
                case 5:
                    x = rect.Right;
                    y = rect.Bottom;
                    break;
                case 6:
                    x = xCenter;
                    y = rect.Bottom;
                    break;
                case 7:
                    x = rect.X;
                    y = rect.Bottom;
                    break;
                case 8:
                    x = rect.X;
                    y = yCenter;
                    break;
            }

            return new Point(x, y);
        }
    }
}
