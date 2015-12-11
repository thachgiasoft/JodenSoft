using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Data;
using myPortal.BLL;
using myPortal.Model;
using System.Linq;
using myPortal.Foundation;
using myPortal.Foundation.Extensions;


namespace myPortal.Web
{
    /// <summary>
    /// HTML生成
    /// </summary>
    public class HtmlRender
    {
         
        /// <summary>
        /// 生成Menu的HTML标签
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="iOrganizationId"></param>
        /// <param name="iLanguage"></param>
        /// <returns></returns>
        public static string GetMenus(int userId)
        {
            var list = saMenu.Current.GetMenus(userId).Where(p => p.iLevel == 1).OrderBy(p => p.iSort).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append("<li id=\"man_nav_");
                sb.Append(item.iIden);
                sb.Append("\" onclick=\"list_sub_nav(");
                sb.Append(item.iIden);
                sb.Append(",'");

                    sb.Append(item.sName);//
                
                sb.Append("')\"  class=\"bg_image");
                sb.Append("\">");

                    sb.Append(item.sName);//
                
                sb.Append("</li>");
                sb.AppendLine();
            }
            return sb.ToString();
        }
        /// <summary>
        /// 生成导航菜单的HTML标签
        /// </summary>
        /// <param name="iMenuId"></param>
        /// <param name="iUserId"></param>
        /// <param name="iOrganizationId"></param>
        /// <param name="iLanguage"></param>
        /// <returns></returns>
        public static string GetNavItemsByModule(int iMenuId, int iUserId)
        {
            var menus = saMenu.Current.GetMenus(iUserId);
            StringBuilder sb = new StringBuilder();

            var navs = menus.Where(p => p.iLevel == 2 && p.iParent == iMenuId).OrderBy(p => p.iSort).ToList();
            foreach (var item in navs)
            {
                sb.Append("<div id=\"sub_sort_");
                sb.Append(item.iIden);
                sb.Append("\" class=\"list_title\" onclick=\"hideorshow('sub_detail_");
                sb.Append(item.iIden);
                sb.Append("')\"><span>");

                    sb.Append(item.sName);//
   

                sb.AppendLine("</span></div>");
                sb.Append("<div id=\"sub_detail_");
                sb.Append(item.iIden);
                sb.AppendLine("\" class=\"list_detail\">");
                sb.AppendLine("<ul>");

                var NavItems = menus.Where(p => p.iLevel == 3 && p.iParent == item.iIden).OrderBy(p => p.iSort).ToList();
                foreach (var menuItem in NavItems)
                {
                    sb.Append("<li id=\"item_03\" onclick=\"changeframe('");

                        sb.Append(menuItem.sName);//
                    
                    sb.Append("',");
                    sb.Append(menuItem.iOpenMode);
                    sb.Append(",");
                    sb.Append(menuItem.iIden);
                    sb.Append(",'");
                    sb.Append(menuItem.sUrl);
                    sb.Append("')\"><a href=\"javascript:void(0);\">");

                        sb.Append(menuItem.sName);//
                    
                    sb.AppendLine("</a></li>");
                }
                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 生成公告的HTML标签
        /// </summary>
        /// <param name="withContent"></param>
        /// <param name="iCompanyId"></param>
        /// <returns></returns>
        public static string GetBulletins(bool withContent)
        {
            var list = saBulletin.Current.GetAllBulletins();
            if (list.Count <= 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul id=\"bcontainer\">");
            foreach (var item in list)
            {
                sb.Append("<li class=\"b_item\"><a href=\"javascript://;\"");

                if (item.iBulletinLevel == (int)BulletinLevel.Important)
                    sb.Append(" class=\"bul_important\"");
                else if (item.iBulletinLevel == (int)BulletinLevel.Emergency)
                    sb.Append(" class=\"bul_emergency\"");
                else
                    sb.Append(" class=\"bul_Ordinary\"");

                sb.Append(">");
                sb.Append(item.sTitle);
                sb.Append("</a><span>[");
                sb.Append(item.tCreateTime);
                sb.Append("]</span>");
                if (withContent)
                {
                    //公告内容
                    sb.Append("<div id=\"b_c_");
                    sb.Append(item.iIden);
                    sb.Append("\" class=\"b_item_c\">");
                    sb.Append(item.sContent.ToStringEx().Replace("\r", string.Empty).Replace("\n", "<br/>"));
                    sb.Append("</div>");
                    sb.Append("<a href=\"javascript://\" class=\"b_collapse\" onclick=\"javascript:$('#b_c_");
                    sb.Append(item.iIden);
                    sb.Append("').toggle('fast');$(this).toggleClass('collapsed');\">&nbsp;</a>");
                }
                sb.Append("</li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        public static string BuildDeptTree(string eleId, int curId)
        {
            //DataView dv = new DataView(PermissionManage.GetAllDept());

            //StringBuilder sb = new StringBuilder();
            //dv.RowFilter = "[Parent]=0 and [State]=1";
            //dv.Sort = "Sort";
            //AccuTreeNode(dv, sb, string.Format(" id=\"{0}\"", eleId));

            //sb.Replace(string.Format("id=\"node_{0}\"", curId),
            //    string.Format("id=\"node_{0}\" class=\"cur\"", curId));

            //return sb.ToString();

            return string.Empty;
        }
        /// <summary>
        /// 生成权限树的HTML标签
        /// </summary>
        /// <param name="eleId"></param>
        /// <returns></returns>
        public static string BuildCheckablePermissionTree(string eleId)
        {
            var menus = saMenu.Current.GetAllMenus();
            var list = menus.Where(p => p.iParent == 0).ToList();
            StringBuilder sb = new StringBuilder();
            AccuCheckablePermissionTreeNode(list, menus, sb, string.Format(" id=\"{0}\"", eleId));
            return sb.ToString();
        }


        public static string BuildCheckableDeptTree(string eleId)
        {
            return string.Empty;
        }


        public static string BuildSingleCheckableDeptTree(string eleId)
        {
            //DataView dv = new DataView(PermissionManage.GetAllDept());

            //StringBuilder sb = new StringBuilder();
            //dv.RowFilter = "[Parent]=0 and [State]=1";
            //dv.Sort = "sort";
            //AccuCheckableTreeNode(dv, sb, string.Format(" id=\"{0}\"", eleId), true);

            //return sb.ToString();

            return string.Empty;
        }


        private static void AccuCheckableTreeNode(DataView dv, StringBuilder output, string attr, bool singleChoice)
        {
            if (dv.Count <= 0)
                return;

            output.Append("<ul");
            output.Append(attr);
            output.Append(">");

            for (int i = 0; i < dv.Count; i++)
            {
                DataRowView drv = dv[i];
                string filter = dv.RowFilter;

                output.Append("<li><input type=\"");

                if (singleChoice)
                    output.Append("radio");
                else
                    output.Append("checkbox");

                output.Append("\" name=\"");

                if (singleChoice)
                    output.Append("radio");
                else
                    output.Append("cb");

                output.Append("_dept\" value=\"");
                output.Append(drv["ID"]);
                output.Append("\" id=\"");

                if (singleChoice)
                    output.Append("radio");
                else
                    output.Append("cb");

                output.Append("_");
                output.Append(drv["ID"]);
                output.Append("\" /><label for=\"");

                if (singleChoice)
                    output.Append("radio");
                else
                    output.Append("cb");

                output.Append("_");
                output.Append(drv["ID"]);
                output.Append("\">");
                output.Append(drv["Name"]);
                output.Append("</label>");

                dv.RowFilter = "[Parent]=" + drv["ID"].ToString();
                if (dv.Count > 0)
                    AccuCheckableTreeNode(dv, output, string.Empty, singleChoice);

                output.Append("</li>");

                dv.RowFilter = filter;
            }
            output.Append("</ul>");
        }

        private static void AccuCheckablePermissionTreeNode(IList<saMenuInfo> menus, IList<saMenuInfo> allmenus, StringBuilder output, string attr)
        {
            if (menus.Count <= 0)
                return;
            output.Append("<ul");
            output.Append(attr);
            output.Append(">");
            foreach (var menu in menus.OrderBy(p => p.iLevel).OrderBy(p => p.iSort))
            {
                output.Append("<li><input type=\"checkbox\" name=\"cb_permission\" value=\"");
                output.Append(menu.iIden);
                output.Append("\" id=\"cb_");
                output.Append(menu.iIden);
                output.Append("\" /><label for=\"cb_");
                output.Append(menu.iIden);
                output.Append("\">");
                output.Append(menu.sName);
                output.Append("</label>");

                var list = allmenus.Where(p => p.iParent == menu.iIden).ToList();
                if (list.Count > 0)
                {
                    AccuCheckablePermissionTreeNode(list, allmenus, output, string.Empty);
                }
                output.Append("</li>");
            }
            output.Append("</ul>");
        }

        private static void AccuTreeNode(DataView dv, StringBuilder output, string attr)
        {
            if (dv.Count <= 0)
                return;

            output.Append("<ul");
            output.Append(attr);
            output.Append(">");

            for (int i = 0; i < dv.Count; i++)
            {
                DataRowView drv = dv[i];
                string filter = dv.RowFilter;

                output.Append("<li><a href=\"deptManage.aspx?d=");
                output.Append(drv["ID"]);
                output.Append("\" id=\"node_");
                output.Append(drv["ID"]);
                output.Append("\">");
                output.Append(drv["Name"]);
                output.Append("</a>");

                dv.RowFilter = "[Parent]=" + drv["ID"].ToString();
                if (dv.Count > 0)
                    AccuTreeNode(dv, output, string.Empty);

                output.Append("</li>");


                dv.RowFilter = filter;

            }
            output.Append("</ul>");
        }

        /// <summary>
        /// 生成角色列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string BuildRoleList(string name)
        {
            var list = saRole.Current.GetAllRole();
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.Append("<div style=\"float:left;margin:5px 5px 5px 0;\">");
                sb.Append("<input type=\"checkbox\" id=\"cb_userRole_");
                sb.Append(item.iIden);
                sb.Append("\" value=\"");
                sb.Append(item.iIden);
                sb.Append("\" name=\"");
                sb.Append(name);
                sb.Append("\"  />");
                sb.Append("<label for=\"cb_userRole_");
                sb.Append(item.iIden);
                sb.Append("\">");
                sb.Append(item.sName);
                sb.Append("</label></div>");
            }

            return sb.ToString();
        }
        /// <summary>
        /// 生成选择框的HTML标签
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public static string BuildSelectOptions(DataView dv)
        {
            return BuildSelectOptions(dv, "ID", "Name");
        }
        /// <summary>
        /// 生成选择框的HTML标签
        /// </summary>
        /// <param name="dv"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <returns></returns>
        public static string BuildSelectOptions(DataView dv, string valueField, string textField)
        {
            if (dv == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (DataRowView drv in dv)
            {
                sb.Append("<option value='");
                sb.Append(drv[valueField]);
                sb.Append("'>");
                sb.Append(drv[textField]);
                sb.AppendLine("</option>");
            }

            return sb.ToString();
        }
        /// <summary>
        /// 获取所有菜单的HTML标签
        /// </summary>
        /// <param name="eleId"></param>
        /// <param name="iMenuId"></param>
        /// <returns></returns>
        public static string GetAllMenu(string eleId, int iMenuId)
        {
            var Menus = saMenu.Current.GetAllMenus();

            StringBuilder sb = new StringBuilder();
            var list = Menus.Where(p => p.iParent == 0).OrderBy(p => p.iSort).ToList();
            CreateMenuTreeNode(list, Menus, sb, string.Format(" id=\"{0}\"", eleId));

            sb.Replace(string.Format("id=\"radio_{0}\"", iMenuId),
                string.Format("id=\"radio_{0}\" class=\"cur\" checked='checked'", iMenuId));

            return sb.ToString();
        }
        /// <summary>
        /// 获取菜单树的HTML标签
        /// </summary>
        /// <param name="list"></param>
        /// <param name="allMenus"></param>
        /// <param name="output"></param>
        /// <param name="attr"></param>
        private static void CreateMenuTreeNode(IList<saMenuInfo> list, IList<saMenuInfo> allMenus, StringBuilder output, string attr)
        {
            if (list.Count <= 0)
                return;
            output.Append("<ul");
            output.Append(attr);
            output.Append(">");
            foreach (saMenuInfo item in list)
            {
                output.Append("<li><input type=\"");
                output.Append("radio");
                output.Append("\" name=\"");
                output.Append("radio");
                output.Append("_menu\" value=\"");
                output.Append(item.iIden);
                output.Append("\" id=\"");
                output.Append("radio");
                output.Append("_");
                output.Append(item.iIden);
                output.Append("\" /><label id=\"");
                output.Append("radio_label_");
                output.Append(item.iIden);
                output.Append("\" ");
                output.Append(" for=\"");
                output.Append("radio");
                output.Append("_");
                output.Append(item.iIden);
                output.Append("\">");
                output.Append(item.iIden.ToString() + "." + item.sName);
                output.Append("</label>");

                var listm = allMenus.Where(p => p.iParent == item.iIden).OrderBy(p => p.iSort).ToList();
                if (listm.Count() > 0)
                {
                    CreateMenuTreeNode(listm, allMenus, output, string.Empty);
                }
                output.Append("</li>");
            }
            output.Append("</ul>");
        }

       
        
    }
}
