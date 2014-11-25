#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：Note
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 14:17:43
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class Note : DrawPolygon
    {
        public Note()
            : this(0, 0, 1, 1)
        {
        }

        public Note(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.BackColor = Color.LightGray;

            this.Name = "备注";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Note;
            }
        }

        /// <summary>
        /// Clone this instance
        /// </summary>
        public override DrawObject Clone()
        {
            Note obj = new Note();

            FillDrawObjectFields(obj);
            return obj;
        }
    }

    class ToolNote : ToolDiagramBase
    {
        public ToolNote()
        {
            Cursor = new Cursor(GetType(), "Cursors.Polygon.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new Note(p.X, p.Y, 100, 50);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }
    }

}
