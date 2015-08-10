using JDM.Framework.ServiceModel;
using SAF.Foundation.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace JDM.SystemModule.ComponentModel
{
    [Export(typeof(IJdmBackstageCommand))]
    public class JdmExitApplicationCommand : JdmBaseBackstageCommand
    {
        public override string Caption
        {
            get
            {
                return "退出";
            }
        }

        public override System.Drawing.Image m_Glyph
        {
            get
            {
                return Properties.Resources.Action_Close_16x16;
            }
        }

        public override bool BeginGroup
        {
            get
            {
                return true;
            }
        }

        public override void ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            ApplicationService.Current.MainForm.Close();
        }
    }
}
