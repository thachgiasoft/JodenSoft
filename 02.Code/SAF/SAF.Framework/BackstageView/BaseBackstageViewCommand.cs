using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public abstract class BaseBackstageViewCommand : IBackstageViewCommand
    {
        public virtual int Index
        {
            get { return 10; }
        }

        public abstract string Caption { get; }

        public abstract Image m_Glyph { get; }

        public virtual bool BeginGroup
        {
            get { return false; }
        }

        public virtual DisplayMode DisplayMode
        {
            get { return DisplayMode.All; }
        }

        public abstract void ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e);
    }
}
