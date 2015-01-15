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

namespace FSDProdPlan
{
    [BusinessObject("sysBillNoFormulaView")]
    public partial class sysBillNoFormulaView : SingleView
    {
        public sysBillNoFormulaView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysBillNoFormulaViewViewModel();
        }

        public new sysBillNoFormulaViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysBillNoFormulaViewViewModel;
            }
        }

    }
}
