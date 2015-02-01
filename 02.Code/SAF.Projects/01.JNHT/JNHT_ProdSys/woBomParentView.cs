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
    [BusinessObject("生产令单管理")]
    public partial class woBomParentView : SingleView
    {
        public woBomParentView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woBomParentViewViewModel();
        }

        public new woBomParentViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as woBomParentViewViewModel;
            }
        }
        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.woOrderEntity.SetBindingSource(bswo);
        }

        private void grvwo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             var woid = this.ViewModel.woOrderEntity.CurrentEntity.Iden;
             this.ViewModel.MainEntitySet.Query("select *  from woBomParent with(nolock) where woid=:woid ",woid);

        }

    }
}
