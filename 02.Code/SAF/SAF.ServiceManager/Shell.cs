using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList;
using SAF.EntityFramework.Config;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace SAF.ServiceManager
{
    public partial class Shell : RibbonForm
    {
        private const string DefaultConnectionName = "Default";

        public Shell()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.App;

            InitNotifyIcon();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblRight.Caption = AssemblyInfoHelper.Company;

            InitData();

            this.Shown += Shell_Shown;
            this.FormClosing += Shell_FormClosing;
            this.treeService.GetSelectImage += treeService_GetSelectImage;
        }

        void treeService_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var obj = (sender as TreeList).GetDataRecordByNode(e.Node) as DataServiceConfig;

            if (obj != null)
            {
                if (HostList.Any(p => p.UniqueId == obj.UniqueId))
                    e.NodeImageIndex = 0;
                else
                    e.NodeImageIndex = 1;
            }
            else
            {
                e.NodeImageIndex = 1;
            }
        }

        void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.HostList.Any(p => p.IsActive))
            {
                var list = this.HostList.Where(p => p.IsActive).Select(x => x.UniqueId);
                var services = DataServiceConfigCollection.Current.Where(p => p.UniqueId.In(list)).Select(x => x.ServiceName).JoinText();

                e.Cancel = true;
                if (MessageService.AskQuestionFormatted("[{0}] 已启动,系统只能最小化.确定要最小化系统吗?{1}如果要退出系统,请停止所有服务再退出.", services, Environment.NewLine))
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
            }
            else
            {
                if (!MessageService.AskQuestion("确定要退出系统吗?"))
                    e.Cancel = true;
            }
        }

        private void InitNotifyIcon()
        {
            this.notifyIcon.Icon = Properties.Resources.App;
            this.notifyIcon.Text = this.Text;
        }

        private void InitData()
        {
            this.bsService.DataSource = DataServiceConfigCollection.Current;
        }

        void Shell_Shown(object sender, EventArgs e)
        {
            try
            {
                this.RefreshUI();
                this.Activate();
            }
            finally
            {
                SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
            }

        }

        public void RefreshUI()
        {
            dataServiceConfigControl.RefreshUI();
            this.dataServiceConfigControl.IsPreviewModel = true;

            var curr = this.bsService.Current as DataServiceConfig;

            bool currIsNull = curr == null;

            bool ServiceIsStart = false;

            if (!currIsNull)
            {
                ServiceIsStart = this.HostList.Any(p => p.UniqueId == curr.UniqueId);
            }

            string ServiceName = currIsNull ? "服务" : curr.ServiceName;

            this.bbiAddNewService.Enabled = !ServiceIsStart;
            this.bbiEditService.Enabled = !currIsNull && !ServiceIsStart;
            this.bbiDeleteService.Enabled = !currIsNull && !ServiceIsStart;

            this.bbiStartService.Enabled = !currIsNull && !ServiceIsStart;
            this.bbiStopService.Enabled = !currIsNull && ServiceIsStart;

            this.lblMessage.Caption = ServiceIsStart ? "[{0}]已启动,正在监听...".FormatEx(ServiceName) : "[{0}]已停止.".FormatEx(ServiceName);

            this.treeService.Refresh();
        }

        private void bbiAddNewService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var obj = new DataServiceConfig();

            var dlg = CreateConfigDialog();
            dlg.DataServiceConfig = obj;
            dlg.Text = "添加服务配置";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.bsService.Add(obj);
                this.bsService.EndEdit();
                DataServiceConfigCollection.Current.Save();
            }

            this.RefreshUI();
        }

        private DataServiceConfigDialog CreateConfigDialog()
        {
            var dlg = new DataServiceConfigDialog();
            dlg.Owner = this;
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.Width = 700;
            dlg.Height = 500;
            return dlg;
        }

        private void bbiEditService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bsService.Current == null)
            {
                MessageService.ShowError("没有服务可以编辑.");
                return;
            }

            var obj = this.bsService.Current as DataServiceConfig;
            var obj2 = ObjectCloner.Clone(obj) as DataServiceConfig;
            var dlg = CreateConfigDialog();
            dlg.DataServiceConfig = obj2;
            dlg.Text = "编辑服务配置";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var index = this.bsService.IndexOf(obj);
                this.bsService[index] = obj2;
                this.bsService.EndEdit();
                this.dataServiceConfigControl.DataServiceConfig = obj2;
                DataServiceConfigCollection.Current.Save();
            }

            this.RefreshUI();
        }

        private void bbiDeleteService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bsService.Current != null)
            {
                if (MessageService.AskQuestion("确定要删除当前选中的服务配置吗?"))
                {
                    this.bsService.RemoveCurrent();
                    DataServiceConfigCollection.Current.Save();
                }
            }
            else
            {
                MessageService.ShowError("没有服务可以删除.");
            }
            this.RefreshUI();
        }

        List<ThreadServiceHost> HostList = new List<ThreadServiceHost>();

        private void bbiStartService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!MessageService.AskQuestion("确定要启动服务吗?"))
                return;

            var config = this.bsService.Current as DataServiceConfig;
            if (HostList.Any(p => p.UniqueId == config.UniqueId))
                throw new Exception("服务已启动.");

            ProgressService.Show("正在尝试连接数据库");
            //测试数据库连接
            foreach (var item in config.ConnectionStringConfigs)
            {
                var tester = new SqlConnectionTester(ApplicationConfig.DecryptConnectionString(item.ConnectionString));
                if (!tester.Connect())
                {
                    ProgressService.Abort();
                    MessageService.ShowErrorFormatted("数据库连接失败,请检查[{0}]的连接字符串[{1}].", config.ServiceName, item.Name);
                    return;
                }
            }

            new ThreadServiceHost(this, HostList, config).Start();
        }

        public void CloseProgressAndRefreshUI()
        {
            ProgressService.Abort();
            this.RefreshUI();
        }

        public void ShowThreadException(Exception ex)
        {
            MessageService.ShowException(ex);
        }

        private void bbiStopService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!MessageService.AskQuestion("确定要停止服务吗?"))
                return;

            var config = this.bsService.Current as DataServiceConfig;

            var host = HostList.FirstOrDefault(p => p.UniqueId == config.UniqueId);
            if (host == null)
                throw new Exception("服务未启动.");

            if (host.IsActive)
                host.Stop();

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void treeService_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var obj = this.bsService.Current as DataServiceConfig;
            this.dataServiceConfigControl.DataServiceConfig = obj;
            this.RefreshUI();
        }

        private void Shell_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }
        }

        private void bbiExitApplication_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        internal void ShowProgressService(string message)
        {
            ProgressService.Show(message);
        }
    }
}
