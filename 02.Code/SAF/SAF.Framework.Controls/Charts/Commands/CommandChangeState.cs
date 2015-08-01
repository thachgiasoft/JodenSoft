using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Changing state of existing objects:
    /// move, resize, change properties.
    /// </summary>
    public class CommandChangeState : Command
    {
        // Selected object(s) before operation
        List<DrawObject> listBefore;

        // Selected object(s) after operation
        List<DrawObject> listAfter;
        

        // Create this command BEFORE operation.
        public CommandChangeState(DrawArea drawArea)
        {
            // Keep objects state before operation.
            FillList(drawArea, ref listBefore);
        }

        // Call this function AFTER operation.
        public void NewState(DrawArea drawArea)
        {
            // Keep objects state after operation.
            FillList(drawArea, ref listAfter);
        }

        public override void Undo(DrawArea drawArea)
        {
            // Replace all objects in the list with objects from listBefore
            ReplaceObjects(drawArea, listBefore);
        }

        public override void Redo(DrawArea drawArea)
        {
            // Replace all objects in the list with objects from listAfter
            ReplaceObjects(drawArea, listAfter);
        }

        // Replace objects in graphicsList with objects from list
        private void ReplaceObjects(DrawArea drawArea, List<DrawObject> list)
        {
            for ( int i = 0; i < drawArea.Count; i++ )
            {
                DrawObject replacement = null;

                foreach(DrawObject o in list)
                {
                    if ( o.ID == drawArea[i].ID )
                    {
                        replacement = o;
                        break;
                    }
                }

                if ( replacement != null )
                {
                    drawArea.Replace(i, replacement);
                }
            }
        }

        // Fill list from selection
        private void FillList(DrawArea drawArea, ref List<DrawObject> listToFill)
        {
            listToFill = new List<DrawObject>();

            foreach (DrawObject o in drawArea.Selection)
            {
                listToFill.Add(o.Clone());
            }
        }
    }
}
