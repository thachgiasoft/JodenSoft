using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblRight.Caption = AssemblyInfoHelper.Company;

            InitData();

            this.Shown += Shell_Shown;
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
            this.grvService.BestFitColumns();

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

        }

        private void grvService_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var obj = this.bsService.Current as DataServiceConfig;
            this.dataServiceConfigControl.DataServiceConfig = obj;
            this.RefreshUI();
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

            ProgressService.Show("正在启动服务...");

            var config = this.bsService.Current as DataServiceConfig;
            if (HostList.Any(p => p.UniqueId == config.UniqueId))
                throw new Exception("服务已启动.");
            //这里加服务
            new ThreadServiceHost(this, HostList, config).Start();

        }


        public void CloseProgressAndRefreshUI()
        {
            ProgressService.Close();
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

            ProgressService.Show("正在停止服务...");
            try
            {
                var config = this.bsService.Current as DataServiceConfig;

                var host = HostList.FirstOrDefault(p => p.UniqueId == config.UniqueId);
                if (host == null)
                    throw new Exception("服务未启动.");

                if (host.IsActive)
                    host.Stop();

                HostList.Remove(host);

                this.RefreshUI();
                ProgressService.Close();
            }
            catch (Exception ex)
            {
                this.RefreshUI();
                ProgressService.Abort();
                throw ex;
            }
        }
    }
}
