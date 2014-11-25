using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Actor : DrawRectangle
    {
        private static readonly int MaxWidth = 41;
        private static readonly int MaxHeight = 80;

        [Browsable(false)]
        public override int Left
        {
            get { return Rectangle.X; }
            set { Rectangle.X = value; }
        }
        [Browsable(false)]
        public override int Top
        {
            get { return Rectangle.Y; }
            set { Rectangle.Y = value; }
        }
        [Browsable(false)]
        public override int Width
        {
            get { return Rectangle.Width; }
            set { Rectangle.Width = value; }
        }
        [Browsable(false)]
        public override int Height
        {
            get { return Rectangle.Height; }
            set { Rectangle.Height = value; }
        }

        public Actor()
            : this(0, 0)
        {
            this.Name = "行动者";
        }

        public Actor(int x, int y)
            : base()
        {
            Rectangle.X = x;
            Rectangle.Y = y;
            Rectangle.Width = MaxWidth;
            Rectangle.Height = MaxHeight;

            this.Name = "行动者";

            Initialize();
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Actor;
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            Actor obj = new Actor();
            obj.Rectangle = this.Rectangle;
            obj.BackColor = this.BackColor;

            FillDrawObjectFields(obj);
            return obj;
        }


        /// <summary>
        /// Draw rectangle
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            this.AllowBestFit = false;

            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                Rectangle.Width = MaxWidth;
                Rectangle.Height = MaxHeight;
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                rect.X = rect.X + 5;
                rect.Width = rect.Width - 10;

                rect.Y = rect.Y + 5;
                rect.Height = rect.Height - 10;

                int headHeight = Math.Min(rect.Width * 80, rect.Height * 33) / 100;
                var headrect = new Rectangle(new Point(rect.X + (rect.Width - headHeight) / 2, rect.Y), new Size(headHeight, headHeight));

                //画头
                g.DrawEllipse(pen, headrect);
                using (var brush = DrawRectangle.GetBackgroundBrush(headrect, this.BackColor))
                {
                    g.FillEllipse(brush, headrect);
                }
                var bodyHeight = (rect.Height - headHeight) / 2;

                //画身
                g.DrawLine(pen, new Point(rect.X + rect.Width / 2, rect.Top + headHeight), new Point(rect.X + rect.Width / 2, rect.Top + headHeight + bodyHeight));

                //画手
                g.DrawLine(pen, new Point(rect.X, rect.Top + headHeight + bodyHeight / 2), new Point(rect.Right, rect.Top + headHeight + bodyHeight / 2));

                //画脚
                g.DrawLine(pen, new Point(rect.X + rect.Width / 2, rect.Top + headHeight + bodyHeight), new Point(rect.Left, rect.Bottom));
                g.DrawLine(pen, new Point(rect.X + rect.Width / 2, rect.Top + headHeight + bodyHeight), new Point(rect.Right, rect.Bottom));

            }

            //写字
            this.DrawObjectContentAutoSize(g);
        }
    }

    class ToolActor : ToolObject
    {
        public ToolActor()
        {
            Cursor = new Cursor(GetType(), "Cursors.Actor.cur");
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left && drawArea.IsPointer)
            {
                Point point = ToolObject.TranslatePoint(drawArea, e.Location);
                drawArea.GraphicsCollection[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var actor = new Actor(p.X, p.Y);
            actor.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, actor);
            base.OnMouseUp(drawArea, e);
        }
    }
}
