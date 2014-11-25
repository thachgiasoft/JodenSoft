#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：UseLine
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 14:58:48
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
    public class UseLine : DrawLine
    {
        public UseLine()
            : this(0, 0, 1, 0)
        {

        }

        public UseLine(int x1, int y1, int x2, int y2)
            : base(x1, y1, x2, y2, false, true, ArrowType.None)
        {
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Use;
            }
        }

        public override DrawObject Clone()
        {
            UseLine drawLine = new UseLine();
            drawLine.CurrentDrawArea = this.CurrentDrawArea;
            FillDrawObjectFields(drawLine);
            return drawLine;
        }
    }

    class ToolUseLine : ToolLine
    {
        public ToolUseLine()
            : base(false, true, ArrowType.None)
        {
            Cursor = new Cursor(GetType(), "Cursors.Use.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, System.Windows.Forms.MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            var obj = ToolObject.GetHitDrawObject(drawArea, e.Location);

            line = new UseLine(p.X, p.Y, p.X + 1, p.Y);
            line.CurrentDrawArea = drawArea;
            if (obj != null)
            {
                line.StartDrawObjectID = obj.GUID;
            }
            AddNewObject(drawArea, line);
        }

    }
}
