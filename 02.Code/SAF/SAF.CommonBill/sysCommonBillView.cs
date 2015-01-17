using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework;
using SAF.Foundation.MetaAttributes;

namespace SAF.CommonBill
{
    [BusinessObject("通用单据")]
    public partial class sysCommonBillView : MasterDetailView
    {
        public sysCommonBillView()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [ViewParam("通用单据配置ID")]
        public virtual int CommonBillConfigId
        {
            get { return Convert.ToInt32(this.GetViewParam("CommonBillConfigId")); }
            set { this.SetViewParam("CommonBillConfigId", value.ToString()); }
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillViewViewModel();
        }

        public new sysCommonBillViewViewModel ViewModel
        {
            get { return this.ViewModel as sysCommonBillViewViewModel; }
        }

        private CommonBillConfig config = new CommonBillConfig();

        protected override void OnInitUI()
        {
            base.OnInitUI();

            var config = ViewModel.QueryBillConfg(this.CommonBillConfigId);

        }

    }
}
