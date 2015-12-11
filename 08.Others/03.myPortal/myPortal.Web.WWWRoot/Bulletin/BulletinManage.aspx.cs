using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myPortal.Foundation.Utils;
using myPortal.BLL;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Bulletin
{
    public partial class BulletinManage : PageBase
    {
        private int page = 1;
        protected string pageStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtDateStart.Value = DbServer.Current.ServerDateTime.AddMonths(-1).ToString("yyyy-MM-dd");
                this.txtDateEnd.Value = DbServer.Current.ServerDateTime.ToString("yyyy-MM-dd");
                BindData(true);
            }
            else if (Request.RequestType.ToUpper().Equals("POST"))
            {
                btnDelete_Click(null, null);
            }
        }

        private void BindData(bool isQuery)
        {
            int.TryParse(Request["p"], out page);

            if (isQuery)
            {
                DateTime dt = Convert.ToDateTime(this.txtDateEnd.Value.ToString()).AddDays(1);
                var list1 = saBulletin.Current.GetAll( this.txtDateStart.Value.ToString(), dt.ToString("yyyy-MM-dd"), this.txtQuery.Value.Trim().ToLower().ToString());
                this.gridBulletin.DataSource = list1;
            }
            else
            {
                var list = saBulletin.Current.GetAllBulletins();
                this.gridBulletin.DataSource = list;
            }
            this.gridBulletin.DataBind();
            int totalPage = this.gridBulletin.PageCount;

            if (page > totalPage || page < 1)
                page = 1;

            this.gridBulletin.CurrentPageIndex = page - 1;
            this.gridBulletin.DataBind();

            if (totalPage > 1)
                pageStr = CommMethods.GetPageNumbers(page, totalPage, "BulletinManage.aspx", 10, "p"); ;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_bid"]))
            {
                string[] ids = Request["cb_bid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    saBulletin.Current.DeleteBulletins(ids);
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>".FormatEx(Resources.GlobalResources.DeletedSuccess, "BulletinManage.aspx"));
                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.BindData(true);
        }
    }
}