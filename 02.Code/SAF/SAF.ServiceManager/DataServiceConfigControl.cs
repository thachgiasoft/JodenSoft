using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using SAF.Foundation.ComponentModel;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;

namespace SAF.ServiceManager
{
    [ToolboxItem(true)]
    public partial class DataServiceConfigControl : XtraUserControl
    {
        public DataServiceConfigControl()
        {
            InitializeComponent();
        }

        public bool TestConnectString()
        {
            if (this.bsConnectionString.Count <= 0)
            {
                MessageService.ShowError("未配置数据库连接字符串.");
                return false;
            }

            foreach (var item in this.bsConnectionString)
            {
                var obj = item as ConnectionStringConfig;
                if (obj == null || obj.ConnectionString.IsEmpty())
                {
                    MessageService.ShowError("未配置数据库连接字符串.");
                    return false;
                }
                if (obj.Name.IsEmpty())
                {
                    MessageService.ShowError("数据库连接名称为空.");
                    return false;
                }
            }
            return true;
        }

        private bool _IsPreviewModel = false;

        public bool IsPreviewModel
        {
            get { return this._IsPreviewModel; }
            set
            {
                if (this._IsPreviewModel != value)
                {
                    this._IsPreviewModel = value;
                    this.bbiConfigConnectionString.Enabled = !_IsPreviewModel;
                    this.txtServiceName.Properties.ReadOnly = _IsPreviewModel;
                    this.lciConnectionString.Visibility = _IsPreviewModel ? LayoutVisibility.Never : LayoutVisibility.Always;
                }
            }
        }

        private DataServiceConfig _DataServiceConfig = null;
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DataServiceConfig DataServiceConfig
        {
            get
            {
                return _DataServiceConfig;
            }
            set
            {
                if (value == null)
                {
                    _DataServiceConfig = value;
                    var obj = new DataServiceConfig();
                    this.bsService.DataSource = obj;
                    this.bsConnectionString.DataSource = obj.ConnectionStringConfigs;
                }
                else
                {
                    _DataServiceConfig = value;
                    this.bsService.DataSource = _DataServiceConfig;
                    this.bsConnectionString.DataSource = _DataServiceConfig.ConnectionStringConfigs;
                }
            }
        }

        public void RefreshUI()
        {
            this.grvConnectionString.BestFitColumns();
        }

        private void bbiConfigConnectionString_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var connectionString = string.Empty;
            var obj = this.bsConnectionString.Current as ConnectionStringConfig;
            if (obj != null)
            {
                connectionString = obj.ConnectionString;
            }

            var dlg = new ConnectionStringDialog();
            dlg.ConnectionString = ApplicationConfig.DecryptConnectionString(connectionString);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                obj = this.bsConnectionString.Current as ConnectionStringConfig;
                if (obj == null)
                {
                    obj = this.bsConnectionString.AddNew() as ConnectionStringConfig;
                    obj.Name = "Default";
                }
                obj.ConnectionString = ApplicationConfig.EncryptConnectionString(dlg.ConnectionString);
                this.bsConnectionString.EndEdit();
                this.bsConnectionString.ResetCurrentItem();
                RefreshUI();
            }
        }
    }
}
