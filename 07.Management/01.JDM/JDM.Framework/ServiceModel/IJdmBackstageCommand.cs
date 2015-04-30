using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public interface IJdmBackstageCommand
    {
        int Index { get; }
        string Caption { get; }
        Image m_Glyph { get; }
        bool BeginGroup { get; }
        void ItemClick(object sender, BackstageViewItemEventArgs e);
    }
}
