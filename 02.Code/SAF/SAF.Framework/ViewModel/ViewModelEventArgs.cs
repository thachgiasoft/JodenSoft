using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    public class AfterSaveEventArgs : EventArgs
    {
        public bool IsSavedSuccessfully { get; private set; }

        public AfterSaveEventArgs(bool isSavedSuccessfully)
        {
            this.IsSavedSuccessfully = isSavedSuccessfully;
        }
    }
}
