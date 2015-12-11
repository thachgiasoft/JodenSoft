using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace myPortal.Foundation.Utils
{
    /// <summary>
    /// 下拉框的助手函数
    /// </summary>
    public class ListItemHelper
    {
        private ListItemHelper()
        {
        }
        /// <summary>
        /// 下拉框的默认选项的默认值
        /// </summary>
        public static int DefaultValue
        {
            get
            {
                return -1;
            }
        }
        /// <summary>
        /// 下拉框的默认选项
        /// </summary>
        /// <returns></returns>
        public static ListItem DefaultItem()
        {

            return DefaultItem("--请选择--");

        }
        /// <summary>
        /// 下拉框的默认选项
        /// </summary>
        /// <param name="defaultText">默认文本</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static ListItem DefaultItem(string defaultText)
        {
            ListItem li = new ListItem();
            li.Text = defaultText;
            li.Value = DefaultValue.ToString();
            return li;
        }
        /// <summary>
        /// HTML控件的Options选项
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <returns></returns>
        public static string GetOptions(DataTable dataTable, string valueField, string textField)
        {
            StringBuilder sb = new StringBuilder();
            if (dataTable != null)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sb.Append("<option value=\"");
                    sb.Append(dataTable.Rows[i][valueField]);
                    sb.Append("\">");
                    sb.Append(dataTable.Rows[i][textField]);
                    sb.Append("</option>");
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 用时间填充HtmlSelect
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="selectedIndex"></param>
        public static void FillTimeOptions(HtmlSelect ddl, int selectedIndex)
        {
            ddl.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                ListItem li = new ListItem(i.ToString().PadLeft(2, '0'));
                if (i == selectedIndex)
                {
                    li.Selected = true;
                }
                ddl.Items.Add(li);
            }
        }

        public static ListItem NewItem(string text, string value)
        {
            return new ListItem(text, value);

        }
    }
}
