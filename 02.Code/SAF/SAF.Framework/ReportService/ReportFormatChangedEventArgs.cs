using System;

namespace SAF.Framework
{
    public class ReportFormatChangedEventArgs : EventArgs
    {
        public int ReportId { get; }
        public string ReportFormatName { get; }

        public ReportFormatChangedEventArgs(int reportId, string reportFormatName)
        {
            this.ReportId = reportId;
            this.ReportFormatName = reportFormatName;
        }
    }
}