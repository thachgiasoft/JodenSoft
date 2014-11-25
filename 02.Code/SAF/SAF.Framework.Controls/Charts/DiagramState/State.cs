#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：State
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/11 11:55:20
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
    public class State : DrawRectangle
    {
        public State()
            : this(0, 0, 1, 1)
        {
        }

        public State(int x, int y, int width, int height)
            : base(x, y, width, height, true)
        {
            this.Name = "状态";
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.State;
            }
        }

        public override DrawObject Clone()
        {
            State obj = new State();

            FillDrawObjectFields(obj);
            return obj;
        }

    }

    class ToolState : ToolDiagramBase
    {
        public ToolState()
        {
            Cursor = new Cursor(GetType(), "Cursors.RoundedRectangle.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj=new State(p.X, p.Y, 100, 50);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }

}
