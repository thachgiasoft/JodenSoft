using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ScheduleQueryPortal.Controls
{
    public partial class PageControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        public int TotalPage { get; set; }
        public int TotalRows { get; set; }
        public int CurrentPage { get; set; }

        /// <summary>
        /// 绑定数据显示
        /// </summary>
        public override void DataBind()
        {
            this.lblTotalPages.Text = this.TotalPage.ToString();
            this.lblTotalRows.Text = this.TotalRows.ToString();
            this.lblCurrentPage.Text = this.CurrentPage.ToString();
        }

    }
}