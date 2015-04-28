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

namespace JDM.SystemModule
{
    [BusinessObject("ServerRegsterView")]
    public partial class ServerRegsterView : SingleView
    {
        public ServerRegsterView()
        {
            InitializeComponent();
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new ServerRegsterViewViewModel();
        }

        public new ServerRegsterViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as ServerRegsterViewViewModel;
            }
        }

    }
}
