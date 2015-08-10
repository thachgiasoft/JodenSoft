using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation
{
    public static class GridControlExtensions
    {
        public static void UnEditableAllColumns(this GridView view)
        {
            if (view == null) return;
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.ReadOnly = false;

            foreach (GridColumn col in view.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.OptionsColumn.AllowEdit = false;
            }
        }

        public static void EditableColumns(this GridView view, params string[] fieldNames)
        {
            if (view == null) return;
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.ReadOnly = false;

            foreach (var item in fieldNames)
            {
                var col = view.Columns[item];
                if (col == null) continue;
                col.OptionsColumn.ReadOnly = false;
                col.OptionsColumn.AllowEdit = true;
            }
        }
    }
}
