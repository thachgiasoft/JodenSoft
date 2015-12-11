using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.BLL;
using myPortal.Foundation;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Handlers
{
    public partial class AddUserRoleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var list = saRole.Current.GetAllRole().Where(p=>p.IsActive==true).ToList();
                string sRoleName = Request["sRoleName"];
                if (!sRoleName.IsNullOrWhiteSpace())
                {
                    this.txtRoleName.Text = sRoleName;
                    list = list.Where(p => p.sName.ToLower().Contains(sRoleName.ToLower().Trim())).ToList();
                }
                this.rptRole.DataSource = list;
                this.rptRole.DataBind();
            }
        }
    }
}