using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Controls
{
    [UserRepositoryItem("RegisterGridSearchEdit")]
    public class RepositoryItemGridSearchEdit : RepositoryItemPopupContainerEdit
    {
        public const string GridSearchEditName = "GridSearchEdit";
        public override string EditorTypeName
        {
            get
            {
                return GridSearchEditName;
            }
        }

        public new GridSearchEdit OwnerEdit { get { return base.OwnerEdit as GridSearchEdit; } }

        static RepositoryItemGridSearchEdit()
        {
            RegisterGridSearchEdit();
        }

        public static void RegisterGridSearchEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(GridSearchEditName,
             typeof(GridSearchEdit), typeof(RepositoryItemGridSearchEdit),
             typeof(DevExpress.XtraEditors.ViewInfo.GridLookUpEditBaseViewInfo), new ButtonEditPainter(), true));
        }

        [Browsable(false)]
        public override TextEditStyles TextEditStyle
        {
            get { return base.TextEditStyle; }
            set { base.TextEditStyle = TextEditStyles.DisableTextEditor; }
        }

        private PopupContainerControl _PopupControl;
        private GridSearchEditSearchControl _SearchControl;

        public RepositoryItemGridSearchEdit()
        {
            this.PopupFormMinSize = new Size(420, 380);
            this.ShowPopupCloseButton = false;
            this.AutoClearSearchFiledsValue = true;

            _PopupControl = new PopupContainerControl();
            _PopupControl.Resize += _PopupControl_Resize;

            _SearchControl = new GridSearchEditSearchControl(this);
            _PopupControl.Controls.Add(_SearchControl);
            _SearchControl.Dock = DockStyle.Fill;

            this.QueryResultValue += RepositoryItemGridSearchEdit_QueryResultValue;
            this.QueryPopUp += RepositoryItemGridSearchEdit_QueryPopUp;

            this.PopupControl = _PopupControl;

            this.ButtonClick += RepositoryItemGridSearchEdit_ButtonClick;

        }

        internal int PopupWidth = 420;
        internal int PopupHeight = 380;

        void _PopupControl_Resize(object sender, EventArgs e)
        {
            PopupWidth = Math.Max(420, ((PopupContainerControl)sender).Width);
            PopupHeight = Math.Max(380, ((PopupContainerControl)sender).Height);
        }

        void RepositoryItemGridSearchEdit_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (this.AutoClearSearchFiledsValue)
                _SearchControl.ClearSearchFiledsValue();
        }

        void RepositoryItemGridSearchEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                if (MessageBox.Show("确定要清空值吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                ((GridSearchEdit)sender).EditValue = null;
                ClearAutoSetFields();
            }
        }

        public void Query()
        {
            _SearchControl.QueryData();
        }

        public TEntity GetSelectedEntity<TEntity>() where TEntity : Entity<TEntity>, new()
        {
            return this._SearchControl.GetSelectedEntity<TEntity>();
        }
        
        public bool ShowPageControl
        {
            get { return _SearchControl.ShowPageControl; }
            set { _SearchControl.ShowPageControl = value; }
        }

        private void ClearAutoSetFields()
        {
            _SearchControl.AutoSetFiels(true);
        }

        void RepositoryItemGridSearchEdit_QueryResultValue(object sender, QueryResultValueEventArgs e)
        {
            if (this.DisplayMember.IsEmpty())
                throw new Exception("请设置DisplayMember.");

            if (!_SearchControl.FieldIsExists(DisplayMember))
                throw new Exception("DisplayMember\"{0}\"不存在.".FormatWith(DisplayMember));

            var obj = _SearchControl.GetSelectedValue(this.DisplayMember);
            if (obj != null)
                e.Value = obj;
            else
                e.Value = null;

            _SearchControl.AutoSetFiels(false);
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            EditorButton clearButton = new EditorButton(ButtonPredefines.Delete);
            clearButton.IsDefaultButton = true;
            Buttons.Add(clearButton);
        }

        private string _ConnectionName = string.Empty;
        public string ConnectionName
        {
            get { return string.IsNullOrWhiteSpace(_ConnectionName) ? ConfigContext.DefaultConnection : _ConnectionName; }
            set { _ConnectionName = value; }
        }

        public string CommandText { get; set; }

        private IList<object> _Parameters = new List<object>();
        public IList<object> Parameters { get { return _Parameters; } }

        private int _PageSize = ConfigContext.DefaultPageSize;
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value <= 0 ? ConfigContext.DefaultPageSize : value; }
        }

        private string _SearchFileds = string.Empty;
        /// <summary>
        /// 查询字段(如:名称=a.Name,文件名=b.FileName)
        /// </summary>
        public string SearchFileds
        {
            get { return _SearchFileds; }
            set
            {
                _SearchFileds = value;
                this._SearchControl.CreateSearchFileds();
            }
        }
        /// <summary>
        /// 列标题
        /// </summary>
        public string ColumnHeaders { get; set; }

        /// <summary>
        /// 自动填充的字段,格式:目标字段名=源字段名;目标字段名=源字段名;
        /// </summary>
        public string AutoFillFieldNames { get; set; }
        /// <summary>
        /// 自动填充数据集
        /// </summary>
        public IEntitySetBase AutoFillEntitySet { get; set; }

        public string DisplayMember { get; set; }

        /// <summary>
        /// 每次弹出时是否清空查询字段的值,默认是true
        /// </summary>
        public bool AutoClearSearchFiledsValue { get; set; }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemGridSearchEdit source = item as RepositoryItemGridSearchEdit;
                if (source == null) return;

                this.ShowPageControl = source.ShowPageControl;
                this.ConnectionName = source.ConnectionName;
                this.CommandText = source.CommandText;

                foreach (var obj in source.Parameters)
                {
                    this.Parameters.Add(obj);
                }

                this.PageSize = source.PageSize;
                this.SearchFileds = source.SearchFileds;
                this.ColumnHeaders = source.ColumnHeaders;
                this.AutoFillFieldNames = source.AutoFillFieldNames;
                this.AutoFillEntitySet = source.AutoFillEntitySet;
                this.DisplayMember = source.DisplayMember;
                this.AutoClearSearchFiledsValue = source.AutoClearSearchFiledsValue;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}
