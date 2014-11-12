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

namespace SAF.Test
{
    [BusinessObject("sdOrderView")]
    public partial class sdOrderView : MasterDetailView
    {
        public sdOrderView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sdOrderViewViewModel();
        }

        public new sdOrderViewViewModel ViewModel
        {
            get { return this.ViewModel as sdOrderViewViewModel; }
        }

    }
}
