
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace SAF.Framework.Component
{
    [Export(typeof(IBackstageViewCommand))]
    public class ExitApplicationCommand : BaseBackstageViewCommand
    {
        public override string Caption
        {
            get { return "退出"; }
        }

        public override System.Drawing.Image m_Glyph
        {
            get { return Properties.Resources.Action_Close_16x16; }
        }

        public override void ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ApplicationService.Current.MainForm.Close();
        }

        public override bool BeginGroup
        {
            get
            {
                return true;
            }
        }
    }
}
