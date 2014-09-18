using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Foundation.ComponentModel
{
    public static class FileDialogHelper
    {
        public static string OpenFile(string title, string filter = null)
        {
            if (filter.IsEmpty())
            {
                filter = "所有文件(*.*)|*.*";
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Title = title.IsEmpty() ? "打开..." : title;
            dlg.CheckFileExists = true;
            dlg.RestoreDirectory = true;
            dlg.Filter = filter;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var result = dlg.ShowDialog();
            if (result==DialogResult.OK)
            {
                return dlg.FileName;
            }
            return string.Empty;
        }

        public static string[] OpenFiles(string title, string filter)
        {
            if (filter.IsEmpty())
            {
                filter = "所有文件(*.*)|*.*";
            }
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Title = title.IsEmpty() ? "打开..." : title;
            dlg.CheckFileExists = true;
            dlg.RestoreDirectory = true;
            dlg.Filter = filter;
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var result = dlg.ShowDialog();
            if (result==DialogResult.OK)
            {
                return dlg.FileNames;
            }
            return null;
        }
    }
}
