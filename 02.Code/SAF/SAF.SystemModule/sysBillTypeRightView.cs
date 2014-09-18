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
    public partial class sysBillTypeRightView : MasterDetailView
    {
        public sysBillTypeRightView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysBillTypeRightViewViewModel();
        }

        public new sysBillTypeRightViewViewModel ViewModel
        {
            get { return this.ViewModel as sysBillTypeRightViewViewModel; }
        }

    }
}
