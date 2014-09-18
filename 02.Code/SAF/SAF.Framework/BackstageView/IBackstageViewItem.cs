using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    public interface IBackstageViewTabItem
    {
        int Index { get;  }

        string Caption { get;  }

        bool IsSelected { get; }

        UserControl View { get; }

        bool BeginGroup { get; }

        DisplayMode DisplayMode { get; }

        void Init();

        void RefreshUI();
    }

    public interface IBackstageViewCommand
    {
        int Index { get; }
        string Caption { get; }
        Image m_Glyph { get; }
        bool BeginGroup { get; }
        DisplayMode DisplayMode { get; }
        void ItemClick(object sender, BackstageViewItemEventArgs e);
    }


    public enum DisplayMode
    {
        All = 0,
        BeforeLogin = 1,
        AfterLogin = 2
    }
}
