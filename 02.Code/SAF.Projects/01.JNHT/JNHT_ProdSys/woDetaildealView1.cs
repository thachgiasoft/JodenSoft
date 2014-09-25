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

namespace JNHT_ProdSys
{
      [BusinessObject("woDetaildealView1")]
    public partial class woDetaildealView1 : MasterDetailView
    {
        public woDetaildealView1()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woDetaildealView1ViewModel();
        }

        public new woDetaildealView1ViewModel ViewModel
        {
            get { return this.ViewModel as woDetaildealView1ViewModel; }
        }

    }
}
