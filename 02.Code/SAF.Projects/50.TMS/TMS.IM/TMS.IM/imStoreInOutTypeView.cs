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

namespace TMS.IM
{
    [BusinessObject("imStoreInOutTypeView")]
    public partial class imStoreInOutTypeView : SingleView
    {
        public imStoreInOutTypeView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new imStoreInOutTypeViewViewModel();
        }

        public new imStoreInOutTypeViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as imStoreInOutTypeViewViewModel;
            }
        }

  
        protected override void OnInitUI()
        {
            base.OnInitUI();
            BoundData();
        }

        /// <summary>
        /// 绑定Lookup
        /// </summary>
        private void BoundData()
          {
             
              DataSet ds = new DataSet();
              DataTable dt = new DataTable();
              ds.Tables.Add(dt);
              dt.Columns.Add("Caption");
              dt.Columns.Add("Value");
              DataRow row1 = dt.NewRow();
              row1["Caption"] = "正向";
              row1["Value"] = "+";
              DataRow row2 = dt.NewRow();
              row2["Caption"] = "反向";
              row2["Value"] = "-";
              if (ds != null)
              {
                  int rows = ds.Tables[0].Rows.Count;

                  lookUp.EditValue = "Value";
                  lookUp.Properties.ValueMember = "Value";
                  lookUp.Properties.DisplayMember = "Caption";
                  lookUp.Properties.DataSource = ds.Tables[0];
  
                 //填充列
                  lookUp.Properties.PopulateColumns();
   
                 //设置列属性
                  //lookUpEdit1.Properties.Columns[0].Visible = false;
                  lookUp.Properties.Columns[1].Caption = "出入库方向";
                  lookUp.Properties.Columns[2].Caption = "方向标号";
                  lookUp.Properties.Columns[1].Width = 60;
                  lookUp.Properties.Columns[2].Width = 30;
   
                 //控制选择项的总宽度
                  lookUp.Properties.PopupWidth = 100;
   
                 //选择第一项
                  lookUp.ItemIndex = 0; 
              }
          }


        

    }
}
