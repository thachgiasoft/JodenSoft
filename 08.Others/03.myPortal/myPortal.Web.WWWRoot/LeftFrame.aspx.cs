using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myPortal.Web.WWWRoot
{
    public partial class LeftFrame : PageBase
    {
        protected string SystemTitle = string.Empty;

        protected int frameWinHeight;
        protected void Page_Load(object sender, EventArgs e)
        {
            SystemTitle = "myPortal";
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
                frameWinHeight = winHeight - 148;
            }
            else
            {
                frameWinHeight = winHeight - 135;
            }
        }
    }
}