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
using SAF.Framework;
using DevExpress.XtraEditors;

namespace FSDProdPlan.NeiCai
{
    [BusinessObject("sMaterialRoutingView")]
    public partial class sMaterialRoutingView : MasterDetailView
    {
        public sMaterialRoutingView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sMaterialRoutingViewViewModel();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            groupCooperation.Visible = false;
            groupReport.Visible = false;
            
            
        }
        public new sMaterialRoutingViewViewModel ViewModel
        {
            get { return base.ViewModel as sMaterialRoutingViewViewModel; }
        }
        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            if (this.ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);
                this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
                this.ViewModel.DetailEntitySet.SetBindingSource(bsDetail);
                this.ViewModel.emModelEntity.SetBindingSource(bsEmodel);
                this.ViewModel.routingBaseEntity.SetBindingSource(bsrouting);
            }
            this.riGluEdit1.DataSource = this.ViewModel.emModelEntity.DefaultView;
            riGluEdit1.DisplayMember = "sEquipmentModelNo";
            riGluEdit1.ValueMember = "sEquipmentModelNo";

            this.riglerouting.DataSource = this.ViewModel.routingBaseEntity.DefaultView;
            riglerouting.DisplayMember = "Routingname";
            riglerouting.ValueMember = "Routingname";
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

        private void riGluEdit1_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as GridLookUpEdit;

            var drv = grid.GetSelectedDataRow() as DataRowView;

            if (drv == null) return;

            var objinventory = this.ViewModel.emModelEntity.FirstOrDefault(p => p.Iden == Convert.ToInt32(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("机型不存在");
                return;
            }
            this.ViewModel.DetailEntitySet.CurrentEntity.uemEquipmentModelGUID = objinventory.uGuid;
            //this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentName = objinventory.sEquipmentModelName;
            this.ViewModel.DetailEntitySet.CurrentEntity.uemEquipmentModelName = objinventory.sEquipmentModelName;
           // this.ViewModel.DetailEntitySet.CurrentEntity.uemEquipmentModelNo = objinventory.sEquipmentModelNo;
           // this.ViewModel.MainEntitySet.CurrentEntity.nDailyOuputQty = 0;
        }

        private void riglerouting_EditValueChanged(object sender, EventArgs e)
        {

        }



    }
}
