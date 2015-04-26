using DevExpress.XtraBars.Ribbon;
using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public interface IJDMShell
    {
        /// <summary>
        /// 视图
        /// </summary>
        Form View { get; }
        /// <summary>
        /// 主菜单
        /// </summary>
        RibbonControl RibbonControl { get; }
    }
}
