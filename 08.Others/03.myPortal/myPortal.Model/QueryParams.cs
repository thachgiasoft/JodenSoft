using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Model
{
    /// <summary>
    /// 查询参数的抽象类
    /// </summary>
    public abstract class QueryParams
    {
        private PageControlParams m_PageControl = new PageControlParams();
        /// <summary>
        /// 分页控件的相关参数
        /// </summary>
        public PageControlParams PageControl
        {
            get { return m_PageControl; }
        }
    }
}
