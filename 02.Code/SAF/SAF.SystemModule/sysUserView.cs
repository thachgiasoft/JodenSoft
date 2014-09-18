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

namespace SAF.SystemModule
{
    [BusinessObject("用户管理")]
    public partial class sysUserView : SingleView
    {
        public sysUserView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysUserViewViewModel();
        }

        public new sysUserViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysUserViewViewModel;
            }
        }

        protected override void OnPostUIData()
        {
        }
    }
}
