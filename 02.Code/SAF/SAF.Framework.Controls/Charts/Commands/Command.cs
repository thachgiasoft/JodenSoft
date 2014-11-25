using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// Undo-Redo code is written using the article:
/// http://www.codeproject.com/cs/design/commandpatterndemo.asp
//  The Command Pattern and MVC Architecture
//  By David Veeneman.

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Base class for commands used for Undo - Redo
    /// </summary>
    public abstract class Command
    {
        // This function is used to make Undo operation.
        // It makes action opposite to the original command.
        public abstract void Undo(GraphicsCollection list);

        // This command is used to make Redo operation.
        // It makes original command again.
        public abstract void Redo(GraphicsCollection list);

        // Derived classes have members which contain enough information
        // to make Undo and Redo operations for every specific command.
    }

}
