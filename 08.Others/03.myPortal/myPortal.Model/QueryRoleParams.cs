using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryRoleParams : QueryParams
    {
        public int? iCompanyId { get; set; }
        public string sRoleName { get; set; }
    }
}
