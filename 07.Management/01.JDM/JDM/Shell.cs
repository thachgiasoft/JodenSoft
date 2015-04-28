using DevExpress.XtraTreeList;
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
            this.Icon = Properties.Resources.SAF_Icon;

            InitMainMenu();
        }

        [ImportMany("MainMenuCommand", typeof(IMenuCommand))]
        Lazy<IMenuCommand, IMenuCommandMetadata>[] mainMenuCommands = null;

        void InitMainMenu()
        {
           
        }

        private void TreeMenu_DoubleClick(object sender, EventArgs e)
        {
            var tree = (sender as TreeList);
            if (tree == null) return;
            Point point = tree.PointToClient(Cursor.Position);
            TreeListHitInfo hitInfo = tree.CalcHitInfo(point);
            switch (hitInfo.HitInfoType)
            {
                case HitInfoType.Cell:
                case HitInfoType.SelectImage:
                    ShowView(tree);
                    break;
                default:
                    this.Cursor = Cursors.Default;
                    break;
            }
        }

        private void ShowView(TreeList tree)
        {
            if (tree.FocusedNode != null)
            {
                var drv = tree.GetDataRecordByNode(tree.FocusedNode) as DataRowView;
                if (drv != null)
                {
                    //sysMenu entity = new sysMenu() { DataRowView = drv };
                    //if (entity.MenuType == (int)sysMenuType.Menu)
                    //{
                    //    ShowBusinessView(entity.DataRowView);
                    //}
                    //else if (entity.MenuType.In((int)sysMenuType.ExternalForm))
                    //{
                    //    string fileName = Path.Combine(Application.StartupPath, entity.GetFieldValue<string>("MenuFileName"));
                    //    if (!File.Exists(fileName))
                    //    {
                    //        MessageService.ShowErrorFormatted("菜单对应的文件名不存在.文件名称为:{0}", fileName);
                    //        return;
                    //    }
                    //    var param = ParseFileParameter(entity.FileParameter);
                    //    ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
                    //    startInfo.Arguments = param;
                    //    var customProcess = Process.Start(startInfo);
                    //    if (entity.IsShowDialog)
                    //        customProcess.WaitForExit();
                    //}
                }
            }
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
