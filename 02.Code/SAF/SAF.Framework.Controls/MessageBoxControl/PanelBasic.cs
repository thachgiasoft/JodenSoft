using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 基础面板
    /// </summary>
    internal class PanelBasic : Control
    {
        public PanelBasic()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, false);//关键，不要设置双缓冲，不然其上的ToolBar不正常
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//重要。不设置的话控件绘制不正常
            SetStyle(ControlStyles.ContainerControl, true);
            SetStyle(ControlStyles.Selectable, false);
        }

        protected override void WndProc(ref Message m)
        {
            //屏蔽WM_ERASEBKGND。防止显示时在原位置快闪
            //不能通过ControlStyles.AllPaintingInWmPaint=true屏蔽
            //会影响其上的ToolBar
            if (m.Msg == 0x14) { return; }

            base.WndProc(ref m);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            //防Dock时面板短暂滞留在原位置
            base.SetBoundsCore(x, y, width, height, specified | BoundsSpecified.Y | BoundsSpecified.Width);
        }
    }
}
