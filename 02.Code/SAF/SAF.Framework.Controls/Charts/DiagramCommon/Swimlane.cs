#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：Swimlane
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 16:09:33
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Swimlane : DrawRectangle
    {
        public Swimlane()
            : this(0, 0, 1, 1)
        {
        }

        public Swimlane(int x, int y, int width, int height)
            : base(x, y, width, height, false)
        {
            this.Name = "泳道";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Swimlane;
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            Swimlane obj = new Swimlane();

            FillDrawObjectFields(obj);
            return obj;
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set { }
        }

        [Browsable(false)]
        public override bool CanChangeBackColor
        {
            get
            {
                return false;
            }
        }


        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Gray, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);
                //rect.Width = Math.Max(1, rect.Width);
                //rect.Height = Math.Max(1, rect.Height);

                Color customColor = Color.FromArgb(50, Color.Linen);

                var brush = new SolidBrush(customColor);

                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);


                using (StringFormat sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Trimming = StringTrimming.EllipsisWord;
                    using (Font font = new System.Drawing.Font(this.Font.FontFamily, 11f, FontStyle.Underline))
                    {
                        var writeRect = new RectangleF(rect.Left, rect.Top + 5, rect.Width, 20);
                        g.DrawString(this.Name, font, Brushes.Black, writeRect, sf);
                    }
                }
            }
        }
    }

    class ToolSwimlane : ToolObject
    {
        public ToolSwimlane()
        {
            Cursor = new Cursor(GetType(), "Cursors.Rectangle.cur");
        }

        private Swimlane newSwimlane = null;

        public override void OnMouseDown(DrawArea drawArea, MouseEventArgs e)
        {
            base.OnMouseDown(drawArea, e);
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            newSwimlane = new Swimlane(p.X, p.Y, 1, 1);
            newSwimlane.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, newSwimlane);
        }

        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;
            if (e.Button == MouseButtons.Left && !drawArea.IsPointer)
            {
                Point point = ToolObject.TranslatePoint(drawArea, e.Location);
                drawArea.GraphicsCollection[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            if (newSwimlane != null)
            {
                newSwimlane.Width = Math.Max(200, newSwimlane.Width);
                newSwimlane.Height = Math.Max(80, newSwimlane.Height);
            }

            base.OnMouseUp(drawArea, e);

            drawArea.GraphicsCollection.MoveSwimlaneToBack();
            drawArea.Refresh();
        }

    }
}
