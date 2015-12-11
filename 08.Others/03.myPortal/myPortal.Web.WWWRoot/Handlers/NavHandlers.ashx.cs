using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myPortal.Foundation;

namespace myPortal.Web.WWWRoot.Handlers
{
    /// <summary>
    /// NavHandlers 的摘要说明
    /// </summary>
    public class NavHandlers : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "text/plain";

            string id = context.Request["mid"];

            int mId = 0;
            if (int.TryParse(id, out mId))
            {
                int uid = 0;
                if (context.User.Identity.IsAuthenticated)
                    uid = int.Parse(context.User.Identity.Name);      

                string ret = HtmlRender.GetNavItemsByModule(mId, uid);

                context.Response.Write(ret);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}