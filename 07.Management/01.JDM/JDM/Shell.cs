using JDM.Framework.ServiceModel;
using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM
{
    [Export("JDMShell", typeof(IJDMShell))]
    public partial class Shell : DevExpress.XtraBars.Ribbon.RibbonForm, IJDMShell
    {
        public Shell()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            InitMainMenu();
        }

        [ImportMany("MainMenuCommand", typeof(IMenuCommand))]
        Lazy<IMenuCommand, IMenuCommandMetadata>[] mainMenuCommands = null;

        void InitMainMenu()
        {
           
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                this.Activate();
            }
            finally
            {
                SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
            }
        }

        public Form View
        {
            get { return this; }
        }

        public DevExpress.XtraBars.Ribbon.RibbonControl RibbonControl
        {
            get { return this.ribbonMain; }
        }
    }
}
