using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.Framework.Controls.Chart
{
    /// <summary>
    /// Delete All command
    /// </summary>
    public class CommandDeleteAll : Command
    {
        List<DrawObject> cloneList;

        // Create this command BEFORE applying Delete All function.
        public CommandDeleteAll(DrawArea drawArea)
        {
            cloneList = new List<DrawObject>();

            // Make clone of the whole list.
            // Add objects in reverse order because GraphicsList.Add
            // insert every object to the beginning.
            int n = drawArea.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                cloneList.Add(drawArea[i].Clone());
            }
        }

        public override void Undo(DrawArea drawArea)
        {
            // Add all objects from clone list to list -
            // opposite to DeleteAll
            foreach (DrawObject o in cloneList)
            {
                drawArea.Add(o);
            }
        }

        public override void Redo(DrawArea drawArea)
        {
            // Clear list - make DeleteAll again
            drawArea.Clear();
        }
    }
}
