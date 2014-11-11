using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using DevExpress.XtraEditors.Controls;

namespace SAF.Framework
{
    public static class LookUpEditExtensions
    {
        public static void SetDataSource(this RepositoryItemLookUpEdit properties, object dataSource,
            string valueMember, string displayMember, string fieldAndCaptionList = "")
        {
            properties.NullText = "";
            properties.Columns.Clear();

            if (fieldAndCaptionList.IsEmpty())
            {
                properties.ShowHeader = false;
                fieldAndCaptionList = "{0}|{0}".FormatEx(displayMember);
            }

            var fieldArray = fieldAndCaptionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < fieldArray.Length; i++)
            {
                var list = fieldArray[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Length > 0)
                {
                    var column = new LookUpColumnInfo(list[0], list.Length == 1 ? list[0] : list[1]);
                    column.Visible = true;
                    properties.Columns.Add(column);
                }
            }

            properties.DataSource = dataSource;
            properties.DisplayMember = displayMember;
            properties.ValueMember = valueMember;

            properties.BestFit();
        }
    }
}
