﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using SAF.Foundation;
using System.Drawing;
using DevExpress.Skins;
using DevExpress.XtraSplashScreen;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;
using SAF.Framework.ServiceModel;
using System.Threading;
using System.IO;
using SAF.Foundation.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Reflection;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;

namespace SAF.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SAF.Framework.Controls.SplashScreen.ShowSplashScreen("系统正在启动");

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在设置系统参数");
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 9f);

            var skinName = ApplicationConfigHelper.GetAppSetting("ApplicationSkinName");
            if (skinName.IsEmpty())
                skinName = "Office 2013";
            UserLookAndFeel.Default.SetSkinStyle(skinName);
            ProgressService.SkinName = skinName;
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在初始化服务");
            ServiceManager.Instance = new SAFServiceManager();

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在更新系统");
            Upgrade();

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在加载组件");
            ComposeModules();

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在创建系统目录");
            CreateSystemDirectory();

            SAF.Framework.Controls.SplashScreen.ShowMessage("正在加载系统配置信息");
            LoadSystemConfiguration();

            SAF.Framework.Controls.SplashScreen.ShowMessage("初始化主界面");
            var shell = CompositionHelper.Current.GetExportedValue<IShell>("Shell");
            shell.InitComponent();
            SAF.Framework.Controls.SplashScreen.ShowMessage("正在处理...");
            Application.Run(shell.View);
        }

        private static void Upgrade()
        {
            var autoUpgrade = ApplicationConfigHelper.GetAppSetting("AutoUpgrade");

            if (autoUpgrade.IsEmpty() || autoUpgrade.Trim().Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                var files = FileUpgradeHelper.GetNeedUpgradeFiles();
                if (files.Count > 0)
                {
                    FileUpgradeHelper.UpgradeFiles(files, ShowMessage);
                    ApplicationService.Current.RestartApplication();
                }
            }
        }

        private static void ShowMessage(string message)
        {
            SAF.Framework.Controls.SplashScreen.ShowMessage(message);
        }

        /// <summary>
        /// 创建系统保存配置信息的目录
        /// </summary>
        private static void CreateSystemDirectory()
        {
            try
            {
                if (!Directory.Exists(UserConfigHelper.ConfigPath))
                {
                    Directory.CreateDirectory(UserConfigHelper.ConfigPath);
                }
            }
            catch (Exception ex)
            {
                throw new CoreException("创建系统文件保存目录时出现错误，请查看错误详细信息。", ex);
            }
        }

        /// <summary>
        /// 加载系统配置信息
        /// </summary>
        private static void LoadSystemConfiguration()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new CoreException("加载系统配置信息出现错误，请查看错误详细信息。", ex);
            }
        }

        private static void ComposeModules()
        {
            try
            {
                var dllFiles = Directory.GetFiles(Application.StartupPath);

                AppDomain ad = AppDomain.CreateDomain("Test DLL Marked IsBusinessModule");
                try
                {
                    LoadAssemblyProxyObject obj = (LoadAssemblyProxyObject)ad.CreateInstanceFromAndUnwrap(LoadAssemblyProxyObject.AssemblyFileName, LoadAssemblyProxyObject.ProxyObjectTypeName);

                    foreach (var fileName in dllFiles)
                    {
                        if (!Path.GetExtension(fileName).Equals(".dll", StringComparison.InvariantCultureIgnoreCase)
                            && !Path.GetExtension(fileName).Equals(".exe", StringComparison.InvariantCultureIgnoreCase)) continue;

                        obj.LoadAssembly(fileName);
                        if (obj.IsBusinessModule())
                        {
                            SAF.Framework.Controls.SplashScreen.ShowMessage("正在加载模块 {0}".FormatEx(Path.GetFileName(fileName)));
                            CompositionHelper.Current.AddFile(fileName);
                        }
                    }
                    CompositionHelper.Current.AddAssembly(Assembly.GetExecutingAssembly());
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
                MessageService.ShowException(e.Exception, "系统发生未知异常.");
            }
            else
            {
                MessageBox.Show(e.Exception.GetAllMessage(), "系统异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}