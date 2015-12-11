using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using SAF.Foundation;
using DevExpress.XtraGrid.Columns;

namespace SAF.Framework
{
    public static class GridViewExtensions
    {
        public static void ReverseSelection(this GridView view)
        {
            if (view.IsEmpty()) return;

            view.BeginSelection();
            try
            {
                if (view.GroupCount == 0)
                {
                    view.SelectAll();
                }
                else
                {
                    for (int i = 0; i < view.DataController.VisibleListSourceRowCount; i++)
                    {
                        if (view.IsRowSelected(i))
                            view.UnselectRow(i);
                        else
                            view.SelectRow(i);
                    }
                    for (int j = 0; j < view.DataController.GroupRowCount; j++)
                    {
                        int handle = view.DataController.GroupInfo[j].Handle;
                        if (view.IsRowSelected(handle))
                            view.UnselectRow(handle);
                        else
                            view.SelectRow(handle);
                    }
                }
            }
            finally
            {
                view.EndSelection();
            }
        }

        public static void ReadOnlyAllColumns(this GridView view, params string[] editableFieldNames)
        {
            if (view == null) return;
            view.OptionsBehavior.Editable = true;
            view.OptionsBehavior.ReadOnly = false;

            foreach (GridColumn col in view.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.OptionsColumn.AllowEdit = col.FieldName.In(editableFieldNames);
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
