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
using DevExpress.XtraEditors;

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
        protected override void OnEdit()
        {
            base.OnEdit();
            this.txtwocode.Enabled = false;
            this.txtwocode.Enabled = false;
            this.luparentid.Enabled = false;
            this.spdqty.Enabled = false;
            this.txtwoversion.Enabled = false;
            this.txtparentname.Enabled = false;
        }

        protected override void OnAddNew()
        {
            base.OnAddNew();
            this.luparentid.EditValueChanged+=luparentid_EditValueChanged;
          
        }
        private void luparentid_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as LookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.GetSelectedDataRow() as DataRowView;
            var objinventory = this.ViewModel.jd_v_parentidEntity.FirstOrDefault(p => p.Iden == Convert.ToInt64(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            this.ViewModel.MainEntitySet.CurrentEntity.CParentName = objinventory.产品名称;
        }
    }
}
