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
using JNHT_ProdSys.Method;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;

namespace JNHT_ProdSys
{
    [BusinessObject("bomMeterialView")]
    public partial class bomMeterialView : SingleView
    {
        bomMeterialViewViewModel bomMeterialvvm = new bomMeterialViewViewModel();
        public bomMeterialView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new bomMeterialViewViewModel();
        }

        public new bomMeterialViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as bomMeterialViewViewModel;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.pcMain.Visible = false;
            this.groupCooperation.Visible = false;
            this.groupReport.Visible = false;
        
        }
        protected override void OnInitCustomRibbonMenuCommands()
        {
            base.OnInitCustomRibbonMenuCommands(); 
            var MyExport = new DefaultRibbonMenuCommand("导入", MyExportExcute) { LargeGlyph = Properties.Resources.Action_ImportData_32x32 };
            this.AddRibbonMenuCommand(MyExport);
        }

        private void MyExportExcute(object obj)
        {
            DataTable dt = ExcelUtil.ExcelToDataTable();
            string bomid = this.ViewModel.IndexEntitySet.CurrentEntity.BomId;// txtBomId.Text.Trim();
            ProgressService.Show("正在上传文件...");
            try
            {

                dt = ReMoveRow(dt); //删除空行;
                SaveMeterial(dt, bomid);
                ProgressService.Close();
            }
            catch (Exception ex)
            {

                ProgressService.Abort();
                MessageService.ShowMessage("导入失败!" + ex.Message);
                return;
            }
        }

        private void SaveMeterial(DataTable dt, string bomid)
        {
            if (bomMeterialvvm.OnImportBomMeterial(dt, bomid))

                MessageService.ShowMessage("导入成功!");
            this.IndexRowChange();
        }

       
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
        
    }
}
