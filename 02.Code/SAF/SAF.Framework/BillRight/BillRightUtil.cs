﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Data;

//namespace SAF.Framework
//{
//    public class BillRightUtil
//    {
//        #region 数据权限实现

//        public BillRightInfo QueryBillRight(int iBillType, string sUserId, int iDepartmentId)
//        {
//            //iDepartmentId参数特别说明：
//            //1.参数iDepartmentId在下面的代码中只用于过滤操作权限，不参与过滤数据权限。
//            //2.如果参数iDepartmentId设置为0或者-1，那么在过滤操作权限的时候，这个参数就不起任何作用。
//            //3.不管iDepartmentId设置为任何值，都不会对过滤数据权限产生影响。

//            const string sql = @"
//--查询单据配置
//SELECT bBillDataRight,bBillOperateRight,iAllowRightType FROM dbo.pbBillType WITH(NOLOCK) WHERE iIden=@iBillType AND bUsable=1
//
//--查询操作权限,如果用户属于同一部门的多个角色,那么权限取角色的并集
//DECLARE @iBillRight INT
//IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.pbBillType WITH(NOLOCK) WHERE iIden=@iBillType AND bUsable=1)
//    SELECT iBillRight=0--单据类型不存在,并且又应用的单据权限,那么返回无权限
//ELSE
//BEGIN
//    SET @iBillRight=0
//    SELECT @iBillRight=@iBillRight | (
//          CASE MAX(CAST(bInsertRight AS INT)) WHEN 1 THEN 1 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth1 AS INT)) WHEN 1 THEN 2 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth2 AS INT)) WHEN 1 THEN 4 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth3 AS INT)) WHEN 1 THEN 8 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth4 AS INT)) WHEN 1 THEN 16 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth5 AS INT)) WHEN 1 THEN 32 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth6 AS INT)) WHEN 1 THEN 64 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth7 AS INT)) WHEN 1 THEN 128 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth8 AS INT)) WHEN 1 THEN 256 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth9 AS INT)) WHEN 1 THEN 512 ELSE 0 END
//        | CASE MAX(CAST(bExtendRigth10 AS INT)) WHEN 1 THEN 1024 ELSE 0 END
//    )
//    FROM dbo.pbUserDataRole A WITH(NOLOCK)
//    JOIN dbo.pbBillOperateRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//    JOIN dbo.pbDepartment C WITH(NOLOCK) ON C.iIden=A.iDepartmentId
//    JOIN dbo.pbBillType d WITH(NOLOCK) ON d.iIden=B.iBillType
//    WHERE A.sUserId=@sUserId AND C.bUsable=1 and a.iSystemId=@iSystemId
//    AND B.iBillType=@iBillType AND B.bUsable=1 and d.bBillOperateRight=1
//    AND (
//            A.iDepartmentId=@iDepartmentId 
//            OR @iDepartmentId=0 
//            OR @iDepartmentId=-1
//            OR EXISTS(
//                    SELECT TOP 1 1
//		            FROM dbo.pbDepartment A1 WITH(NOLOCK)
//		            WHERE iIden=@iDepartmentId AND A1.sDepartmentCode LIKE C.sDepartmentCode+'%'
//                    --WHERE iIden=@iDepartmentId AND C.sDepartmentCode LIKE A1.sDepartmentCode+'%'
//                )
//        )
//    SELECT iBillRight=ISNULL(@iBillRight,0)
//END
//
//--查询数据权限
//SELECT sCreator=@sUserId,iDepartmentId=D.iIden,D.sDepartmentCode
//    ,iUpdateRight=MAX(B.iUpdateRight)
//    ,iDeleteRight=MAX(B.iDeleteRight)
//    ,iExtendRight1=MAX(B.iExtendRight1),iExtendRight2=MAX(B.iExtendRight2)
//    ,iExtendRight3=MAX(B.iExtendRight3),iExtendRight4=MAX(B.iExtendRight4)
//    ,iExtendRight5=MAX(B.iExtendRight5),iExtendRight6=MAX(B.iExtendRight6)
//    ,iExtendRight7=MAX(B.iExtendRight7),iExtendRight8=MAX(B.iExtendRight8)
//    ,iExtendRight9=MAX(B.iExtendRight9),iExtendRight10=MAX(B.iExtendRight10)
//FROM dbo.pbUserDataRole A WITH(NOLOCK)
//JOIN dbo.pbBillDataRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//JOIN dbo.pbBillType C WITH(NOLOCK) ON C.iIden=@iBillType 
//LEFT JOIN dbo.pbDepartment D WITH(NOLOCK) ON D.iIden=A.iDepartmentId AND D.bUsable=1
//WHERE B.bUsable=1 AND B.iBillType=@iBillType 
//AND A.sUserId=@sUserId and a.iSystemId=@iSystemId
//AND C.bBillDataRight=1 AND C.bUsable=1
//GROUP BY D.iIden,D.sDepartmentCode
//
//--取操作权限中具有新增功能的部门列表
//SELECT distinct iDepartmentId=c.iIden,c.sDepartmentCode
//    FROM dbo.pbUserDataRole A WITH(NOLOCK)
//    JOIN dbo.pbBillOperateRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//    JOIN dbo.pbDepartment C WITH(NOLOCK) ON C.iIden=A.iDepartmentId
//     JOIN dbo.pbBillType d WITH(NOLOCK) ON d.iIden=B.iBillType
//    WHERE A.sUserId=@sUserId AND C.bUsable=1 and a.iSystemId=@iSystemId
//    AND B.iBillType=@iBillType AND B.bUsable=1 and d.bBillOperateRight=1
//    AND (
//            A.iDepartmentId=@iDepartmentId 
//            OR @iDepartmentId=0
//            OR @iDepartmentId=-1 
//            OR EXISTS(
//                    SELECT TOP 1 1
//		            FROM dbo.pbDepartment A1 WITH(NOLOCK)
//		            WHERE iIden=@iDepartmentId AND A1.sDepartmentCode LIKE C.sDepartmentCode+'%'
//                    --WHERE iIden=@iDepartmentId AND C.sDepartmentCode LIKE A1.sDepartmentCode+'%'
//                )
//        )
//   and  b.bInsertRight=1
//
//--提取操作权限中的有效角色列表
//SELECT distinct a.iDataRoleId,e.sDataRoleName
//    FROM dbo.pbUserDataRole A WITH(NOLOCK)
//    JOIN dbo.pbBillOperateRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//    JOIN dbo.pbDepartment C WITH(NOLOCK) ON C.iIden=A.iDepartmentId
//    JOIN dbo.pbBillType d WITH(NOLOCK) ON d.iIden=B.iBillType
//    join dbo.pbDataRole e on a.iDataRoleId=e.iIden
//    WHERE A.sUserId=@sUserId AND C.bUsable=1 and a.iSystemId=@iSystemId
//    AND B.iBillType=@iBillType AND B.bUsable=1 and d.bBillOperateRight=1
//    AND (
//            A.iDepartmentId=@iDepartmentId 
//            OR @iDepartmentId=0 
//            OR @iDepartmentId=-1
//            OR EXISTS(
//                    SELECT TOP 1 1
//		            FROM dbo.pbDepartment A1 WITH(NOLOCK)
//		            WHERE iIden=@iDepartmentId AND A1.sDepartmentCode LIKE C.sDepartmentCode+'%'
//                    --WHERE iIden=@iDepartmentId AND C.sDepartmentCode LIKE A1.sDepartmentCode+'%'
//                )
//        )
//   and  b.bInsertRight=1
//
//
//--提取数据权限中的有效角色列表
//SELECT distinct a.iDataRoleId,e.sDataRoleName
//FROM dbo.pbUserDataRole A WITH(NOLOCK)
//JOIN dbo.pbBillDataRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//JOIN dbo.pbBillType C WITH(NOLOCK) ON C.iIden=@iBillType 
//LEFT JOIN dbo.pbDepartment D WITH(NOLOCK) ON D.iIden=A.iDepartmentId AND D.bUsable=1
//join dbo.pbDataRole e on a.iDataRoleId=e.iIden
//WHERE B.bUsable=1 AND B.iBillType=@iBillType 
//AND A.sUserId=@sUserId and a.iSystemId=@iSystemId
//AND C.bBillDataRight=1 AND C.bUsable=1
//
//
//
//";

