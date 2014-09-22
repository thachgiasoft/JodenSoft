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
            this.ViewModel.jd_v_inventory.SetBindingSource(bsinventory);
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
                //bsDetail.DataSource = this.ViewModel.DetailEntitySet.DefaultView;
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

            base.OnAddNew();
           // grvdetail.OptionsBehavior.ReadOnly = false;
           
        }

        protected override void OnDetailAddNew()
        {
            base.OnDetailAddNew();
            this.ViewModel.DetailEntitySet.AddNew();
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
            base.OnSave();
            this.ViewModel.DetailEntitySet.SaveChanges();
        }

        private void repositoryItemGridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
           var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            //(this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CInvCode = objinventory.CInvCode;            
            //(this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CInvName = objinventory.存货名称;
           // (this.ViewModel.DetailEntitySet.CurrentEntity as bomChild).CComUnitCode = objinventory.单位;

        }

        private void repositoryItemGridLookUpEdit1_Click(object sender, EventArgs e)
        {
            //if (gridView1.ActiveEditor.EditValue.ToString() == "System.Object")
            //{
            //    var objinventory = this.ViewModel.jd_v_inventory.CurrentEntity;
            //    if (objinventory == null)
            //    {
            //        MessageBox.Show("存货不存在");
            //        return;
            //    }
            //    gridView1.ActiveEditor.EditValue = objinventory.存货编码;
            //}
        }

    }
}
