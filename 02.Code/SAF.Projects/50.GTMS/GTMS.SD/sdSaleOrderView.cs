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

namespace GTMS.SD
{
    [BusinessObject("sdSaleOrderView[销售订单]")]
    public partial class sdSaleOrderView : MasterDetailView
    {
        public sdSaleOrderView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sdSaleOrderViewViewModel();
        }

        public new sdSaleOrderViewViewModel ViewModel
        {
            get { return base.ViewModel as sdSaleOrderViewViewModel; }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

    }
}
