using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myPortal.Foundation.Utils;
using myPortal.BLL;
using myPortal.Model;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class UserManage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int page = 0;
                int.TryParse(Request["p"], out page);
                this.BindingPage(page);
            }
        }

        protected void MyPageControl_PageChanged(object sender, EventArgs e)
        {
            BindingPage(this.MyPageControl.CurrentPage);
        }

        private void BindingPage(int pageIndex)
        {
            QueryUserParams param = new QueryUserParams();
            if (pageIndex == 0) pageIndex++;
            param.PageControl.PageIndex = pageIndex;

            param.sUserNo = this.txtUserNo.Text.Trim();
            param.sUserName = this.txtUserName.Text.Trim();

            var list = saUser.Current.GetPageList(param);
            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();

            this.MyPageControl.TotalPages = param.PageControl.TotalPageCount;
            this.MyPageControl.TotalRows = param.PageControl.TotalRecordCount;
            this.MyPageControl.CurrentPage = pageIndex;
            this.MyPageControl.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_id"]))
            {
                string[] ids = Request["cb_id"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (ids.Length >= 1)
                    {
                        string message = string.Empty;
                        foreach (var item in ids)
                        {
                            var user = saUser.Current.GetUser(Convert.ToInt32(item));
                            if (user.bIsSystem)
                            {
                                message += user.sUserName + ",";
                            }
                        }
                        if (message.Length > 0) message = message.Substring(0, message.Length - 1);
                        saUser.Current.DeleteUser(ids);

                        Response.Clear();
                        if (message.Length > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                                "<script type=\"text/javascript\">alert('{0}');location.href='UserManage.aspx';</script>".FormatEx((string.IsNullOrWhiteSpace(message) ? string.Empty : "用户 " + message + "为系数内置用户,不能禁用.")));
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                                "<script type=\"text/javascript\">alert('{0}');location.href='UserManage.aspx';</script>".FormatEx(Resources.GlobalResources.DisabledSuccess + (string.IsNullOrWhiteSpace(message) ? string.Empty : "用户 " + message + "为系数内置用户,不能禁用.")));
                        }
                    }

                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                }


            }
        }

        protected void bntQuery_Click(object sender, EventArgs e)
        {
            BindingPage(1);
        }
    }
}