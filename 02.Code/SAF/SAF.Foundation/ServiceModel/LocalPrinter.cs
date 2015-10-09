using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    public static class LocalPrinter
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        /// <summary>
        /// 获取本机默认打印机名称
        /// </summary>
        public static String DefaultPrinter
        {
            get
            {
                return fPrintDocument.PrinterSettings.PrinterName;
            }
        }

        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter); //默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                {
                    fPrinters.Add(fPrinterName);
                }
            }
            return fPrinters;
        }
    }
}
