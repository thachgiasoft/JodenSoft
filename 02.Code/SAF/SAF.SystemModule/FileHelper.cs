
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.IO;
using SAF.Foundation.ComponentModel;
using System.Diagnostics;
using SAF.SystemEntity;

namespace SAF.SystemModule
{
    public static class FileHelper
    {
        public static void SetFileInfo(sysFile sysFile, string fileName)
        {
            if (sysFile != null && !fileName.IsEmpty())
            {
                sysFile.FileData = File.ReadAllBytes(fileName);
                sysFile.Name = Path.GetFileName(fileName).Trim();   
                sysFile.FileName = fileName;
                sysFile.FileSize = FileSize.GetSize(fileName);
                sysFile.LastWriteTime = File.GetLastWriteTime(fileName);
                sysFile.LastWriteTime = Convert.ToDateTime(sysFile.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                FileVersionInfo version = FileVersionInfo.GetVersionInfo(fileName);
                sysFile.FileVersion = "1.0.0.0";
                if (version.FileVersion != null)
                    sysFile.FileVersion = version.FileVersion;
            }
        }
    }
}