//            var cmd = Database.GetSqlStringCommand(sql);
//            Database.AddInParameter(cmd, "iBillType", DbType.Int32, iBillType);
//            Database.AddInParameter(cmd, "sUserId", DbType.String, sUserId);
//            Database.AddInParameter(cmd, "iDepartmentId", DbType.Int32, iDepartmentId);
//            Database.AddInParameter(cmd, "iSystemId", DbType.String, Session.CurrentUser.SystemId);

//            var ds = Database.ExecuteDataSet(cmd);
//            var billRightInfo = new BillRightInfo()
//            {
//                BillType = ds.Tables[0].Rows.Count == 0 ? 0 : iBillType,
//                UseDataRight = ds.Tables[0].Rows.Count == 0 ? false : Convert.ToBoolean(ds.Tables[0].Rows[0][0]),
//                UseOperateRight = ds.Tables[0].Rows.Count == 0 ? false : Convert.ToBoolean(ds.Tables[0].Rows[0][1]),
//                AllowRightType = ds.Tables[0].Rows.Count == 0 ? 0 : (BillRightType)Convert.ToInt32(ds.Tables[0].Rows[0][2]),
//                operateRight = (BillOperateRight)Convert.ToInt32(ds.Tables[1].Rows[0][0]),
//                dataRights = ds.Tables[2],
//                InsertDepartMentDatable = ds.Tables[3]  ////新增权限对应的可选部门列表

