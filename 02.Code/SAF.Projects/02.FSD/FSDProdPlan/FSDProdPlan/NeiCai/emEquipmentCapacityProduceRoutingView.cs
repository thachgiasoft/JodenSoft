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

namespace FSDProdPlan.NeiCai
{
    [BusinessObject("emEquipmentCapacityProduceRoutingView")]
    public partial class emEquipmentCapacityProduceRoutingView : SingleView
    {
        public emEquipmentCapacityProduceRoutingView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new emEquipmentCapacityProduceRoutingViewViewModel();
        }

        public new emEquipmentCapacityProduceRoutingViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as emEquipmentCapacityProduceRoutingViewViewModel;
            }
        }

    }
}
