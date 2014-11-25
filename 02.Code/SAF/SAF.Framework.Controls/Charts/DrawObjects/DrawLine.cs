using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace SAF.Framework.Controls.Charts
{
    [Serializable]
    public class DrawLine : DrawObject
    {
        [Browsable(false)]
        public Point StartPoint;
        [Browsable(false)]
        public Point EndPoint;
        [Browsable(false)]
        public Guid StartDrawObjectID { get; set; }
        [Browsable(false)]
        public Guid EndDrawObjectID { get; set; }
        /// <summary>
        /// 是否是虚线
        /// </summary>
        [Browsable(false)]
        public bool IsDotLine { get; set; }

        [Browsable(false)]
        public bool CanMove { get; set; }

        [Browsable(false)]
        public ArrowType ArrowType { get; set; }

        public DrawLine()
            : this(0, 0, 1, 0, false, true, ArrowType.Fill)
        {

        }

        internal DrawArea CurrentDrawArea { get; set; }

        public DrawLine(int x1, int y1, int x2, int y2, bool isDotLine, bool canMove, ArrowType drawArrowType)
            : base()
        {
            StartPoint.X = x1;
            StartPoint.Y = y1;
            EndPoint.X = x2;
            EndPoint.Y = y2;
            this.IsDotLine = isDotLine;
            this.CanMove = canMove;
            this.ArrowType = drawArrowType;

            this.StartOffsetSize = new Size(0, 0);
            this.EndOffsetSize = new Size(0, 0);

            this.StartDrawObjectID = Guid.Empty;
            this.EndDrawObjectID = Guid.Empty;

        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Line;
            }
        }

        [Browsable(false)]
        public override int Left
        {
            get
            {
                return StartPoint.X;
            }
            set
            {
                StartPoint.X = value;
            }
        }
        [Browsable(false)]
        public override int Top
        {
            get
            {
                return StartPoint.Y;
            }
            set
            {
                StartPoint.Y = value;
            }
        }
        [Browsable(false)]
        public override int Width
        {
            get
            {
                return Math.Abs(EndPoint.X - StartPoint.X);
            }
            set
            {
                EndPoint.X = StartPoint.X + value;
            }
        }
        [Browsable(false)]
        public override int Height
        {
            get
            {
                return Math.Abs(EndPoint.Y - StartPoint.Y);
            }
            set
            {
                EndPoint.Y = StartPoint.Y + value;
            }
        }

        [Browsable(false)]
        public Size StartOffsetSize { get; set; }
        [Browsable(false)]
        public Size EndOffsetSize { get; set; }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            DrawLine drawLine = new DrawLine();
            drawLine.CurrentDrawArea = this.CurrentDrawArea;
            FillDrawObjectFields(drawLine);
            return drawLine;
        }

        protected override void FillDrawObjectFields(DrawObject drawObject)
        {
            DrawLine drawLine = drawObject as DrawLine;

            drawLine.StartPoint = this.StartPoint;
            drawLine.EndPoint = this.EndPoint;
            drawLine.StartDrawObjectID = this.StartDrawObjectID;
            drawLine.EndDrawObjectID = this.EndDrawObjectID;
            drawLine.IsDotLine = this.IsDotLine;
            drawLine.StartOffsetSize = this.StartOffsetSize;
            drawLine.EndOffsetSize = this.EndOffsetSize;
            drawLine.ArrowType = this.ArrowType;

            base.FillDrawObjectFields(drawObject);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(PenColor, PenWidth);

            Point? point1, point2;

            if (this.StartDrawObjectID != Guid.Empty && this.EndDrawObjectID != Guid.Empty)
            {
                var StartDrawObject = CurrentDrawArea.GraphicsCollection.FirstOrDefault(p => p.GUID == this.StartDrawObjectID);
                if (StartOffsetSize == new Size(0, 0))
                {
                    StartPoint.X = StartDrawObject.Left + StartDrawObject.Width / 2;
                    StartPoint.Y = StartDrawObject.Top + StartDrawObject.Height / 2;
                }
                else
                {
                    StartPoint.X = StartDrawObject.Left + Math.Min(StartOffsetSize.Width, StartDrawObject.Width);
                    StartPoint.Y = StartDrawObject.Top + Math.Min(StartOffsetSize.Height, StartDrawObject.Height);
                }

                var EndDrawObject = CurrentDrawArea.GraphicsCollection.FirstOrDefault(p => p.GUID == this.EndDrawObjectID);
                if (EndOffsetSize == new Size(0, 0))
                {
                    EndPoint.X = EndDrawObject.Left + EndDrawObject.Width / 2;
                    EndPoint.Y = EndDrawObject.Top + EndDrawObject.Height / 2;
                }
                else
                {
                    EndPoint.X = EndDrawObject.Left + Math.Min(EndOffsetSize.Width, EndDrawObject.Width);
                    EndPoint.Y = EndDrawObject.Top + Math.Min(EndOffsetSize.Height, EndDrawObject.Height);
                }

                ////先算开始图形的交点
                Rectangle rt = new Rectangle(StartDrawObject.Left, StartDrawObject.Top, StartDrawObject.Width, StartDrawObject.Height);
                point1 = LineHelper.GetRectInterPt(rt, StartPoint, EndPoint);

                //算结束图形的交点
                rt = new Rectangle(EndDrawObject.Left, EndDrawObject.Top, EndDrawObject.Width, EndDrawObject.Height);
                point2 = LineHelper.GetRectInterPt(rt, EndPoint, StartPoint);

                if (point1.HasValue)
                {
                    StartPoint = point1.Value;
                }
                if (point2.HasValue)
                {
                    EndPoint = point2.Value;
                }
            }

            if (IsDotLine)
            {
                float[] dashValues = { 10, 8 };
                pen.DashPattern = dashValues;
            }

            if (this.ArrowType == ArrowType.Open)
            {
                var lineArrow = new AdjustableArrowCap(10, 10, false);
                pen.CustomEndCap = lineArrow;
                g.DrawLine(pen, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
            }
            else if (this.ArrowType == ArrowType.Fill)
            {
                var lineArrow = new AdjustableArrowCap(6, 6, true);
                pen.CustomEndCap = lineArrow;
                g.DrawLine(pen, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
            }
            else if (this.ArrowType == ArrowType.Empty)
            {
                this.DrawArrow(g, pen, new PointF(StartPoint.X, StartPoint.Y), new PointF(EndPoint.X, EndPoint.Y));
            }
            else
            {
                g.DrawLine(pen, StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
            }

            //写字
            if (!string.IsNullOrEmpty(this.Name))
            {
                var cp = new Point((EndPoint.X + StartPoint.X) / 2, (EndPoint.Y + StartPoint.Y) / 2);
                int width = Math.Max(Math.Abs(EndPoint.X - StartPoint.X), 100);
                int height = Math.Max(Math.Abs(EndPoint.Y - StartPoint.Y), 50);
                Rectangle rect = new Rectangle(cp.X - width / 2, cp.Y - height / 2, width, height);

                rect = DrawRectangle.GetNormalizedRectangle(rect);
                g.DrawString(this.Name, this.Font, Brushes.Black, rect, DefaultStringFormat);
            }
            pen.Dispose();
        }

        private void DrawArrow(Graphics graphics, Pen pen, PointF startPoint, PointF endPoint)
        {
            int ArrowLength = 15;
            int RelativeValue = 4;

            double distance = Math.Abs(Math.Sqrt(
               (startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) +
               (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y)));
            if (distance == 0)
            {
                return;
            }

            double xa = endPoint.X + ArrowLength * ((startPoint.X - endPoint.X)
                + (startPoint.Y - endPoint.Y) / RelativeValue) / distance;
            double ya = endPoint.Y + ArrowLength * ((startPoint.Y - endPoint.Y)
                - (startPoint.X - endPoint.X) / RelativeValue) / distance;
            double xb = endPoint.X + ArrowLength * ((startPoint.X - endPoint.X)
                - (startPoint.Y - endPoint.Y) / RelativeValue) / distance;
            double yb = endPoint.Y + ArrowLength * ((startPoint.Y - endPoint.Y)
                + (startPoint.X - endPoint.X) / RelativeValue) / distance;

            PointF[] polygonPoints ={ 
                 new PointF(endPoint.X , endPoint.Y), 
                 new PointF( (float)xa   ,  (float)ya),
                 new PointF( (float)xb   ,  (float)yb)};
            graphics.DrawLine(pen, startPoint, endPoint);
            graphics.DrawPolygon(pen, polygonPoints);
            graphics.FillPolygon(new SolidBrush(Color.White), polygonPoints);

        }

        protected override int HandleCount
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public override Point GetHandle(int handleNumber)
        {
            if (handleNumber == 1)
                return StartPoint;
            else
                return EndPoint;
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
            using (var AreaRegion = CreateObjects())
            {
                return AreaRegion.IsVisible(point);
            }
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            using (var AreaRegion = CreateObjects())
            {
                return AreaRegion.IsVisible(rectangle);
            }
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (handleNumber == 1)
                StartPoint = point;
            else
                EndPoint = point;

        }

        public override void Move(int deltaX, int deltaY)
        {
            StartPoint.X += deltaX;
            StartPoint.Y += deltaY;

            EndPoint.X += deltaX;
            EndPoint.Y += deltaY;

        }

        /// <summary>
        /// Create graphic objects used from hit test.
        /// </summary>
        protected virtual Region CreateObjects()
        {
            // Create path which contains wide line
            // for easy mouse selection
            using (var AreaPath = new GraphicsPath())
            {
                using (var AreaPen = new Pen(Color.Black, 7))
                {
                    AreaPath.AddLine(StartPoint.X, StartPoint.Y, EndPoint.X, EndPoint.Y);
                    AreaPath.Widen(AreaPen);
                    // Create region from the path
                    return new Region(AreaPath);
                }
            }
        }

        public override void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            this.StartPoint = (Point)info.GetValue(this.SerializationName(p => p.StartPoint, orderNumber), typeof(Point));
            this.EndPoint = (Point)info.GetValue(this.SerializationName(p => p.EndPoint, orderNumber), typeof(Point));

            this.StartDrawObjectID = (Guid)info.GetValue(this.SerializationName(p => p.StartDrawObjectID, orderNumber), typeof(Guid));
            this.EndDrawObjectID = (Guid)info.GetValue(this.SerializationName(p => p.EndDrawObjectID, orderNumber), typeof(Guid));

            this.IsDotLine = info.GetBoolean(this.SerializationName(p => p.IsDotLine, orderNumber));

            this.CanMove = info.GetBoolean(this.SerializationName(p => p.CanMove, orderNumber));
            this.ArrowType = (ArrowType)info.GetInt32(this.SerializationName(p => p.ArrowType, orderNumber));

            this.StartOffsetSize = (Size)info.GetValue(this.SerializationName(p => p.StartOffsetSize, orderNumber), typeof(Size));
            this.EndOffsetSize = (Size)info.GetValue(this.SerializationName(p => p.EndOffsetSize, orderNumber), typeof(Size));

            base.LoadFromStream(info, orderNumber);
        }

        public override void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(this.SerializationName(p => p.StartPoint, orderNumber), StartPoint);
            info.AddValue(this.SerializationName(p => p.EndPoint, orderNumber), EndPoint);

            info.AddValue(this.SerializationName(p => p.StartDrawObjectID, orderNumber), StartDrawObjectID);
            info.AddValue(this.SerializationName(p => p.EndDrawObjectID, orderNumber), EndDrawObjectID);

            info.AddValue(this.SerializationName(p => p.IsDotLine, orderNumber), IsDotLine);

            info.AddValue(this.SerializationName(p => p.CanMove, orderNumber), this.CanMove);

            info.AddValue(this.SerializationName(p => p.ArrowType, orderNumber), (int)this.ArrowType);

            info.AddValue(this.SerializationName(p => p.StartOffsetSize, orderNumber), this.StartOffsetSize);
            info.AddValue(this.SerializationName(p => p.EndOffsetSize, orderNumber), this.EndOffsetSize);

            base.SaveToStream(info, orderNumber);
        }

    }


    public enum ArrowType
    {
        None = 0,
        /// <summary>
        /// 填充的箭头
        /// </summary>
        Fill = 1,
        /// <summary>
        /// 打开的箭头
        /// </summary>
        Open = 2,
        /// <summary>
        /// 空心的箭头
        /// </summary>
        Empty = 3
    }

}
