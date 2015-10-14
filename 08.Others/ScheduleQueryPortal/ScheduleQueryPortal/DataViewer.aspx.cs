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
    public partial class DataViewer : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = string.Empty;
                int pageSize = 10;
                int fontSize = 12;
                int hdrId = 0;
                try
                {
                    int QueryId = 0;
                    int.TryParse(Request["QueryId"], out QueryId);

                    int queryIndex = 0;
                    int.TryParse(Request["ChildQueryIndex"], out queryIndex);


                    var dt = QueryHelper.GetScheduleQueryHdrByQueryId(QueryId);

                    if (dt == null || dt.Rows.Count <= 0)
                    {
                        throw new Exception("没有配置子查询.");
                    }

                    if (queryIndex + 1 > dt.Rows.Count)
                        queryIndex = 0;

                    this.hidChildQueryIndex.Value = queryIndex.ToString();
                    this.hidChildQueryCount.Value = dt.Rows.Count.ToString();

                    sql = dt.Rows[queryIndex]["sSql"].ToString();
                    pageSize = Convert.ToInt32(dt.Rows[queryIndex]["iPageSize"]);
                    fontSize = Convert.ToInt32(dt.Rows[queryIndex]["iFontSize"]);
                    hdrId = Convert.ToInt32(dt.Rows[queryIndex]["iIden"]);
                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                    return;
                }

                QueryParam param = new QueryParam();
                param.PageSize = pageSize;
                param.PageIndex = 1;
                if (Request["PageIndex"] != null)
                {
                    param.PageIndex = Convert.ToInt32(Request["PageIndex"]);
                }

                this.hidPageIndex.Value = param.PageIndex.ToString();

                var dtFields = QueryHelper.GetScheduleQueryField(hdrId);

                var result = QueryHelper.ExecutePageQuery(sql, param);
                if (result.IsSucess)
                {
                    this.hasError = false;
                    this.hidTotalPage.Value = result.TotalPage.ToString();

                    this.GridView.Columns.Clear();
                    foreach (DataRow row in dtFields.Rows)
                    {
                        if (!Convert.ToBoolean(row["bShow"])) continue;

                        BoundField bc = new BoundField();
                        bc.DataField = row["sFieldName"].ToString();
                        bc.HeaderStyle.Font.Size = new FontUnit(fontSize - 2);
                        bc.HeaderText = string.IsNullOrWhiteSpace(row["sCaption"].ToString()) ? row["sFieldName"].ToString() : row["sCaption"].ToString();
                        bc.HeaderStyle.CssClass = "th WordWrap";  //若有默认样式，此行代码及对应的参数可以移除
                        int width = Convert.ToInt32(row["iWidth"].ToString());
                        if (width != 0)
                        {
                            bc.HeaderStyle.Width = Math.Abs(width);
                        }

                        string style = row["sHorizontalAlignment"].ToString() + " " + row["sVerticalAlignment"].ToString();
                        if (!Convert.ToBoolean(row["bAllowWarp"].ToString()))
                        {
                            style += " nowrap";
                        }
                        else
                        {
                            style += " WordWrap";
                        }
                        bc.ItemStyle.CssClass = style;
                        bc.ItemStyle.Font.Size = new FontUnit(fontSize);

                        GridView.Columns.Add(bc);  //把动态创建的列，添加到GridView中 
                    }
                    this.GridView.DataSource = result.Data;
                    this.GridView.DataBind();

                    PageControl1.TotalPage = result.TotalPage;
                    PageControl1.TotalRows = result.TotalRowCount;
                    PageControl1.CurrentPage = result.PageIndex;
                    PageControl1.DataBind();

                }
                else
                {
                    this.hasError = true;
                    this.errorMsg = result.Message;
                }
            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object objColor = null;
                try
                {
                    objColor = DataBinder.Eval(e.Row.DataItem, "sColor");
                }
                catch
                {
                    objColor = null;
                }
                if (objColor != null)
                {
                    e.Row.Attributes["style"] += string.Format("color: {0};", objColor);
                }
            }
        }
    }
}