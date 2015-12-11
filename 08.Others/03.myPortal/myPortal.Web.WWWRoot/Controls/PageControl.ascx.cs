using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myPortal.Web.WWWRoot.Controls
{
    public partial class PageControl : System.Web.UI.UserControl
    {
        public event EventHandler PageChanged;//单击事件

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRows
        {
            get
            {
                if (ViewState["TotalRows"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState["TotalRows"];
                }
            }
            set { ViewState["TotalRows"] = value; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (ViewState["TotalPages"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)ViewState["TotalPages"];
                }
            }
            set { ViewState["TotalPages"] = value; }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 1;
                }
                else
                {
                    return (int)ViewState["CurrentPage"];
                }
            }
            set { ViewState["CurrentPage"] = value; }
        }

        /// <summary>
        /// 绑定数据显示
        /// </summary>
        public override void DataBind()
        {
            this.lblTotalPages.Text = this.TotalPages.ToString();
            this.lblTotalRows.Text = this.TotalRows.ToString();
            this.lblCurrentPage.Text = this.CurrentPage.ToString();

            if (this.CurrentPage <= 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
            else
            {
                this.btnFirst.Enabled = true;
                this.btnPrevious.Enabled = true;
            }

            if (this.CurrentPage >= this.TotalPages)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            else
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
        }
        /// <summary>
        /// 执行 PageChanged 事件
        /// </summary>
        private void OnPageChanged()
        {
            if (this.PageChanged != null)
            {
                this.PageChanged(null, null);
            }
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFirst_Click(object sender, ImageClickEventArgs e)
        {
            this.CurrentPage = 1;
            this.DataBind();
            OnPageChanged();
        }
        /// <summary>
        /// 前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrevious_Click(object sender, ImageClickEventArgs e)
        {
            if (this.CurrentPage > 1)
            {
                this.CurrentPage -= 1;
            }
            this.DataBind();
            OnPageChanged();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNext_Click(object sender, ImageClickEventArgs e)
        {
            if (this.CurrentPage < this.TotalPages)
            {
                this.CurrentPage += 1;
            }
            this.DataBind();
            OnPageChanged();
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLast_Click(object sender, ImageClickEventArgs e)
        {
            this.CurrentPage = this.TotalPages;
            this.DataBind();
            OnPageChanged();
        }
        /// <summary>
        /// 跳转页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGoto_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtGotoPageNumber.Value))
            {
                int GotoPageNumber = Convert.ToInt32(this.txtGotoPageNumber.Value.Trim());

                if (GotoPageNumber <= this.TotalPages && GotoPageNumber > 0)
                {
                    this.CurrentPage = GotoPageNumber;
                }
                else if (GotoPageNumber <= 0)
                {
                    this.CurrentPage = 1;
                }
                else
                {
                    this.CurrentPage = this.TotalPages;
                }
            }
            this.DataBind();
            OnPageChanged();
            this.txtGotoPageNumber.Value = string.Empty;
        }
    }
}