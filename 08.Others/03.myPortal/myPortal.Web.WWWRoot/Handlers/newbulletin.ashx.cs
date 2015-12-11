using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPortal.Web.WWWRoot.Handlers
{
    /// <summary>
    /// newbulletin1 的摘要说明
    /// </summary>
    public class newbulletin : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "text/plain";
            string s = JSONRender.GetNewBulletin();
            context.Response.Write(s);
            context.Response.End();
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