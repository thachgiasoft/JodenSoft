using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPortal.Web.WWWRoot.Handlers
{
    /// <summary>
    /// BulletinHandler 的摘要说明
    /// </summary>
    public class BulletinHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "text/plain";

            bool withContent = true;

            if (!string.IsNullOrEmpty(context.Request["c"]))
                withContent = false;

            context.Response.Write(GetRuningBulletin(withContent));
        }

        public string GetRuningBulletin(bool withContent)
        {
            return HtmlRender.GetBulletins(withContent);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}