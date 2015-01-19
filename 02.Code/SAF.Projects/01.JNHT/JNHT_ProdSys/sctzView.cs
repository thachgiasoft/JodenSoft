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
using SAF.Foundation;

namespace JNHT_ProdSys
{
    [BusinessObject("sctzView")]
    public partial class sctzView : SingleView
    {
        public sctzView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sctzViewViewModel();
        }

        public new sctzViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sctzViewViewModel;
            }
        }

        protected override void OnInitUI()
        {
            //base.OnInitUI();
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiAddNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            pnlPageControl.Visible = false;
            pnlQueryControl.Visible = false;
            //qcMain.Visible = false;
            //pcMain.Visible = false;
        }
        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);
            this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
           // this.grvMain.OptionsView.ColumnAutoWidth = true;
            
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            int selectHandle;
            selectHandle = this.gridView2.FocusedRowHandle;
            string bomid = this.gridView2.GetDataRow(selectHandle)[1].ToString();
            this.ViewModel.MainEntitySet.Query("exec jd_p_sctz @bomid=:bomid",bomid);
            this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
        }
    }
}
