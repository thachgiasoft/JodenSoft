#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：UserCase
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/12 14:59:19
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
    public class UserCase : DrawEllipse
    {
        public UserCase()
            : this(0, 0, 1, 1)
        {
            this.Name = "用例";
        }

        //public static UserCase CreateNew()
        //{
        //    UserCase obj = new UserCase();
        //    obj.Width = 100;
        //    obj.Height = 50;
        //    return obj;
        //}

        public UserCase(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.Name = "用例";

            this.iStatus = 0;
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.UserCase;
            }
        }

        public override DrawObject Clone()
        {
            UserCase obj = new UserCase();
            FillDrawObjectFields(obj);
            return obj;
        }
    }

    class ToolUserCase : ToolDiagramBase
    {
        public ToolUserCase()
        {
            Cursor = new Cursor(GetType(), "Cursors.Ellipse.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj=new UserCase(p.X, p.Y, 100, 50);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }
    }
}
