using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JDM.Framework.ServiceModel;
using System.ComponentModel.Composition;
using SAF.Framework.Controls;
using SAF.Foundation;
using SAF.Framework.ComponentModel;
using SAF.Foundation.ComponentModel;

namespace JDM.SystemModule.ComponentModel
{
    [Export(typeof(IJdmBackstageTabItem))]
    public partial class JdmConnectionConfigControl : JdmBaseBackstageTabItem
    {
        public JdmConnectionConfigControl()
        {
            InitializeComponent();
        }

        public override string Caption
        {
            get { return "连接配置"; }
        }

        public override bool IsSelected
        {
            get
            {
                return true;
            }
        }

        public override void Init()
        {
            base.Init();
            this.txtConnectionString.EditValue = ApplicationConfig.GetConnectionString("Default");
        }

        private void txtConnectionString_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ConnectionStringDialog dlg = new ConnectionStringDialog();
            dlg.ConnectionString = this.txtConnectionString.EditValue.ToStringEx();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var connectionString=ApplicationConfig.EncryptConnectionString(dlg.ConnectionString);
                this.txtConnectionString.EditValue = connectionString;
                ApplicationConfig.SetConnectionString("Default", connectionString);
                ApplicationConfig.SetAppSetting("DataPortalProxy", "Local");
            }
        }
    }
}
