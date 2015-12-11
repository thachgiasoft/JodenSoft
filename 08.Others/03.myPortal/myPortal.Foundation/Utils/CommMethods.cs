using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;


namespace myPortal.Foundation.Utils
{
    public class CommMethods
    {
        private static DateTime minSqlDateTime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 链接两个ＳＱＬ查询WHERE子句,含空串筛选
        /// </summary>
        /// <param name="baseCondition"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static string LinkCondition(string baseCondition, string current)
        {
            if (baseCondition.Length > 0)
            {
                if (current.Length > 0)
                    return string.Format("{0} AND {1}", baseCondition, current);
                else
                    return baseCondition;
            }
            else
            {
                return current;
            }
        }

        public static bool IsNum(string str)
        {
            if (str.Length <= 0)
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str, i))
                {
                    return false;
                }

                if (str[i] > '9' || str[i] < '0')
                {
                    return false;
                }
            }

            return true;
        }

        public static DateTime GetMinTime()
        {
            //DateTime.MinValue在SQL中会导致溢出异常
            return minSqlDateTime;
        }

        public static int GetTotalPage(int totalRecord, int pageSize)
        {
            return totalRecord % pageSize > 0 ?
                totalRecord / pageSize + 1 : totalRecord / pageSize;
        }


        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, "page");
        }

        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="pagetag">页码标记</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, pagetag, null);
        }

        /// <summary>
        /// 获得页码显示链接
        /// </summary>
        /// <param name="curPage">当前页数</param>
        /// <param name="countPage">总页数</param>
        /// <param name="url">超级链接地址</param>
        /// <param name="extendPage">周边页码显示个数上限</param>
        /// <param name="pagetag">页码标记</param>
        /// <param name="anchor">锚点</param>
        /// <returns>页码html</returns>
        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag, string anchor)
        {
            if (pagetag == "")
                pagetag = "page";
            int startPage = 1;
            int endPage = 1;

            if (url.IndexOf("?") > 0)
                url = url + "&";
            else
                url = url + "?";

            string t1 = "<a href=\"" + url +  pagetag + "=1";
            string t2 = "<a href=\"" + url +  pagetag + "=" + countPage;
            if (anchor != null)
            {
                t1 += anchor;
                t2 += anchor;
            }
            t1 += "\">&laquo;</a>";
            t2 += "\">&raquo;</a>";

            if (countPage < 1)
                countPage = 1;
            if (extendPage < 3)
                extendPage = 2;

            if (countPage > extendPage)
            {
                if (curPage - (extendPage / 2) > 0)
                {
                    if (curPage + (extendPage / 2) < countPage)
                    {
                        startPage = curPage - (extendPage / 2);
                        endPage = startPage + extendPage - 1;
                    }
                    else
                    {
                        endPage = countPage;
                        startPage = endPage - extendPage + 1;
                        t2 = "";
                    }
                }
                else
                {
                    endPage = extendPage;
                    t1 = "";
                }
            }
            else
            {
                startPage = 1;
                endPage = countPage;
                t1 = "";
                t2 = "";
            }

            StringBuilder s = new StringBuilder("");

            s.Append(t1);
            for (int i = startPage; i <= endPage; i++)
            {
                if (i == curPage)
                {
                    s.Append("<span>");
                    s.Append(i);
                    s.Append("</span>");
                }
                else
                {
                    s.Append("<a href=\"");
                    s.Append(url);
                    s.Append(pagetag);
                    s.Append("=");
                    s.Append(i);
                    if (anchor != null)
                    {
                        s.Append(anchor);
                    }
                    s.Append("\">");
                    s.Append(i);
                    s.Append("</a>");
                }
            }
            s.Append(t2);

            return s.ToString();
        }
    }
}
