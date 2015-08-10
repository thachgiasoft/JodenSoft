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
using SAF.EntityFramework;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;

namespace FSDProdPlan.NeiCai
{
    [BusinessObject("jdMoorderNeiCaiView")]
    public partial class jdMoorderNeiCaiView : MasterDetailView
    {
        public jdMoorderNeiCaiView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new jdMoorderNeiCaiViewViewModel();
        }

        public new jdMoorderNeiCaiViewViewModel ViewModel
        {
            get { return base.ViewModel as jdMoorderNeiCaiViewViewModel; }
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
                this.ViewModel.sMaterialEntity.SetBindingSource(bsch);
            }
            this.slusMaterialNo.Properties.DataSource = this.ViewModel.sMaterialEntity.DefaultView;
            this.slusMaterialNo.Properties.DisplayMember = "sMaterialNo";
            this.slusMaterialNo.Properties.ValueMember = "sMaterialNo";

            this.riGluEdit1.DataSource = this.ViewModel.emModelEntity.DefaultView;
            riGluEdit1.DisplayMember = "sEquipmentModelNo";
            riGluEdit1.ValueMember = "sEquipmentModelNo";

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

        private void slusMaterialNo_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as SearchLookUpEdit;
                        
            var drv = grid.Properties.View.GetFocusedDataRow() as DataRow;
            if (drv == null) return;

            var objinventory = this.ViewModel.sMaterialEntity.FirstOrDefault(p => p.Iden == Convert.ToInt32(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("产品不存在");
                return;
            }
           
            this.ViewModel.MainEntitySet.CurrentEntity.sMaterialIden = objinventory.Iden;
            this.ViewModel.MainEntitySet.CurrentEntity.sMaterialName = objinventory.sMaterialName;
            this.ViewModel.MainEntitySet.CurrentEntity.sMaterialNo = objinventory.sMaterialNo;

           // this.ViewModel.MainEntitySet.CurrentEntity.uemEquipmentModelNo = objinventory.sEquipmentModelNo;
            // this.ViewModel.MainEntitySet.CurrentEntity.nDailyOuputQty = 0;
        }

        private void ricmb1_SelectedValueChanged(object sender, EventArgs e)
        {
            var combox=sender as ComboBoxEdit;
            this.ViewModel.DetailEntitySet.CurrentEntity.banzhi =Convert.ToInt32(combox.Text);
        }

       

        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();
            var MyExport = new DefaultRibbonMenuCommand("加载工序", MyExportExcute) { LargeGlyph = Properties.Resources.Action_Refresh_32x32 };
            this.AddRibbonMenuCommand(MyExport);
            var MyExport1 = new DefaultRibbonMenuCommand("自动排机", MyExportExcute1) { LargeGlyph = Properties.Resources.Action_PublishEntity_32x32 };
            this.AddRibbonMenuCommand(MyExport1);
        }

        //加载工序
        private void MyExportExcute(object obj)
        {
            try
            {
                ProgressService.Show("正在加载工序....");
                jdMoorderNeiCai entity = this.ViewModel.MainEntitySet.CurrentEntity;
                DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, "exec JD_P_GeneratWoRouting @woiden=:woiden,@createdby=:createdby", entity.Iden, Session.Current.UserId);
                ProgressService.Close();
                MessageService.ShowMessage("加载完成");
            }
            catch (Exception ex)
            {
                MessageService.ShowMessage("错误:  "+ex.Message);
                ProgressService.Close();
            }
        }

        //自动排机
        private void MyExportExcute1(object obj)
        {
            ProgressService.Show("正在自动排机....");
            // PreProcessMessage    MessageService.ShowMessage("正在自动排机...");
            DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, "jd_zdpjnc");
            ProgressService.Close();
            MessageService.ShowMessage("排机完成");

        }

        private void barcancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string routingname = this.ViewModel.DetailEntitySet.CurrentEntity.routingName;
            string sbillno = this.ViewModel.DetailEntitySet.CurrentEntity.sBillNO;
            int iden = this.ViewModel.DetailEntitySet.CurrentEntity.Iden;
            string sOrderNo = this.ViewModel.DetailEntitySet.CurrentEntity.sOrderNo;
            if (MessageService.AskQuestion("确定要取消工序[  " + routingname + "  ]的派工吗?"))
            { 
                try
                {
                    DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, "exec jd_CancelPaigong :sbillno", sbillno);

                    //string sql1 = "DELETE psWppex WHERE sbillno like ':sOrderNo%'";
                    //DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, sql1, sbillno);
                    //string sql2 = "update worouting set routingstate='' WHERE iden in (:iden)";
                    //DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, sql2, iden);
                    //string sql3 = "delete dbo.psWppSplit WHERE sbillno like ':sbillno%'";
                    //DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, sql3, sbillno);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
