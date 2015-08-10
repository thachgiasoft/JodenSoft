using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework
{
    public static class SearchLookUpEditExtensions
    {
        public static void SetDataSource(this RepositoryItemSearchLookUpEdit properties, object dataSource,
            string valueMember, string displayMember, string fieldAndCaptionList)
        {
            properties.View.OptionsBehavior.AutoPopulateColumns = false;
            properties.View.OptionsView.ColumnAutoWidth = false;
            properties.NullText = "";
            properties.View.Columns.Clear();

            if (fieldAndCaptionList.IsEmpty())
                fieldAndCaptionList = "{0}|{0}".FormatWith(displayMember);

            var fieldArray = fieldAndCaptionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < fieldArray.Length; i++)
            {
                var list = fieldArray[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Length > 0)
                {
                    var column = properties.View.Columns.AddField(list[0]);
                    column.Visible = true;
                    column.Caption = list.Length == 1 ? list[0] : list[1];
                }
            }

            properties.DataSource = dataSource;
            properties.DisplayMember = displayMember;
            properties.ValueMember = valueMember;

            properties.View.BestFitColumns();
        }
    }
}
