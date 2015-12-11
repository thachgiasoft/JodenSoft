using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myPortal.BLL;
using myPortal.Foundation.Utils;
using myPortal.Foundation.Extensions;


namespace myPortal.Web.WWWRoot.Dictionary
{
    public partial class BulletinTypeManage : PageBase
    {
        protected string pageStr = string.Empty;
        private int page = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData(false);
            }
            //else if (Request.RequestType.ToUpper().Equals("POST"))
            //{
            //    this.btnDelete_Click(null, null);
            //}
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_bid"]))
            {
                string[] ids = Request["cb_bid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    saBulletinType.Current.DeleteBulletinType(ids);

                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>".FormatEx("禁用成功!", "BulletinTypeManage.aspx"));
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

        private void BindData(bool isQuery)
        {
            int.TryParse(Request["p"], out page);

            var list = saBulletinType.Current.GetAllBulletinType();
            if (isQuery)
            {
                this.grid.DataSource = list.Where(p => p.sName.ToLower().Contains(this.txtQuery.Value.Trim().ToLower())).ToList();
            }
            else
            {
                this.grid.DataSource = list;
            }
            this.grid.CurrentPageIndex = 0;
            this.grid.DataBind();
            int totalPage = this.grid.PageCount;
            if (page > totalPage || page < 1)
                page = 1;

            this.grid.CurrentPageIndex = page - 1;
            this.grid.DataBind();

            if (totalPage > 1)
                pageStr = CommMethods.GetPageNumbers(page, totalPage, "BulletinTypeManage.aspx", 10, "p"); ;
        }
    }
}