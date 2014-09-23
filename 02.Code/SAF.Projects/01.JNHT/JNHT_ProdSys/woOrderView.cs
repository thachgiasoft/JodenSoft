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
using SAF.Framework.Controls;

namespace JNHT_ProdSys
{
    [BusinessObject("woOrderView")]
    public partial class woOrderView : SingleView
    {
        public woOrderView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woOrderViewViewModel();
        }

        public new woOrderViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as woOrderViewViewModel;
            }
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);
            this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
            //this.bsProd.DataSource= this.ViewModel.jd_v_parentidEntity.DefaultView;
            this.ViewModel.jd_v_parentidEntity.SetBindingSource(bsProd);
            
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
    }
}
