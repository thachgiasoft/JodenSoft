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
using SAF.EntityFramework;
using SAF.Framework.Controls;
using SAF.Framework.ComponentModel;

namespace GTMS.IM
{
    [BusinessObject("imStoreManageView[仓库管理]")]
    public partial class imStoreManageView : SingleView
    {
        public imStoreManageView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new imStoreManageViewViewModel();
        }

        public new imStoreManageViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as imStoreManageViewViewModel;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

    }
}
