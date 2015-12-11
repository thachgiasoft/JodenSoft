using System;
using System.Collections.Generic;
using System.Text;

namespace myPortal.Model
{
    public class PageControlParams
    {
        private int m_PageSize = 10;
        /// <summary>
        /// ÿҳ��¼��
        /// </summary>
        public int PageSize
        {
            get { return m_PageSize; }
            set { m_PageSize = value; }
        }
        private int m_PageIndex = 0;
        /// <summary>
        /// ҳ��
        /// </summary>
        public int PageIndex
        {
            get { return m_PageIndex; }
            set { m_PageIndex = value; }
        }
        private int m_TotalPageCount = 0;
        /// <summary>
        /// ��ҳ��
        /// </summary>
        public int TotalPageCount
        {
            get { return m_TotalPageCount; }
            set { m_TotalPageCount = value; }
        }
        private int m_TotalRecordCount = 0;
        /// <summary>
        /// ������
        /// </summary>
        public int TotalRecordCount
        {
            get { return m_TotalRecordCount; }
            set { m_TotalRecordCount = value; }
        }
    }
}
