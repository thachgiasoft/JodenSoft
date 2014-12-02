using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public class DrawMenu : DrawRectangle
    {
        public DrawMenu()
            : this(0, 0, 1, 1)
        {
        }

        public DrawMenu(int x, int y, int width, int height)
            : base(x, y, width, height, true)
        {
            this.Name = "菜单";
        }

        public int iMenuId
        {
            get;
            set;
        }

        public override GraphicsType Type
        {
            get
            {
                return GraphicsType.Menu;
            }
        }

        public override DrawObject Clone()
        {
            DrawMenu obj = new DrawMenu();
            obj.iMenuId = iMenuId;
            FillDrawObjectFields(obj);
            return obj;
        }

        public override void SaveToStream(System.Runtime.Serialization.SerializationInfo info, int orderNumber)
        {
            info.AddValue(this.SerializationName(p => p.iMenuId, orderNumber), iMenuId);
            base.SaveToStream(info, orderNumber);
        }
        public override void LoadFromStream(System.Runtime.Serialization.SerializationInfo info, int orderNumber)
        {
            this.iMenuId = info.GetInt32(this.SerializationName(p => p.iMenuId, orderNumber));
            base.LoadFromStream(info, orderNumber);
        }

    }

    class ToolMenu : ToolDiagramBase
    {
        public ToolMenu()
        {
            Cursor = new Cursor(GetType(), "Cursors.RoundedRectangle.cur");
        }

        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            var p = ToolObject.TranslatePoint(drawArea, e.Location);
            p = ToolObject.UnzoomPoint(p, drawArea.Zoom);
            var obj = new DrawMenu(p.X, p.Y, 100, 50);
            obj.Name += " " + drawArea.NameIndex;
            AddNewObject(drawArea, obj);
            base.OnMouseUp(drawArea, e);
        }

    }
}
