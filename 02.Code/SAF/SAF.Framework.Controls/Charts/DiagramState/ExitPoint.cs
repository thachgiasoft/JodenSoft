#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：ExitPoint
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/11 11:15:10
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
    public class ExitPoint : DrawEllipse
    {
        public ExitPoint()
            : this(0, 0, 1, 1)
        {

        }

        public ExitPoint(int x, int y, int width, int height)
            : base()
        {
            this.Name = "出口";
            Rectangle = new Rectangle(x, y, width, height);
            Initialize();
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.ExitPoint;
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Linen;
            }
            set
            {
                base.BackColor = Color.Linen;
            }
        }

        public override DrawObject Clone()
        {
            ExitPoint obj = new ExitPoint();
            obj.Rectangle = this.Rectangle;
            obj.BackColor = this.BackColor;

            FillDrawObjectFields(obj);
            return obj;
        }

        [Browsable(false)]
        public override bool CanChangeBackColor
        {
            get
            {
                return false;
            }
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            Rectangle.Width = 40;
            Rectangle.Height = 40;

            this.AllowBestFit = false;

            base.Draw(g);

            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                var rectX = new Rectangle(rect.Left + rect.Width / 4, rect.Top + rect.Height / 4, rect.Width / 2, rect.Height / 2);

                g.DrawLine(pen, rectX.Location, new Point(rectX.Left + rectX.Width, rectX.Top + rectX.Height));
                g.DrawLine(pen, new Point(rectX.Left, rectX.Top + rectX.Height), new Point(rectX.Left + rectX.Width, rectX.Top));

            }
        }

        protected override void DrawObjectContent(Graphics g)
        {
            DrawObjectContentAutoSize(g);
        }

    }

    class ToolExitPoint : ToolDiagramBase
    {
        public ToolExitPoint()
        {
            Cursor = new Cursor(GetType(), "Cursors.Final.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new ExitPoint(p.X, p.Y, 40, 40);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }

}
