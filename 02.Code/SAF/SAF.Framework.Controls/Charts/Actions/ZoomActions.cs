#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：ZoomActions
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/20 14:29:49
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

namespace SAF.Framework.Controls.Charts.Actions
{
    public class ZoomRestoreAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            drawArea.Zoom = 1f;
        }
    }

    public class ZoomInAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            drawArea.ZoomIn();
        }
    }

    public class ZoomOutAction : AbstractEditAction
    {
        public override void m_Execute(DrawArea drawArea)
        {
            drawArea.ZoomOut();
        }
    }

}
