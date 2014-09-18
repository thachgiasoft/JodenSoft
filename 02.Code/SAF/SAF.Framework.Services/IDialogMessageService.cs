using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Services
{
    public interface IDialogMessageService : IMessageService
    {
        IWin32Window DialogOwner { set; get; }
        ISynchronizeInvoke DialogSynchronizeInvoke { set; get; }
    }
}
