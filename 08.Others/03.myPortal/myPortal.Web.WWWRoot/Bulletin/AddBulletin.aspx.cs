using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.Web;
using System.Data;
using myPortal.Foundation.Utils;
using myPortal.Foundation;
using myPortal.BLL;
using myPortal.Model;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Bulletin
{
    public partial class AddBulletin : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlBulletinLevel.DataTextField = "Text";
                ddlBulletinLevel.DataValueField = "Value";
                ddlBulletinLevel.DataSource = EnumHelper.ToDataTable<int>(typeof(BulletinLevel));
                ddlBulletinLevel.DataBind();

                ddlBulletinType.DataTextField = "sName";
                ddlBulletinType.DataValueField = "iIden";
                ddlBulletinType.DataSource = saBulletinType.Current.GetAllBulletinType().Where(p => p.bUsable == true).ToList();
                ddlBulletinType.DataBind();

                this.txtDateStart.Value = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtDateEnd.Value = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

                BindModItemData();
            }
        }

        private void BindModItemData()
        {
            if (this.IsModifyAction && !string.IsNullOrEmpty(Request["iBulletinId"]))
            {
                int id;
                if (int.TryParse(Request["iBulletinId"], out id))
                {
                    var bulletin = saBulletin.Current.GetBulletin(id);

                    if (bulletin != null)
                    {
                        this.txtTitle.Text = bulletin.sTitle.ToStringEx();
                        this.txtContent.Text = bulletin.sContent.ToStringEx();
                        this.ddlBulletinLevel.SelectedValue = bulletin.iBulletinLevel.ToStringEx();
                        this.ddlBulletinType.SelectedValue = bulletin.iBulletinType.ToStringEx();

                        this.txtDateStart.Value = bulletin.tStartTime.ToString("yyyy-MM-dd");
                        this.ddlStartHour.Value = bulletin.tStartTime.Hour.ToString();
                        this.txtDateEnd.Value = bulletin.tEndTime.ToString("yyyy-MM-dd");
                        this.ddlEndHour.Value = bulletin.tEndTime.Hour.ToString();
                    }
                    else
                    {
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinManage.aspx';</script>".FormatEx(Resources.GlobalResources.DoesNotExistItMayHaveBeenDeleted));
                    }
                }
            }
        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.MinValue;
            DateTime endTime = DateTime.MinValue;

            if (CheckInput(ref startTime, ref endTime))
            {
                try
                {
                    var bulletin = new saBulletinInfo();
                    bulletin.sTitle = this.txtTitle.Text.Trim();
                    bulletin.sContent = this.txtContent.Text.Trim();
                    bulletin.tStartTime = startTime;
                    bulletin.tEndTime = endTime;
                    bulletin.iBulletinLevel = int.Parse(ddlBulletinLevel.SelectedValue);
                    bulletin.iBulletinType = int.Parse(ddlBulletinType.SelectedValue);


                    if (this.IsModifyAction)
                    {
                        int id;
                        int.TryParse(Request["iBulletinId"], out id);
                        bulletin.iIden = id;
                        bulletin.bUsable = true;
                        bulletin.tUpdateTime = DbServer.Current.ServerDateTime;
                        saBulletin.Current.UpdateBulletin(bulletin);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinManage.aspx';</script>".FormatEx(Resources.GlobalResources.ModifiedSuccess));
                    }
                    else
                    {
                        bulletin.iIden = IdenGenerator.Current.NewIden(saBulletinInfo.sTableName);
                        bulletin.iCreator = iUserID;
                        bulletin.bUsable = true;
                        bulletin.tCreateTime = DbServer.Current.ServerDateTime;
                        bulletin.tUpdateTime = bulletin.tCreateTime;
                        saBulletin.Current.CreateBulletin(bulletin);

                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            "<script type=\"text/javascript\">alert('{0}');location.href='BulletinManage.aspx';</script>".FormatEx(Resources.GlobalResources.AddedSuccess));
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

        private bool CheckInput(ref DateTime startTime, ref DateTime endTime)
        {

            if (string.IsNullOrEmpty(txtTitle.Text))//标题
            {
                this.errorMsg = "标题不能为空。";
                return false;
            }
            if (!DateTime.TryParse(this.txtDateStart.Value, out startTime))//生效时间
            {
                this.errorMsg = "生效时间无效。";
                return false;
            }
            if (!DateTime.TryParse(this.txtDateEnd.Value, out endTime))//失效时间
            {
                this.errorMsg = "失效时间无效。";
                return false;
            }
            int hour = -1;
            if (int.TryParse(this.ddlEndHour.Value, out hour))
                endTime = endTime.AddHours(hour);
            else
                return false;

            hour = -1;
            if (int.TryParse(this.ddlStartHour.Value, out hour))
                startTime = startTime.AddHours(hour);
            else
                return false;

            return true;
        }
    }
}