using System;
using System.Web;

namespace myPortal.Foundation.Utils
{
    public class MessageBox
    {
        private MessageBox() { }

        public static void Show(string strMsg)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');</script>");
        }

        public static void Show(System.Web.UI.Page page, string strMsg)
        {
            page.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');</script>");
        }

        public static void Show(string strMsg, string Url)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');window.location.href ='" + Url + "'</script>");
        }

        public static void Show(System.Web.UI.Page page, string strMsg, string Url)
        {
            page.Response.Write("<Script Language='JavaScript'>window.alert('" + strMsg + "');window.location.href ='" + Url + "'</script>");
        }

        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'> if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                              "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }
    }
}
