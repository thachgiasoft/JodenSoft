using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.Foundation.Utils;
using myPortal.Foundation;
using myPortal.BLL;
using myPortal.Model;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Dictionary
{
    public partial class AddBulletinType : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindModItemData();
            }
        }
        private void BindModItemData()
        {
            if ("m".Equals(Request["Action"]) && !string.IsNullOrEmpty(Request["iIden"]))
            {
                int id;
                if (int.TryParse(Request["iIden"], out id))
                {
                    var model = saBulletinType.Current.GetsaBulletinType(id);

                    if (model != null)
                    {
                        this.txtName.Text = model.sName.ToStringEx();
                        this.txtSort.Text = model.iSort.ToStringEx();
                        this.cbxIsActive.Checked = !model.bUsable;
                    }
                    else
                    {
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinTypeManage.aspx';</script>".FormatEx(Resources.GlobalResources.DoesNotExistItMayHaveBeenDeleted));
                    }
                }
            }
        }
        protected void buttonOK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                try
                {
                    var bulletin = new saBulletinTypeInfo();
                    bulletin.sName = this.txtName.Text.Trim();
                    bulletin.iSort = int.Parse(this.txtSort.Text.Trim());
                    bulletin.bUsable = !this.cbxIsActive.Checked;
                    if (this.IsModifyAction)
                    {
                        int id;
                        int.TryParse(Request["iIden"], out id);
                        bulletin.iIden = id;
                        saBulletinType.Current.UpdateBulletinType(bulletin);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinTypeManage.aspx';</script>".FormatEx(Resources.GlobalResources.ModifiedSuccess));
                    }
                    else
                    {
                        bulletin.iIden = IdenGenerator.Current.NewIden(saBulletinTypeInfo.sTableName);
                        bulletin.bUsable = true;
                        bulletin.iCreator = this.iUserID;
                        saBulletinType.Current.CreateBulletinType(bulletin);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinTypeManage.aspx';</script>".FormatEx(Resources.GlobalResources.AddedSuccess));
                    }
                }
                catch (Exception ex)
                {
                    hasError = true;
                    errorMsg = ex.Message;
                }
            }
            else
            {
                hasError = true;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(this.txtName.Text))//标题
            {
                this.errorMsg = "请输入名称.";
                return false;
            }
            if (string.IsNullOrEmpty(this.txtSort.Text))//标题
            {
                this.errorMsg = "请输入排序.";
                return false;
            }
            return true;
        }
    }
}