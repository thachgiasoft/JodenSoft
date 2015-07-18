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

namespace SAF.CommonConfig
{
    [BusinessObject("报表中心配置")]
    public partial class sysCommonReportView : MasterDetailView
    {
        public sysCommonReportView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonReportConfigViewViewModel();
        }

        public new sysCommonReportConfigViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonReportConfigViewViewModel;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(txtIden, false);
            UIController.RefreshControl(txtParamList, false);
        }

    }
}
