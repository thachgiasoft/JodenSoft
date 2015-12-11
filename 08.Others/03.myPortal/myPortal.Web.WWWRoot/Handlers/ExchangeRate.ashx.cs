using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CttSoft.BLL;
using CttSoft.Foundation.Extensions;
using CttSoft.Cache;
using CttSoft.Model;


namespace CttSoft.Web.WWWRoot.Handlers
{
    /// <summary>
    /// ExchangeRate 的摘要说明
    /// </summary>
    public class ExchangeRate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetNoStore();
            context.Response.ContentType = "text/plain";
            string strValue = string.Empty;
            int SourceCurrency = int.Parse(context.Request["SourceCurrency"]);
            int iTargetCurrency = int.Parse(context.Request["iTargetCurrency"]);
            var info = pbExchangeRate.Current.GetCurrencyExchangeRate(SourceCurrency, iTargetCurrency, GetOrgId(context));
            context.Response.Clear();
            if (info != null)
            {
                context.Response.Write("{" + string.Format("\"rate\":\"{0}\",\"error\":\"0\"", info.dExchangeRate) + "}");
            }
            else
            {
                context.Response.Write("{\"rate\":\"0\",\"error\":\"1\"}");
            }
        }
        private int GetOrgId(HttpContext context)
        {
            HttpCookie t2 = context.Request.Cookies["SERVICE_ORG"];
            if (t2 != null)
            {
                int dep = 0;
                if (int.TryParse(t2.Value, out dep))
                {

                    t2.Expires = DateTime.Now.AddMinutes(System.Web.Security.Membership.UserIsOnlineTimeWindow + 1);
                    context.Response.Cookies.Set(t2);

                    return dep;
                }
            }
            return 0;
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