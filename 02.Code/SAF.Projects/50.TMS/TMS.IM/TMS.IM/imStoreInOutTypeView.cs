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
            DataTable dt = new DataTable();
            dt.Columns.Add("Value");
            dt.Columns.Add("Caption");
            dt.Rows.Add(new object[] { "+", "正向标识" });
            dt.Rows.Add(new object[] { "-", "反向标识" });
            this.lookUp.Properties.DataSource = dt;
            lookUp.Properties.Columns.Clear();
            lookUp.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption", 100, "方向标号"));
            lookUp.Properties.DisplayMember = "Caption";
            lookUp.Properties.ValueMember = "Value";
            lookUp.Properties.NullText = null;   
          }

        private void lookUp_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grvIndex_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            IndexRowChange();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }


        

    }
}
