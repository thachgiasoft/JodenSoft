using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.View
{
    public class DirtyEventArgs : EventArgs
    {
        public bool IsDirty { get; private set; }

        public DirtyEventArgs(bool isDirty)
        {
            this.IsDirty = isDirty;
        }
    }

   
}
