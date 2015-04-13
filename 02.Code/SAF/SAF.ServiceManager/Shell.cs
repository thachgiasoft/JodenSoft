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

        //void serviceWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        serviceHost = new ServiceHost(typeof(SAF.EntityFramework.Server.Hosts.WcfPortal));
        //        if (serviceHost.State != CommunicationState.Opened)
        //        {
        //            serviceHost.Open();
        //        }

        //        e.Result = "正常";
        //    }
        //    catch (Exception ex)
        //    {
        //        e.Result = ex;
        //    }
        //}

        private void RefreshUI()
        {
            dataServiceConfigControl.RefreshUI();
            this.dataServiceConfigControl.IsPreviewModel = true;
            this.grvService.BestFitColumns();

            bool currIsNull = (this.bsService.Current == null);
            this.bbiAddNewService.Enabled = !this.ServiceIsStart;
            this.bbiEditService.Enabled = !currIsNull && !this.ServiceIsStart;
            this.bbiDeleteService.Enabled = !currIsNull && !this.ServiceIsStart;

            this.bbiStartService.Enabled = !currIsNull && !this.ServiceIsStart;
            this.bbiStopService.Enabled = !currIsNull && this.ServiceIsStart;

            this.lblMessage.Caption = this.ServiceIsStart ? "服务已启动,正在监听..." : "服务已停止.";
        }

        private void grvService_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var obj = this.bsService.Current as DataServiceConfig;
            this.dataServiceConfigControl.DataServiceConfig = obj;
        }

        private void bbiAddNewService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var obj = new DataServiceConfig();
            obj.ServiceName = "未命名服务";

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
                this.dataServiceConfigControl.DataServiceConfig = obj2 ;
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


        private bool ServiceIsStart = false;

        private void bbiStartService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!MessageService.AskQuestion("确定要启动服务吗?"))
                return;

            ProgressService.Show("正在启动服务...");
            try
            {
                ServiceIsStart = true;
                this.RefreshUI();
                ProgressService.Close();
            }
            catch
            {
                this.RefreshUI();
                ProgressService.Abort();
            }

        }

        private void bbiStopService_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!MessageService.AskQuestion("确定要停止服务吗?"))
                return;

            ProgressService.Show("正在停止服务...");
            try
            {
                ServiceIsStart = false;
                this.RefreshUI();
                ProgressService.Close();
            }
            catch
            {
                this.RefreshUI();
                ProgressService.Abort();
            }
        }
    }
}
