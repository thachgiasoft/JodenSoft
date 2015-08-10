using DevExpress.XtraBars.Ribbon;
using SAF.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework
{
    /// <summary>
    /// Shell接口
    /// </summary>
    public interface IShell : IShellBase
    {
        /// <summary>
        /// 视图
        /// </summary>
        Form View { get; }
        /// <summary>
        /// 主菜单
        /// </summary>
        RibbonControl RibbonControl { get; }
        /// <summary>
        /// 初始化一些特殊的组件,此方法需由接口主动调用
        /// </summary>
        void InitComponent();
        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="iMenuId"></param>
        void ShowBusinessView(int iMenuId);
        /// <summary>
        /// 刷新收藏夹
        /// </summary>
        void RefreshFavorite();
        /// <summary>
        /// 重新登录
        /// </summary>
        void Relogin();
    }
}