//            };
//            //生成新增权限对应的可选部门列表对应的数据字典
//            billRightInfo.InsertDepartMentDict = billRightInfo.InsertDepartMentDatable.AsEnumerable().ToDictionary(x => x["iDepartmentId"].ToInt(), x => x["sDepartmentCode"].ToString());

//            billRightInfo.operateRightsRoleDict = ds.Tables[4].AsEnumerable().ToDictionary(x => x["iDataRoleId"].ToInt(), x => x["sDataRoleName"].ToString());

//            billRightInfo.dataRightsRoleDict = ds.Tables[5].AsEnumerable().ToDictionary(x => x["iDataRoleId"].ToInt(), x => x["sDataRoleName"].ToString());

//            //如果新增权限对应的可选部门列表只有一条记录，那么默认该部门作为新增记录的对应部门
//            if (billRightInfo.InsertDepartMentDatable.Rows.Count == 1)
//            {
//                billRightInfo.iInsertDepartmentId = billRightInfo.InsertDepartMentDatable.Rows[0][0].ToInt();

//            }
//            return billRightInfo;
//        }



//        /// <summary>
//        /// 计算实体单据数据权限值
//        /// </summary>
//        /// <param name="aEntity">实体对象</param>
//        /// <param name="billRights">单据权限数据集</param>
//        /// <returns>合并的单据数据权限值</returns>
//        public BillDataRight CalcDataRowBillDataRight(DataRow row, BillRightInfo billRightInfo)
//        {
//            if (row == null)
//                return BillDataRight.None;
//            //string sTableName = row.Table.TableName;
//            //if (billRightInfo == null || billRightInfo.BillType <= 0 || !billRightInfo.UseDataRight )
//            //    return BillDataRight.All;
//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.OnlyOwner) && !row.IsFieldExists(billRightInfo.sCreatorField))
//            //{
//            //    MessageBoxHelper.ShowErrorMessage("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, billRightInfo.sCreatorField));
//            //    return BillDataRight.None;
//            //}
//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.OnlyDepartment) && !row.IsFieldExists(billRightInfo.sDepartmentIdField))
//            //{
//            //    MessageBoxHelper.ShowErrorMessage("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, billRightInfo.sDepartmentIdField));
//            //    return BillDataRight.None;
//            //}
//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.DepartmentAndChild) && !row.IsFieldExists(billRightInfo.sDepartmentCodeField))
//            //{
//            //    MessageBoxHelper.ShowErrorMessage("数据集[{0}]中缺少字段[{1}]，无法应用单据权限".FormatEx(sTableName, billRightInfo.sDepartmentCodeField));
//            //    return BillDataRight.None;
//            //}

//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.OnlyOwner) && row[billRightInfo.sCreatorField].IsEmpty())
//            //    return BillDataRight.None;
//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.OnlyDepartment) && row[billRightInfo.sDepartmentIdField].ToInt(-1) == -1)//因为有的时候部门ID确实有负数，比如外发生产地点，所以不能把所有部门ID为负数的都列为无权限
//            //    return BillDataRight.None;
//            //if (billRightInfo.AllowRightType.IncludeEnum(BillRightType.DepartmentAndChild) && row[billRightInfo.sDepartmentCodeField].IsEmpty())
//            //    return BillDataRight.None;


//            //return CalcCurrentRowBillDataRight("iUpdateRight", billRightInfo, BillDataRight.Update, row)
//            //        | CalcCurrentRowBillDataRight("iDeleteRight", billRightInfo, BillDataRight.Delete, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight1", billRightInfo, BillDataRight.Extend1, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight2", billRightInfo, BillDataRight.Extend2, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight3", billRightInfo, BillDataRight.Extend3, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight4", billRightInfo, BillDataRight.Extend4, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight5", billRightInfo, BillDataRight.Extend5, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight6", billRightInfo, BillDataRight.Extend6, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight7", billRightInfo, BillDataRight.Extend7, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight8", billRightInfo, BillDataRight.Extend8, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight9", billRightInfo, BillDataRight.Extend9, row)
//            //        | CalcCurrentRowBillDataRight("iExtendRight10", billRightInfo, BillDataRight.Extend10, row);
//        }

