using System;
using System.Collections.Generic;
using System.Text;

/// Undo-Redo code is written using the article:
/// http://www.codeproject.com/cs/design/commandpatterndemo.asp
//  The Command Pattern and MVC Architecture
//  By David Veeneman.

namespace SAF.Framework.Controls.Chart
{
    /// <summary>
    /// Base class for commands used for Undo - Redo
    /// </summary>
    public abstract class Command
    {
        // This function is used to make Undo operation.
        // It makes action opposite to the original command.
        public abstract void Undo(DrawArea drawArea);

        // This command is used to make Redo operation.
        // It makes original command again.
        public abstract void Redo(DrawArea drawArea);

        // Derived classes have members which contain enough information
        // to make Undo and Redo operations for every specific command.
    }
}
