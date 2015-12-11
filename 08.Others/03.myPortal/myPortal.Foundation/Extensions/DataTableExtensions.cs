using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace myPortal.Foundation.Extensions
{
    public static class DataTableExtensions
    {
        public static IList<T> ToList<T>(this DataTable dt, Func<DataRow, T> DataRowToModel) where T : class ,new()
        {
            IList<T> modelList = new List<T>();
            if (dt == null) return modelList;
            foreach (DataRow row in dt.Rows)
            {
                T model = DataRowToModel(row);
                if (model != null)
                {
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
