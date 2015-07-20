
using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    public static class FileUpgradeHelper     
    {
        public static IList<string> GetNeedUpgradeFiles()
        {
            var result = new List<string>();

            var currFiles = Directory.GetFiles(Application.StartupPath);
            var es = new EntitySet<QueryEntity>();
            string sql = "SELECT [Name],[FileVersion],[LastWriteTime] FROM [dbo].[sysFile] with(nolock)";
            es.Query(sql);

            foreach (var item in es)
            {
                string fileName = Path.Combine(Application.StartupPath, item.GetFieldValue<string>("Name"));
                //取本地文件信息
                var lastWriteTime = File.GetLastWriteTime(fileName);
                lastWriteTime = Convert.ToDateTime(lastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                FileVersionInfo version = FileVersionInfo.GetVersionInfo(fileName);
                var fileVersion = "1.0.0.0";
                if (version.FileVersion != null)
                    fileVersion = version.FileVersion;

                if (new Version(item.GetFieldValue<string>("FileVersion")) != new Version(fileVersion)
                    || item.GetFieldValue<DateTime>("LastWriteTime") != lastWriteTime)
                {
                    result.Add(item.GetFieldValue<string>("Name"));
                }
            }

            return result;
        }

        private static string UpgradePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Upgrade");
            }
        }

        private static string TempPath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Temp");
            }
        }

        public static void UpgradeFiles(IList<string> files, Action<string> ShowMessage)
        {
            CreateUpgradeDirectory();

            var es = new EntitySet<QueryEntity>();
            var newFileList = new List<string>();
            foreach (var item in files)
            {
                ShowMessage(string.Format("正在下载文件 {0}...", item));
                es.Query("SELECT top 1 [Name],[FileData],[LastWriteTime] FROM [sysFile] with(nolock) WHERE [Name]=@Name", item);
                if (es.Count > 0)
                {
                    var bytes = es[0].GetFieldValue<byte[]>("FileData");
                    if (bytes != null && bytes.Length > 0)
                    {
                        var fileName = Path.Combine(UpgradePath, item);
                        newFileList.Add(fileName);
                        File.WriteAllBytes(fileName, bytes);
                        File.SetLastWriteTime(fileName, es[0].GetFieldValue<DateTime>("LastWriteTime"));
                    }
                }
            }

            foreach (var newFile in newFileList)
            {
                ShowMessage(string.Format("正在更新文件 {0}...", Path.GetFileName(newFile)));
                var oldFileName = Path.Combine(Application.StartupPath, Path.GetFileName(newFile));
                var tempFileName = Path.Combine(TempPath, Path.GetFileName(newFile));
                if (File.Exists(oldFileName))
                {
                    File.Move(oldFileName, tempFileName);
                }
                File.Copy(newFile, oldFileName, true);
            }

        }

        private static void CreateUpgradeDirectory()
        {
            if (Directory.Exists(TempPath))
            {
                Directory.Delete(TempPath, true);
            }
            Directory.CreateDirectory(TempPath);
            File.SetAttributes(TempPath, FileAttributes.Hidden);

            if (Directory.Exists(UpgradePath))
            {
                Directory.Delete(UpgradePath, true);
            }
            Directory.CreateDirectory(UpgradePath);
            File.SetAttributes(UpgradePath, FileAttributes.Hidden);
        }
    }
}
