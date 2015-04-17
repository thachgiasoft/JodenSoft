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
using SAF.Framework.Diaglogs;
using DevExpress.XtraEditors.Controls;

namespace SAF.Framework.Component
{
    [ToolboxItem(true)]
    [Export(typeof(IBackstageViewTabItem))]
    public partial class ConnectionConfigControl : BaseBackstageViewTabItem
    {
        public ConnectionConfigControl()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;

            this.Load += AppConfigControl_Load;
        }

        private const string DataPortalUrl = "DataPortalUrl";

        void AppConfigControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            string url = ApplicationConfig.GetAppSetting(DataPortalUrl);
            this.txtDataPortalUrl.EditValue = url;

            RefreshUI();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (this.txtDataPortalUrl.EditValue.ToStringEx().IsEmpty())
            {
                MessageService.ShowError("数据服务地址为空,请先输入数据服务地址.");
                this.txtDataPortalUrl.Focus();
                return;
            }

            ApplicationConfig.SetAppSetting(DataPortalUrl, this.txtDataPortalUrl.EditValue.ToStringEx());

            TestWcfProxy();
        }

        private void TestWcfProxy()
        {
            ProgressService.Show("正在尝试连接远程服务器,请稍等");
            try
            {
                var es = new EntitySet<QueryEntity>();
                es.Query("select getdate()");
                ProgressService.Close();
                MessageService.ShowMessage("连接成功!");
            }
            catch (Exception ex)
            {
                ProgressService.Close();
                MessageService.ShowException(ex, "连接失败!");
            }
        }

        protected override void OnRefreshUI()
        {
            if (Session.IsInvalid)
            {
                foreach (EditorButton item in this.txtDataPortalUrl.Properties.Buttons)
                {
                    item.Enabled = true;
                    item.Visible = true;
                }
            }
            else
            {
                foreach (EditorButton item in this.txtDataPortalUrl.Properties.Buttons)
                {
                    item.Enabled = false;
                    item.Visible = false;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = Color.Transparent;
        }

        public override string Caption
        {
            get { return "连接配置"; }
        }

        private void txtDataPortalUrl_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var url = this.txtDataPortalUrl.EditValue.ToStringEx();
            if (InputBox.Show("请输入数据服务地址", "数据服务地址：", ref url))
            {
                this.txtDataPortalUrl.EditValue = url;
                ApplicationConfig.SetAppSetting(DataPortalUrl, this.txtDataPortalUrl.EditValue.ToStringEx());
            }
        }


    }
}
