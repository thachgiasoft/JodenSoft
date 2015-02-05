﻿using System;
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



        protected override void OnInitUI()
        {
            base.OnInitUI();

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

        private CommonBillConfig _CommonBillConfig = new CommonBillConfig();
        public CommonBillConfig CommonBillConfig
        {
            get { return _CommonBillConfig; }
            set
            {
                if (value == null)
                    _CommonBillConfig = new CommonBill.CommonBillConfig();
                else
                    _CommonBillConfig = value;

                BindingCommonBillConfig();
            }
        }

        private void BindingCommonBillConfig()
        {
            this.indexConfig.EntitySetConfig = CommonBillConfig.IndexEntitySetConfig;
            this.mainConfig.EntitySetConfig = CommonBillConfig.MainEntitySetConfig;

            this.queryConfig.QueryConfig = CommonBillConfig.QueryConfig;

            this.bsDetailEntitySetConfig.DataSource = CommonBillConfig.DetailEntitySetConfigs;
            this.listDetailEntitySet.DataSource = bsDetailEntitySetConfig;
            this.listDetailEntitySet.DisplayMember = "Caption";
            this.listDetailEntitySet.ValueMember = "Caption";
        }

        protected override void OnIndexRowChange()
        {
            base.OnIndexRowChange();

            if (this.ViewModel.MainEntitySet.CurrentEntity != null)
            {
                CommonBillConfig = XmlSerializerHelper.Deserialize<CommonBillConfig>(this.ViewModel.MainEntitySet.CurrentEntity.Config);
                if (CommonBillConfig == null)
                    CommonBillConfig = new CommonBillConfig();
            }
        }

        protected override void OnAddNew()
        {
            CommonBillConfig = new CommonBillConfig();
            base.OnAddNew();
        }

        protected override bool OnSave()
        {
            var config = XmlSerializerHelper.Serialize(this.CommonBillConfig);
            this.ViewModel.MainEntitySet.CurrentEntity.Config = config;
            return base.OnSave();
        }

        private void listDetailEntitySet_SelectedValueChanged(object sender, EventArgs e)
        {
            this.detailConfig.EntitySetConfig = listDetailEntitySet.SelectedItem as EntitySetConfig;
        }

        private void btnDetailEntitySetConfigAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsDetailEntitySetConfig.AddNew();
        }

        private void btnDetailEntitySetConfigDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsDetailEntitySetConfig.RemoveCurrent();
        }

    }
}
