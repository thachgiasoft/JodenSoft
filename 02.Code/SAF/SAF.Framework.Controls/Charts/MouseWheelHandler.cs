#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：MouseWheelHandler
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/20 18:06:40
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    class MouseWheelHandler
    {
        const int WHEEL_DELTA = 120;

        int mouseWheelDelta;

        public int GetScrollAmount(MouseEventArgs e)
        {
            mouseWheelDelta += e.Delta;

            int linesPerClick = Math.Max(SystemInformation.MouseWheelScrollLines, 1);

            int scrollDistance = mouseWheelDelta * linesPerClick / WHEEL_DELTA;
            mouseWheelDelta %= Math.Max(1, WHEEL_DELTA / linesPerClick);
            return scrollDistance;
        }
    }
}
