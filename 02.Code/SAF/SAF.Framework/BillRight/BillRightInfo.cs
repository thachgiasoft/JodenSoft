using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SAF.Framework
{
    public class BillRightInfo
    {
        public BillRightType AllowRightType;
        public int BillType;
        public DataTable dataRights;
        public BillOperateRight operateRight;
        public string sCreatorField;
        public string sDepartmentCodeField;
        public string sDepartmentIdField;
        public bool UseDataRight;
        public bool UseOperateRight;

        public BillRightInfo()
        {
            AllowRightType = BillRightType.All;
            operateRight = BillOperateRight.All;

            sCreatorField = "CreateBy";
            sDepartmentCodeField = "sDepartmentCode";
            sDepartmentIdField = "iDepartmentId";
        }
    }
}
