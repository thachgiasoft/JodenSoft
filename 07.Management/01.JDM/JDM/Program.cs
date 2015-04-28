using DevExpress.LookAndFeel;
using JDM.Framework.ServiceModel;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using SAF.Framework.ServiceModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace JDM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SAF.Framework.Controls.SplashScreen.ShowSplashScreen("系统正在启动");

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在设置系统参数");

            System.Globalization.CultureInfo zhHans = new System.Globalization.CultureInfo("zh-Hans");
            System.Threading.Thread.CurrentThread.CurrentCulture = zhHans;
            System.Threading.Thread.CurrentThread.CurrentUICulture = zhHans;

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 9);

            var ThemeName = "Office 2013";

            UserLookAndFeel.Default.SetSkinStyle(ThemeName);
            ProgressService.SkinName = ThemeName;

            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在初始化服务");
            ServiceManager.Instance = new SAFServiceManager();

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在加载组件");
            ComposeModules();

            SAF.Framework.Controls.SplashScreen.ShowMessage("初始化主界面");
            var shell = new Shell();
            SAF.Framework.Controls.SplashScreen.ShowMessage("正在处理...");
            Application.Run(shell.View);
        }

        private static void ComposeModules()
        {
            try
            {
                var dllFiles = Directory.GetFiles(Application.StartupPath);

                AppDomain ad = AppDomain.CreateDomain("Test JDM DLL Marked IsComposeModule");
                try
                {
                    LoadAssemblyProxyObject obj = (LoadAssemblyProxyObject)ad.CreateInstanceFromAndUnwrap(LoadAssemblyProxyObject.AssemblyFileName, LoadAssemblyProxyObject.ProxyObjectTypeName);

                    foreach (var fileName in dllFiles)
                    {
                        if (!Path.GetExtension(fileName).Equals(".dll", StringComparison.InvariantCultureIgnoreCase)
                            && !Path.GetExtension(fileName).Equals(".exe", StringComparison.InvariantCultureIgnoreCase)) continue;

                        obj.LoadAssembly(fileName);
                        if (obj.IsComposeModule())
                        {
                            SAF.Framework.Controls.SplashScreen.ShowMessage("正在加载模块 {0}".FormatEx(Path.GetFileName(fileName)));
                            CompositionHelper.Current.AddFile(fileName);
                        }
                    }
                    CompositionHelper.Current.ComposeParts();
                }
                finally
                {
                    AppDomain.Unload(ad);
                }
            }
            catch (Exception ex)
            {
                throw new CoreException("系统加载组件时出现错误，请查看错误详细信息。", ex);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
                MessageService.ShowException(ex);
                if (e.IsTerminating)
                {
                    Application.Exit();
                }
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            SAF.Framework.Controls.SplashScreen.CloseSplashScreen();

            if (ServiceManager.Instance != null)
            {
                MessageService.ShowException(e.Exception);
            }
            else
            {
                MessageBox.Show(e.Exception.GetAllMessage(), "系统异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
