using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using SAF.Foundation;

namespace SAF.Framework.Controls
{
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public partial class PageControl : BaseUserControl
    {

        public bool IsSimpleMode { get; set; }

        public PageControl()
        {
            InitializeComponent();

            IsSimpleMode = false;

            this.txtGotoPageIndex.EditValue = null;

            SetButtonState();
        }

        private int _TotalPageCount = 0;
        public int TotalPageCount
        {
            get { return _TotalPageCount <= 0 ? 0 : _TotalPageCount; }
            set
            {
                _TotalPageCount = value;
                SetButtonState();
            }
        }

        private int _TotalRecordCount = 0;
        public int TotalRecordCount
        {
            get { return _TotalRecordCount <= 0 ? 0 : _TotalRecordCount; }
            set { _TotalRecordCount = value; SetButtonState(); }
        }

        private int _CurrentPageIndex = 0;
        public int CurrentPageIndex
        {
            get { return _CurrentPageIndex <= 0 ? 1 : _CurrentPageIndex; }
            set { _CurrentPageIndex = value; SetButtonState(); }
        }

        public event EventHandler PageIndexChanged;

        private void FirePageIndexChanged()
        {
            var handler = PageIndexChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void SetButtonState()
        {
            this.btnFirstPage.Enabled = this.TotalPageCount > 1 && this.CurrentPageIndex > 1;
            this.btnPrevPage.Enabled = this.TotalPageCount > 1 && this.CurrentPageIndex > 1;
            this.btnNext.Enabled = this.TotalPageCount > 1 && this.CurrentPageIndex < this.TotalPageCount;
            this.btnLastPage.Enabled = this.TotalPageCount > 1 && this.CurrentPageIndex < this.TotalPageCount;
            this.btnGoto.Enabled = this.TotalPageCount > 1;

            if (this.IsSimpleMode)
                this.lblMessage.Text = string.Format("当前第 {0} 页 / 共 {1} 页", this.CurrentPageIndex, this.TotalPageCount);
            else
                this.lblMessage.Text = string.Format("当前第 {2} 页 / 共 {0} 页  {1} 条数据", this.TotalPageCount, this.TotalRecordCount, this.CurrentPageIndex);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            FirePageIndexChanged();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex -= 1;
            }
            FirePageIndexChanged();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPageCount)
            {
                this.CurrentPageIndex += 1;
            }
            FirePageIndexChanged();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = this.TotalPageCount;
            FirePageIndexChanged();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            if (this.txtGotoPageIndex.EditValue != null)
            {
                int GotoPageNumber = Convert.ToInt32(this.txtGotoPageIndex.EditValue);
                if (GotoPageNumber <= 0) GotoPageNumber = 1;
                if (GotoPageNumber > this.TotalPageCount) GotoPageNumber = this.TotalPageCount;

                this.CurrentPageIndex = GotoPageNumber;
                FirePageIndexChanged();
                this.txtGotoPageIndex.EditValue = null;
            }
            else
            {
                MessageService.ShowError("请输入要跳转的页号.");
                this.txtGotoPageIndex.Focus();
            }
        }

        private Dictionary<string, object> queryArgs = new Dictionary<string, object>();
        public void SaveQueryArgs(string key, object value)
        {
            if (key.IsEmpty())
                throw new ArgumentNullException("Key");
            if (queryArgs.ContainsKey(key))
            {
                queryArgs[key] = value;
            }
            else
            {
                queryArgs.Add(key, value);
            }
        }
        public object GetQueryArgs(string key)
        {
            if (key.IsEmpty())
                throw new ArgumentNullException("Key");
            if (queryArgs.ContainsKey(key))
            {
                return queryArgs[key];
            }
            return null;
        }
        public void ClearQueryArgs()
        {
            this.queryArgs.Clear();
        }

    }
}
