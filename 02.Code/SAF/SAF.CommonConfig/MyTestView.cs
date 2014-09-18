using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;

namespace SAF.CommonConfig
{
    public partial class MyTestView : MasterDetailView
    {
        public MyTestView()
        {
            InitializeComponent();
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new MyTestViewViewModel();
        }

        public new MyTestViewViewModel ViewModel
        {
            get { return base.ViewModel as MyTestViewViewModel; }
        }
    }
}
