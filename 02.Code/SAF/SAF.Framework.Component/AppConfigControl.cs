using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation.ComponentModel;
using DevExpress.XtraLayout.Utils;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Foundation.Security;
using System.Data.SqlClient;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System.ComponentModel.Composition;

namespace SAF.Framework.Component
{
    [ToolboxItem(true)]
    [Export(typeof(IBackstageViewTabItem))]
    public partial class AppConfigControl : BaseBackstageViewTabItem
    {
        public AppConfigControl()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;

            this.Load += AppConfigControl_Load;
        }

        private const string DataPortalProxy = "DataPortalProxy";
        private const string DataPortalUrl = "DataPortalUrl";

        private const string WcfProxy = "SAF.EntityFramework.DataPortalClient.WcfProxy, SAF.EntityFramework";

        private const string LocalProxy = "local";

        private const string DefaultConnection = "Default";

        void AppConfigControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            //如果是本地访问
            var dataPortalProxy = ApplicationConfigHelper.GetAppSetting(DataPortalProxy);
            if (dataPortalProxy.IsEmpty() || dataPortalProxy.Equals(LocalProxy, StringComparison.InvariantCultureIgnoreCase))
            {
                this.cbxAccessMode.SelectedIndex = 0;

                string conStr = ApplicationConfigHelper.GetConnectionString(DefaultConnection);
                if (conStr.IsNotEmpty())
                {
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(conStr);
                    this.txtServer.EditValue = csb.DataSource;
                    this.txtDatabase.EditValue = csb.InitialCatalog;
                    this.txtUserName.EditValue = csb.UserID;
                    this.txtPassword.EditValue = csb.Password;
                }
                else
                {
                    this.txtServer.EditValue = null;
                    this.txtDatabase.EditValue = null;
                    this.txtUserName.EditValue = null;
                    this.txtPassword.EditValue = null;
                }
            }
            else
            {
                this.cbxAccessMode.SelectedIndex = 1;

                string url = ApplicationConfigHelper.GetAppSetting(DataPortalUrl);

            }

            RefreshUI();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (this.cbxAccessMode.SelectedIndex == 0)
            {
                if (ConnectionStringParamHaError()) return;
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = this.txtServer.EditValue.ToStringEx();
                csb.InitialCatalog = this.txtDatabase.EditValue.ToStringEx();
                csb.UserID = this.txtUserName.EditValue.ToStringEx();
                csb.Password = this.txtPassword.EditValue.ToStringEx();
                csb.ConnectTimeout = 10;
                TestLocalSqlConnection(csb.ConnectionString);
            }
            else
            {
                if (DataPortalUrlHasError()) return;

                ApplicationConfigHelper.SetAppSetting(DataPortalProxy, WcfProxy);
                ApplicationConfigHelper.SetAppSetting(DataPortalUrl, this.txtDataPortalUrl.EditValue.ToStringEx());

                TestWcfProxy();
            }
        }

        private void TestWcfProxy()
        {
            try
            {
                var es = new EntitySet<QueryEntity>();
                es.Query("select getdate()");
                MessageService.ShowMessage("连接成功!");
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, "连接失败!");
            }
        }

        private bool DataPortalUrlHasError()
        {
            if (this.txtDataPortalUrl.EditValue.IsEmpty())
            {
                MessageService.ShowError("请输入数据服务地址.");
                this.txtDataPortalUrl.Focus();
                return true;
            }
            return false;
        }

        private void TestLocalSqlConnection(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandTimeout = 5;
                    cmd.CommandText = "select getdate()";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteScalar();
                    MessageService.ShowMessage("连接成功!");
                }
                catch (Exception ex)
                {
                    MessageService.ShowException(ex, "连接失败!");
                }
            }
        }

        private bool ConnectionStringParamHaError()
        {
            if (this.txtServer.EditValue.IsEmpty())
            {
                MessageService.ShowError("请输入服务器名称或服务器IP地址.");
                this.txtServer.Focus();
                return true;
            }

            if (this.txtDatabase.EditValue.IsEmpty())
            {
                MessageService.ShowError("请输入数据库名称.");
                this.txtDatabase.Focus();
                return true;
            }

            if (this.txtUserName.EditValue.IsEmpty())
            {
                MessageService.ShowError("请输入用户名.");
                this.txtUserName.Focus();
                return true;
            }

            if (this.txtPassword.EditValue.IsEmpty())
            {
                MessageService.ShowError("请输入密码.");
                this.txtPassword.Focus();
                return true;
            }

            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cbxAccessMode.SelectedIndex == 0)
            {
                if (ConnectionStringParamHaError()) return;
                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = this.txtServer.EditValue.ToStringEx();
                csb.InitialCatalog = this.txtDatabase.EditValue.ToStringEx();
                csb.UserID = this.txtUserName.EditValue.ToStringEx();
                csb.Password = this.txtPassword.EditValue.ToStringEx();

                ApplicationConfigHelper.SetConnectionString(DefaultConnection, csb.ConnectionString, "System.Data.SqlClient");

                ApplicationConfigHelper.SetAppSetting(DataPortalProxy, LocalProxy);

                ApplicationConfigHelper.RemoveAppSetting(DataPortalUrl);

                MessageService.ShowMessage("保存成功!");
            }
            else
            {
                if (DataPortalUrlHasError()) return;

                ApplicationConfigHelper.RemoveConnectionString(DefaultConnection);

                ApplicationConfigHelper.SetAppSetting(DataPortalProxy, WcfProxy);
                ApplicationConfigHelper.SetAppSetting(DataPortalUrl, this.txtDataPortalUrl.EditValue.ToStringEx());

                MessageService.ShowMessage("保存成功!");
            }
        }

        private void cbxAccessMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshUI();
        }

        protected override void OnRefreshUI()
        {
            if (this.cbxAccessMode.SelectedIndex == 0)
            {
                lciServerName.Visibility = LayoutVisibility.Always;
                lciServerName.Control.Enabled = true;

                lciDataBaseName.Visibility = LayoutVisibility.Always;
                lciDataBaseName.Control.Enabled = true;

                lciUserName.Visibility = LayoutVisibility.Always;
                lciUserName.Control.Enabled = true;

                lciPassword.Visibility = LayoutVisibility.Always;
                lciPassword.Control.Enabled = true;

                lciRemote.Visibility = LayoutVisibility.Never;
                lciRemote.Control.Enabled = false;
            }
            else
            {
                lciServerName.Visibility = LayoutVisibility.Never;
                lciServerName.Control.Enabled = false;

                lciDataBaseName.Visibility = LayoutVisibility.Never;
                lciDataBaseName.Control.Enabled = false;

                lciUserName.Visibility = LayoutVisibility.Never;
                lciUserName.Control.Enabled = false;

                lciPassword.Visibility = LayoutVisibility.Never;
                lciPassword.Control.Enabled = false;

                lciRemote.Visibility = LayoutVisibility.Always;
                lciRemote.Control.Enabled = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.Transparent;
        }

        public override string Caption
        {
            get { return "系统配置"; }
        }


    }
}
