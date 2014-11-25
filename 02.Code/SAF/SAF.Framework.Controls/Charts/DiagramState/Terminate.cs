#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：Terminate
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/11 14:01:44
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
    public class Terminate : DrawRectangle
    {
        public Terminate()
            : this(0, 0, 1, 1)
        {
        }

        public Terminate(int x, int y, int width, int height)
            : base(x, y, width, height, false)
        {
            this.Name = "终止";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Terminate;
            }
        }

        public override DrawObject Clone()
        {
            Terminate obj = new Terminate();
            FillDrawObjectFields(obj);
            return obj;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
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
            this.AllowBestFit = false;

            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                var rectX = new Rectangle(rect.Left + rect.Width / 4, rect.Top + rect.Height / 4, rect.Width / 2, rect.Height / 2);

                g.DrawLine(pen, rectX.Location, new Point(rectX.Left + rectX.Width, rectX.Top + rectX.Height));
                g.DrawLine(pen, new Point(rectX.Left, rectX.Top + rectX.Height), new Point(rectX.Left + rectX.Width, rectX.Top));

                DrawObjectContentAutoSize(g);
            }
        }
    }

    class ToolTerminate : ToolDiagramBase
    {
        public ToolTerminate()
        {
            Cursor = new Cursor(GetType(), "Cursors.Final.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj=new Terminate(p.X, p.Y, 40, 40);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }



    }
}
