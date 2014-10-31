using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SAF.EntityFramework
{
    public class BillRightInfo
    {
        public BillRightType AllowRightType;
        public int BillTypeId;
        public DataTable DataRights;
        public BillOperateRight OperateRight;
        public string CreateByField;
        public string OrganizationCodeField;
        public string OrganizationIdField;
        public bool UseDataRight;
        public bool UseOperateRight;

        public BillRightInfo()
        {
            AllowRightType = BillRightType.All;
            OperateRight = BillOperateRight.All;

            CreateByField = "CreateBy";
            OrganizationCodeField = "OrganizationCode";
            OrganizationIdField = "OrganizationId";
        }
    }
}
