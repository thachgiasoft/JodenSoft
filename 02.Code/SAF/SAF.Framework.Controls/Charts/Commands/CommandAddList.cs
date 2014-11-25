using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    class CommandAddList : Command
    {
        List<DrawObject> cloneList;

        public CommandAddList(GraphicsCollection addList)
        {
            cloneList = new List<DrawObject>();

            // Make clone of the list selection.

            foreach (DrawObject o in addList)
            {
                cloneList.Add(o.Clone());
            }
        }

        public override void Undo(GraphicsCollection list)
        {
            list.UnselectAll();

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

        public override void Redo(GraphicsCollection list)
        {
            list.UnselectAll();

            // Add all objects from cloneList to list.
            foreach (DrawObject o in cloneList)
            {
                list.Add(o);
            }

        }
    }
}
