using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using SAF.Foundation;

namespace SAF.Framework.Extensions
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
    }
}
