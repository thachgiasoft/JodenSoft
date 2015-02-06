using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "精确查找")]
        Exact = 0,
        /// <summary>
        /// 模糊匹配
        /// </summary>
         [Display(Name = "模糊匹配")]
        Fuzzy = 1,
        /// <summary>
        /// 组合查找
        /// </summary>
         [Display(Name = "组合查找")]
        Combinatorial = 2,
        /// <summary>
        /// 左匹配
        /// </summary>
         [Display(Name = "左匹配")]
        LeftMatch = 3,
    }
}
