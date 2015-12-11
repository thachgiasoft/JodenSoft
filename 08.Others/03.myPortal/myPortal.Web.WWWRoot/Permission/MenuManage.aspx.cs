using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.BLL;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class MenuManage : PageBase
    {
        protected string path = string.Empty;
        protected int iParentId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            path = Request["Message"] == null ? "顶级菜单" : Request["Message"];
            iParentId = Request["iParentId"] == null ? 0 : int.Parse(Request["iParentId"]);
            if (!IsPostBack)
            {
                CreateTreeView();
                BindData();
            }
            else if (Request.RequestType.Equals("POST"))
            {
                btnDelete_Click(null, null);
            }
        }

        private void CreateTreeView()
        {
            Dictionary<string, TreeNode> dicNodes = new Dictionary<string, TreeNode>();
            var menus = saMenu.Current.GetAllMenus();
            foreach (var menu in menus)
            {
                TreeNode node = new TreeNode("{0}".FormatEx(menu.sName));
                node.NavigateUrl = string.Format("MenuManage.aspx?iParentId={0}&Message={1}", menu.iIden, menu.sName);
                if (dicNodes.ContainsKey(menu.iParent.ToStringEx()))
                {
                    dicNodes[menu.iParent.ToStringEx()].ChildNodes.Add(node);
                }
                else
                {
                    this.treeMenus.Nodes.Add(node);
                }
                dicNodes.Add(menu.iIden.ToStringEx(), node);
            }
        }

        private void BindData()
        {
            var list = saMenu.Current.GetChildMenus(iParentId);
            this.repMenus.DataSource = list;
            this.repMenus.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_id"]))
            {
                string[] ids = Request["cb_id"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    saMenu.Current.DeleteMenus(ids);
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('删除成功！');location.href='MenuManage.aspx';</script>");
                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                }
            }
        }
    }
}