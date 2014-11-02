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
using SAF.EntityFramework;

namespace SAF.SystemModule
{
    [BusinessObject("单据类型")]
    public partial class sysBillTypeView : MasterDetailView
    {
        public sysBillTypeView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysBillTypeViewViewModel();
        }

        public new sysBillTypeViewViewModel ViewModel
        {
            get { return this.ViewModel as sysBillTypeViewViewModel; }
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.AccessFocusControl = this.txtName;
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();
            this.cbxAllowRightType.Properties.SetFlags(typeof(BillRightType));
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
            UIController.RefreshControl(this.chkIsSystem, false);
        }
    }
}
