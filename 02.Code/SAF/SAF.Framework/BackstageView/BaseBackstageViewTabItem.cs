using DevExpress.XtraEditors;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public class BaseBackstageViewTabItem : BaseUserControl, IBackstageViewTabItem
    {
        public virtual int Index
        {
            get
            {
                return 10;
            }
        }

        public virtual string Caption
        {
            get { return string.Empty; }
        }

        public virtual bool IsSelected
        {
            get { return false; }
        }

        public virtual UserControl View
        {
            get { return this; }
        }

        public virtual bool BeginGroup
        {
            get { return false; }
        }

        public virtual DisplayMode DisplayMode
        {
            get { return DisplayMode.All; }
        }
    }
}
