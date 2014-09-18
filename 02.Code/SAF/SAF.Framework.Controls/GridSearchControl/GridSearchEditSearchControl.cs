using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAF.EntityFramework;
using SAF.Foundation;
using DevExpress.XtraLayout;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    public partial class GridSearchEditSearchControl : BaseUserControl
    {
        public class QueryEntity : Entity<QueryEntity>
        {
        }

        private EntitySet<QueryEntity> _QueryEntitySet = null;
        protected EntitySet<QueryEntity> QueryEntitySet
        {
            get
            {
                if (_QueryEntitySet == null)
                    _QueryEntitySet = new EntitySet<QueryEntity>(this.OwnerEdit.ConnectionName, null, this.OwnerEdit.PageSize);
                _QueryEntitySet.IsReadOnly = true;
                _QueryEntitySet.PageSize = this.OwnerEdit.PageSize;
                return _QueryEntitySet;
            }
        }

        private GridSearchEditSearchControl()
        {
            InitializeComponent();
        }

        private void ClosePopup()
        {
            if (this.OwnerEdit.OwnerEdit != null)
                OwnerEdit.OwnerEdit.ClosePopup();
        }

        public GridSearchEditSearchControl(RepositoryItemGridSearchEdit ownerEdit)
            : this()
        {
            this._OwnerEdit = ownerEdit;
            this.pageControl1.IsSimpleMode = true;
            this.pageControl1.PageIndexChanged += pageControl1_PageIndexChanged;

            this.grvMain.DoubleClick += grvMain_DoubleClick;
            this.grvMain.KeyDown += grvMain_KeyDown;
        }

        void grvMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                ClosePopup();
            }
        }

        void grvMain_DoubleClick(object sender, EventArgs e)
        {
            ClosePopup();
        }

        void pageControl1_PageIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        private bool _ShowPageControl = true;
        public bool ShowPageControl
        {
            get { return _ShowPageControl; }
            set
            {
                _ShowPageControl = value;
                this.pageControl1.Visible = value;
            }
        }

        public void QueryData()
        {
            string sql = CalcCommandText(this.OwnerEdit.CommandText);
            try
            {
                QueryEntitySet.CurrentPageIndex = this.pageControl1.CurrentPageIndex;

                QueryEntitySet.Query(sql, this.OwnerEdit.Parameters.ToArray());

                InitGridColumns();

                this.pageControl1.TotalPageCount = QueryEntitySet.TotalPageCount;
                this.pageControl1.TotalRecordCount = QueryEntitySet.TotalRecordCount;
            }
            catch
            {
                this.grdMain.DataSource = null;
                this.grvMain.Columns.Clear();

                this.pageControl1.TotalPageCount = 0;
                this.pageControl1.TotalRecordCount = 0;
                this.pageControl1.CurrentPageIndex = 1;

                throw;
            }
        }

        private string CalcCommandText(string commandText)
        {
            StringBuilder result = new StringBuilder();
            string sValue = string.Empty;
            foreach (KeyValuePair<TextEdit, string> item in this.QueryControls)
            {
                if (item.Key.Text.IsEmpty())
                    continue;
                sValue = item.Key.Text.Trim();
                if (result.Length > 0)
                    result.Append(" AND ");
                string sFieldName = item.Value;

                result.Append(QueryControlHelper.GenerateQuickQueryCondition(sFieldName, sValue, QuickQueryType.Combinatorial));
            }
            if (result.Length > 0)
                return commandText.FormatEx(result.ToString());

            return commandText.FormatEx(" (1=1) ");
        }

        private void InitGridColumns()
        {
            this.grdMain.DataSource = null;
            this.grvMain.Columns.Clear();

            this.grvMain.OptionsBehavior.AutoPopulateColumns = false;
            this.grdMain.DataSource = QueryEntitySet.DefaultView;

            string columnHeaders = this.OwnerEdit.ColumnHeaders.IsEmpty() ? string.Empty : this.OwnerEdit.ColumnHeaders.Trim();

            var headers = columnHeaders.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int count = Math.Min(headers.Length, QueryEntitySet.DataTable.Columns.Count - 1);

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var col = grvMain.Columns.Add();
                    col.VisibleIndex = i;
                    col.Caption = headers[i].Trim();
                    col.FieldName = QueryEntitySet.DataTable.Columns[i].ColumnName;
                }
            }
            else
            {
                for (int i = 0; i < QueryEntitySet.DataTable.Columns.Count; i++)
                {
                    if (!QueryEntitySet.DataTable.Columns[i].ColumnName.Equals("ROWSTAT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var col = grvMain.Columns.Add();
                        col.VisibleIndex = i;
                        col.Caption = QueryEntitySet.DataTable.Columns[i].ColumnName;
                        col.FieldName = QueryEntitySet.DataTable.Columns[i].ColumnName;
                    }
                }
            }

            this.grvMain.BestFitColumns();
        }

        private RepositoryItemGridSearchEdit _OwnerEdit;

        public RepositoryItemGridSearchEdit OwnerEdit
        {
            get { return _OwnerEdit; }
        }

        private Dictionary<TextEdit, string> _queryControls;
        public Dictionary<TextEdit, string> QueryControls
        {
            get
            {
                if (_queryControls == null)
                    _queryControls = new Dictionary<TextEdit, string>();
                return _queryControls;
            }
        }

        public void ClearSearchFiledsValue()
        {
            foreach (var item in this.QueryControls)
            {
                item.Key.Text = string.Empty;
            }
        }

        public void CreateSearchFileds()
        {
            var items = this.OwnerEdit.SearchFileds.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(p =>
            {
                string sCaption = p;
                string sFieldName = p;
                if (p.Contains('='))
                {
                    sCaption = p.Before("=");
                    sFieldName = p.After("=");
                }
                return new { sCaption = sCaption.Trim(), sFieldName = sFieldName.Trim() };
            }).ToList();

            if (items.Count % 2 != 0)
            {
                items.Add(new { sCaption = string.Empty, sFieldName = string.Empty });
            }
            int controlCount = items.Count();

            lcMain.Clear(true, true);
            lcMain.BeginUpdate();
            try
            {
                LayoutControlGroup group = new LayoutControlGroup();
                group.GroupBordersVisible = false;
                for (int i = 0; i < controlCount; i = i + 2)
                {
                    group.GroupBordersVisible = false;

                    var dataItem = items[i];
                    //创建内部控件
                    TextEdit textEdit = CreateTextEdit();

                    LayoutControlItem item1 = lcMain.Root.AddItem(dataItem.sCaption, textEdit);
                    item1.Text = string.Format("&{0}.{1}", i + 1, dataItem.sCaption);
                    this.QueryControls.Add(textEdit, dataItem.sFieldName);

                    dataItem = items[i + 1];
                    if (dataItem.sCaption.IsEmpty())
                    {
                        LayoutControlItem item2 = new EmptySpaceItem(group);
                        item2.Move(item1, DevExpress.XtraLayout.Utils.InsertType.Right);
                    }
                    else
                    {
                        textEdit = CreateTextEdit();
                        LayoutControlItem item2 = new LayoutControlItem(lcMain, textEdit);
                        item2.Text = string.Format("&{0}.{1}", i + 2, dataItem.sCaption);
                        item2.Move(item1, DevExpress.XtraLayout.Utils.InsertType.Right);

                        this.QueryControls.Add(textEdit, dataItem.sFieldName);
                    }
                }
                lcMain.Root.Add(group);
            }
            finally
            {
                lcMain.EndUpdate();

                if (controlCount > 0)
                {
                    this.splitContainerControl1.SplitterPosition = controlCount / 2 * 24 + 30;
                }
                else
                {
                    this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                }
            }

        }

        private TextEdit CreateTextEdit()
        {
            var edit = new TextEdit();
            edit.KeyDown += edit_KeyDown;
            return edit;
        }

        void edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QueryData();
                this.grdMain.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (!this.grdMain.Focused)
                {
                    this.grdMain.Focus();
                }
            }
        }

        public bool FieldIsExists(string fieldName)
        {
            var obj = this.grvMain.GetFocusedRow();

            if (obj == null) return false;

            var drv = obj as DataRowView;
            if (drv != null)
            {
                return drv.Row.Table.Columns.Contains(fieldName);
            }
            else
            {
                var list = obj.GetType().GetProperties();
                return list.Any(p => p.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public object GetSelectValue(string fieldName)
        {
            if (fieldName.IsEmpty())
                throw new Exception("字段名不能为空.");

            var obj = this.grvMain.GetFocusedRow();
            if (obj == null) return null;

            if (!FieldIsExists(fieldName))
                throw new Exception("字段\"{0}\"不存在.".FormatEx(fieldName));

            var drv = obj as DataRowView;
            if (drv != null)
            {
                return drv[fieldName];
            }
            else
            {
                var type = obj.GetType();
                var propertyInfo = type.GetProperty(fieldName, System.Reflection.BindingFlags.IgnoreCase);
                if (propertyInfo != null)
                    return propertyInfo.GetValue(obj, null);
                return null;
            }
        }

        public void AutoSetFiels(bool clearValue)
        {
            var autoFillEntitySet = this.OwnerEdit.AutoFillEntitySet;
            var autoFillFieldNames = this.OwnerEdit.AutoFillFieldNames;

            if (autoFillEntitySet != null && autoFillEntitySet.CurrentEntity != null && !string.IsNullOrWhiteSpace(autoFillFieldNames))
            {
                var currentEntity = autoFillEntitySet.CurrentEntity;
                var list = autoFillFieldNames.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in list)
                {
                    var fields = item.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    if (fields.Length == 2 && !string.IsNullOrWhiteSpace(fields[0]) && !string.IsNullOrWhiteSpace(fields[1]))
                    {
                        if (currentEntity.FieldIsExists(fields[0].Trim()) && FieldIsExists(fields[1].Trim()))
                        {
                            if (clearValue)
                            {
                                currentEntity.SetFieldValue(fields[0].Trim(), null);
                            }
                            else
                            {
                                currentEntity.SetFieldValue(fields[0].Trim(), GetSelectValue(fields[1].Trim()));
                            }
                        }
                    }
                }
            }
        }
    }


}
