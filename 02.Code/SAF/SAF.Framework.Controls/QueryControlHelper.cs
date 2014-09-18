using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework.Controls
{
    public static class QueryControlHelper
    {
        public static string GenerateQuickQueryCondition(string sField, string sValue, QuickQueryType queryType)
        {
            string result;
            if (sField.IsEmpty() || sValue.IsEmpty())
            {
                result = string.Empty;
            }
            else
            {
                IEnumerable<string> source = sField.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                sValue = sValue.Replace('？', '?').Replace('，', ',').Replace('\u3000', ' ');
                sValue = sValue.Replace('?', '_').Replace('*', '%');
                switch (queryType)
                {
                    case QuickQueryType.Exact:
                        result = (from s in source select string.Format("{0} = '{1}'", s, sValue)).JoinText(" OR ");
                        break;
                    case QuickQueryType.Fuzzy:
                        result = (from s in source select string.Format("{0} LIKE '%{1}%'", s, sValue)).JoinText(" OR ");
                        break;
                    case QuickQueryType.Combinatorial:
                        result = (
                                    from s in source
                                    select (
                                        from s1 in sValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        select string.Format("({0})", (
                                            from s2 in s1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            select string.Format("{0} LIKE '%{1}%'", s, s2)
                                            ).JoinText(" AND ")
                                            )
                                    ).JoinText(" OR ")
                                  ).JoinText(" OR ");
                        break;
                    case QuickQueryType.LeftMatch:
                        result = (from s in source select string.Format("{0} LIKE '{1}%'", s, sValue)).JoinText(" OR ");
                        break;
                    default:
                        result = string.Empty;
                        break;
                }
            }
            return result;
        }
    }

    public enum QuickQueryType
    {
        /// <summary>
        /// 精确查找
        /// </summary>
        Exact = 0,
        /// <summary>
        /// 模糊匹配
        /// </summary>
        Fuzzy = 1,
        /// <summary>
        /// 组合查找
        /// </summary>
        Combinatorial = 2,
        /// <summary>
        /// 左匹配
        /// </summary>
        LeftMatch = 3,
    }
}
