using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Model
{
    public class QueryOrgParams : QueryParams
    {
        public int iOrgType { get; set; }
        public string sOrgName { get; set; }

        public int? iParentId { get; set; }

        public int? iCompanyId { get; set; }
    }
}