//        /// <summary>
//        /// 计算当前这一行的数据，判断是否有指定权限
//        /// </summary>
//        /// <param name="sFieldName">指定权限字段</param>
//        /// <param name="table">权限配置数据</param>
//        /// <param name="iDestRight">目标权限</param>s
//        /// <param name="aEntity">数据行实体</param>
//        /// <returns></returns>
//        private BillDataRight CalcCurrentRowBillDataRight(string sFieldName, BillRightInfo billRight, BillDataRight iDestRight, DataRow row)
//        {
//            bool temp = false;
//            string sCreator = row.IsFieldExists(billRight.sCreatorField) && !row.IsNull(billRight.sCreatorField) ? row.Field<string>(billRight.sCreatorField) : string.Empty;
//            int iDepartmentId = row.IsFieldExists(billRight.sDepartmentIdField) && !row.IsNull(billRight.sDepartmentIdField) ? row.Field<int>(billRight.sDepartmentIdField) : -1;

//            bool bHasDeptCode = billRight.AllowRightType.IncludeEnum(BillRightType.DepartmentAndChild);
//            string sDepartmentCode = bHasDeptCode ? row[billRight.sDepartmentCodeField].ToString() : string.Empty;
//            foreach (DataRow dr in billRight.dataRights.Rows)
//            {
//                //部门为空，则表示针对所有部门都是此角色
//                bool bAllDepartment = dr.IsNull(RES.iDepartmentId);
//                bool bSameCreator = sCreator.Equals(dr[RES.sCreator].ToString().Trim(), StringComparison.CurrentCultureIgnoreCase);
//                bool bSameDepartmentId = iDepartmentId == Convert.ToInt32(dr[RES.iDepartmentId]);
//                bool bSameDepartmentCode = sDepartmentCode.StartsWith(dr[RES.sDepartmentCode].ToString(), StringComparison.OrdinalIgnoreCase);
//                switch ((BillRightType)Convert.ToInt32(dr[sFieldName]))
//                {
//                    case BillRightType.None: continue;
//                    case BillRightType.OnlyOwner: temp = bSameCreator
//                       && (bAllDepartment || bSameDepartmentId || (bHasDeptCode ? bSameDepartmentCode : false)); break;
//                    case BillRightType.OnlyDepartment: temp = bAllDepartment || bSameDepartmentId; break;
//                    case BillRightType.DepartmentAndChild: temp = bAllDepartment || bSameDepartmentCode || bSameDepartmentId; break;
//                    case BillRightType.All: temp = true; break;
//                }
//                if (temp)
//                    return iDestRight;
//            }
//            return BillDataRight.None;
//        }

//        #endregion

//        private class RES
//        {
//            public const string QueryRight = @"/*QueryRight(";
//            public const string bBillDataRight = @"bBillDataRight";
//            public const string iBillType = @"iBillType";
//            public const string iQueryRight = @"iQueryRight";
//            public const string sCreator = @"sCreator";
//            public const string iDepartmentId = @"iDepartmentId";
//            public const string sDepartmentCode = @"sDepartmentCode";
//            public const string sCondition = "sCondition";
//            public const string iAllowRightType = @"iAllowRightType";
//        }

//        public string CalcBillQueryRight(string sql, int iBillType, string sUserId)
//        {
//            if (iBillType <= 0)
//                return sql;
//            if (!sql.Contains(RES.QueryRight))
//                return sql;
//            List<BillQueryRightInfo> bills = ParseBillTypeInSql(sql);
//            //代码中未写明的单据类型，就是整个的单据类型ID
//            foreach (BillQueryRightInfo info in bills.Where(x => x.iBillType == 0))
//            {
//                info.iBillType = iBillType;
//            }
//            FilterNoneRightBill(bills);
//            DataTable billQueryRights = QueryBillQueryRight(sUserId, bills.Select(x => x.iBillType).ToList());
//            return CalcSqlTextByBillRight(sql, sUserId, bills, billQueryRights);
//        }

//        /// <summary>
//        /// 删除 不存在的单据类型及不需要单据权限的单据类型
//        /// </summary>
//        private void FilterNoneRightBill(List<BillQueryRightInfo> bills)
//        {
//            const string sql =
//@"SELECT iBillType=iIden FROM dbo.pbBillType WITH(NOLOCK) 
//WHERE iIden IN ({0}) AND bBillDataRight=1 AND bUsable=1";

