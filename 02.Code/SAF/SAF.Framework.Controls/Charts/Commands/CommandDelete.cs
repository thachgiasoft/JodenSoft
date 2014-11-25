using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Delete command
    /// </summary>
    class CommandDelete : Command
    {
        List<DrawObject> cloneList;    // contains selected items which are deleted

        // Create this command BEFORE applying Delete All function.
        public CommandDelete(GraphicsCollection graphicsList)
        {
            cloneList = new List<DrawObject>();

            // Make clone of the list selection.

            foreach (DrawObject o in graphicsList.Selection)
            {
                cloneList.Add(o.Clone());
            }
        }

        public override void Undo(GraphicsCollection list)
        {
            list.UnselectAll();

            // Add all objects from cloneList to list.
            foreach (DrawObject o in cloneList)
            {
                list.Add(o);
            }
        }

        public override void Redo(GraphicsCollection list)
        {
            // Delete from list all objects kept in cloneList

            int n = list.Count;

            for (int i = n - 1; i >= 0; i--)
            {
                bool toDelete = false;
                DrawObject objectToDelete = list[i];

                foreach (DrawObject o in cloneList)
                {
                    if (objectToDelete.GUID == o.GUID)
                    {
                        toDelete = true;
                        break;
                    }
                }

                if (toDelete)
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}
