#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：IChartPad
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/24 9:54:02
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
    public interface IChartPad
    {
        Guid Id { get; }
        string Caption { get; }
        UserControl View { get; }
    }
}