//            string s = string.Format(sql, bills.Select(x => x.iBillType.ToString()).Distinct().JoinText(","));
//            DataTable es = Database.ExecuteDataSet(CommandType.Text, s).Tables[0];
//            //无需单据权限的删除
//            bills.RemoveAll(info => !es.AsEnumerable().Any(x => x.Field<int>(RES.iBillType) == info.iBillType));
//        }

//        private List<BillQueryRightInfo> ParseBillTypeInSql(string sql)
//        {
//            List<BillQueryRightInfo> result = new List<BillQueryRightInfo>();
//            int i = -1;
//            string s = sql.Between(RES.QueryRight, ")", false, ref i);
//            while (i > -1)
//            {
//                int iEnd = sql.IndexOf(@"*/", i + 1);
//                result.Add(new BillQueryRightInfo() { sCode = s, iStart = i, iLength = iEnd - i + 2 });
//                i++;
//                s = sql.Between(RES.QueryRight, ")", false, ref i);
//            }
//            return result;
//        }

//        /// <summary>
//        /// 查询单据查询权限
//        /// </summary>
//        /// <param name="iUserId">用户ID</param>
//        /// <param name="bills">单据类型ID</param>
//        private DataTable QueryBillQueryRight(string sUserId, IEnumerable<int> bills)
//        {
//            const string sql =
//@"SELECT iDepartmentId=C.iIden,C.sDepartmentCode
//,B.iBillType,D.iAllowRightType,B.sCondition,iQueryRight=MAX(B.iQueryRight)
//FROM dbo.pbUserDataRole A WITH(NOLOCK)
//JOIN dbo.pbBillDataRight B WITH(NOLOCK) ON B.iDataRoleId=A.iDataRoleId
//LEFT JOIN dbo.pbDepartment C WITH(NOLOCK) ON C.iIden=A.iDepartmentId AND C.bUsable=1
//JOIN dbo.pbBillType D WITH(NOLOCK) ON D.iIden=B.iBillType
//WHERE B.bUsable=1 AND B.iBillType IN ({0}) 
//AND A.sUserId=@sUserId and a.iSystemId=@iSystemId
//AND D.bUsable=1 AND D.bBillDataRight=1--单据有效且启用数据权限
//GROUP BY B.iBillType,D.iAllowRightType,B.sCondition,C.iIden,C.sDepartmentCode";
//            string s = bills.IsEmpty() ? "0" : bills.Select(x => x.ToString()).JoinText(",");
//            s = string.Format(sql, s);
//            var cmd = Database.GetSqlStringCommand(s);
//            Database.AddInParameter(cmd, "sUserId", DbType.String, sUserId);
//            Database.AddInParameter(cmd, "iSystemId", DbType.String, Session.CurrentUser.SystemId);
//            var ds = Database.ExecuteDataSet(cmd);
//            DataTable result = ds.Tables[0];
//            return result;
//        }

//        /// <summary>
//        /// 根据单据查询权限，改写原有sql语句
//        /// </summary>
//        /// <param name="sSqlText">sql文本</param>
//        /// <param name="session"></param>
//        /// <param name="bills">单据查询配置列表</param>
//        /// <param name="billQueryRights">单据查询权限实体集</param>
//        /// <returns>修改后的sql文本</returns>
//        private string CalcSqlTextByBillRight(string sSqlText, string sUserId,
//            IEnumerable<BillQueryRightInfo> bills, DataTable billQueryRights)
//        {
//            StringBuilder sb = new StringBuilder(sSqlText);
//            foreach (BillQueryRightInfo info in bills.OrderByDescending(x => x.iStart))
//            {
//                info.sCondition = CalcQueryRight(info, sUserId, billQueryRights);
//                sb.Remove(info.iStart, info.iLength);
//                sb.Insert(info.iStart, info.sCondition);
//            }
//            return sb.ToString();
//        }

//        private string CalcQueryRight(BillQueryRightInfo info, string sUserId, DataTable billQueryRights)
//        {
//            const string OnlyOwnerCondition1 = @"({0}='{1}'  {2})";
//            const string OnlyOwnerCondition2 = @"({0}='{1}' AND dbo.fnpbGetDepartmentCode({2}) LIKE '{3}%' {4})";
//            const string OnlyOwnerCondition3 = @"({0}='{1}' AND {2}={3} {4})";
//            const string OnlyDepartmentCondition = @"({0}={1} {2})";
//            const string DepartmentAndChildCondition1 = @"({0} LIKE '{1}%' {2})";
//            const string DepartmentAndChildCondition2 = @"(dbo.fnpbGetDepartmentCode({0}) LIKE '{1}%' {2})";
//            //开始计算权限
//            List<string> conditions = new List<string>();

