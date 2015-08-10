using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 查询权限
    /// </summary>
    public class BillQueryRightInfo
    {
        public int BillTypeId = 0;
        public string sPrefix = string.Empty;
        public int Start = 0;
        public int Length = 0;
        public string Condition = string.Empty;

        public string CreateByField = string.Empty;
        public string OrganizationIdField = string.Empty;
        public string OrganizationCodeField = string.Empty;

        private string _Code = string.Empty;
        public string Code
        {
            get { return _Code; }
            set
            {
                _Code = value;
                if (value.Contains(","))
                {
                    string[] lst = value.Split(',').ToArray();
                    sPrefix = lst[0];
                    BillTypeId = Convert.ToInt32(lst[1]);
                    if (lst.Length > 2)
                        CreateByField = lst[2];
                    if (lst.Length > 3)
                        OrganizationIdField = lst[3];
                    if (lst.Length > 4)
                        OrganizationCodeField = lst[4];
                }
                else
                {
                    sPrefix = value;
                }
            }
        }
    }
}
