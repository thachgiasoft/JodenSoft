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

namespace SAF.CommonBill
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
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();
            UIController.RefreshControl(this.txtIden, false);
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

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();

            var config = new CommonBillConfig();
            if (this.ViewModel.MainEntitySet.CurrentEntity != null)
            {
                config = XmlSerializerHelper.Deserialize<CommonBillConfig>(this.ViewModel.MainEntitySet.CurrentEntity.Config);
                if (config == null)
                    config = new CommonBillConfig();
            }


        }

    }
}
