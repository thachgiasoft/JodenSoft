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

namespace JNHT_ProdSys
{
    [BusinessObject("woDealView")]
    public partial class woDealView : SingleView
    {
        public woDealView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new woDealViewViewModel();
        }

        public new woDealViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as woDealViewViewModel;
            }
        }


    }
}
