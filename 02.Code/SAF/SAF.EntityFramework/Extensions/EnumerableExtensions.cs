using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.EntityFramework
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 删除列表中的实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entitySet"></param>
        public static void Delete<TEntity>(this EntitySet<TEntity> entitySet, IEnumerable<TEntity> el) where TEntity : Entity<TEntity>,new()
        {
            if (entitySet == null || entitySet.Count <= 0) return;

            if (el == null || el.Count() <= 0) return;

            var list = entitySet.Where(p => p.DataRowView.In(el.Select(x => x.DataRowView)));
            foreach (var item in list)
            {
                item.Delete();
            }
        }
    }
}
