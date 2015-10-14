using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScheduleQueryPortal.Foundation;

namespace ScheduleQueryPortal
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dt = QueryHelper.GetScheduleQuery();
                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_bid"]))
            {
                string[] ids = Request["cb_bid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    QueryHelper.DeleteScheduleQuery(ids);

                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                       string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>", "删除成功!", "Default.aspx"));
                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                }
            }
        }
    }
}