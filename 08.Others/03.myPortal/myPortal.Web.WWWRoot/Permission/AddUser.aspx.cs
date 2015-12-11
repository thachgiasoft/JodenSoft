using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.BLL;
using myPortal.BLL.Permission;
using myPortal.Foundation.Extensions;
using myPortal.Model;
using myPortal.Foundation.Utils;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class AddUser : PageBase
    {
        protected int iUserId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected bool bIsSystemUser = false;

        private void BindData()
        {
            if (this.IsModifyAction)
            {
                int.TryParse(Request["iUserId"], out iUserId);
                saUserInfo u = ((myMembershipProvider)Membership.Provider).GetUser(iUserId) as saUserInfo;
                if (u != null)
                {
                    bIsSystemUser = u.bIsSystem;

                    txtUserName.Text = u.sUserName;
                    txtUserNo.Text = u.sUserNo;
                    txtEmail.Text = u.sEmail.ToStringEx();
                    cbxUsable.Checked = !u.bUsable;
                    txtRemark.Text = u.sRemark;
                    repOrgRoles.DataSource = u.UserOrgRole;
                    repOrgRoles.DataBind();

                    if (u.bIsSystem)
                    {
                        this.cbxUsable.Enabled = false;
                    }
                }
                else
                {
                    Response.Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('{0}');location.href='UserManage.aspx';</script>".FormatEx(Resources.GlobalResources.DoesNotExistItMayHaveBeenDeleted));
                }
            }
            else
            {
                iUserId = -1;
            }

        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                myMembershipProvider provider = Membership.Provider as myMembershipProvider;
                try
                {
                    saUserInfo user = new saUserInfo();
                    user.sUserNo = txtUserNo.Text.Trim();
                    user.sUserName = txtUserName.Text.Trim();
                    user.sPassword = txtUserNo.Text.Trim();
                    user.sEmail = txtEmail.Text.Trim();
                    user.sRemark = txtRemark.Text.Trim();

                    user.bUsable = !cbxUsable.Checked;

                    if (!this.txtRoles.Value.IsNullOrWhiteSpace())
                    {
                        string[] roles = this.txtRoles.Value.Split(',');

                        for (int i = 0; i < roles.Length; i++)
                        {
                            var a = user.UserOrgRole.FirstOrDefault(p =>
                                p.iUserId == user.iIden
                                && p.iRoleId == int.Parse(roles[i]));
                            if (a == null)
                            {
                                saUserRoleInfo uor = new saUserRoleInfo();
                                uor.iIden = IdenGenerator.Current.NewIden(saUserRoleInfo.sTableName);
                                uor.iRoleId = int.Parse(roles[i]);
                                user.UserOrgRole.Add(uor);
                            }
                        }
                    }

                    if (this.IsModifyAction)
                    {
                        int.TryParse(Request["iUserId"], out iUserId);
                        user.iIden = iUserId;
                        user.UserOrgRole.ToList().ForEach(p => p.iUserId = iUserId);
                        provider.UpdateUser(user);
                        Response.Clear();

                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                                                      "<script type=\"text/javascript\">alert('{0}');location.href='UserManage.aspx';</script>".FormatEx(Resources.GlobalResources.ModifiedSuccess));


                    }
                    else
                    {
                        MembershipCreateStatus status;
                        int iUserId = IdenGenerator.Current.NewIden(saUserInfo.sTableName);
                        user.iIden = iUserId;
                        user.UserOrgRole.ToList().ForEach(p => p.iUserId = iUserId);
                        saUserInfo nuser = provider.CreateUser(user, out status) as saUserInfo;
                        if (nuser == null)
                        {
                            hasError = true;
                            switch (status)
                            {
                                case MembershipCreateStatus.DuplicateUserName:
                                    errorMsg = "用户ID已经存在";
                                    break;
                                case MembershipCreateStatus.InvalidPassword:
                                    errorMsg = "密码的格式设置不正确";
                                    break;
                                default:
                                    errorMsg = "未知错误!";
                                    break;
                            }

                            return;
                        }
                        Response.Clear();

                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                           "<script type=\"text/javascript\">alert('{0}');location.href='UserManage.aspx';</script>".FormatEx(Resources.GlobalResources.AddedSuccess));


                    }
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMsg = ex.Message;
                }
            }
        }

        private bool CheckInput()
        {
            hasError = false;

            if (string.IsNullOrEmpty(txtUserNo.Text))
            {
                hasError = true;
                errorMsg = "用户名不能为空。";
                return false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                hasError = true;
                errorMsg = "用户姓名不能为空.";
                return false;
            }

            if (string.IsNullOrEmpty(this.txtEmail.Text))
            {
                hasError = true;
                errorMsg = "用户邮箱不能为空.";
                return false;
            }


            return true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("UserManage.aspx");

        }

    }
}