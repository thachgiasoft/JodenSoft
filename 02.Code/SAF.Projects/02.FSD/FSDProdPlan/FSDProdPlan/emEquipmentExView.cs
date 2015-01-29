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
using DevExpress.XtraEditors;
using SAF.Framework;

namespace FSDProdPlan
{
    [BusinessObject("emEquipmentExView")]
    public partial class emEquipmentExView : SingleView
    {
        public emEquipmentExView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new emEquipmentExViewViewModel();
        }

        public new emEquipmentExViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as emEquipmentExViewViewModel;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            groupCooperation.Visible = false;
            groupReport.Visible = false;
        }
        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            if (this.ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

                this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
            }
            this.ViewModel.emModelEntity.SetBindingSource(bsjt);
        }
        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
            lusEquipmentModelCaption.EditValueChanged += lusEquipmentNo_EditValueChanged;
        }

        void lusEquipmentNo_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as LookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.GetSelectedDataRow() as DataRowView;

            if (drv == null) return;

            var objinventory = this.ViewModel.emModelEntity.FirstOrDefault(p => p.Iden == Convert.ToInt32(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("机台不存在");
                return;
            }
           // this.ViewModel.MainEntitySet.CurrentEntity.uGuid = objinventory.uGuid;
            //this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentNo = objinventory.sEquipmentModelNo;
            this.ViewModel.MainEntitySet.CurrentEntity.uemEquipmentModelGUID = objinventory.uGuid;
            //this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentName = objinventory.sEquipmentModelName;
            this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentModelName = objinventory.sEquipmentModelName;
            this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentModelCaption = objinventory.sEquipmentModelNo;
            this.ViewModel.MainEntitySet.CurrentEntity.nDailyOuputQty = 0;
            
            

        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
        
    }
}
