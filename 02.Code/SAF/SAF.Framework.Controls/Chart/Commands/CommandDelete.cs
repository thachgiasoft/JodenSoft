using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.Framework.Controls.Chart
{
    /// <summary>
    /// Delete command
    /// </summary>
    public class CommandDelete : Command
    {
        List<DrawObject> cloneList;    // contains selected items which are deleted

        // Create this command BEFORE applying Delete All function.
        public CommandDelete(DrawArea drawArea)
        {
            cloneList = new List<DrawObject>();

            // Make clone of the list selection.

            foreach (DrawObject o in drawArea.Selection)
            {
                cloneList.Add(o.Clone());
            }
        }

        public override void Undo(DrawArea drawArea)
        {
            drawArea.UnselectAll();

            // Add all objects from cloneList to list.
            foreach (DrawObject o in cloneList)
            {
                drawArea.Add(o);
            }
        }

        public override void Redo(DrawArea drawArea)
        {
            // Delete from list all objects kept in cloneList

            int n = drawArea.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                bool toDelete = false;
                DrawObject objectToDelete = drawArea[i];

                foreach (DrawObject o in cloneList)
                {
                    if (objectToDelete.ID == o.ID)
                    {
                        toDelete = true;
                        break;
                    }
                }

                if (toDelete)
                {
                    drawArea.RemoveAt(i);
                }
            }
        }
    }
}
