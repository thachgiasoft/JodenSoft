using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using myPortal.Web;

namespace myPortal.Web.WWWRoot
{
    public partial class MainFrame : PageBase
    {
        protected int frameWinHeight;
        protected string workNo;
        protected string autoLogin = "no";
        protected string ctiSubAddr = "nt/";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.workNo = base.sUserNo;

            this.CaculateWindowHeight();
        }

        public void CaculateWindowHeight()
        {
            int winHeight = 584;
            int ieVersion = 8;

            if (!string.IsNullOrEmpty(Request["wh"]))
            {
                int.TryParse(Request["wh"], out winHeight);
            }

            if (!string.IsNullOrEmpty(Request["iv"]))
            {
                int.TryParse(Request["iv"], out ieVersion);
            }

            if (ieVersion == 6)
            {
                frameWinHeight = winHeight - 140;
            }
            else
            {
                frameWinHeight = winHeight - 139;
            }

            Session["WorkspaceHeight"] = frameWinHeight;
        }
    }
}