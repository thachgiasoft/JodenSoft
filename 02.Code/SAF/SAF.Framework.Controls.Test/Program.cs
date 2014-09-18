using DevExpress.LookAndFeel;
using DevExpress.Skins;
using SAF.Foundation.ServiceModel;
using SAF.Framework.ServiceModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceManager.Instance = new SAFServiceManager();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", 9f);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");
            ProgressService.SkinName = "Office 2013";
            SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
