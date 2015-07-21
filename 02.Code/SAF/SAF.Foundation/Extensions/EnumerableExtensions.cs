using SAF.Foundation.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SAF.Foundation
{
    /// <summary>
    /// Linq 扩展
    /// </summary>
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            return source.Distinct(Equality<T>.CreateComparer(keySelector));
        }

        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return source.Distinct(Equality<T>.CreateComparer(keySelector, comparer));
        }

        /// <summary>
        /// 返回一个字符串，该字符串是通过将列表内包含的若干子字符串联接在一起形成的。
        /// </summary>
        /// <param name="source">可枚举的列表</param>
        /// <param name="delimiter">用于在返回的字符串中分隔子字符串的任意字符串。
        /// <para>如果 delimiter 是零长度字符串 ("")或 null，则列表中的所有项都串联在一起，中间没有分隔符。</param>
        /// <returns></returns>
        public static string JoinText(this IEnumerable<string> source, string delimiter = ",")
        {
            if (delimiter == null) delimiter = "";
            var arr = source.ToArray();
            return Microsoft.VisualBasic.Strings.Join(arr, delimiter) ?? string.Empty;
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // column names  
            PropertyInfo[] oProps = null;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow  
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

    }
}
