using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SAF.Foundation;
using SAF.Foundation.ComponentModel;

namespace SAF.EntityFramework
{
    public static class BillRight
    {
        private static class RES
        {
            public const string QueryRightString = @"/*QueryRight(";
            public const string UseBillDataRight = @"UseBillDataRight";
            public const string BillTypeId = @"BillTypeId";
            public const string QueryRight = @"QueryRight";
            public const string CreatedBy = @"CreatedBy";
            public const string OrganizationId = @"OrganizationId";
            public const string OrganizationCode = @"OrganizationCode";
        }

        #region 数据权限实现

        public static BillRightInfo QueryBillRight(int billTypeId, int userId, int organizationId = 0)
        {
            const string sql = @"
--查询单据配置
SELECT UseBillDataRight,UseBillOperateRight 
FROM dbo.sysBillType WITH(NOLOCK) 
WHERE Iden=:BillTypeId AND IsActive=1

--查询操作权限
DECLARE @BillRight INT
IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.sysBillType WITH(NOLOCK) WHERE Iden=:BillTypeId AND UseBillOperateRight=1 AND IsActive=1)
    SELECT BillRight=65536
ELSE
BEGIN
    SET @BillRight=0
    SELECT @BillRight=@BillRight | (
          CASE AddNew WHEN 1 THEN 1 ELSE 0 END
        | CASE ExtendRight1 WHEN 1 THEN 2 ELSE 0 END
        | CASE ExtendRight2 WHEN 1 THEN 4 ELSE 0 END
        | CASE ExtendRight3 WHEN 1 THEN 8 ELSE 0 END
        | CASE ExtendRight4 WHEN 1 THEN 16 ELSE 0 END
        | CASE ExtendRight5 WHEN 1 THEN 32 ELSE 0 END
        | CASE ExtendRight6 WHEN 1 THEN 64 ELSE 0 END
        | CASE ExtendRight7 WHEN 1 THEN 128 ELSE 0 END
        | CASE ExtendRight8 WHEN 1 THEN 256 ELSE 0 END
        | CASE ExtendRight9 WHEN 1 THEN 512 ELSE 0 END
        | CASE ExtendRight10 WHEN 1 THEN 1024 ELSE 0 END
    )
    FROM dbo.sysUserDataRole A WITH(NOLOCK)
    JOIN dbo.sysBillOperateRight B WITH(NOLOCK) ON B.DataRoleId=A.DataRoleId
    JOIN dbo.sysOrganization C WITH(NOLOCK) ON C.Iden=A.OrganizationId
    WHERE A.UserId=:UserId AND C.IsActive=1 AND B.BillTypeId=:BillTypeId AND B.IsActive=1
    AND (
            A.OrganizationId=:OrganizationId 
            OR :OrganizationId=0 
            OR EXISTS(
                    SELECT TOP 1 1
		            FROM dbo.sysOrganization A1 WITH(NOLOCK)
		            WHERE Iden=:OrganizationId AND A1.Code LIKE C.Code+'%'
                )
        )
    SELECT BillRight=ISNULL(@BillRight,0)
END

--查询数据权限
SELECT CreatedBy=:UserId,OrganizationId=D.Iden,OrganizationCode=D.Code
    ,UpdateRight=MAX(B.UpdateRight)
    ,DeleteRight=MAX(B.DeleteRight)
    ,AuditRight=MAX(B.AuditRight)
    ,PrintRight=MAX(B.PrintRight)
    ,ExtendRight1=MAX(B.ExtendRight1)
    ,ExtendRight2=MAX(B.ExtendRight2)
    ,ExtendRight3=MAX(B.ExtendRight3)
    ,ExtendRight4=MAX(B.ExtendRight4)
    ,ExtendRight5=MAX(B.ExtendRight5)
    ,ExtendRight6=MAX(B.ExtendRight6)
    ,ExtendRight7=MAX(B.ExtendRight7)
    ,ExtendRight8=MAX(B.ExtendRight8)
    ,ExtendRight9=MAX(B.ExtendRight9)
    ,ExtendRight10=MAX(B.ExtendRight10)
FROM dbo.sysUserDataRole A WITH(NOLOCK)
JOIN dbo.sysBillDataRight B WITH(NOLOCK) ON B.DataRoleId=A.DataRoleId AND B.IsActive=1 
JOIN dbo.sysBillType C WITH(NOLOCK) ON B.BillTypeId=C.Iden AND C.UseBillDataRight=1 AND C.IsActive=1
LEFT JOIN dbo.sysOrganization D WITH(NOLOCK) ON D.Iden=A.OrganizationId AND D.IsActive=1
WHERE C.Iden=:BillTypeId  AND A.UserId=:UserId
GROUP BY D.Iden,D.Code
";
            var ds = DataPortal.ExecuteDataset(ConfigContext.DefaultConnection, sql, billTypeId, userId, organizationId);

