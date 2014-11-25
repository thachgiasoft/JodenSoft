#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：ToolDiagramBase
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/11 14:12:43
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
    class ToolDiagramBase : ToolObject
    {
        public override void OnMouseMove(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea.Cursor = Cursor;

            if (e.Button == MouseButtons.Left && drawArea.IsPointer)
            {
                Point point = ToolObject.TranslatePoint(drawArea, e.Location);
                drawArea.GraphicsCollection[0].MoveHandleTo(point, 5);
                drawArea.Refresh();
            }
        }
    }
}
