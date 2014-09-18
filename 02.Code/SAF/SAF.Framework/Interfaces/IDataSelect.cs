using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    public interface IDataSelect
    {
        /// <summary>
        /// 选中所有
        /// </summary>
        void SelectAll();
        /// <summary>
        /// 取消选中
        /// </summary>
        void CancelSelect();
        /// <summary>
        /// 反向选择
        /// </summary>
        void ReverseSelect();
    }
}
