using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScheduleQueryPortal.Foundation;

namespace ScheduleQueryPortal
{
    public partial class AddScheduleQuery : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsModifyAction)
            {
                this.Title = "修改进度查询";
            }
            else
            {
                this.Title = "添加进度查询";
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            if (this.IsModifyAction && !string.IsNullOrEmpty(Request["Iden"]))
            {
                int id;
                if (int.TryParse(Request["Iden"], out id))
                {
                    var dtScheduleQuery = QueryHelper.GetScheduleQuery(id);
                    if (dtScheduleQuery != null && dtScheduleQuery.Rows.Count > 0)
                    {
                        this.txtName.Text = dtScheduleQuery.Rows[0]["sName"].ToString();
                        this.txtTimeInterval.Text = dtScheduleQuery.Rows[0]["iTimeInterval"].ToString();
                    }
                    else
                    {
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            string.Format("<script type=\"text/javascript\">alert('{0}');location.href='Default.aspx';</script>", "数据不存在,可能已被删除!"));
                    }
                }
            }
        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    var scheduleQueryInfo = new ScheduleQueryInfo();
                    scheduleQueryInfo.sName = this.txtName.Text.Trim();
                    scheduleQueryInfo.iTimeInterval = Convert.ToInt32(this.txtTimeInterval.Text);

                    if (this.IsModifyAction)
                    {
                        int id;
                        int.TryParse(Request["Iden"], out id);
                        scheduleQueryInfo.iIden = id;

                        QueryHelper.ModifyScheduleQuery(scheduleQueryInfo);
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                          string.Format("<script type=\"text/javascript\">alert('{0}');location.href='Default.aspx';</script>", "修改成功!"));
                    }
                    else
                    {
                        scheduleQueryInfo.iIden = QueryHelper.NewIden("smScheduleQuery");

                        QueryHelper.AddScheduleQuery(scheduleQueryInfo);
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                          string.Format("<script type=\"text/javascript\">alert('{0}');location.href='Default.aspx';</script>", "添加成功!"));
                    }
                }
                else
                {
                    hasError = true;
                }
            }
            catch (System.Exception ex)
            {
                hasError = true;
                errorMsg = ex.Message;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                this.errorMsg = "进度查询名称不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.txtTimeInterval.Text))
            {
                this.errorMsg = "翻页时间间隔不能为空。";
                return false;
            }
            return true;
        }
    }
}