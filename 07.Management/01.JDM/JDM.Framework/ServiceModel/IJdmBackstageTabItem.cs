using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public interface IJdmBackstageTabItem
    {
        int Index { get; }

        string Caption { get; }

        bool IsSelected { get; }

        UserControl View { get; }

        bool BeginGroup { get; }

        void Init();

        void RefreshUI();
    }

   
}
