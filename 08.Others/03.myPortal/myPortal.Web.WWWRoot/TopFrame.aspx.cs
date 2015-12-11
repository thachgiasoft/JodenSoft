using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myPortal.Web.WWWRoot
{
    public partial class TopFrame : PageBase
    {
        protected string Menus = string.Empty;
        protected string deptName;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Menus = HtmlRender.GetMenus(iUserID);

        }
    }
}