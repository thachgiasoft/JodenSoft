using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 消息呈现控件
    /// </summary>
    internal class MessageViewer : Control
    {
        const TextFormatFlags textFlags = TextFormatFlags.EndEllipsis //未完省略号
                                          | TextFormatFlags.WordBreak //允许换行
                                          | TextFormatFlags.NoPadding //无边距
                                          | TextFormatFlags.ExternalLeading //行间空白。NT5必须，不然文字挤在一起
                                          | TextFormatFlags.TextBoxControl; //避免半行

        const int IconSpace = 5; //图标与文本间距

        const float PreferredScale = 13;//最佳文本区块比例（宽/高）

        /// <summary>
        /// 最小高度。不要重写MinimumSize，那会在窗体移动和缩放时都会执行
        /// </summary>
        public int MinimumHeight
        {
            get
            {
                return (this.Icon != null ? Math.Max(this.Icon.Height, this.Font.Height) : this.Font.Height) + Padding.Vertical;
            }
        }

        /// <summary>
        /// 获取或设置图标
        /// </summary>
        public Icon Icon { get; set; }

        public MessageViewer()
        {
            this.SetStyle(ControlStyles.CacheText, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.ResizeRedraw, true); //重要

            this.DoubleBuffered = true; //双缓冲
            BackColor = Environment.OSVersion.Version.Major == 5 ? SystemColors.Control : Color.White;
        }

        //防Dock改变尺寸
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified | BoundsSpecified.Size);
        }

        /// <summary>
        /// 计算合适的消息区尺寸
        /// </summary>
        /// <param name="proposedSize">该参数此处定义为此控件可设置的最大尺寸</param>
        /// <remarks>该方法对太长的单行文本有做比例优化处理，避免用户摆头幅度过大扭到脖子</remarks>
        public override Size GetPreferredSize(Size proposedSize)
        {
            if (proposedSize.Width < 10) { proposedSize.Width = int.MaxValue; }
            if (proposedSize.Height < 10) { proposedSize.Height = int.MaxValue; }

            int reservedWidth = Padding.Horizontal + (this.Icon == null ? 0 : (this.Icon.Width + IconSpace));

            Size wellSize = Size.Empty;
            if (!string.IsNullOrEmpty(this.Text))
            {
                //用指定宽度测量文本面积
                Size size = TextRenderer.MeasureText(this.Text, this.Font, new Size(proposedSize.Width - reservedWidth, 0), textFlags);
                int lineHeight = TextRenderer.MeasureText(" ", this.Font, new Size(int.MaxValue, 0), textFlags).Height;//单行高，Font.Height不靠谱

                wellSize = Convert.ToSingle(size.Width) / size.Height > PreferredScale //过于宽扁的情况
                    ? Size.Ceiling(GetSameSizeWithNewScale(size, PreferredScale))
                    : size;

                //凑齐整行高，确保尾行显示
                wellSize.Height = Convert.ToInt32(Math.Ceiling(wellSize.Height / Convert.ToDouble(lineHeight))) * lineHeight;
            }
            if (this.Icon != null)
            {
                wellSize.Width += this.Icon.Width + IconSpace;
                wellSize.Height = Math.Max(this.Icon.Height, wellSize.Height);
            }
            wellSize += Padding.Size;

            //不应超过指定尺寸。宽度在上面已确保不会超过
            if (wellSize.Height > proposedSize.Height) { wellSize.Height = proposedSize.Height; }

            return wellSize;
        }

        /// <summary>
        /// 重绘
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = GetPaddedRectangle();

            //绘制图标
            if (this.Icon != null)
            {
                g.DrawIcon(this.Icon, Padding.Left, Padding.Top);

                //右移文本区
                rect.X += this.Icon.Width + IconSpace;
                rect.Width -= this.Icon.Width + IconSpace;

                //若文字太少，则与图标垂直居中
                if (this.Text.Length < 100)
                {
                    Size textSize = TextRenderer.MeasureText(g, this.Text, this.Font, rect.Size, textFlags);
                    if (textSize.Height <= this.Icon.Height)
                    {
                        rect.Y += (this.Icon.Height - textSize.Height) / 2;
                    }
                }
            }

            //g.FillRectangle(Brushes.Gainsboro, rect);//test

            //绘制文本
            TextRenderer.DrawText(g, this.Text, this.Font, rect, Color.Black, textFlags);

            base.OnPaint(e);
        }

        /// <summary>
        /// 根据原尺寸，得到相同面积、且指定比例的新尺寸
        /// </summary>
        /// <param name="src">原尺寸</param>
        /// <param name="scale">新尺寸比例。需是width/height</param>
        private static SizeF GetSameSizeWithNewScale(Size src, float scale)
        {
            int sqr = src.Width * src.Height;//原面积
            double w = Math.Sqrt(sqr * scale);//新面积宽
            return new SizeF(Convert.ToSingle(w), Convert.ToSingle(sqr / w));
        }

        /// <summary>
        /// 获取刨去Padding的内容区
        /// </summary>
        private Rectangle GetPaddedRectangle()
        {
            Rectangle r = this.ClientRectangle;
            r.X += this.Padding.Left;
            r.Y += this.Padding.Top;
            r.Width -= this.Padding.Horizontal;
            r.Height -= this.Padding.Vertical;
            return r;
        }
    }
}
