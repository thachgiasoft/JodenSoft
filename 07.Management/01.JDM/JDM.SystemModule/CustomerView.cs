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

namespace JDM.SystemModule
{
    [BusinessObject("CustomerView")]
    public partial class CustomerView : SingleView
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new CustomerViewViewModel();
        }

        public new CustomerViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as CustomerViewViewModel;
            }
        }

        protected override void OnInitViewParam()
        {
            //base.OnInitViewParam();
        }

        protected override void OnAddMenuToFavorite()
        {
            //base.OnAddMenuToFavorite();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.AccessFocusControl = this.txtName;
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(this.txtIden, false);
        }

    }
}
