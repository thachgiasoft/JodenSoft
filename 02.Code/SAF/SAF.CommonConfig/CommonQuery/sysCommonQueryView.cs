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
    [BusinessObject("查询平台")]
    public partial class sysCommonQueryView : SingleView
    {
        public sysCommonQueryView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonQueryViewViewModel();
        }

        public new sysCommonQueryViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonQueryViewViewModel;
            }
        }

    }
}
