using DevExpress.XtraReports.UserDesigner;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.CommonConfig.CommonReport
{
    public class ClosingCommandHandler : ICommandHandler
    {
        XRDesignPanel panel;

        public ClosingCommandHandler(XRDesignPanel panel)
        {
            this.panel = panel;
        }

        public bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            if (command == ReportCommand.Closing)
                useNextHandler = false;
            else
                useNextHandler = true;

            // This handler is used for SaveFile, SaveFileAs and Closing commands.
            return !useNextHandler;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            bool useNextHandler = false;
            if (!CanHandleCommand(command, ref useNextHandler)) return;

            if (panel.ReportState == ReportState.Changed)
            {
                if (MessageService.AskQuestion("报表已被修改，是否保存？"))
                {
                    panel.ExecCommand(ReportCommand.SaveFile);
                }
            }
        }
    }
}
