using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// 应用程序上下文
    /// </summary>
    public class ApplicationService
    {
        private static object lockobj = new object();
        private static ApplicationService current = null;
        public static ApplicationService Current
        {
            get
            {
                if (current == null)
                {
                    lock (lockobj)
                    {
                        if (current == null)
                        {
                            current = new ApplicationService();
                        }
                    }
                }
                return current;
            }
        }

        private Form _MainForm = null;

        public Form MainForm
        {
            get
            {
                return this._MainForm;
            }
            set
            {
                if (value != null)
                {
                    this._MainForm = value;
                    this.MainFormHandle = value.Handle;
                }
                else
                {
                    this._MainForm = null;
                    this.MainFormHandle = IntPtr.Zero;
                }
            }
        }

        public IntPtr MainFormHandle
        {
            get;
            private set;
        }


        /// <summary>
        /// 重启主程序
        /// </summary>
        public void RestartApplication()
        {
            ProcessStartInfo startInfo = Process.GetCurrentProcess().StartInfo;
            startInfo.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            Process.Start(startInfo);
            Thread.Sleep(5);
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string ConfigFilePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "Config");
            }
        }
    }
}
