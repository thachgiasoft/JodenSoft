using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 删除列表中的实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entitySet"></param>
        public static void Delete<TEntity>(this IEnumerable<TEntity> entitySet) where TEntity : IEntityBase
        {
            if (entitySet == null || entitySet.Count() <= 0) return;

            var en = entitySet.First();
            if (en.DataRowView == null || en.DataRowView.Row == null || en.DataRowView.Row.Table == null) return;

            var dt = en.DataRowView.Row.Table;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (entitySet.Any(p => p.DataRowView.Row == dt.Rows[i]))
                    dt.Rows[i].Delete();
            }
        }
    }
}
