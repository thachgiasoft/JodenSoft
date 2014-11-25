#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：Object
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 14:24:29
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Objects : DrawRectangle
    {
        public Objects()
            : this(0, 0, 1, 1)
        {
        }

        public Objects(int x, int y, int width, int height)
            : base(x, y, width, height,false)
        {
            this.Name = "对象";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Objects;
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            Objects obj = new Objects();

            FillDrawObjectFields(obj);
            return obj;
        }
    }

    class ToolObjects : ToolDiagramBase
    {
        public ToolObjects()
        {
            Cursor = new Cursor(GetType(), "Cursors.Rectangle.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj=new Objects(p.X, p.Y, 100, 50);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }
    }
}
