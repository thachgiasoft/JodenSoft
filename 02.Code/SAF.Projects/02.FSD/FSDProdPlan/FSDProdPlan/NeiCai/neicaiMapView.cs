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

namespace FSDProdPlan.NeiCai
{
    [BusinessObject("neicaiMapView")]
    public partial class neicaiMapView :SingleView
    {
        public neicaiMapView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new neicaiMapViewViewModel();
        }

        public new neicaiMapViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as neicaiMapViewViewModel;
            }
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

            this.listBoxControl1.DataSource = bsIndex;
            this.listBoxControl1.DisplayMember = "机台编号";
            this.listBoxControl1.ValueMember = "机台编号";
        }

    }
}
