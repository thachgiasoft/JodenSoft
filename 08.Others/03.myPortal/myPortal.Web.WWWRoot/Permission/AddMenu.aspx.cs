using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.BLL;
using myPortal.Foundation.Extensions;
using myPortal.Foundation.Utils;
using myPortal.Foundation;
using myPortal.Model;

namespace myPortal.Web.WWWRoot.Permission
{
    public partial class AddMenu : PageBase
    {
        protected int iParentId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request["iParentId"], out iParentId))
            {
                Response.Redirect("MenuManage.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                this.txtParentId.Value = iParentId.ToString();

                CreateTreeView();
                this.BindDll();
                this.BindData();
            }
        }
        private void CreateTreeView()
        {
            Dictionary<string, TreeNode> dicNodes = new Dictionary<string, TreeNode>();
            var menus = saMenu.Current.GetAllMenus().Where(p => p.iLevel <= 2).ToList();
            foreach (var menu in menus)
            {
                TreeNode node = new TreeNode(menu.sName.ToStringEx());
                node.Text = "<input type='radio' id='radio_menu_{0}' name='radio_menu' value='{0}' title='{0}.{1}' />".FormatEx(menu.iIden, menu.sName.ToStringEx()) +
                    "{0}.{1}".FormatEx(menu.iIden, menu.sName.ToStringEx());
                node.NavigateUrl = "javascript:void(0);";
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
        private void BindDll()
        {
            this.ddlLevel.DataTextField = "Text";
            this.ddlLevel.DataValueField = "Value";
            this.ddlLevel.DataSource = EnumHelper.ToDataTable<int>(typeof(MenuLevel));
            this.ddlLevel.DataBind();

            this.ddlOpenMode.DataTextField = "Text";
            this.ddlOpenMode.DataValueField = "Value";
            this.ddlOpenMode.DataSource = EnumHelper.ToDataTable<int>(typeof(MenuOpenMode));
            this.ddlOpenMode.DataBind();
        }

        private void BindData()
        {
            if (this.IsModifyAction)
            {
                int iMenuId = 0;
                int.TryParse(Request["iMenuId"], out iMenuId);
                var menu = saMenu.Current.GetMenu(iMenuId);
                if (menu != null)
                {
                    this.txtMenuId.Value = iMenuId.ToStringEx();
                    this.txtMenuName.Text = menu.sName.ToStringEx();
                    this.txtParentId.Value = menu.iParent.ToStringEx();
                    this.txtSort.Text = menu.iSort.ToStringEx();
                    this.txtURL.Text = menu.sUrl.ToStringEx();
                    this.ddlLevel.SelectedValue = menu.iLevel.ToStringEx();
                    this.ddlOpenMode.SelectedValue = menu.iOpenMode.ToStringEx();
                    var pMenu = saMenu.Current.GetMenu(menu.iParent);
                    if (pMenu != null)
                    {
                        this.txtParentId.Value = pMenu.iIden.ToStringEx();
                        this.txtParentMenuName.Text = "{0}.{1}".FormatEx(pMenu.iIden, pMenu.sName.ToStringEx());
                    }
                    else
                    {
                        this.txtMenuId.Value = string.Empty;
                        this.txtParentId.Value = string.Empty;
                        this.txtParentMenuName.Text = string.Empty;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('菜单不存在或已被删除！');location.href='MenuManage.aspx?iParentId=" +
                        iParentId + "';</script>");
                }
            }
            else
            {
                var pMenu = saMenu.Current.GetMenu(iParentId);
                if (pMenu != null)
                {
                    this.txtParentId.Value = pMenu.iIden.ToStringEx();
                    this.txtParentMenuName.Text = "{0}.{1}".FormatEx(pMenu.iIden, pMenu.sName.ToStringEx());
                }
                else
                {
                    this.txtParentId.Value = "0";
                    this.txtParentMenuName.Text = string.Empty;
                    this.txtMenuId.Value = string.Empty;
                }
            }
        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                try
                {
                    int iMenuId = 0;
                    int.TryParse(Request["iMenuId"], out iMenuId);

                    int.TryParse(txtParentId.Value.Trim(), out iParentId);

                    var menu = new saMenuInfo();
                    menu.iParent = iParentId;
                    menu.iSort = int.Parse(this.txtSort.Text);
                    menu.sName = this.txtMenuName.Text.Trim();
                    menu.sUrl = this.txtURL.Text.ToStringEx();
                    menu.iLevel = int.Parse(this.ddlLevel.SelectedValue);
                    menu.iOpenMode = int.Parse(this.ddlOpenMode.SelectedValue);
                    menu.iCreator = this.iUserID;

                    if (this.IsModifyAction)
                    {
                        menu.iIden = iMenuId;
                        saMenu.Current.UpdateMenu(menu);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('菜单信息处理成功！');location.href='MenuManage.aspx?iParentId=" +
                            iParentId + "';</script>");
                    }
                    else
                    {
                        menu.iIden = IdenGenerator.Current.NewIden(saMenuInfo.sTableName);
                        saMenu.Current.CreateMenu(menu);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('菜单信息处理成功！');location.href='MenuManage.aspx?iParentId=" +
                            iParentId + "';</script>");
                    }
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMsg = ex.Message;
                    throw ex;
                }
            }
            else
            {
                hasError = true;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(this.txtMenuName.Text.Trim()))
            {
                errorMsg = "菜单名称不能为空";
                return false;
            }
  
            if (string.IsNullOrEmpty(txtSort.Text.Trim()))
            {
                errorMsg = "排序不能为空";
                return false;
            }

            return true;
        }

        protected string BuildMenuTree(string eleId)
        {
            return HtmlRender.GetAllMenu(eleId, iParentId);
        }
    }
}