//            //得到当前单据的权限数据
//            var rights = billQueryRights.AsEnumerable().Where(x => x.Field<int>(RES.iBillType) == info.iBillType);
//            //未配置权限，则无任何权限，不可查询出任何数据
//            if (rights.Count() <= 0)
//                return " AND 1=2 ";
//            bool bHasDeptCode = rights.Any(x => ((BillRightType)x.Field<int>(RES.iAllowRightType)).IncludeEnum(BillRightType.DepartmentAndChild));
           
            
//            //若有查询所有权限，则只抓取查询限定条件，其他条件默认为1=1(所有部门的本部门权限，等同于所有权限)
//            if (rights.Any(x => (BillRightType)x.Field<int>(RES.iQueryRight) == BillRightType.All
//                                || (((BillRightType)x.Field<int>(RES.iQueryRight)).InEnum(BillRightType.DepartmentAndChild, BillRightType.OnlyDepartment)
//                                    && x.IsNull(RES.iDepartmentId)
//                                    )))
//            {
//                //return string.Empty;
//                foreach (DataRow a in rights)
//                {
//                    string sCondition = a.Field<string>(RES.sCondition);
//                    if (!sCondition.IsEmpty())
//                    {
//                        if ((sCondition.Trim().Length > 4) && (sCondition.Trim().Substring(0, 4).ToLower() == "and "))
//                        {
//                            sCondition = sCondition.Trim().Substring(4);
//                        }

//                        sCondition = string.Format(" ({0}) ", sCondition);
//                        conditions.Add(sCondition);
//                    }
//                }
//                if (conditions.Count <= 0)
//                    return string.Empty;
//                else
//                    return string.Format(" AND ({0})", conditions.Distinct().JoinText(" OR "));
//            }

//            //计算字段名
//            //string sCreatorField = info.sCreatorField.IsEmpty() ? string.Format("{0}.CreateBy", info.sPrefix) : info.sCreatorField;
//            //string sDepartmentIdField = info.sDepartmentIdField.IsEmpty() ? string.Format("{0}.iDepartmentId", info.sPrefix) : info.sDepartmentIdField;
//            //string sDepartmentCodeField = info.sDepartmentCodeField.IsEmpty() ? string.Format("{0}.sDepartmentCode", info.sPrefix) : info.sDepartmentCodeField;

//            string sCreatorField = info.sCreatorField.IsEmpty() ? string.Format("{0}.CreateBy", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sCreatorField);
//            string sDepartmentIdField = info.sDepartmentIdField.IsEmpty() ? string.Format("{0}.iDepartmentId", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sDepartmentIdField);
//            string sDepartmentCodeField = info.sDepartmentCodeField.IsEmpty() ? string.Format("{0}.sDepartmentCode", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sDepartmentCodeField);



//            foreach (DataRow a in rights)
//            {
//                bool bAllDepartment = a.IsNull(RES.iDepartmentId);

//                int iDepartmentId = -1;
//                if (!bAllDepartment)
//                    iDepartmentId = a.Field<int>(RES.iDepartmentId);

//                string sDepartmentCode = a.Field<string>(RES.sDepartmentCode);
//                BillRightType iQueryRight = (BillRightType)a.Field<int>(RES.iQueryRight);
//                string sCondition = a.Field<string>(RES.sCondition);
//                if (!sCondition.IsEmpty())
//                {
//                    if ((sCondition.Trim().Length > 4) && (sCondition.Trim().Substring(0, 4).ToLower() == "and "))
//                    {
//                        sCondition = sCondition.Trim().Substring(4);
//                    }
 
