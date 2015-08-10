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

namespace SAF.CommonConfig
{
    [BusinessObject("查询平台配置")]
    public partial class sysCommonQueryConfigView : SingleView
    {
        public sysCommonQueryConfigView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonQueryConfigViewViewModel();
        }

        public new sysCommonQueryConfigViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonQueryConfigViewViewModel;
            }
        }

    }
}
