using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.ServiceManager
{
    public partial class DataServiceConfigDialog : XtraForm
    {
        public DataServiceConfig DataServiceConfig
        {
            get
            {
                return this.dataServiceConfigControl1.DataServiceConfig;
            }
            set
            {
                this.dataServiceConfigControl1.DataServiceConfig = value;
            }
        }

        public DataServiceConfigDialog()
        {
            InitializeComponent();

            this.dataServiceConfigControl1.IsPreviewModel = false;

            this.Shown += DataServiceConfigDialog_Shown;
        }


        void DataServiceConfigDialog_Shown(object sender, EventArgs e)
        {
            dataServiceConfigControl1.RefreshUI();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.dataServiceConfigControl1.DataServiceConfig.ServiceName.IsEmpty())
            {
                MessageService.ShowError("服务名称为空,请修改.");
                return;
            }

            if (DataServiceConfigCollection.Current.Any(p => p.ServiceName == this.dataServiceConfigControl1.DataServiceConfig.ServiceName
                && p.UniqueId != this.dataServiceConfigControl1.DataServiceConfig.UniqueId))
            {
                MessageService.ShowError("服务名称已存在,请修改.");
                return;
            }

            if (!dataServiceConfigControl1.TestConnectString())
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