//                    sCondition = string.Format(" and  ({0}) ",  sCondition);
//                }
//                string s = string.Empty;
//                switch (iQueryRight)
//                {
//                    case BillRightType.OnlyOwner:
//                        if (bAllDepartment)
//                            s = string.Format(OnlyOwnerCondition1, sCreatorField, sUserId, sCondition);
//                        else if (bHasDeptCode)
//                            s = string.Format(OnlyOwnerCondition2, sCreatorField, sUserId, sDepartmentIdField, sDepartmentCode, sCondition);
//                        else
//                            s = string.Format(OnlyOwnerCondition3, sCreatorField, sUserId, sDepartmentIdField, iDepartmentId, sCondition);
//                        break;
//                    case BillRightType.OnlyDepartment:
//                        s = string.Format(OnlyDepartmentCondition, sDepartmentIdField, iDepartmentId, sCondition);
//                        break;
//                    case BillRightType.DepartmentAndChild:
//                        if (!info.sDepartmentCodeField.IsEmpty())
//                            s = string.Format(DepartmentAndChildCondition1, sDepartmentCodeField, sDepartmentCode, sCondition);
//                        else
//                            s = string.Format(DepartmentAndChildCondition2, sDepartmentIdField, sDepartmentCode, sCondition);
//                        break;
//                    case BillRightType.All:
//                        if (sCondition.IsNotEmpty())
//                            s = string.Format("( 1=1 {0})",sCondition);
//                        break;
//                    case BillRightType.None:
//                        s = "( 1=2 )";
//                        break;
//                }
//                if (!s.IsEmpty())
//                    conditions.Add(s);
//            }
//            if (conditions.Count <= 0)
//                return string.Empty;
//            else
//                return string.Format(" AND ({0})", conditions.Distinct().JoinText(" OR "));
//        }


//        #region Neo, 2014-1-17, 重写数据权限的Sql 条件构造语句
//        public string CalcBillQueryRightWithInFilter(string sql, int iBillType, string sUserId)
//        {
//            if (iBillType <= 0)
//                return sql;
//            if (!sql.Contains(RES.QueryRight))
//                return sql;
//            List<BillQueryRightInfo> bills = ParseBillTypeInSql(sql);
//            //代码中未写明的单据类型，就是整个的单据类型ID
//            foreach (BillQueryRightInfo info in bills.Where(x => x.iBillType == 0))
//            {
//                info.iBillType = iBillType;
//            }
//            FilterNoneRightBill(bills);
//            DataTable billQueryRights = QueryBillQueryRight(sUserId, bills.Select(x => x.iBillType).ToList());
//            return CalcSqlTextByBillRightWithInFilte(sql, sUserId, bills, billQueryRights);
//        }

//        private string CalcSqlTextByBillRightWithInFilte(string sSqlText, string sUserId, IEnumerable<BillQueryRightInfo> bills, DataTable billQueryRights)
//        {
//            StringBuilder sb = new StringBuilder(sSqlText);
//            foreach (BillQueryRightInfo info in bills.OrderByDescending(x => x.iStart))
//            {
//                info.sCondition = CalcQueryRightWithInFilte(info, sUserId, billQueryRights);
//                sb.Remove(info.iStart, info.iLength);
//                sb.Insert(info.iStart, info.sCondition);
//            }
//            return sb.ToString();
//        }

//        private string CalcQueryRightWithInFilte(BillQueryRightInfo info, string sUserId, DataTable billQueryRights)
//        {
//            const string OnlyOwnerCondition1 = @"({0}='{1}'  {2})";
//            const string OnlyOwnerCondition2 = @"({0}='{1}' AND dbo.fnpbGetDepartmentCode({2}) LIKE '{3}%' {4})";
//            const string OnlyOwnerCondition3 = @"({0}='{1}' AND {2}={3} {4})";
//            const string OnlyDepartmentCondition = @"({0}={1} {2})";
//            const string DepartmentAndChildCondition1 = @"({0} LIKE '{1}%' {2})";
//            //const string DepartmentAndChildCondition2 = @"(dbo.fnpbGetDepartmentCode({0}) LIKE '{1}%' {2})";
//            const string DepartmentAndChildCondition2 = @"({0} IN (SELECT iIden FROM EsquelLibrary.dbo.pbDepartment WHERE sDepartmentCode LIKE '{1}%' {2}))";

//            //开始计算权限
//            List<string> conditions = new List<string>();

//            //得到当前单据的权限数据
//            var rights = billQueryRights.AsEnumerable().Where(x => x.Field<int>(RES.iBillType) == info.iBillType);
//            //未配置权限，则无任何权限，不可查询出任何数据
//            if (rights.Count() <= 0)
//                return " AND 1=2 ";
//            bool bHasDeptCode = rights.Any(x => ((BillRightType)x.Field<int>(RES.iAllowRightType)).IncludeEnum(BillRightType.DepartmentAndChild));


