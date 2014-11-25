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
    public class EntryPoint : DrawEllipse
    {
        public EntryPoint()
            : this(0, 0, 1, 1)
        {

        }

        [Browsable(false)]
        public override bool CanChangeBackColor
        {
            get
            {
                return false;
            }
        }

        public EntryPoint(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.Name = "入口";

        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.EntryPoint;
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
            EntryPoint obj = new EntryPoint();
            obj.Rectangle = this.Rectangle;
            obj.BackColor = this.BackColor;

            FillDrawObjectFields(obj);
            return obj;
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

    }

    class ToolEntryPoint : ToolDiagramBase
    {
        public ToolEntryPoint()
        {
            Cursor = new Cursor(GetType(), "Cursors.Final.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new EntryPoint(p.X, p.Y, 40, 40);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }

}
