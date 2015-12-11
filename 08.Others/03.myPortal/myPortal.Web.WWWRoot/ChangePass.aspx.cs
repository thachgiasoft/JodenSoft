using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using myPortal.BLL;
using myPortal.BLL.Permission;

namespace myPortal.Web.WWWRoot
{
    public partial class ChangePass : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            myMembershipProvider provider = Membership.Provider as myMembershipProvider;

            if (CheckInput())
            {
                bool ret = provider.ChangePassword(iUserID.ToString(), txtOrignalPass.Text, txtNewPass.Text);

                if (ret)
                {
                    Response.Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('密码修改成功！');location.href='changePass.aspx?d=';</script>");
                }
                else
                {
                    Response.Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('发生错误，请确认您的原密码是否正确！');location.href='changePass.aspx';</script>");
                }
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtOrignalPass.Text))
                return false;
            if (string.IsNullOrEmpty(txtNewPass.Text))
                return false;
            if (!txtNewPass.Text.Equals(txtRepass.Text))
                return false;

            return true;
        }
    }
}