using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScheduleQueryPortal.Foundation;
using System.Data;

namespace ScheduleQueryPortal
{
    public partial class AddScheduleQueryHdr : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsModifyAction)
            {
                this.Title = "修改子查询";
            }
            else
            {
                this.Title = "添加子查询";
            }

            if (!IsPostBack)
            {
                BindData();
                GridViewBind();
            }
        }

        private void GridViewBind()
        {
            int id = 0;
            if (!string.IsNullOrEmpty(Request["Iden"]))
            {
                int.TryParse(Request["Iden"], out id);
            }

            var dt = QueryHelper.GetScheduleQueryField(id);
            this.GridViewField.DataSource = dt.DefaultView;
            this.GridViewField.DataBind();
        }

        private void BindData()
        {
            if (this.IsModifyAction)
            {
                int id;
                if (int.TryParse(Request["Iden"], out id))
                {
                    var dtScheduleQueryHdr = QueryHelper.GetScheduleQueryHdr(id);
                    if (dtScheduleQueryHdr != null && dtScheduleQueryHdr.Rows.Count > 0)
                    {
                        var row = dtScheduleQueryHdr.Rows[0];
                        this.txtName.Text = row["sName"].ToString();
                        this.txtQueryId.Text = row["iQueryId"].ToString();
                        this.txtSQL.Value = row["sSql"].ToString();
                        this.txtPageSize.Text = row["iPageSize"].ToString();
                        this.txtFontSize.Text = row["iFontSize"].ToString();
                    }
                    else
                    {
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                            string.Format("<script type=\"text/javascript\">alert('{0}');location.href='Default.aspx';</script>", "数据不存在,可能已被删除!"));
                    }
                }
            }
            else
            {
                this.txtQueryId.Text = Request["QueryId"];
            }
        }

        protected void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    var scheduleQueryHdrInfo = new ScheduleQueryHdrInfo();
                    scheduleQueryHdrInfo.sName = this.txtName.Text.Trim();
                    scheduleQueryHdrInfo.iQueryId = Convert.ToInt32(this.txtQueryId.Text);
                    scheduleQueryHdrInfo.iPageSize = Convert.ToInt32(this.txtPageSize.Text);
                    scheduleQueryHdrInfo.iFontSize = Convert.ToInt32(this.txtFontSize.Text);
                    scheduleQueryHdrInfo.sSql = this.txtSQL.Value.Trim();

                    if (this.IsModifyAction)
                    {
                        int id;
                        int.TryParse(Request["Iden"], out id);
                        scheduleQueryHdrInfo.iIden = id;

                        QueryHelper.ModifyScheduleQueryHdr(scheduleQueryHdrInfo);
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                          string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>", "修改成功!", Request.Url.PathAndQuery));
                    }
                    else
                    {
                        scheduleQueryHdrInfo.iIden = QueryHelper.NewIden("smScheduleQueryHdr");

                        QueryHelper.AddScheduleQueryHdr(scheduleQueryHdrInfo);
                        Response.Clear();
                        ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                          string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>", "添加成功!", "AddScheduleQueryHdr.aspx?Action=m&Iden=" + scheduleQueryHdrInfo.iIden.ToString()));
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
                this.errorMsg = "子查询名称不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.txtPageSize.Text))
            {
                this.errorMsg = "每页行数不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.txtFontSize.Text))
            {
                this.errorMsg = "字体大小不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.txtSQL.Value))
            {
                this.errorMsg = "查询语句不能为空。";
                return false;
            }

            return true;
        }

        protected void GridViewField_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewField.EditIndex = e.NewEditIndex;
            GridViewBind();
        }

        protected void GridViewField_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewField.EditIndex = -1;
            GridViewBind();
        }

        private DataTable GetHorizontalAlignment()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            dt.Rows.Add("", "-请选择-");
            dt.Rows.Add("left", "居左");
            dt.Rows.Add("center", "居中");
            dt.Rows.Add("right", "居右");
            return dt;
        }

        private DataTable GetVerticalAlignment()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            dt.Rows.Add("", "-请选择-");
            dt.Rows.Add("top", "顶部");
            dt.Rows.Add("middle", "中部");
            dt.Rows.Add("bottom", "底部");
            return dt;
        }

        protected string CalcHorizontalAlignment(object value)
        {
            var dv = new DataView(GetHorizontalAlignment());
            dv.RowFilter = string.Format("Id='{0}'", value);
            if (dv.Count > 0)
            {
                return dv[0]["Value"].ToString();
            }
            else
            {
                return value.ToString();
            }
        }

        protected string CalcVerticalAlignment(object value)
        {
            var dv = new DataView(GetVerticalAlignment());
            dv.RowFilter = string.Format("Id='{0}'", value);
            if (dv.Count > 0)
            {
                return dv[0]["Value"].ToString();
            }
            else
            {
                return value.ToString();
            }
        }

        protected void GridViewField_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (((DropDownList)e.Row.FindControl("ddlHorizontalAlignment")) != null)
            {
                DropDownList ddlHorizontalAlignment = (DropDownList)e.Row.FindControl("ddlHorizontalAlignment");
                ddlHorizontalAlignment.DataSource = GetHorizontalAlignment().DefaultView;
                ddlHorizontalAlignment.DataValueField = "Id";
                ddlHorizontalAlignment.DataTextField = "Value";
                ddlHorizontalAlignment.DataBind();
                //  选中 DropDownList
                ddlHorizontalAlignment.SelectedValue = ((HiddenField)e.Row.FindControl("hidHorizontalAlignment")).Value;
            }

            if (((DropDownList)e.Row.FindControl("ddlVerticalAlignment")) != null)
            {
                DropDownList ddlVerticalAlignment = (DropDownList)e.Row.FindControl("ddlVerticalAlignment");
                ddlVerticalAlignment.DataSource = GetVerticalAlignment().DefaultView;
                ddlVerticalAlignment.DataValueField = "Id";
                ddlVerticalAlignment.DataTextField = "Value";
                ddlVerticalAlignment.DataBind();
                //  选中 DropDownList
                ddlVerticalAlignment.SelectedValue = ((HiddenField)e.Row.FindControl("hidVerticalAlignment")).Value;
            }
        }

        protected void GridViewField_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var obj = new ScheduleQueryFieldInfo();
                GridViewRow row = this.GridViewField.Rows[e.RowIndex];
                obj.iIden = Convert.ToInt32(this.GridViewField.DataKeys[e.RowIndex].Values[0].ToString());
                obj.sCaption = ((TextBox)row.FindControl("txtCaption")).Text.Trim();
                obj.bShow = ((CheckBox)row.FindControl("chkShow")).Checked;
                obj.iWidth = Convert.ToInt32(((TextBox)row.FindControl("txtWidth")).Text);
                obj.bAllowWarp = ((CheckBox)row.FindControl("chkAllowWarp")).Checked;
                obj.sHorizontalAlignment = ((DropDownList)row.FindControl("ddlHorizontalAlignment")).SelectedValue;
                obj.sVerticalAlignment = ((DropDownList)row.FindControl("ddlVerticalAlignment")).SelectedValue;
                obj.iSortIndex = Convert.ToInt32(((TextBox)row.FindControl("txtSortIndex")).Text);
                QueryHelper.ModifyScheduleQueryField(obj);

                GridViewField.EditIndex = -1;
                GridViewBind();
            }
            catch (Exception ex)
            {
                this.hasError = true;
                this.errorMsg = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request["Iden"], out id);

                QueryHelper.DeleteScheduleQueryHdr(id);

                Response.Clear();
                ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                  string.Format("<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>", "删除成功!", "Default.aspx"));

            }
            catch (Exception ex)
            {
                this.hasError = true;
                this.errorMsg = ex.Message;
            }
        }

        protected void btnGetFields_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request["Iden"], out id);

                var dt = QueryHelper.GetScheduleQueryHdr(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var sql = dt.Rows[0]["sSql"].ToString();
                    var result = QueryHelper.ExecutePageQuery(sql, new QueryParam() { PageIndex = 1, PageSize = 1 });
                    if (result.IsSucess && result.Data != null && result.Data.Columns.Count > 0)
                    {
                        var table = result.Data;
                        List<ScheduleQueryFieldInfo> fields = new List<ScheduleQueryFieldInfo>();
                        foreach (DataColumn item in table.Columns)
                        {
                            if (item.ColumnName != "ROWSTAT")
                            {
                                var field = new ScheduleQueryFieldInfo();
                                field.iIden = QueryHelper.NewIden("smScheduleQueryField");
                                field.iQueryHdrId = id;
                                field.sFieldName = item.ColumnName;
                                field.sCaption = item.ColumnName;
                                field.bShow = true;
                                field.iWidth = 0;
                                field.bAllowWarp = true;
                                field.sHorizontalAlignment = "center";
                                field.sVerticalAlignment = "middle";
                                field.iSortIndex = table.Columns.IndexOf(item);
                                fields.Add(field);
                            }
                        }
                        QueryHelper.AddScheduleQueryField(fields);

                        GridViewBind();
                    }
                    else
                    {
                        throw new Exception(result.Message);
                    }
                }
                else
                {
                    throw new Exception("未配置子查询!");
                }
            }
            catch (Exception ex)
            {
                this.hasError = true;
                this.errorMsg = ex.Message;
            }
        }

        protected void btnDeleteAllFields_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request["Iden"], out id);

                QueryHelper.DeleteScheduleQueryFields(id);

                GridViewBind();
            }
            catch (Exception ex)
            {
                this.hasError = true;
                this.errorMsg = ex.Message;
            }
        }

    }
}