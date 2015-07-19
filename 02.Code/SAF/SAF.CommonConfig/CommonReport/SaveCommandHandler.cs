using DevExpress.XtraReports.UserDesigner;
using SAF.Framework.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SAF.CommonConfig.CommonReport
{
    public class SaveCommandHandler : ICommandHandler
    {
        XRDesignPanel panel;

        sysCommonReportView CommonReportView;
        sysReportFormat format;

        public SaveCommandHandler(XRDesignPanel panel, sysCommonReportView CommonReportView)
        {
            this.panel = panel;
            this.CommonReportView = CommonReportView;
            format = CommonReportView.ViewModel.DetailEntitySet.CurrentEntity;
        }

        public virtual void HandleCommand(ReportCommand command, object[] args)
        {
            bool useNextHandler = false;
            if (!CanHandleCommand(command, ref useNextHandler)) return;

            // Save a report.
            Save();

        }

        public virtual bool CanHandleCommand(ReportCommand command, ref bool useNextHandler)
        {
            if (command == ReportCommand.SaveFile || command == ReportCommand.SaveAll)
                useNextHandler = false;
            else
                useNextHandler = true;
            // This handler is used for SaveFile, SaveFileAs and Closing commands.
            return !useNextHandler;

        }

        void Save()
        {
            // Write your custom saving here.
            System.IO.MemoryStream ms = new MemoryStream();
            panel.Report.SaveLayout(ms, true);
            byte[] arrFormat = ms.ToArray();
            format.FormatData = arrFormat;
            this.CommonReportView.Save();

            // Prevent the "Report has been changed" dialog from being shown.
            panel.ReportState = ReportState.Saved;
        }
    }

}
