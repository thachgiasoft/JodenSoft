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

            this.gluDep.DataSource = this.ViewModel.sysOrganizationEntity.DefaultView;
            gluDep.DisplayMember = "部门名称";
            gluDep.ValueMember = "部门名称";
            bindTree();



        }
        protected override void OnInitUI()
        {
            // base.OnInitUI();
            //EntitySet<jd_v_inventory> jd_v_inventory = new EntitySet<jd_v_inventory>();
            //jd_v_inventory.Query("select * from jd_v_inventory");
            // bsinventory.DataSource = jd_v_inventory.DefaultView;

            //去除
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            base.OnDetailAddNew();
            //this.ViewModel.DetailEntitySet.AddNew();
            this.ViewModel.DetailEntitySet.CurrentEntity.Iden = IdenGenerator.NewIden(this.ViewModel.DetailEntitySet.CurrentEntity.DbTableName);
            this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();
            this.ViewModel.DetailEntitySet.CurrentEntity.BomChildId = txtbomchildid.Text.Trim();
            this.ViewModel.DetailEntitySet.CurrentEntity.CreatedBy = Session.Current.UserId;
            this.ViewModel.DetailEntitySet.CurrentEntity.CreatedOn = DateTime.Today;
            this.ViewModel.DetailEntitySet.CurrentEntity.EditStatus = "草稿";
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



        #region 索引指向
        private void grvIndex_Click(object sender, EventArgs e)
        {
            this.IndexRowChange();
            bindTree();
        } 
        #endregion

        #region 右键粘帖
        private void tsbtnniantie_Click(object sender, EventArgs e)
        {
            try
            {

                // 获取剪切板的内容，并按行分割
                string pasteText = Clipboard.GetText();
                if (string.IsNullOrEmpty(pasteText))
                    return;
                string[] lines = pasteText.Split(new char[] { '\r', '\n' });

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line.Trim()))
                        continue;
                    // 按 Tab 分割数据
                    string[] vals = line.Split('\t');
                    if (vals.Length > this.grvdetail.Columns.Count)
                        throw new ApplicationException("粘贴的列数不正确。");
                    //ds.Tables["stock"].Rows.Add(vals);

                    packEntity(vals);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 粘帖时候封装成实体类
        private void packEntity(string[] vals)
        {
            base.OnDetailAddNew();
            this.ViewModel.DetailEntitySet.CurrentEntity.Iden = IdenGenerator.NewIden(this.ViewModel.DetailEntitySet.CurrentEntity.DbTableName);
            this.ViewModel.DetailEntitySet.CurrentEntity.BomId = txtbomid.Text.Trim();
            this.ViewModel.DetailEntitySet.CurrentEntity.BomChildId = txtbomchildid.Text.Trim();
            this.ViewModel.DetailEntitySet.CurrentEntity.CreatedBy = Session.Current.UserId;
            this.ViewModel.DetailEntitySet.CurrentEntity.CreatedOn = DateTime.Today;
            this.ViewModel.DetailEntitySet.CurrentEntity.EditStatus = "草稿";
            this.ViewModel.DetailEntitySet.CurrentEntity.NoPicCode = vals[0];
            this.ViewModel.DetailEntitySet.CurrentEntity.NoPicName = vals[1];
            this.ViewModel.DetailEntitySet.CurrentEntity.CInvCode = vals[2];
            this.ViewModel.DetailEntitySet.CurrentEntity.CInvName = vals[3];
            this.ViewModel.DetailEntitySet.CurrentEntity.CComUnitCode = vals[4];
            this.ViewModel.DetailEntitySet.CurrentEntity.SingleQty = Convert.ToDecimal(vals[5]);
            this.ViewModel.DetailEntitySet.CurrentEntity.ProcQty = Convert.ToDecimal(vals[6]);
            this.ViewModel.DetailEntitySet.CurrentEntity.FeedStd = vals[7];
            this.ViewModel.DetailEntitySet.CurrentEntity.OpDep = vals[8];
            this.ViewModel.DetailEntitySet.CurrentEntity.ReMark = vals[9];
            // this.ViewModel.DetailEntitySet.SaveChanges();
        }
        #endregion

        #region ctl+v 粘帖
        private void grvdetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.KeyCode == Keys.V)
            {
                if (sender != null && sender.GetType() == typeof(DataGridView))
                {
                    try
                    {

                        // 获取剪切板的内容，并按行分割
                        string pasteText = Clipboard.GetText();
                        if (string.IsNullOrEmpty(pasteText))
                            return;
                        string[] lines = pasteText.Split(new char[] { '\r' });

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrEmpty(line.Trim()))
                                continue;
                            // 按 Tab 分割数据
                            string[] vals = line.Split('\t');
                            if (vals.Length > this.grvdetail.Columns.Count)
                                throw new ApplicationException("粘贴的列数不正确。");
                            //dgvidmark.Rows.Add(vals);
                            packEntity(vals);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
        #endregion

    }
}
