﻿#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：InvokesLine
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 14:59:10
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
    public class Reference : DrawLine
    {
        public Reference()
            : this(0, 0, 1, 0)
        {

        }

        public Reference(int x1, int y1, int x2, int y2)
            : base(x1, y1, x2, y2, false, false, ArrowType.Fill)
        {
            
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Reference;
            }
        }

        public override DrawObject Clone()
        {
            Reference drawLine = new Reference();
            drawLine.CurrentDrawArea = this.CurrentDrawArea;
            FillDrawObjectFields(drawLine);
            return drawLine;
        }
    }

    class ToolReference : ToolLine
    {
        public ToolReference()
            : base(false, false, ArrowType.Fill)
        {
            Cursor = new Cursor(GetType(), "Cursors.Line.cur");
        }

        public override void OnMouseDown(DrawArea drawArea, System.Windows.Forms.MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);

            var obj = ToolObject.GetHitDrawObject(drawArea, e.Location);

            line = new Reference(p.X, p.Y, p.X + 1, p.Y);
            line.CurrentDrawArea = drawArea;
            if (obj != null)
            {
                line.StartDrawObjectID = obj.GUID;
            }
            AddNewObject(drawArea, line);
        }
    }
}
