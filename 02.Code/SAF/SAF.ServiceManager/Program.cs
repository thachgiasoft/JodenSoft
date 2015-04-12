﻿using DevExpress.LookAndFeel;
using SAF.Framework.ServiceModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;

namespace SAF.ServiceManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SAF.Foundation.ServiceModel.ServiceManager.Instance = new SAFServiceManager();

            SAF.Framework.Controls.SplashScreen.ShowSplashScreen("正在启动服务管理器...");

            System.Globalization.CultureInfo zhHans = new System.Globalization.CultureInfo("zh-Hans");
            System.Threading.Thread.CurrentThread.CurrentCulture = zhHans;
            System.Threading.Thread.CurrentThread.CurrentUICulture = zhHans;

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 9);
            DevExpress.Skins.SkinManager.EnableFormSkins();

            UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            ProgressService.SkinName = "Office 2013";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Shell());
        }
    }
}
