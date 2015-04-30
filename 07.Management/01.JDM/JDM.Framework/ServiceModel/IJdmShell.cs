using DevExpress.XtraBars.Ribbon;
using SAF.Foundation;
using SAF.Framework.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JDM.Framework.ServiceModel
{
    public interface IJdmShell
    {
        /// <summary>
        /// 视图
        /// </summary>
        Form View { get; }
        /// <summary>
        /// 主菜单
        /// </summary>
        RibbonControl RibbonControl { get; }

        void ShowForm<T>(string menuId, string menuHeader) where T : BaseView;
    }
}
