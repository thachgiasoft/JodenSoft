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

namespace JNHT_ProdSys
{
    [BusinessObject("bomParentView")]
    public partial class bomParentView : SingleView
    {
        bomParentViewViewModel bomparentvvm = new bomParentViewViewModel();
        public bomParentView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new bomParentViewViewModel();
        }

        public new bomParentViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as bomParentViewViewModel;
            }
        }

        private void bbiPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands();
            var MyExport = new DefaultRibbonMenuCommand("导入", MyExportExcute) { LargeGlyph = Properties.Resources.Action_ImportData_32x32 };
            this.AddRibbonMenuCommand(MyExport);
        }

        private void MyExportExcute(object obj)
        {
            

            if (string.IsNullOrEmpty(txtBomId.Text.Trim()))
            {
                MessageService.ShowMessage("请选择导入文件的根节点,产品区分号不能为空!");
                return;
            }
            if (txtBomId.Text != txtBomParentId.Text || txtBomParentId.Text != txtBomChildId.Text)
            {
                MessageService.ShowMessage("选择的根节点不是总的区分号");
                return;
            }
            DataTable dt = ExcelUtil.ExcelToDataTable();
            string bomid = txtBomId.Text.Trim();
            ProgressService.Show("正在上传文件...");
            try
            {

                dt = ReMoveRow(dt); //删除空行;
                SaveBom(dt, bomid);
                ProgressService.Close();
            }
            catch (Exception ex)
            {

                ProgressService.Abort();
                MessageService.ShowMessage("导入失败!" + ex.Message);
                return;
            }


        }
        #region 保存导入到datatable数据到数据库bomParent表

        private void SaveBom(DataTable dt, string bomid)
        {

            // bomparentvvm.OnImportBomParent(dt,bomid);
            if (bomparentvvm.OnImportBomParent(dt, bomid))
             
                   MessageService.ShowMessage("导入成功!");
            this.IndexRowChange();

        }
        #endregion

        #region 删除DataTable里的空行
        private DataTable ReMoveRow(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool rowdataisnull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    if (dt.Rows[i][j].ToString().Trim() != "")
                    {

                        rowdataisnull = false;
                    }

                }
                if (rowdataisnull)
                {
                    removelist.Add(dt.Rows[i]);
                }

            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            return dt;
        }
        #endregion


        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            UIController.SetupGridControl(this.grdIndex);
        }

        protected override void OnSave()
        {
            base.OnSave();
        }

        protected override void OnInitBinding()
        {
            base.OnInitBinding();
            this.ViewModel.bomEntity.SetBindingSource(bsMainIndex);
            

        }

        private void grvMainIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        private void tsdeleteprod_Click(object sender, EventArgs e)
        {
            string bomid = this.grvIndex.GetFocusedDataRow()[0].ToString();
            if (grvIndex.SelectedRowsCount > 0)
            {
                ProgressService.Show("正在删除总装产品...");
                if (bomparentvvm.deleteprod(bomid))
                {
                    ProgressService.Close();
                    MessageService.ShowMessage("删除成功!");
                    
                }
                    
            }
            else
            {
                MessageService.ShowMessage("请选择要删除的产品区分号");
                return;
            }
        }

        private void grvMainIndex_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            this.IndexRowChange();
        }

        //private void grvIndex_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        //{
        //    //if (sender != null)
        //    //{
        //    //    DataRow dr = sender as DataRow;
        //    //}
        //    //// string bomid = dr["BomParentId"].ToString();
        //    //string bomid = this.grvMainIndex.GetRowCellValue(e.RowHandle, this.colBomId).ToString();
        //    //bomParentViewViewModel.Bomid = bomid;
        //    //Query(string.Empty);
        //    ////var bomEntity = new EntitySet<bomParent>();
        //    ////bomEntity.Query("select Iden,BomParentId,BomChildId,BomChildDesc  from bomparent where BomId=@bomid", bomid);
        //    ////grdIndex.DataSource = bomEntity.DefaultView;
        //    ////BomTreeList.bomEntity = bomEntity;
        //    ////this.bomTreeList1.Init();

        //    this.IndexRowChange();
        //}



    }
}
