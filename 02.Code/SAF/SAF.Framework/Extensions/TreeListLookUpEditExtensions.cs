using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework
{
    public static class TreeListLookUpEditExtensions
    {
        public static void SetDataSource(this RepositoryItemTreeListLookUpEdit properties, object dataSource,
           string valueMember, string displayMember, string parentFieldName, string fieldAndCaptionList = "")
        {
            properties.TreeList.OptionsBehavior.AutoPopulateColumns = false;

            if (fieldAndCaptionList.IsEmpty() || fieldAndCaptionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length <= 1)
            {
                properties.TreeList.OptionsView.AutoWidth = true;
                properties.TreeList.OptionsView.ShowColumns = false;
            }
            else
            {
                properties.TreeList.OptionsView.AutoWidth = false;
            }

            properties.NullText = "";
            properties.TreeList.OptionsView.ShowHorzLines = false;
            properties.TreeList.OptionsView.ShowVertLines = false;
            properties.TreeList.OptionsView.ShowIndicator = false;
            properties.TreeList.Columns.Clear();

            if (fieldAndCaptionList.IsEmpty())
                fieldAndCaptionList = "{0}|{0}".FormatWith(displayMember);

            var fieldArray = fieldAndCaptionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < fieldArray.Length; i++)
            {
                var list = fieldArray[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (list.Length > 0)
                {
                    var column = properties.TreeList.Columns.AddField(list[0]);
                    column.Visible = true;
                    column.Caption = list.Length == 1 ? list[0] : list[1];
                }
            }

            properties.DataSource = dataSource;
            properties.DisplayMember = displayMember;
            properties.ValueMember = valueMember;
            properties.TreeList.KeyFieldName = valueMember;
            properties.TreeList.ParentFieldName = parentFieldName;

            properties.TreeList.BestFitColumns();
        }
    }
}
