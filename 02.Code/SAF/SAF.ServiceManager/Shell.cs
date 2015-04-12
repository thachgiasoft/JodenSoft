using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
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
    public partial class Shell : XtraForm
    {
        private DataTable dtConnectionString = new DataTable();
        private BindingSource bsConnectionString = new BindingSource();

        private const string DefaultConnectionName = "Default";

        public Shell()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.lblRight.Caption = AssemblyInfoHelper.Company;

            InitConnectionStringTable();
            InitServiceWorker();

            this.Shown += Shell_Shown;
        }

        private void InitConnectionStringTable()
        {
            dtConnectionString.Columns.Add("连接名称", typeof(string));
            dtConnectionString.Columns.Add("连接字符串", typeof(string));

            this.bsConnectionString.DataSource = dtConnectionString;
            this.grdConnectionString.DataSource = bsConnectionString;
            this.grvConnectionString.Columns[0].Fixed = FixedStyle.Left;
        }

        void Shell_Shown(object sender, EventArgs e)
        {
            SAF.Framework.Controls.SplashScreen.CloseSplashScreen();
            this.RefreshServiceState(false);
            ReadConnectionString();
        }

        private void bbiEditConnectionString_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dlg = new ConnectionStringDialog();
            dlg.ConnectionString = ApplicationConfig.DecryptConnectionString(dtConnectionString.Rows[0]["连接字符串"].ToString());
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveConnectionString(dlg.ConnectionString);
            }
        }

        private void ReadConnectionString()
        {
            var connectionString = ApplicationConfig.GetConnectionString(DefaultConnectionName);
            var obj = this.dtConnectionString.AsEnumerable().FirstOrDefault(p => p.Field<string>("连接名称") == DefaultConnectionName);
            if (obj == null)
                obj = this.dtConnectionString.Rows.Add(DefaultConnectionName, connectionString);
            else
                obj["连接字符串"] = connectionString;
            obj.EndEdit();

            this.grvConnectionString.BestFitColumns();
        }

        private void SaveConnectionString(string connectionString)
        {
            connectionString = ApplicationConfig.EncryptConnectionString(connectionString);
            ApplicationConfig.SetConnectionString(DefaultConnectionName, connectionString);
            ReadConnectionString();
        }


        ServiceHost serviceHost = null;
        BackgroundWorker serviceWorker = new BackgroundWorker();

        private void RefreshServiceState(bool isStart)
        {
            this.lblMessage.Caption = isStart ? "服务已启动,正在进行侦听..." : "服务已停止";
            this.lblServiceState.Text = isStart ? "已启动" : "已停止";

            this.btnStartService.Enabled = !isStart;
            this.btnStopService.Enabled = isStart;
            this.btnServiceConfig.Enabled = !isStart;
        }

        private void InitServiceWorker()
        {
            serviceWorker.RunWorkerCompleted += serviceWorker_RunWorkerCompleted;
            serviceWorker.DoWork += serviceWorker_DoWork;
        }

        void serviceWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                serviceHost = new ServiceHost(typeof(SAF.EntityFramework.Server.Hosts.WcfPortal));
                if (serviceHost.State != CommunicationState.Opened)
                {
                    serviceHost.Open();
                }

                e.Result = "正常";
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void serviceWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                if (e.Result.ToString() == "正常")
                {
                    RefreshServiceState(true);
                }
                else
                {
                    MessageService.ShowException(e.Result as Exception);
                    RefreshServiceState(false);
                }
            }
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (!serviceWorker.IsBusy)
            {
                serviceWorker.RunWorkerAsync();
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {

        }

    }
}
