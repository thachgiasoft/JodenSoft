using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace myPortal.Foundation.Utils
{
    /// <summary>
    /// ����������ֺ���
    /// </summary>
    public class ListItemHelper
    {
        private ListItemHelper()
        {
        }
        /// <summary>
        /// �������Ĭ��ѡ���Ĭ��ֵ
        /// </summary>
        public static int DefaultValue
        {
            get
            {
                return -1;
            }
        }
        /// <summary>
        /// �������Ĭ��ѡ��
        /// </summary>
        /// <returns></returns>
        public static ListItem DefaultItem()
        {

            return DefaultItem("--��ѡ��--");

        }
        /// <summary>
        /// �������Ĭ��ѡ��
        /// </summary>
        /// <param name="defaultText">Ĭ���ı�</param>
        /// <param name="defaultValue">Ĭ��ֵ</param>
        /// <returns></returns>
        public static ListItem DefaultItem(string defaultText)
        {
            ListItem li = new ListItem();
            li.Text = defaultText;
            li.Value = DefaultValue.ToString();
            return li;
        }
        /// <summary>
        /// HTML�ؼ���Optionsѡ��
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
        /// ��ʱ�����HtmlSelect
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
