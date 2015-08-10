using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SAF.Framework.Controls.GanttChart
{
    public class DefaultRenderer : AbstractRenderer
    {
        public override Color BackColor
        {
            get
            {
                return Color.White;
            }
        }

        public override Color HeaderBackColor
        {
            get
            {
                return Color.FromArgb(213, 228, 242);
            }
        }

        public override Color ResourceBackColor
        {
            get
            {
                return Color.FromArgb(213, 228, 242);
            }
        }

        private Color _LabelColor
        {
            get
            {
                return Color.FromArgb(101, 147, 207);
            }
        }

        public override Color ScaleSeperatorColor
        {
            get
            {
                return Color.LightGray;
            }
        }

        private Font _Font = null;

        public override Font Font
        {
            get
            {
                if (_Font == null)
                {
                    _Font = new Font("Segoe UI", 8, FontStyle.Regular);
                }
                return _Font;
            }
        }

        public override void DrawScaleHeaderLabel(Graphics g, Rectangle rect, DateTime startTime, int scale, GanttView view)
        {
            DateTime date;
            int i;
            if (view == GanttView.HourView)
            {
                date = startTime.AddHours(scale);
                i = date.Hour;
            }
            else
            {
                date = startTime.AddHours(scale * 24);
                i = date.Day;
                var days = (new DateTime(date.Year, date.Month, 1).AddMonths(1) - new DateTime(date.Year, date.Month, 1)).Days;
            }

            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            if (view == GanttView.HourView)
            {
                if (i == 0)
                {
                    using (Pen pen = new Pen(_LabelColor))
                        g.DrawLine(pen, rect.X, rect.Top, rect.X, rect.Height);
                }
                else if (i == 11)
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.LineAlignment = StringAlignment.Center;
                        using (Font fntDayDate = new Font("Segoe UI", 9, FontStyle.Bold))
                        {
                            var str = date.Date.ToString("yyyy年MM月dd日");
                            g.DrawString(str, fntDayDate, SystemBrushes.WindowText, rect, sf);
                        }
                    }
                }
            }
            else if (view == GanttView.DayView)
            {
                if (i == 1)
                {
                    using (Pen pen = new Pen(_LabelColor))
                        g.DrawLine(pen, rect.X, rect.Top, rect.X, rect.Height);
                }
                else if (i == 14)
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.Alignment = StringAlignment.Near;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.LineAlignment = StringAlignment.Center;
                        using (Font fntDayDate = new Font("Segoe UI", 9, FontStyle.Bold))
                        {
                            var str = date.Date.ToString("yyyy年MM月");
                            g.DrawString(str, fntDayDate, SystemBrushes.WindowText, rect, sf);
                        }
                    }
                }
            }
        }

        public override void DrawScaleLabel(Graphics g, Rectangle rect, DateTime startTime, int scale, bool drawContent, GanttView view, int scaleWidth)
        {
            using (Pen pen = new Pen(_LabelColor))
            {
                g.DrawLine(pen, rect.X, rect.Top, rect.X, rect.Height);
                g.DrawLine(pen, rect.X, rect.Height, rect.Right, rect.Height);
            }

            if (drawContent)
            {
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    var str = string.Empty;

                    if (view == GanttView.HourView)
                        str = startTime.AddHours(scale).Hour.ToString();
                    else
                    {
                        var dt = startTime.AddDays(scale);
                        if (scaleWidth >= 120)
                            str = dt.ToString("yyyy-MM-dd");
                        else if (scaleWidth >= 72)
                            str = dt.ToString("MM-dd");
                        else
                            str = dt.Day.ToString();
                    }

                    using (var sf = new StringFormat())
                    {
                        var rect2 = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                        rect2.Width = scaleWidth;
                        sf.Alignment = StringAlignment.Center;
                        g.DrawString(str, ScaleFont, brush, rect2, sf);
                    }
                }
            }
        }

        public override void DrawResourceLabels(Graphics g, Rectangle rect, int headerHeight, int resourceWidth)
        {
            using (Pen pen = new Pen(_LabelColor))
            {
                g.DrawLine(pen, 0, headerHeight, resourceWidth, headerHeight);
                g.DrawLine(pen, resourceWidth, 0, resourceWidth, rect.Height);
            }
        }

        public override void DrawScaleHeader(Graphics g, Rectangle rect)
        {
            using (Pen aPen = new Pen(_LabelColor))
            {
                g.DrawRectangle(aPen, rect);
            }
        }

        public override void DrawTaskCenterHeader(Graphics g, Rectangle rect, int taskCenterWidth, string title, bool showHorizontalLine, bool newGroup)
        {
            if (showHorizontalLine)
            {
                using (Pen aPen = new Pen(this._LabelColor))
                {
                    //g.DrawLine(aPen, rect.X, rect.Top, rect.Right, rect.Top);
                    g.DrawLine(aPen, rect.X, rect.Bottom, rect.Right, rect.Bottom);
                }
            }

            rect.Width = taskCenterWidth;

            Color end = InterpolateColors(Color.FromArgb(183, 208, 219), Color.White, 0.5f);
            Color start = InterpolateColors(Color.FromArgb(149, 185, 203), Color.White, 0.3f);

            if (newGroup)
            {
                end = InterpolateColors(Color.White, Color.White, 0.5f);
                start = InterpolateColors(Color.White, Color.White, 0.3f);
            }

            // Draw back
            using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(aGB, new Rectangle() { X = rect.X, Y = rect.Y + 1, Width = rect.Width, Height = rect.Height - 2 });
            }

            using (Pen aPen = new Pen(this._LabelColor))
            {
                g.DrawLine(aPen, new Point(rect.X, rect.Y), new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(aPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(aPen, new Point(rect.X + rect.Width, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y));
            }

            rect.X += 10;
            rect.Y += 5;
            rect.Width -= 20;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                g.DrawString(title, this.Font, SystemBrushes.WindowText, rect, sf);
            }
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        }

        public override void DrawSelectionTaskCenterHeader(Graphics g, Rectangle rect, int taskCenterWidth, string title)
        {
            using (Pen aPen = new Pen(Color.FromArgb(238, 147, 17)))
            {
                g.DrawLine(aPen, rect.X, rect.Top, rect.Right, rect.Top);
                g.DrawLine(aPen, rect.X, rect.Bottom, rect.Right, rect.Bottom);
            }

            rect.Width = taskCenterWidth;

            Color end = InterpolateColors(Color.FromArgb(241, 159, 37), Color.White, 0.8f);
            Color start = InterpolateColors(Color.FromArgb(246, 196, 93), Color.White, 0.1f);

            // Draw back
            using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Horizontal))
                g.FillRectangle(aGB, rect);

            using (Pen aPen = new Pen(Color.FromArgb(238, 147, 17)))
                g.DrawRectangle(aPen, rect);

            rect.X += 10;
            rect.Y += 5;
            rect.Width -= 20;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                g.DrawString(title, this.Font, SystemBrushes.WindowText, rect, sf);
            }
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        }

        public override void DrawTask(Graphics g, Rectangle rect, Task task, bool isSelected, bool drawPercent)
        {
            Color start = InterpolateColors(task.BackColor, Color.White, 0.4f);
            Color end = InterpolateColors(task.BackColor, Color.FromArgb(191, 210, 234), 0.7f);

            using (Pen m_Pen = new Pen(task.BorderColor, 1))
                g.DrawRectangle(m_Pen, rect);

            if (isSelected)
            {
                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, this.SelectionTaskColor, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(aGB, rect);
                }
            }
            else
            {
                using (LinearGradientBrush aGB = new LinearGradientBrush(rect, start, end, LinearGradientMode.Vertical))
                    g.FillRectangle(aGB, rect);
            }

            g.TextRenderingHint = TextRenderingHint.SystemDefault;
            if (drawPercent)
            {
                using (Pen percent_Pen = new Pen(Color.DarkGreen, 2.0f))
                {
                    g.DrawLine(percent_Pen, rect.X, rect.Top + (rect.Bottom - rect.Top) / 2, rect.Left + (int)((rect.Right - rect.Left) * task.Percent), rect.Top + (rect.Bottom - rect.Top) / 2);
                }
            }

            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(task.Name, this.Font, SystemBrushes.WindowText, rect, sf);
            }
        }
    }
}
