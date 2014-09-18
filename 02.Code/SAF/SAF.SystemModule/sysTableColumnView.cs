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

namespace SAF.SystemModule
{
    public partial class sysTableColumnView : SingleView
    {
        public sysTableColumnView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysTableColumnViewViewModel();
        }

        public new sysTableColumnViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysTableColumnViewViewModel;
            }
        }

    }
}