            var billCount = ds.Tables[0].Rows.Count;
            return new BillRightInfo()
            {
                BillTypeId = billCount == 0 ? 0 : billTypeId,
                UseDataRight = billCount == 0 ? false : Convert.ToBoolean(ds.Tables[0].Rows[0][0]),
                UseOperateRight = billCount == 0 ? false : Convert.ToBoolean(ds.Tables[0].Rows[0][1]),
                OperateRight = (BillOperateRight)Convert.ToInt32(ds.Tables[1].Rows[0][0]),
                DataRights = ds.Tables[2]
            };
        }

        /// <summary>
        /// 计算实体单据数据权限值
        /// </summary>
        /// <param name="aEntity">实体对象</param>
        /// <param name="billRights">单据权限数据集</param>
        /// <returns>合并的单据数据权限值</returns>
        public static BillDataRight CalcEntityBillDataRight(IEntityBase entity, BillRightInfo billRightInfo)
        {
            if (entity == null)
                return BillDataRight.None;
            string sTableName = entity.TableName;
            if (billRightInfo == null || billRightInfo.BillTypeId <= 0 || !billRightInfo.UseDataRight)
                return BillDataRight.All;
            if (!entity.FieldIsExists(BillRightInfo.CreatedByField))
                throw new ArgumentNullException("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, BillRightInfo.CreatedByField));

            if (!entity.FieldIsExists(BillRightInfo.OrganizationIdField))
                throw new ArgumentNullException("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, BillRightInfo.OrganizationIdField));

            if (!entity.FieldIsExists(BillRightInfo.OrganizationCodeField))
                throw new ArgumentNullException("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, BillRightInfo.OrganizationCodeField));

            return CalcCurrentEntityBillDataRight("UpdateRight", billRightInfo, BillDataRight.Edit, entity)
                | CalcCurrentEntityBillDataRight("DeleteRight", billRightInfo, BillDataRight.Delete, entity)
                | CalcCurrentEntityBillDataRight("AuditRight", billRightInfo, BillDataRight.SendToAudit, entity)
                | CalcCurrentEntityBillDataRight("PrintRight", billRightInfo, BillDataRight.Print, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight1", billRightInfo, BillDataRight.Extend1, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight2", billRightInfo, BillDataRight.Extend2, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight3", billRightInfo, BillDataRight.Extend3, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight4", billRightInfo, BillDataRight.Extend4, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight5", billRightInfo, BillDataRight.Extend5, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight6", billRightInfo, BillDataRight.Extend6, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight7", billRightInfo, BillDataRight.Extend7, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight8", billRightInfo, BillDataRight.Extend8, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight9", billRightInfo, BillDataRight.Extend9, entity)
                | CalcCurrentEntityBillDataRight("ExtendRight10", billRightInfo, BillDataRight.Extend10, entity);
        }

        /// <summary>
        /// 计算当前这一行的数据，判断是否有指定权限
        /// </summary>
        /// <param name="fieldName">指定权限字段</param>
        /// <param name="table">权限配置数据</param>
        /// <param name="destBillDataRight">目标权限</param>s
        /// <param name="aEntity">数据行实体</param>
        /// <returns></returns>
        private static BillDataRight CalcCurrentEntityBillDataRight(string fieldName, BillRightInfo billRight, BillDataRight destBillDataRight, IEntityBase entity)
        {
            bool temp = false;
            int CreatedBy = -1;
            if (entity.FieldIsExists(BillRightInfo.CreatedByField) && !entity.FieldIsNull(BillRightInfo.CreatedByField) && entity.GetFieldValue<int>(BillRightInfo.CreatedByField) > 0)
            {
                CreatedBy = entity.GetFieldValue<int>(BillRightInfo.CreatedByField);
            }

            int OrganizationId = -1;
            if (entity.FieldIsExists(BillRightInfo.OrganizationIdField) && !entity.FieldIsNull(BillRightInfo.OrganizationIdField))
            {
                OrganizationId = entity.GetFieldValue<int>(BillRightInfo.OrganizationIdField);
            }

            string OrganizationCode = "XXXXXX";
            if (entity.FieldIsExists(BillRightInfo.OrganizationCodeField) && !entity.FieldIsNull(BillRightInfo.OrganizationCodeField))
            {
                OrganizationCode = entity.GetFieldValue<string>(BillRightInfo.OrganizationCodeField);
            }

            foreach (DataRow dr in billRight.DataRights.Rows)
            {
                //部门为空，则表示针对所有部门都是此角色
                bool bAllOrganization = dr.IsNull(RES.OrganizationId);

                bool bSameCreator = false;
                if (!dr.IsNull(RES.CreatedBy))
                {
                    bSameCreator = (CreatedBy == Convert.ToInt32(dr[RES.CreatedBy]));
                }

                bool bSameOrganizationId = false;
                if (!dr.IsNull(RES.OrganizationId))
                {
                    bSameOrganizationId = (OrganizationId == Convert.ToInt32(dr[RES.OrganizationId]));
                }

                bool bSameOrganizationCode = false;
                if (!dr.IsNull(RES.OrganizationCode))
                {
                    bSameOrganizationCode = OrganizationCode.StartsWith(dr[RES.OrganizationCode].ToString(), StringComparison.OrdinalIgnoreCase);
                }
                switch ((BillRightType)Convert.ToInt32(dr[fieldName]))
                {
                    case BillRightType.None: continue;
                    case BillRightType.OnlyOwner: temp = bSameCreator && (bAllOrganization || bSameOrganizationCode || bSameOrganizationId); break;
                    case BillRightType.OnlyDepartment: temp = bSameCreator || bAllOrganization || bSameOrganizationId; break;
                    case BillRightType.DepartmentAndChild: temp = bSameCreator || bAllOrganization || bSameOrganizationCode; break;
                    case BillRightType.All: temp = true; break;
                }
                if (temp)
                    return destBillDataRight;
            }
            return BillDataRight.None;
        }

        #endregion

        #region 查询权限实现

        public static string CalcBillQueryRight(string sql, int billTypeId, int userId)
        {
            if (billTypeId <= 0)
                return sql;
            if (!sql.Contains(RES.QueryRightString))
                return sql;
            List<BillQueryRightInfo> bills = ParseBillTypeInSql(sql);
            //代码中未写明的单据类型，就是整个的单据类型ID
            foreach (BillQueryRightInfo info in bills.Where(x => x.BillTypeId == 0))
            {
                info.BillTypeId = billTypeId;
            }
            FilterNoneRightBill(bills);
            DataTable billQueryRights = QueryBillQueryRight(userId, bills.Select(x => x.BillTypeId).ToList());
            return CalcSqlTextByBillRight(sql, userId, bills, billQueryRights);
        }

        /// <summary>
        /// 删除 不存在的单据类型及不需要单据权限的单据类型
        /// </summary>
        private static void FilterNoneRightBill(List<BillQueryRightInfo> bills)
        {
            const string sql = @"
SELECT BillTypeId=Iden 
FROM dbo.sysBillType WITH(NOLOCK) 
WHERE Iden IN ({0}) AND UseBillDataRight=1 AND IsActive=1";

            string s = string.Format(sql, bills.Select(x => x.BillTypeId.ToString()).Distinct().JoinText(","));
            DataTable dt = DataPortal.ExecuteDataset(ConfigContext.DefaultConnection, s).Tables[0];

            //无需单据权限的删除
            bills.RemoveAll(info => !dt.AsEnumerable().Any(x => x.Field<int>(RES.BillTypeId) == info.BillTypeId));
        }

        private static List<BillQueryRightInfo> ParseBillTypeInSql(string sql)
        {
            List<BillQueryRightInfo> result = new List<BillQueryRightInfo>();
            int i = -1;
            string s = sql.Between(RES.QueryRightString, ")", false, ref i);
            while (i > -1)
            {
                int iEnd = sql.IndexOf(@"*/", i + 1);
                result.Add(new BillQueryRightInfo() { Code = s, Start = i, Length = iEnd - i + 2 });
                i++;
                s = sql.Between(RES.QueryRightString, ")", false, ref i);
            }
            return result;
        }

        /// <summary>
        /// 查询单据查询权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="bills">单据类型ID</param>
        private static DataTable QueryBillQueryRight(int userId, IEnumerable<int> bills)
        {
            const string sql = @"
SELECT OrganizationId=C.Iden,OrganizationCode=C.Code,B.BillTypeId,QueryRight=MAX(B.QueryRight)
FROM dbo.sysUserDataRole A WITH(NOLOCK)
JOIN dbo.sysBillDataRight B WITH(NOLOCK) ON B.DataRoleId=A.DataRoleId AND B.IsActive=1 AND B.BillTypeId IN ({0}) 
JOIN dbo.sysBillType D WITH(NOLOCK) ON D.Iden=B.BillTypeId AND D.IsActive=1 AND D.UseBillDataRight=1--单据有效且启用数据权限
LEFT JOIN dbo.sysOrganization C WITH(NOLOCK) ON C.Iden=A.OrganizationId AND C.IsActive=1
WHERE A.UserId=:UserId     
GROUP BY B.BillTypeId,C.Iden,C.Code";
            string s = bills.IsEmpty() ? "0" : bills.Select(x => x.ToString()).JoinText(",");
            s = string.Format(sql, s);
            return DataPortal.ExecuteDataset(ConfigContext.DefaultConnection, s, userId).Tables[0];
        }

        /// <summary>
        /// 根据单据查询权限，改写原有sql语句
        /// </summary>
        /// <param name="sqlText">sql文本</param>
        /// <param name="session"></param>
        /// <param name="bills">单据查询配置列表</param>
        /// <param name="billQueryRights">单据查询权限实体集</param>
        /// <returns>修改后的sql文本</returns>
        private static string CalcSqlTextByBillRight(string sqlText, int userId, IEnumerable<BillQueryRightInfo> bills, DataTable billQueryRights)
        {
            StringBuilder sb = new StringBuilder(sqlText);
            foreach (BillQueryRightInfo info in bills.OrderByDescending(x => x.Start))
            {
                info.Condition = CalcQueryRight(info, userId, billQueryRights);
                sb.Remove(info.Start, info.Length);
                sb.Insert(info.Start, info.Condition);
            }
            return sb.ToString();
        }

        private static string CalcQueryRight(BillQueryRightInfo info, int sUserId, DataTable billQueryRights)
        {
            const string OnlyOwnerCondition1 = @"({0}='{1}')";
            //const string OnlyOwnerCondition2 = @"({0}='{1}' AND dbo.sysGetOrganizationCode({2}) LIKE '{3}%')";
            //const string OnlyOwnerCondition3 = @"({0}='{1}' AND {2}={3})";
            const string OnlyDepartmentCondition = @"({0}={1})";
            const string DepartmentAndChildCondition1 = @"({0} LIKE '{1}%')";
            //const string DepartmentAndChildCondition2 = @"(dbo.sysGetOrganizationCode({0}) LIKE '{1}%')";
            //得到当前单据的权限数据
            var rights = billQueryRights.AsEnumerable().Where(x => x.Field<int>(RES.BillTypeId) == info.BillTypeId);
            //未配置权限，则无任何权限，不可查询出任何数据
            if (rights.IsEmpty())
                return " AND 1=2 ";
            //bool bHasOrganizationCode = true;
            //若有查询所有权限，则直接返回1=1(所有部门的本部门权限，等同于所有权限)
            if (rights.Any(x => (BillRightType)x.Field<int>(RES.QueryRight) == BillRightType.All
                                || (((BillRightType)x.Field<int>(RES.QueryRight)).In(BillRightType.DepartmentAndChild, BillRightType.OnlyDepartment)
                                    && x.IsNull(RES.OrganizationId)
                                    )))
            {
                return string.Empty;
            }
            //计算字段名
            string CreateByField = info.CreateByField.IsEmpty() ? string.Format("{0}.CreatedBy", info.sPrefix) : info.CreateByField;
            string sDepartmentIdField = info.OrganizationIdField.IsEmpty() ? string.Format("{0}.OrganizationId", info.sPrefix) : info.OrganizationIdField;
            string sDepartmentCodeField = info.OrganizationCodeField.IsEmpty() ? string.Format("{0}.OrganizationCode", info.sPrefix) : info.OrganizationCodeField;
            //开始计算权限
            List<string> conditions = new List<string>();
            foreach (DataRow a in rights)
            {
                bool bAllDepartment = a.IsNull(RES.OrganizationId);
                int iDepartmentId = a.IsNull(RES.OrganizationId) ? -1 : a.Field<int>(RES.OrganizationId);
                string sDepartmentCode = a.Field<string>(RES.OrganizationCode);
                BillRightType iQueryRight = (BillRightType)a.Field<int>(RES.QueryRight);

                string s = string.Empty;
                switch (iQueryRight)
                {
                    case BillRightType.OnlyOwner:
                        //if (bAllDepartment)
                        s = string.Format(OnlyOwnerCondition1, CreateByField, sUserId);
                        //else if (bHasOrganizationCode)
                        //    s = string.Format(OnlyOwnerCondition2, CreateByField, sUserId, sDepartmentIdField, sDepartmentCode);
                        //else
                        //    s = string.Format(OnlyOwnerCondition3, CreateByField, sUserId, sDepartmentIdField, iDepartmentId);
                        break;
                    case BillRightType.OnlyDepartment:
                        s = string.Format(OnlyDepartmentCondition, sDepartmentIdField, iDepartmentId);
                        break;
                    case BillRightType.DepartmentAndChild:
                        //if (!info.OrganizationCodeField.IsEmpty())
                        s = string.Format(DepartmentAndChildCondition1, sDepartmentCodeField, sDepartmentCode);
                        //else
                        //    s = string.Format(DepartmentAndChildCondition2, sDepartmentIdField, sDepartmentCode);
                        break;
                }
                if (!s.IsEmpty())
                    conditions.Add(s);
            }
            if (conditions.IsEmpty())
                return string.Empty;
            else
                return string.Format(" AND ({0})", conditions.Distinct().JoinText(" OR "));
        }

        #endregion

    }
}