//            ////若有查询所有权限，则只抓取查询限定条件，其他条件默认为1=1(所有部门的本部门权限，等同于所有权限)
//            //if (rights.Any(x => (BillRightType)x.Field<int>(RES.iQueryRight) == BillRightType.All
//            //                    || (((BillRightType)x.Field<int>(RES.iQueryRight)).InEnum(BillRightType.DepartmentAndChild, BillRightType.OnlyDepartment)
//            //                        && x.IsNull(RES.iDepartmentId)
//            //                        )))
//            //{
//            //    //return string.Empty;
//            //    foreach (DataRow a in rights)
//            //    {
//            //        string sCondition = a.Field<string>(RES.sCondition);
//            //        if (!sCondition.IsEmpty())
//            //        {
//            //            if ((sCondition.Trim().Length > 4) && (sCondition.Trim().Substring(0, 4).ToLower() == "and "))
//            //            {
//            //                sCondition = sCondition.Trim().Substring(4);
//            //            }

//            //            sCondition = string.Format(" ({0}) ", sCondition);
//            //            conditions.Add(sCondition);
//            //        }
//            //    }
//            //    if (conditions.Count <= 0)
//            //        return string.Empty;
//            //    else
//            //        return string.Format(" AND ({0})", conditions.Distinct().JoinText(" OR "));
//            //}

//            //计算字段名
//            //string sCreatorField = info.sCreatorField.IsEmpty() ? string.Format("{0}.CreateBy", info.sPrefix) : info.sCreatorField;
//            //string sDepartmentIdField = info.sDepartmentIdField.IsEmpty() ? string.Format("{0}.iDepartmentId", info.sPrefix) : info.sDepartmentIdField;
//            //string sDepartmentCodeField = info.sDepartmentCodeField.IsEmpty() ? string.Format("{0}.sDepartmentCode", info.sPrefix) : info.sDepartmentCodeField;

//            string sCreatorField = info.sCreatorField.IsEmpty() ? string.Format("{0}.CreateBy", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sCreatorField);
//            string sDepartmentIdField = info.sDepartmentIdField.IsEmpty() ? string.Format("{0}.iDepartmentId", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sDepartmentIdField);
//            string sDepartmentCodeField = info.sDepartmentCodeField.IsEmpty() ? string.Format("{0}.sDepartmentCode", info.sPrefix) : string.Format("{0}.{1}", info.sPrefix, info.sDepartmentCodeField);



//            foreach (DataRow a in rights)
//            {
//                bool bAllDepartment = a.IsNull(RES.iDepartmentId);

//                int iDepartmentId = -1;
//                if (!bAllDepartment)
//                    iDepartmentId = a.Field<int>(RES.iDepartmentId);

//                string sDepartmentCode = a.Field<string>(RES.sDepartmentCode);
//                BillRightType iQueryRight = (BillRightType)a.Field<int>(RES.iQueryRight);
//                string sCondition = a.Field<string>(RES.sCondition);
//                if (!sCondition.IsEmpty())
//                {
//                    if ((sCondition.Trim().Length > 4) && (sCondition.Trim().Substring(0, 4).ToLower() == "and "))
//                    {
//                        sCondition = sCondition.Trim().Substring(4);
//                    }

//                    sCondition = string.Format(" and  ({0}) ", sCondition);
//                }
//                string s = string.Empty;
//                switch (iQueryRight)
//                {
//                    case BillRightType.OnlyOwner:
//                        if (bAllDepartment)
//                            s = string.Format(OnlyOwnerCondition1, sCreatorField, sUserId, sCondition);
//                        else if (bHasDeptCode)
//                            s = string.Format(OnlyOwnerCondition2, sCreatorField, sUserId, sDepartmentIdField, sDepartmentCode, sCondition);
//                        else
//                            s = string.Format(OnlyOwnerCondition3, sCreatorField, sUserId, sDepartmentIdField, iDepartmentId, sCondition);
//                        break;
//                    case BillRightType.OnlyDepartment:
//                        s = string.Format(OnlyDepartmentCondition, sDepartmentIdField, iDepartmentId, sCondition);
//                        break;
//                    case BillRightType.DepartmentAndChild:
//                        if (!info.sDepartmentCodeField.IsEmpty())
//                            s = string.Format(DepartmentAndChildCondition1, sDepartmentCodeField, sDepartmentCode, sCondition);
//                        else
//                            s = string.Format(DepartmentAndChildCondition2, sDepartmentIdField, sDepartmentCode, sCondition);
//                        break;
//                    case BillRightType.All:
//                        if (sCondition.IsNotEmpty())
//                            s = string.Format("( 1=1 {0})", sCondition);
//                        break;
//                    case BillRightType.None:
//                        s = "( 1=2 )";
//                        break;
//                }
//                if (!s.IsEmpty())
//                    conditions.Add(s);
//            }
//            if (conditions.Count <= 0)
//                return string.Empty;
//            else
//                return string.Format(" AND ({0})", conditions.Distinct().JoinText(" OR "));
//        }
//        #endregion
//    }
//}