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
using SAF.Foundation.ServiceModel;
using SAF.EntityFramework;
using SAF.Framework.Controls;


namespace FSDProdPlan
{
    [BusinessObject("jdMoorderView")]
    public partial class jdMoorderView : SingleView
    {
        public jdMoorderView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new jdMoorderViewViewModel();
        }

        public new jdMoorderViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as jdMoorderViewViewModel;
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
            
            this.ViewModel.emEquipmentCapacityProduceEntity.SetBindingSource(bsch);
           // this.sluchbm.Properties.DataSource = this.ViewModel.emEquipmentCapacityProduceEntity.DefaultView;
            this.sluchbm.Properties.DisplayMember = "sMaterialNo";
            this.sluchbm.Properties.ValueMember = "sMaterialNo";
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
           // lusMaterialNo.EditValueChanged += lusMaterialNo_EditValueChanged;

            sluchbm.EditValueChanged += sluchbm_EditValueChanged;
        }

        void sluchbm_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as SearchLookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.Properties.View.GetFocusedDataRow() as DataRow;

            if (drv == null) return;

            var objinventory = this.ViewModel.emEquipmentCapacityProduceEntity.FirstOrDefault(p => p.Iden == Convert.ToInt32(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            this.ViewModel.MainEntitySet.CurrentEntity.sMaterialNo = objinventory.sMaterialNo;
            this.ViewModel.MainEntitySet.CurrentEntity.sMaterialName = objinventory.sMaterialName;
            this.ViewModel.MainEntitySet.CurrentEntity.sEquipmentModelName = objinventory.sEquipmentNo;
            this.ViewModel.MainEntitySet.CurrentEntity.uemEquipmentModelGUID = objinventory.uemEquipmentModelGUID;
            this.ViewModel.MainEntitySet.CurrentEntity.nCapacity = objinventory.nCapacity;
        }

      


        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

       
        protected override void OnAddNew()
        {
            base.OnAddNew();
            this.sluchbm.Text = string.Empty;
            this.txtsMaterialName.Text = string.Empty;
            this.txtsEquipmentModelName.Text = string.Empty;
        }

        protected override void OnEdit()
        {
            if ("开工".Equals(this.ViewModel.MainEntitySet.CurrentEntity.state))
            {
                MessageService.ShowMessage("已经开工,无法修改!");
                return;
            }
            if ("完工".Equals(this.ViewModel.MainEntitySet.CurrentEntity.state))
            {
                MessageService.ShowMessage("已经完工,无法修改!");
                return;
            }
            base.OnEdit();
        }
        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();
            var MyExport = new DefaultRibbonMenuCommand("自动排机", MyExportExcute) { LargeGlyph = Properties.Resources.Action_PublishEntity_32x32 };
            this.AddRibbonMenuCommand(MyExport);
            var MyExport1 = new DefaultRibbonMenuCommand("工单完工", MyExportExcute1) { LargeGlyph = Properties.Resources.Action_Mark_32x32 };
            this.AddRibbonMenuCommand(MyExport1);
        }

        private void MyExportExcute1(object obj)
        {
            if (this.ViewModel.MainEntitySet.CurrentEntity == null)
            {
                MessageService.ShowMessage("请选择需要完工的工单");
                return;
            }
            if ("完工".Equals(this.ViewModel.MainEntitySet.CurrentEntity.state))
            {
                MessageService.ShowMessage("该工单已经完工");
                return;
            }
            try
            { 
                    string sbillno = this.ViewModel.MainEntitySet.CurrentEntity.sBillNO;
                    if(MessageService.AskQuestion("确定要完工工单  " + sbillno + "  吗?"))
                    { 
                     string sql1 = "update jdmoorder set state='完工' where sbillno=:sbillno";
                     DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, sql1, sbillno);
                     string sql = "UPDATE dbo.psWpp SET bFinish=1 WHERE sBillNo=:sbillno ";
                     DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection, sql, sbillno);
                     MessageService.ShowMessage("工单完工操作完成");
                     
                    }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void MyExportExcute(object obj)
        {
            ProgressService.Show("正在自动排机....");
           // PreProcessMessage    MessageService.ShowMessage("正在自动排机...");
            DataPortal.ExecuteNonQuery(ConfigContext.DefaultConnection,"jd_zdpj");
            ProgressService.Close();
            MessageService.ShowMessage("排机完成");

        }

        private void sluchbm_EditValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
 