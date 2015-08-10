using DevExpress.XtraRichEdit;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls
{
    public class ObjectHelper
    {
        static RichEditDocumentServer rich = new RichEditDocumentServer();
        public static string GetPlainText(string htmlText)
        {
            rich.HtmlText = htmlText;
            return rich.Text.TrimStart();
        }
        public static void ShowWebSite(string url)
        {
            if (url == null) return;
            string processName = GetCorrectUrl(url);
            if (processName.Length == 0) return;
            StartProcess(processName);
        }
        public static string GetCorrectUrl(string url)
        {
            string ret = url.Replace(" ", string.Empty);
            if (ret.Length == 0) return string.Empty;
            const string protocol = "http://";
            const string protocol2 = "https://";
            if (ret.IndexOf(protocol) != 0 && ret.IndexOf(protocol2) != 0)
                ret = protocol + ret;
            return ret;
        }
        public static void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, "StartProcess出现错误!");
            }
        }
    }
}
