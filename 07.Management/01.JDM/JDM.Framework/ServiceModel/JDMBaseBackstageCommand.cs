using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public abstract class JdmBaseBackstageCommand : IJdmBackstageCommand
    {
        public virtual int Index
        {
            get { return 100; }
        }

        public abstract string Caption { get; }

        public abstract Image m_Glyph { get; }

        public virtual bool BeginGroup
        {
            get { return false; }
        }

        public abstract void ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e);

    }
}
