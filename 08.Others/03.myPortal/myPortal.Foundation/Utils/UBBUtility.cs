
//作者:deerchao 
// http://www.unibetter.com/blogs/blogdeerchao/default.aspx 
//在不移除以上(及本条)注释的前提下,任何人可以以任何方式使用此代码. 

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

namespace myPortal.Foundation.Utils
{
    public class UbbDecoder
    {
        private static readonly RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
        /// <summary> 
        /// 解析Ubb代码为Html代码 
        /// </summary> 
        /// <param name="ubb">Ubb代码</param> 
        /// <returns>解析得到的Html代码</returns> 
        public static string Decode(string ubb)
        {
            if (string.IsNullOrEmpty(ubb))
                return null;
            string result = ubb;
            result = HttpUtility.HtmlEncode(result);
            result = DecodeStyle(result);
            result = DecodeFont(result);
            result = DecodeColor(result);
            result = DecodeImage(result);
            result = DecodeLinks(result);
            result = DecodeQuote(result);
            result = DecodeAlign(result);
            result = DecodeList(result);
            result = DecodeHeading(result);
            result = DecodeBlank(result);
            return result;
        }
        /// <summary> 
        /// 解析Ubb代码为Html代码,所有的链接为rel="nofollow" 
        /// </summary> 
        /// <param name="ubb">Ubb代码</param> 
        /// <returns>解析得到的Html代码</returns> 
        public static string DecodeNoFollow(string ubb)
        {
            if (string.IsNullOrEmpty(ubb))
                return null;
            string result = ubb;
            result = HttpUtility.HtmlEncode(result);
            result = DecodeStyle(result);
            result = DecodeFont(result);
            result = DecodeColor(result);
            result = DecodeImage(result);
            result = DecodeLinksNoFollow(result);
            result = DecodeQuote(result);
            result = DecodeAlign(result);
            result = DecodeList(result);
            result = DecodeHeading(result);
            result = DecodeBlank(result);
            return result;
        }
        private static string DecodeHeading(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[h(\d)\](.*?)\[/h\1\]", "<h$1>$2</h$1>", options);
            return result;
        }
        private static string DecodeList(string ubb)
        {
            string sListFormat = "<ol style=\"list-style:{0};\">$1</ol>";
            string result = ubb;
            // Lists 
            result = Regex.Replace(result, @"\[\*\]([^\[]*)", "<li>$1</li>", options);
            result = Regex.Replace(result, @"\[list\]\s*(.*?)\[/list\]", "<ul>$1</ul>", options);
            result = Regex.Replace(result, @"\[list=1\]\s*(.*?)\[/list\]", string.Format(sListFormat, "decimal"), options);
            result = Regex.Replace(result, @"\[list=i\]\s*(.*?)\[/list\]", string.Format(sListFormat, "lower-roman"), options);
            result = Regex.Replace(result, @"\[list=I\]\s*(.*?)\[/list\]", string.Format(sListFormat, "upper-roman"), options);
            result = Regex.Replace(result, @"\[list=a\]\s*(.*?)\[/list\]", string.Format(sListFormat, "lower-alpha"), options);
            result = Regex.Replace(result, @"\[list=A\]\s*(.*?)\[/list\]", string.Format(sListFormat, "upper-alpha"), options);
            return result;
        }
        private static string DecodeBlank(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"(?<= ) | (?= )", " ", options);
            result = Regex.Replace(result, @"\r\n", "<br />");
            string[] blockTags = { "h[1-6]", "li", "list", "div", "p", "ul" };
            //clear br before block tags(start or end) 
            foreach (string tag in blockTags)
            {
                Regex r = new Regex("<br />(<" + tag + ")", options);
                result = r.Replace(result, "$1");
                r = new Regex("<br />(</" + tag + ")", options);
                result = r.Replace(result, "$1");
            }
            return result;
        }
        private static string DecodeAlign(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[left\](.*?)\[/left\]", "<div style=\"text-align:left\">$1</div>", options);
            result = Regex.Replace(result, @"\[right\](.*?)\[/right\]", "<div style=\"text-align:right\">$1</div>", options);
            result = Regex.Replace(result, @"\[center\](.*?)\[/center\]", "<div style=\"text-align:center\">$1</div>", options);
            return result;
        }
        private static string DecodeQuote(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[quote\]", "<blockquote><div>", options);
            result = Regex.Replace(result, @"\[/quote\]", "</div></blockquote>", options);
            return result;
        }
        private static string DecodeFont(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[size=([-\w]+)\](.*?)\[/size\]", "<span style=\"font-size:$1\">$2</span>", options);
            result = Regex.Replace(result, @"\[font=(.*?)\](.*?)\[/font\]", "<span style=\"font-family:$1\">$2</span>", options);
            return result;
        }
        private static string DecodeLinks(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[url\]www\.(.*?)\[/url\]", "<a href=\"http://www.$1\">$1</a>", options);
            result = Regex.Replace(result, @"\[url\](.*?)\[/url\]", "<a href=\"$1\">$1</a>", options);
            result = Regex.Replace(result, @"\[url=(.*?)\](.*?)\[/url\]", "<a href=\"$1\" title=\"$2\">$2</a>", options);
            result = Regex.Replace(result, @"\[email\](.*?)\[/email\]", "<a href=\"mailto:$1\">$1</a>", options);
            return result;
        }
        private static string DecodeLinksNoFollow(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[url\]www\.(.*?)\[/url\]", "<a rel=\"nofollow\" href=\"http://www.$1\">$1</a>", options);
            result = Regex.Replace(result, @"\[url\](.*?)\[/url\]", "<a rel=\"nofollow\" href=\"$1\">$1</a>", options);
            result = Regex.Replace(result, @"\[url=(.*?)\](.*?)\[/url\]", "<a rel=\"nofollow\" href=\"$1\" title=\"$2\">$2</a>", options);
            result = Regex.Replace(result, @"\[email\](.*?)\[/email\]", "<a href=\"mailto:$1\">$1</a>", options);
            return result;
        }
        private static string DecodeImage(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[hr\]", "<hr />", options);
            result = Regex.Replace(result, @"\[img\](.+?)\[/img\]", "<img src=\"$1\" alt=\"\" />", options);
            result = Regex.Replace(result, @"\[img=(\d+)x(\d+)\](.+?)\[/img\]", "<img src=\"$3\" style=\"width:$1px;height:$2px\" alt=\"\" />", options);
            return result;
        }
        private static string DecodeColor(string ubb)
        {
            string result = ubb;
            result = Regex.Replace(result, @"\[color=(#?\w+?)\](.+?)\[/color\]", "<span style=\"color:$1\">$2</span>", options);
            return result;
        }
        private static string DecodeStyle(string ubb)
        {
            string result = ubb;
            //we don't need this for perfomance and other consideration: 
            //(<table[^>]*>(?><table[^>]*>(?<Depth>)|</table>(?<-Depth>)|.)+(?(Depth)(?!))</table>) 
            result = Regex.Replace(result, @"\[[b]\](.*?)\[/[b]\]", "<strong>$1</strong>", options);
            result = Regex.Replace(result, @"\[[u]\](.*?)\[/[u]\]", "<span style=\"text-decoration:underline\">$1</span>", options);
            result = Regex.Replace(result, @"\[[i]\](.*?)\[/[i]\]", "<i>$1</i>", options);
            return result;
        }
    }
}
