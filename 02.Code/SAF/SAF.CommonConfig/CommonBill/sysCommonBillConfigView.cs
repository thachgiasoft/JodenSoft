using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
using SAF.Foundation.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using SAF.Foundation;
using SAF.CommonConfig.CommonBill;

namespace SAF.CommonConfig
{
    [BusinessObject("通用单据配置")]
    public partial class sysCommonBillConfigView : SingleView
    {
        public sysCommonBillConfigView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillConfigViewViewModel();
        }

        public new sysCommonBillConfigViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonBillConfigViewViewModel;
            }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.AccessFocusControl = this.txtName;

            this.indexConfigControl.EntitySetType = EntitySetType.Index;
            this.mainConfigControl.EntitySetType = EntitySetType.Main;
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();

            this.DataBindings.Add("Config", this.bsMain, "Config");
        }

        private CommonBillConfig _CommonBillConfig = new CommonBillConfig();

        public string Config
        {
            get { return XmlSerializerHelper.Serialize<CommonBillConfig>(_CommonBillConfig); }
            set
            {
                var obj = XmlSerializerHelper.Deserialize<CommonBillConfig>(value);
                if (obj == null)
                    _CommonBillConfig = new CommonBillConfig();
                else
                    _CommonBillConfig = obj;

                this.indexConfigControl.EntitySetConfig = _CommonBillConfig.IndexEntitySetConfig;
                this.mainConfigControl.EntitySetConfig = _CommonBillConfig.MainEntitySetConfig;

                this.detailEntitySetConfigControl.DetailEntitySetConfigs = _CommonBillConfig.DetailEntitySetConfigs;

                this.queryConfigControl.QueryConfig = _CommonBillConfig.QueryConfig;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();
            UIController.RefreshControl(this.txtIden, false);

            if (this.IsEdit || this.IsAddNew)
            {
                detailEntitySetConfigControl.RefreshUI();
            }
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();
            this.grvIndex.FocusedRowChanged += grvIndex_FocusedRowChanged;
        }

        void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
    }
}
