using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using myPortal.BLL;
using myPortal.Foundation.Extensions;

namespace myPortal.Web
{
    public class JSONRender
    {
        /// <summary>
        /// json序列化后的要弹窗的新公告
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static string GetNewBulletin()
        {
            var list = saBulletin.Current.GetNewBulletins();
            if (list.Count <= 0)
                return "{\"count\":\"0\"}";
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"count\":\"");
            sb.Append(list.Count.ToString() + "\"");
            sb.Append(",\"items\":[");
            bool isfirst = true;
            foreach (var item in list)
            {
                if (isfirst)
                    isfirst = false;
                else
                    sb.Append(",");
                sb.Append("{\"title\":\"");
                sb.Append(item.sTitle.ToStringEx().Replace("'", "’"));
                sb.Append("\",\"content\":\"");
                sb.Append(item.sContent.ToStringEx().Replace("\r", "").Replace("\n", "<br/>").Replace("'", "’"));
                sb.Append("\"}");
            }
            sb.Append("]}");
            return sb.ToString(); 
        }
    }
}
