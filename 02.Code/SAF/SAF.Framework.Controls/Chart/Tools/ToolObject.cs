using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Chart
{
    /// <summary>
    /// Base class for all tools which create new graphic object
    /// </summary>
    abstract class ToolObject : Tool
    {
        /// <summary>
        /// Tool cursor.
        /// </summary>
        protected Cursor Cursor { get; set; }


        /// <summary>
        /// Left mouse is released.
        /// New object is created and resized.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="e"></param>
        public override void OnMouseUp(DrawArea drawArea, MouseEventArgs e)
        {
            drawArea[0].Normalize();
            drawArea.AddCommandToHistory(new CommandAdd(drawArea[0]));
            drawArea.ActiveDrawTool = DrawToolType.Pointer;

            drawArea.Capture = false;
            drawArea.Refresh();
        }

        /// <summary>
        /// Add new object to draw area.
        /// Function is called when user left-clicks draw area,
        /// and one of ToolObject-derived tools is active.
        /// </summary>
        /// <param name="drawArea"></param>
        /// <param name="o"></param>
        protected void AddNewObject(DrawArea drawArea, DrawObject o)
        {
            drawArea.UnselectAll();

            o.Selected = true;
            drawArea.Add(o);

            drawArea.Capture = true;
            drawArea.Refresh();

            drawArea.SetDirty();
        }
    }
}
