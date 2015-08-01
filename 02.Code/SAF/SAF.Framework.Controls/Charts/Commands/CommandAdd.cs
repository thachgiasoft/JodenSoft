using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Add new object command
    /// </summary>
    public class CommandAdd : Command
    {
        DrawObject drawObject;

        // Create this command with DrawObject instance added to the list
        public CommandAdd(DrawObject drawObject)
            : base()
        {
            // Keep copy of added object
            this.drawObject = drawObject.Clone();
        }

        public override void Undo(DrawArea drawArea)
        {
            drawArea.DeleteLastAddedObject();
        }

        public override void Redo(DrawArea drawArea)
        {
            drawArea.UnselectAll();
            drawArea.Add(drawObject);
        }
    }
}
