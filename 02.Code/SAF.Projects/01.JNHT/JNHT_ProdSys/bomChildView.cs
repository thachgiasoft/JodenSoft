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
using SAF.Framework;
using SAF.Framework.Controls;
using SAF.Foundation.MetaAttributes;
using JNHT_ProdSys.Method;
using SAF.EntityFramework;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using SAF.Foundation;
using DevExpress.XtraEditors;

namespace JNHT_ProdSys
{
    [BusinessObject("bomChildView")]
    public partial class bomChildView : MasterDetailView
    {
        
        public bomChildView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new bomChildViewViewModel();
        }

        public new bomChildViewViewModel ViewModel
        {
            get { return base.ViewModel as bomChildViewViewModel; }//this.ViewModel as bomChildViewViewModel
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

            //this.ViewModel.jd_v_inventory.SetBindingSource(bsinventory);
            if (this.ViewModel != null)
            {
                this.ViewModel.DetailEntitySet.SetBindingSource(this.bsDetail);
            }

            this.gluCinvcode.DataSource = this.ViewModel.jd_v_inventoryEntity.DefaultView;
            gluCinvcode.DisplayMember = "存货编码";
            gluCinvcode.ValueMember = "存货编码";

            this.gluCinvName.DataSource = this.ViewModel.jd_v_inventoryEntity.DefaultView;
            gluCinvName.DisplayMember = "存货名称";
            gluCinvName.ValueMember = "存货名称";
            bindTree();

            
            
        }
        protected override void OnInitUI()
        {
           // base.OnInitUI();
            //EntitySet<jd_v_inventory> jd_v_inventory = new EntitySet<jd_v_inventory>();
            //jd_v_inventory.Query("select * from jd_v_inventory");
           // bsinventory.DataSource = jd_v_inventory.DefaultView;
           // bbiAddNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        private void bindTree()
        {
            bstree.DataSource = this.ViewModel.MainEntitySet.DefaultView;
            tlbom.ParentFieldName = "BomParentId";
            tlbom.KeyFieldName = "BomChildId";
           // tlbom.Columns[0].Tag = "BomId";
        }
        
      

        private void tlbom_MouseDown(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hi = tlbom.CalcHitInfo(e.Location);
            TreeListNode CurrentNode = hi.Node;
            if (CurrentNode != null)
            {
                // Treebomid = CurrentNode.Tag.ToString();//.GetValue("CategoryID").ToString();
                this.txtbomchildid.Text = CurrentNode.GetValue("BomChildId").ToString();
                this.txtbomid.Text = CurrentNode.GetValue("BomId").ToString();
                this.txtbomchilddesc.Text = CurrentNode.GetValue("BomChildDesc").ToString();
                this.txtbomchildstyle.Text = CurrentNode.GetValue("BomChildStyle").ToString();

               // EntitySet<bomChild> bomchildEntity = new EntitySet<bomChild>();
                this.ViewModel.DetailEntitySet.Query("select * from bomChild where BomId='{0}' and BomChildId='{1}'".FormatEx(this.txtbomid.Text, this.txtbomchildid.Text));
                bsDetail.DataSource = this.ViewModel.DetailEntitySet.DefaultView;
                this.ViewModel.DetailEntitySet.SetBindingSource(bsDetail);
            }
        }

        protected override void OnAddNew()
        {
            if (string.IsNullOrEmpty(txtbomchildid.Text.Trim()))
            {
                MessageService.ShowMessage("请选择零部件!");
                return;
            }

           // base.OnAddNew();
            //pnlDtlToolbar. = true;
           // this.ViewModel.DetailEntitySet.IsBusy = true;
            this.ViewModel.EditStatus = EditStatus.AddNew;
            grvdetail.OptionsBehavior.ReadOnly = false;
           
        }

        protected override void OnDetailAddNew()
        {
            //base.OnDetailAddNew();
            ////this.ViewModel.DetailEntitySet.AddNew();
            
            //this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();
            //this.ViewModel.DetailEntitySet.CurrentEntity.BomChildId = txtbomchildid.Text.Trim();
           
        }
      
        
            
            //bomChild bc = new bomChild();
            //bc.BomChildId = txtbomchildid.Text.Trim();
            //bc.BomId = txtbomid.Text.Trim();
            //this.ViewModel.DetailEntitySet.CurrentEntity.Iden = IdenGenerator.NewIden(this.ViewModel.DetailEntitySet.CurrentEntity.DbTableName);
            //this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();
            //this.ViewModel.DetailEntitySet.CurrentEntity.BomChildId = txtbomchildid.Text.Trim();
            //this.ViewModel.DetailEntitySet.CurrentEntity.CInvCode = "zk";
            //this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();

           // this.ViewModel.DetailEntitySet.SaveChanges();
           

        protected override void OnSave()
        {
           // entityPack();
            
            base.OnSave();
            this.ViewModel.DetailEntitySet.SaveChanges();
        }


        #region 参照存货编码后带出存货名称
        private void gluCinvcode_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as GridLookUpEdit;

           //方法一:适用于不同实体集
            var drv = grid.GetSelectedDataRow() as DataRowView;
            var objinventory = this.ViewModel.jd_v_inventoryEntity.FirstOrDefault(p => p.Iden == Convert.ToInt64(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }          
            (this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CInvName = objinventory.存货名称;
            (this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CComUnitCode = objinventory.单位;
        } 
        #endregion

        #region 参照存货名称后带出存货编码
        private void gluCinvName_EditValueChanged(object sender, EventArgs e)
        {
            var grid = sender as GridLookUpEdit;

            //方法一:适用于不同实体集
            var drv = grid.GetSelectedDataRow() as DataRowView;
            var objinventory = this.ViewModel.jd_v_inventoryEntity.FirstOrDefault(p => p.Iden == Convert.ToInt64(drv["Iden"]));

            //方法二:适合与同一实体集
            //var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //var drv = grid.GetSelectedDataRow() as DataRowView;
            //var objinventory = this.ViewModel.jd_v_inventoryEntity.CreateEntity(drv);

            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            (this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CInvCode = objinventory.存货编码;
            (this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CComUnitCode = objinventory.单位;
        }
        #endregion

        private void grvdetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            base.OnDetailAddNew();
            //this.ViewModel.DetailEntitySet.AddNew();

            this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();
            this.ViewModel.DetailEntitySet.CurrentEntity.BomChildId = txtbomchildid.Text.Trim();
        }
    }
}
