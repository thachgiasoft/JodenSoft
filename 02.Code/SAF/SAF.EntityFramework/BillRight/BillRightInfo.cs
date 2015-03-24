using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SAF.EntityFramework
{
    public class BillRightInfo
    {
        public int BillTypeId { get; set; }
        public DataTable DataRights { get; set; }
        public BillOperateRight OperateRight { get; set; }

        public static readonly string CreatedByField = "CreatedBy";
        public static readonly string OrganizationCodeField = "OrganizationCode";
        public static readonly string OrganizationIdField = "OrganizationId";

        public bool UseDataRight { get; set; }
        public bool UseOperateRight { get; set; }

        public BillRightInfo()
        {
            OperateRight = BillOperateRight.All;
        }
    }
}
