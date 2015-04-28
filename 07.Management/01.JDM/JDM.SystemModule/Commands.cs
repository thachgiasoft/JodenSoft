using JDM.Framework.ServiceModel;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.SystemModule
{
    [ExportMenuCommand(Menu = "服务端注册", MenuCategory = MenuCategory.SystemManagement, MenuOrder = 1)]
    internal class ServerRegsterViewCommand : MenuCommand
    {
        public override void Execute(object parameter)
        {
            MessageService.ShowError("234123");
        }
    }
}
