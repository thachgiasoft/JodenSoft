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
using DevExpress.XtraGrid.Views.Grid;

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
            get { return base.ViewModel as woDetaildealView1ViewModel; }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            //if (this.ViewModel != null)
            //{
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

             //   this.ViewModel.MainEntitySet.SetBindingSource(bsMain);

           // }
            this.ViewModel.DetailEntitySet.SetBindingSource(bsDetail);
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // var grid = sender as GridRow;
            var grid = grvIndex.GetDataRow(grvIndex.FocusedRowHandle);
            //方法一:适用于不同实体集
            //var drv = grid.GetFocusedRow();
            var objinventory = this.ViewModel.IndexEntitySet.FirstOrDefault(p => p.Iden == Convert.ToInt32(grid["Iden"]));
            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            this.txtbomid.Text = objinventory.BomId;
            this.txtisclose.Text = objinventory.IsClose;
            this.txtparentid.Text = objinventory.CParentId;
            this.txtparentname.Text = objinventory.CParentName;
            this.txtwocode.Text = objinventory.WoCode;
            this.txtwoversion.Text = objinventory.WoVersion.ToString();
            this.txtqty.Text = objinventory.Qty.ToString();
        }

       
    }
}
