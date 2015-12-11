using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using myPortal.BLL.Permission;
using myPortal.Model;
using myPortal.Foundation.Extensions;
using myPortal.BLL;
using System.Configuration;
using System.Collections.Specialized;
using System.Reflection;
using myPortal.Foundation;

namespace myPortal.Web.WWWRoot
{
    public partial class Default : System.Web.UI.Page
    {
        protected string url = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.Url.Host + Request.ApplicationPath;
            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

        }

        protected void login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int winHeight = 584;
            int ieVersion = 8;

            if (!string.IsNullOrEmpty(Request["txtWinHeight"]))
            {
                int.TryParse(Request["txtWinHeight"], out winHeight);
            }
            if (!string.IsNullOrEmpty(Request["txtIEVersion"]))
            {
                int.TryParse(Request["txtIEVersion"], out ieVersion);
            }

            string userNo = login1.UserName;
            myMembershipProvider provider = Membership.Provider as myMembershipProvider;

            saUserInfo user = provider.GetUser(login1.UserName);
            string iIden = user == null ? string.Empty : user.iIden.ToString();
            if (string.IsNullOrEmpty(iIden))
            {
                e.Authenticated = false;
                lblMsg.Text = "用户名不存在。";
                return;
            }
            //判断用户是否已被禁用
            if (!user.bUsable)
            {
                e.Authenticated = false;
                lblMsg.Text = "用户已被禁用";
                return;
            }

            if (provider.ValidateUser(iIden, login1.Password))
            {
                e.Authenticated = true;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    iIden,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(Membership.UserIsOnlineTimeWindow + 1),
                    false, string.Empty);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie t = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(t);
                FormsAuthentication.SetAuthCookie(iIden, false, FormsAuthentication.FormsCookiePath);

                Response.RedirectPermanent(string.Format("WorkSpace.aspx?wh={0}&iv={1}", winHeight, ieVersion));

            }
            else
            {
                e.Authenticated = false;
                lblMsg.Text = "用户名或密码错误！";
            }
        }

    }
}