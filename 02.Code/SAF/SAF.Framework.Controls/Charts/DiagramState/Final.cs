using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Final : DrawEllipse
    {
        public Final()
            : this(0, 0, 1, 1)
        {

        }

        public Final(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.Name = "结束";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Final;
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
            Rectangle.Width = 40;
            Rectangle.Height = 40;

            this.AllowBestFit = false;

            base.Draw(g);

            using (Pen pen = new Pen(PenColor, PenWidth))
            {
                var rect = DrawRectangle.GetNormalizedRectangle(Rectangle);

                using (var brush = DrawRectangle.GetBackgroundBrush(rect, Color.Linen))
                {
                    var rect2 = new Rectangle(rect.Left + rect.Width / 4, rect.Top + rect.Height / 4, rect.Width / 2, rect.Height / 2);

                    using (var brush2 = DrawRectangle.GetBackgroundBrush(rect, Color.Black))
                    {
                        g.FillEllipse(brush2, rect2);
                    }
                }
            }

        }

        protected override void DrawObjectContent(Graphics g)
        {
            DrawObjectContentAutoSize(g);
        }

        public override DrawObject Clone()
        {
            Final obj = new Final();
            obj.Rectangle = this.Rectangle;
            obj.BackColor = this.BackColor;

            FillDrawObjectFields(obj);
            return obj;
        }

    }

    class ToolFinal : ToolDiagramBase
    {
        public ToolFinal()
        {
            Cursor = new Cursor(GetType(), "Cursors.Final.cur");
        }


        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new Final(p.X, p.Y, 40, 40);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }
}
