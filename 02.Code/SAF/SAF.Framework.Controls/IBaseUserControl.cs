using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls
{
    public interface IBaseUserControl
    {
        Image Icon { get; }
        void Init();

        void RefreshUI();
    }
}
