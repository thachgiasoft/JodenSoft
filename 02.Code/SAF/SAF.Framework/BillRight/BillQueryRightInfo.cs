using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework
{
    /// <summary>
    /// 查询权限
    /// </summary>
    public class BillQueryRightInfo
    {
        public int iBillType = 0;
        public string sPrefix = string.Empty;
        public int iStart = 0;
        public int iLength = 0;
        public string sCondition = string.Empty;

        public string sCreatorField = string.Empty;
        public string sDepartmentIdField = string.Empty;
        public string sDepartmentCodeField = string.Empty;

        private string _sCode = string.Empty;
        public string sCode
        {
            get { return _sCode; }
            set
            {
                _sCode = value;
                if (value.Contains(","))
                {
                    string[] lst = value.Split(',').ToArray();
                    sPrefix = lst[0];
                    iBillType = Convert.ToInt32(lst[1]);
                    if (lst.Length > 2)
                        sCreatorField = lst[2];
                    if (lst.Length > 3)
                        sDepartmentIdField = lst[3];
                    if (lst.Length > 4)
                        sDepartmentCodeField = lst[4];
                }
                else
                {
                    sPrefix = value;
                }
            }
        }
    }
}
