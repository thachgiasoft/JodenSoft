using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// 用来计算直线与直线交点的直线
    /// </summary>
    internal struct MyLine
    {
        ///根据直线方程定义 a*x+b*y+c=0
        public double a;
        public double b;
        public double c;
    }


    public static class LineHelper
    {
        private static MyLine GetLine(Point pt1, Point pt2)
        {
            MyLine line;
            line.a = pt2.Y - pt1.Y;
            line.b = pt1.X - pt2.X;
            line.c = pt2.X * pt1.Y - pt1.X * pt2.Y;
            return line;
        }

        public static bool PointInLine(Point pt1, Point pt2, Point pt3)
        {
            // Create path which contains wide line
            // for easy mouse selection
            var AreaPath = new GraphicsPath();
            var AreaPen = new Pen(Color.Black, 7);
            AreaPath.AddLine(pt1.X, pt1.Y, pt2.X, pt2.Y);
            AreaPath.Widen(AreaPen);

            // Create region from the path
            var AreaRegion = new Region(AreaPath);

            return AreaRegion.IsVisible(pt3);
        }

        public static Point? GetLineInterPt(Point pt1, Point pt2, Point pt3, Point pt4)
        {
            if (pt1 == pt2)
                return null;

            if (pt3 == pt4)
                return null;

            int x, y;
            MyLine Line1 = GetLine(pt1, pt2);
            MyLine Line2 = GetLine(pt3, pt4);

            //当a1b2-a2b1==0时,无交点
            double seta = Line1.a * Line2.b - Line2.a * Line1.b;
            if (seta == 0)
            {
                return null;
            }

            //当a1b2-a2b1!=0时,有一个交点
            //取b1c2-c1b2
            double p = (Line1.b * Line2.c - Line1.c * Line2.b);
            //计算 x= (b1c2-c1b2) / (a1b2-a2b1)
            x = (int)(p / seta);

            //计算y=(a2c1-a1c2)/(a1b2-a2b1)
            p = Line2.a * Line1.c - Line1.a * Line2.c;
            y = (int)(p / seta);

            return new Point(x, y);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="ptA">图形内的点</param>
        /// <param name="ptB"></param>
        /// <returns></returns>
        public static Point? GetRectInterPt(Rectangle rt, Point ptA, Point ptB)
        {
            if (ptA == ptB) return null;

            rt.Width = Math.Max(1, rt.Width);
            rt.Height = Math.Max(1, rt.Height);

            Point? ptRet = null;

            Rectangle rt2, rtTemp;
            rt2 = rt;

            rtTemp = new Rectangle();
            rtTemp.X = rt.Left + 1;
            rtTemp.Width = rt.Width - 2;
            rtTemp.Y = rt.Top + 1;
            rtTemp.Height = rt.Height - 2;

            rt = rtTemp;

            Point ptCenter = new Point(rt.Left + rt.Width / 2, rt.Top + rt.Height / 2);

            //右上角
            if (ptB.X >= ptCenter.X && ptB.Y <= ptCenter.Y)
            {
                //上线交点
                ptRet = GetLineInterPt(new Point(rt.Left, rt.Top), new Point(rt.Right, rt.Top), ptA, ptB);
                if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                {
                    //右线交点
                    ptRet = GetLineInterPt(new Point(rt.Right, rt.Top), new Point(rt.Right, rt.Bottom), ptA, ptB);
                    if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                    {
                        ptRet = null;
                    }
                }
            }
            //左上角
            if (ptB.X < ptCenter.X && ptB.Y < ptCenter.Y)
            {
                //上线交点
                ptRet = GetLineInterPt(new Point(rt.Left, rt.Top), new Point(rt.Right, rt.Top), ptA, ptB);
                if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                {
                    //左线交点
                    ptRet = GetLineInterPt(new Point(rt.Left, rt.Top), new Point(rt.Left, rt.Bottom), ptA, ptB);
                    if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                    {
                        ptRet = null;
                    }
                }
            }
            //左下角 
            if (ptB.X <= ptCenter.X && ptB.Y >= ptCenter.Y)
            {
                //底线交点
                ptRet = GetLineInterPt(new Point(rt.Left, rt.Bottom), new Point(rt.Right, rt.Bottom), ptA, ptB);
                if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                {
                    //左线交点
                    ptRet = GetLineInterPt(new Point(rt.Left, rt.Top), new Point(rt.Left, rt.Bottom), ptA, ptB);
                    if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                    {
                        ptRet = null;
                    }
                }
            }
            //右下角 
            if (ptB.X > ptCenter.X && ptB.Y > ptCenter.Y)
            {
                //底线交点
                ptRet = GetLineInterPt(new Point(rt.Left, rt.Bottom), new Point(rt.Right, rt.Bottom), ptA, ptB);
                if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                {
                    //右线交点
                    ptRet = GetLineInterPt(new Point(rt.Right, rt.Top), new Point(rt.Right, rt.Bottom), ptA, ptB);
                    if (!ptRet.HasValue || !rt2.Contains(ptRet.Value))
                    {
                        ptRet = null;
                    }
                }
            }

            return ptRet;

        }

    }








}
