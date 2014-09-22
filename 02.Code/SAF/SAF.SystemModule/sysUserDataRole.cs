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
    [BusinessObject("用户数据权限")]
    public partial class sysUserDataRole : SingleView
    {
        public sysUserDataRole()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysUserDataRoleViewModel();
        }

        public new sysUserDataRoleViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysUserDataRoleViewModel;
            }
        }

    }
}
