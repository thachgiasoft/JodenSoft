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
using SAF.Foundation;
using SAF.EntityFramework;

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
            if (this.ViewModel != null)
            {
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

                this.ViewModel.MainEntitySet.SetBindingSource(bsMain);
            }
            //this.bsProd.DataSource= this.ViewModel.jd_v_parentidEntity.DefaultView;
             this.ViewModel.jd_v_parentidEntity.SetBindingSource(bsProd);
           // this.luparentid.Properties.DataSource = this.ViewModel.jd_v_parentidEntity.DefaultView;
            //this.luparentid.Properties.DisplayMember = "产品代码";
           // this.luparentid.Properties.ValueMember = "Iden";

            
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
            this.luparentid.EditValueChanged += luparentid_EditValueChanged;
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }
        protected override void OnEdit()
        {
            base.OnEdit();
            //this.txtwocode.Enabled = false;
            //this.txtwocode.Enabled = false;
            //this.luparentid.Enabled = false;
            //this.spdqty.Enabled = false;
            //this.txtwoversion.Enabled = false;
            //this.txtparentname.Enabled = false;
        }

        protected override void OnAddNew()
        {
            base.OnAddNew();
            

        }

        protected override void OnSave()
        {
            base.OnSave();
            InsertWodetail(this.ViewModel.MainEntitySet.CurrentEntity);
            this.ViewModel.woDetailEntity.SaveChanges();
        }

        private void InsertWodetail(woOrder woOrder)
        {
            //this.ViewModel.bomParentEntity.Query("select * from bomParent wit(nolock) where bomparentid=bomchildid and bomid='{0}'".FormatEx(woOrder.BomId));
            this.ViewModel.bomChildEntity.Query("select * from bomChild with(nolock) where Editstatus='通过' and  bomid='{0}'".FormatEx(woOrder.BomId));

            foreach (var item in this.ViewModel.bomChildEntity)
            {
                this.ViewModel.woDetailEntity.AddNew();
              //  this.ViewModel.woDetailEntity.CurrentEntity.Iden = IdenGenerator.NewIden(this.ViewModel.woDetailEntity.CurrentEntity.DbTableName);
                this.ViewModel.woDetailEntity.CurrentEntity.WoIden = woOrder.Iden;
                this.ViewModel.woDetailEntity.CurrentEntity.WoCode = woOrder.WoCode;
                this.ViewModel.woDetailEntity.CurrentEntity.WoVersion = woOrder.WoVersion;
                this.ViewModel.woDetailEntity.CurrentEntity.BomId = woOrder.BomId;
                this.ViewModel.woDetailEntity.CurrentEntity.BomChildId = item.BomChildId;
                this.ViewModel.woDetailEntity.CurrentEntity.BomChildName =item.BomChildName;
                this.ViewModel.woDetailEntity.CurrentEntity.NoPicCode = item.NoPicCode;
                this.ViewModel.woDetailEntity.CurrentEntity.NoPicName = item.NoPicName;
                this.ViewModel.woDetailEntity.CurrentEntity.CInvCode = item.CInvCode;
                this.ViewModel.woDetailEntity.CurrentEntity.CInvName = item.CInvName;
                this.ViewModel.woDetailEntity.CurrentEntity.SingleQty = item.SingleQty;
                this.ViewModel.woDetailEntity.CurrentEntity.CComUnitCode = item.CComUnitCode;
                this.ViewModel.woDetailEntity.CurrentEntity.ProcQty = item.ProcQty;
                this.ViewModel.woDetailEntity.CurrentEntity.ProdQty = item.ProcQty*woOrder.Qty;
                this.ViewModel.woDetailEntity.CurrentEntity.FeedStd = item.FeedStd;
                this.ViewModel.woDetailEntity.CurrentEntity.ReMark = null;
                this.ViewModel.woDetailEntity.CurrentEntity.Dept = item.OpDep;
                this.ViewModel.woDetailEntity.CurrentEntity.CState =0;
                this.ViewModel.woDetailEntity.CurrentEntity.Addbatch =0;
                this.ViewModel.woDetailEntity.CurrentEntity.Cdefine1 = null;
                this.ViewModel.woDetailEntity.CurrentEntity.Cdefine2 = null;
                this.ViewModel.woDetailEntity.CurrentEntity.Cdefine3 = null;
                this.ViewModel.woDetailEntity.CurrentEntity.Cdefine4 = 0;
                this.ViewModel.woDetailEntity.CurrentEntity.Cdefine5 = 0;
                this.ViewModel.woDetailEntity.CurrentEntity.BomChildIden = item.Iden;
                this.ViewModel.woDetailEntity.CurrentEntity.RelsUser = null;
                this.ViewModel.woDetailEntity.CurrentEntity.RelsDate = null;
                this.ViewModel.woDetailEntity.CurrentEntity.TotalQty = item.SingleQty*woOrder.Qty;
                this.ViewModel.woDetailEntity.CurrentEntity.PlanDate = null;
                this.ViewModel.woDetailEntity.CurrentEntity.PuState = 0;
                

            }

            


        }
        private void luparentid_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as LookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.GetSelectedDataRow() as DataRowView;

            if (drv == null) return;

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
            this.ViewModel.MainEntitySet.CurrentEntity.CParentId = objinventory.产品代号;
            this.ViewModel.MainEntitySet.CurrentEntity.BomId = objinventory.产品区分号;
            this.ViewModel.MainEntitySet.CurrentEntity.CParentName = objinventory.产品名称;
            
        }

       
    }
}
