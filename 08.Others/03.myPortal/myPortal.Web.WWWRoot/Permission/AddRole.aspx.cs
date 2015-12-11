using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myPortal.BLL;
using myPortal.Foundation.Extensions;
using myPortal.Model;
using myPortal.Foundation.Utils;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class AddRole : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }

        protected bool bIsAdministrator = false;

        private void BindData()
        {
            if (this.IsModifyAction)
            {
                int modId = 0;
                int.TryParse(Request["iRoleId"], out modId);
                var role = saRole.Current.GetRole(modId);

                if (role != null)
                {
                    bIsAdministrator = role.bIsAdministrator;

                    if (role.bIsAdministrator)
                    {
                        this.cbxIsActive.Enabled = false;
                    }

                    txtRoleName.Text = role.sName.ToStringEx();
                    txtSort.Text = role.iSort.ToStringEx();
                    txtDes.Text = role.sRemark.ToStringEx();
                    this.cbxIsActive.Checked = !role.IsActive;
                }
                else
                {
                    Response.Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('{0}');location.href='RoleManage.aspx';</script>".FormatEx("数据不存在，可能已被删除！"));

                }
            }
        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                string permissions = Request["cb_permission"];

                if (permissions.IsNullOrWhiteSpace())
                    permissions = string.Empty;

                var role = new saRoleInfo();
                role.sName = txtRoleName.Text.Trim();
                role.iSort = int.Parse(txtSort.Text.Trim());
                role.sRemark = txtDes.Text.Trim();
                role.IsActive = !this.cbxIsActive.Checked;

                int iRoleId = 0;
                int.TryParse(Request["iRoleId"], out iRoleId);

                if (this.IsModifyAction)
                {
                    role.iIden = iRoleId;
                    saRole.Current.UpdateRole(role, permissions);

                    Response.Clear();

                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                       "<script type=\"text/javascript\">alert('{0}');location.href='RoleManage.aspx';</script>".FormatEx("修改成功！"));

                }
                else
                {
                    role.iIden = IdenGenerator.Current.NewIden(saRoleInfo.sTableName);

                    saRole.Current.CreateRole(role, permissions);

                    Response.Clear();

                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                          "<script type=\"text/javascript\">alert('{0}');location.href='RoleManage.aspx';</script>".FormatEx("添加成功！"));



                }
                txtId.Value = string.Empty;
            }
        }

        private bool CheckInput()
        {
            hasError = false;

            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                hasError = true;
                this.errorMsg = "请输入角色名称";
                this.txtRoleName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSort.Text))
            {
                hasError = true;
                this.errorMsg = "请输入排序。";
                this.txtSort.Focus();
                return false;
            }

            return true;
        }

        protected string BuildPermissionTree(string eleId)
        {
            string ret = HtmlRender.BuildCheckablePermissionTree(eleId);

            if (this.IsModifyAction)
            {
                int modId = 0;
                int.TryParse(Request["iRoleId"], out modId);
                var list = saRole.Current.GetMenuByRoleId(modId);
                foreach (var item in list)
                {
                    ret = ret.Replace(string.Format("value=\"{0}\"", item.iIden),
                        string.Format("checked=\"checked\"  value=\"{0}\"", item.iIden));
                }
            }
            return ret;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleManage.aspx");
        }
    }
}