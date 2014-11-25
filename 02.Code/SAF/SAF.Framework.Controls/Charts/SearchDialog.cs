#region Copyright ? 2013 Libra. All rights reserved.
/*
 * 文 件 名：SearchDialog
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2013/12/20 9:08:29
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    public partial class SearchDialog : Form
    {
        public Guid SelectedGuid { get; private set; }

        private DataTable dtGraphics = new DataTable();

        private SearchDialog()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            dtGraphics.Columns.Add("Guid", typeof(Guid));
            dtGraphics.Columns.Add("Name", typeof(string));
            dtGraphics.Columns.Add("Text", typeof(string));
            dtGraphics.Columns.Add("Status", typeof(string));
            dtGraphics.Columns.Add("Description", typeof(string));

            this.txtSearch.EditValueChanging += txtSearch_EditValueChanging;
        }

        void txtSearch_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string filter = string.Empty;
            if (!this.txtSearch.Text.m_IsEmpty())
            {
                filter = " Name like '%{0}%' or Text like '%{0}%' or Status like '%{0}%' or Description like '%{0}%' ".FormatEx2(this.txtSearch.Text);
            }
            this.dtGraphics.DefaultView.RowFilter = filter;
        }

        public SearchDialog(GraphicsCollection graphics)
            : this()
        {

            if (graphics != null)
            {
                RichTextBox txt = new RichTextBox();
                foreach (var item in graphics)
                {
                    txt.Rtf = item.Description;
                    if (!item.Name.m_IsEmpty()
                        || !item.Text.m_IsEmpty()
                        || !item.Status.m_IsEmpty()
                        || !txt.Text.m_IsEmpty())
                        dtGraphics.Rows.Add(item.GUID, item.Name, item.Text, item.Status, txt.Text);
                }
            }

            this.gridView.OptionsBehavior.AutoPopulateColumns = false;
            this.gridControl.DataSource = dtGraphics.DefaultView;

            this.gridView.Columns.Clear();
            this.gridView.Columns.AddVisible("Name", "名称");
            this.gridView.Columns.AddVisible("Text", "文本");
            this.gridView.Columns.AddVisible("Status", "状态");
            this.gridView.Columns.AddVisible("Description", "备注");

            this.gridView.BestFitColumns();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataRow obj = this.gridView.GetFocusedDataRow() as DataRow;

            if (obj != null)
            {
                this.SelectedGuid = new Guid(obj["Guid"].ToString());
            }
            else
            {
                this.SelectedGuid = Guid.Empty;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridView.RowCount > 0)
            {
                this.btnOK.PerformClick();
            }
        }
    }
}
