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

namespace FSDProdPlan
{
    [BusinessObject("zhusuTotalView")]
    public partial class zhusuTotalView : SingleView
    {
        public zhusuTotalView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new zhusuTotalViewViewModel();
        }

        public new zhusuTotalViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as zhusuTotalViewViewModel;
            }
        }

    }
}
