using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public class NotifyMessageEventArgs : EventArgs
    {
        public string Message { get; set; }

        public NotifyMessageEventArgs()
        {
            this.Message = string.Empty;
        }

        public NotifyMessageEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
