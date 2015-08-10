using JDM.Framework.ServiceModel;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.SystemModule
{
    [JdmExportMenuCommand(Header = "服务端注册", Category = JdmMenuCategory.SystemManagement, Order = 50)]
    internal class ServerRegsterViewCommand : JdmMenuCommand
    {
        public override void Execute(object parameter)
        {
            var menu = parameter as JdmMenuInfo;
            var shell = (ApplicationService.Current.MainForm as IJdmShell);
            shell.ShowForm<RegistrationInfoView>(menu.Id, menu.MenuHeader);
        }
    }

    [JdmExportMenuCommand(Header = "客户管理", Category = JdmMenuCategory.SystemManagement, Order = 10)]
    internal class CustomerViewCommand : JdmMenuCommand
    {
        public override void Execute(object parameter)
        {
            var menu = parameter as JdmMenuInfo;
            var shell = (ApplicationService.Current.MainForm as IJdmShell);
            shell.ShowForm<CustomerView>(menu.Id, menu.MenuHeader);
        }
    }
}
