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
using myPortal.Model;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class RoleManage : PageBase
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


        private void BindingPage(int pageIndex)
        {
            QueryRoleParams param = new QueryRoleParams();
            if (pageIndex == 0) pageIndex++;
            param.PageControl.PageIndex = pageIndex;

            param.sRoleName = this.txtRoleName.Text.Trim();

            var list = saRole.Current.GetPageList(param);
            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();

            this.MyPageControl.TotalPages = param.PageControl.TotalPageCount;
            this.MyPageControl.TotalRows = param.PageControl.TotalRecordCount;
            this.MyPageControl.CurrentPage = pageIndex;
            this.MyPageControl.DataBind();
        }

        protected void MyPageControl_PageChanged(object sender, EventArgs e)
        {
            BindingPage(this.MyPageControl.CurrentPage);
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
                            var role = saRole.Current.GetRole(Convert.ToInt32(item));
                            if (role.bIsAdministrator)
                            {
                                message += role.sName + ",";
                            }
                        }
                        if (message.Length > 0) message = message.Substring(0, message.Length - 1);
                        saRole.Current.DeleteRole(ids);

                        if (message.Length > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                                "<script type=\"text/javascript\">alert('{0}');location.href='RoleManage.aspx';</script>".FormatEx((string.IsNullOrWhiteSpace(message) ? string.Empty : "角色 " + message + "为系数内置角色,不能禁用.")));
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                                                         "<script type=\"text/javascript\">alert('{0}');location.href='RoleManage.aspx';</script>".FormatEx(Resources.GlobalResources.DisabledSuccess + (string.IsNullOrWhiteSpace(message) ? string.Empty : "角色 " + message + "为系数内置角色,不能禁用.")));
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
            this.BindingPage(1);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            this.BindingPage(this.MyPageControl.CurrentPage);
        }
    }
}