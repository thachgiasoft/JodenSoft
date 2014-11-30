using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Initial : DrawEllipse
    {
        public Initial()
            : this(0, 0, 1, 1)
        {

        }

        public Initial(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.Name = "开始";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Initial;
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Black;
            }
            set
            {
                base.BackColor = Color.Black;
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

        }

        protected override void DrawObjectContent(Graphics g)
        {
            DrawObjectContentAutoSize(g);
        }

        public override DrawObject Clone()
        {
            Initial obj = new Initial();
            obj.Rectangle = this.Rectangle;
            obj.BackColor = this.BackColor;

            FillDrawObjectFields(obj);
            return obj;
        }
    }

    class ToolInitial : ToolDiagramBase
    {
        public ToolInitial()
        {
            Cursor = new Cursor(GetType(), "Cursors.Initial.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new Initial(p.X, p.Y, 40, 40);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }
}
