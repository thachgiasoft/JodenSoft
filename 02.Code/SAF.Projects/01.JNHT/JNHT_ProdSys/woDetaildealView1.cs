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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using SAF.Foundation;
using SAF.Framework;


namespace JNHT_ProdSys
{
      [BusinessObject("woDetaildealView1")]
    public partial class woDetaildealView1 : MasterDetailView
    {
        public woDetaildealView1()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woDetaildealView1ViewModel();
        }

        public new woDetaildealView1ViewModel ViewModel
        {
            get { return base.ViewModel as woDetaildealView1ViewModel; }
        }

        protected override void OnInitConfig()
        {
           // base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        protected override void OnInitUI()
        {
            //base.OnInitUI();
            //去除
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
           // this.bbiAddNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
        }
        protected override void OnInitBinding()
        {
            //base.OnInitBinding();
           
            //if (this.ViewModel != null)
            //{
                this.ViewModel.IndexEntitySet.SetBindingSource(bsIndex);

             //   this.ViewModel.MainEntitySet.SetBindingSource(bsMain);

           // }
            this.ViewModel.DetailEntitySet.SetBindingSource(bsDetail);
            AddUnboundColumn();
        }

        protected override void OnAddNew()
        {
            //base.OnAddNew();
            this.ViewModel.EditStatus = EditStatus.AddNew;
            grvdetail.OptionsBehavior.ReadOnly = false;
            
        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // var grid = sender as GridRow;
            var grid = grvIndex.GetDataRow(grvIndex.FocusedRowHandle);
            //方法一:适用于不同实体集
            //var drv = grid.GetFocusedRow();
            var objinventory = this.ViewModel.IndexEntitySet.FirstOrDefault(p => p.Iden == Convert.ToInt32(grid["Iden"]));
            if (objinventory == null)
            {
                MessageBox.Show("存货不存在");
                return;
            }
            this.txtbomid.Text = objinventory.BomId;
            this.txtisclose.Text = objinventory.IsClose;
            this.txtparentid.Text = objinventory.CParentId;
            this.txtparentname.Text = objinventory.CParentName;
            this.txtwocode.Text = objinventory.WoCode;
            this.txtwoversion.Text = objinventory.WoVersion.ToString();
            this.txtqty.Text = objinventory.Qty.ToString();

            this.IndexRowChange();
            //this.ViewModel.DetailEntitySet.Query("select * from bomChild where BomId='{0}' and BomChildId='{1}'".FormatEx(this.txtbomid.Text, this.txtbomchildid.Text));
            //bsDetail.DataSource = this.ViewModel.DetailEntitySet.DefaultView;
            //this.ViewModel.DetailEntitySet.SetBindingSource(bsDetail);
        }

        Dictionary<int, bool> data = new Dictionary<int, bool>();
        /// <summary>
        /// 绑定第一列为选择列
        /// </summary>
        private void AddUnboundColumn()
        {
            GridColumn col = this.grvdetail.Columns.AddField("选择");
            col.VisibleIndex = 0;
            col.Visible = true;

            col.UnboundType = UnboundColumnType.Boolean;
            this.grvdetail.Columns["选择"].OptionsColumn.ReadOnly = false;
            this.grvdetail.Columns["选择"].OptionsColumn.AllowEdit = true;
        }

        private void grvdetail_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "选择")
            {
                if (e.IsGetData)
                {
                    if (data.ContainsKey(e.ListSourceRowIndex))
                    {
                        e.Value = data[e.ListSourceRowIndex];
                    }
                    else
                    {
                        e.Value = false;
                    }
                }
                if (e.IsSetData)
                {
                    if (data.ContainsKey(e.ListSourceRowIndex))
                    {
                        data[e.ListSourceRowIndex] = Convert.ToBoolean(e.Value);
                    }
                    else
                    {
                        data.Add(e.ListSourceRowIndex, Convert.ToBoolean(e.Value));
                    }

                }
            }
        }

    }
}
