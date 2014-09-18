using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using SAF.Framework.ViewModel;
using SAF.Foundation;

namespace SAF.Framework.View
{
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public partial class BusinessView : BaseView, IBusinessView
    {
        public BusinessView()
        {
            InitializeComponent();
        }

        protected new IBusinessViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as IBusinessViewViewModel;
            }
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new BusinessViewViewModel();
        }

       

        

    }
}
