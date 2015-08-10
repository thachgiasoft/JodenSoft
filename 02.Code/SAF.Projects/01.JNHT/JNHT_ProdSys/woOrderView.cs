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
using SAF.SystemEntities;
using SAF.Framework;
using System.Data.SqlClient;

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
               // this.ViewModel.jd_v_parentidEntity.SetBindingSource(bsProd);
            }
            //this.bsProd.DataSource= this.ViewModel.jd_v_parentidEntity.DefaultView;
            
            this.luparentid.Properties.DataSource = this.ViewModel.jd_v_parentidEntity.DefaultView;
            this.luparentid.Properties.DisplayMember = "产品代号";
            this.luparentid.Properties.ValueMember = "产品代号";


        }
        protected override void OnInitUI()
        {
            base.OnInitUI();
             InitOrgGridSearch();

            this.AccessFocusControl = this.txtwocode;
        }

        private void InitOrgGridSearch()
        {
            this.gseOrg.Properties.CommandText = @"
SELECT Iden,Name 
FROM dbo.sysOrganization a WITH(NOLOCK)
where {0}
ORDER BY [Iden]";
            this.gseOrg.Properties.DisplayMember = "Name";
            this.gseOrg.Properties.AutoFillEntitySet = this.ViewModel.MainEntitySet;
            this.gseOrg.Properties.AutoFillFieldNames = "OrganizationId=Iden,OrganizationName=Name";
            this.gseOrg.Properties.ColumnHeaders = "组织序号,组织名称";
            this.gseOrg.Properties.Query();
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
            this.txtwocode.Enabled = false;
            this.txtwocode.Enabled = false;
            this.luparentid.Enabled = false;
            this.spdqty.Enabled = false;
            this.txtwoversion.Enabled = false;
            this.txtparentname.Enabled = false;
            this.gseOrg.Enabled = false;
        }

        protected override void OnAddNew()
        {
            base.OnAddNew();
            this.txtwocode.Enabled = true;
            this.txtwocode.Enabled = true;
            this.luparentid.Enabled = true;
            this.spdqty.Enabled = true;
            this.txtwoversion.Enabled = true;
            this.txtparentname.Enabled = true;

        }

        protected override bool OnSave()
        {
            base.OnSave();
            try
            {
                //InsertWodetail(this.ViewModel.MainEntitySet.CurrentEntity);
               woOrder entity=this.ViewModel.MainEntitySet.CurrentEntity;
                DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, "exec JD_P_GetRotingMaterial @woid=:woid,@userid=:userid,@organizationid=:organizationid,@qty=:qty", entity.Iden, Session.Current.UserId, entity.OrganizationId, entity.Qty);
                return true;
            }
            catch (Exception )
            {
                return false;
                
            }
        }

        //todo:新增有问题
        //private void InsertWodetail(woOrder woOrder)
        //{
        //    //this.ViewModel.bomParentEntity.Query("select * from bomParent wit(nolock) where bomparentid=bomchildid and bomid='{0}'".FormatEx(woOrder.BomId));
        //    this.ViewModel.bomChildEntity.Query("select * from bomChild with(nolock) where Editstatus='通过' and  bomid='{0}'".FormatEx(woOrder.BomId));

        //    foreach (var item in this.ViewModel.bomChildEntity)
        //    {
        //        //base.OnAddNew
        //        woDetail wodetail= this.ViewModel.woDetailEntity.AddNew();
        //        wodetail.Iden = IdenGenerator.NewIden(wodetail.DbTableName);
        //        wodetail.WoIden = woOrder.Iden;
        //        wodetail.WoCode = woOrder.WoCode;
        //        wodetail.WoVersion = woOrder.WoVersion;
        //        wodetail.BomId = woOrder.BomId;
        //        wodetail.BomChildId = item.BomChildId;
        //        wodetail.BomChildName = item.BomChildName;
        //        wodetail.NoPicCode = item.NoPicCode;
        //        wodetail.NoPicName = item.NoPicName;
        //        wodetail.CInvCode = item.CInvCode;
        //        wodetail.CInvName = item.CInvName;
        //        wodetail.SingleQty = item.SingleQty;
        //        wodetail.CComUnitCode = item.CComUnitCode;
        //        wodetail.ProcQty = item.ProcQty;
        //        wodetail.ProdQty = item.ProcQty * woOrder.Qty;
        //        wodetail.FeedStd = item.FeedStd;
        //        wodetail.ReMark = null;
        //        wodetail.Dept = item.OpDep;
        //        wodetail.CState = 0;
        //        wodetail.Addbatch = 0;
        //        wodetail.Cdefine1 = null;
        //        wodetail.Cdefine2 = null;
        //        wodetail.Cdefine3 = null;
        //        wodetail.Cdefine4 = 0;
        //        wodetail.Cdefine5 = 0;
        //        wodetail.BomChildIden = item.Iden;
        //        wodetail.RelsUser = null;
        //        wodetail.RelsDate = null;
        //        wodetail.TotalQty = item.SingleQty * woOrder.Qty;
        //        wodetail.PlanDate = null;
        //        wodetail.PuState = 0;


        //    }
        //}
        private void luparentid_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as SearchLookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.Properties.View.GetFocusedDataRow() as DataRow;

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
