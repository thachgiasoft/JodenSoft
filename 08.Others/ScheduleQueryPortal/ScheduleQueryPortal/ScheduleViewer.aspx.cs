using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ScheduleQueryPortal.Foundation;

namespace ScheduleQueryPortal
{
    public partial class ScheduleViewer : PageBase
    {
        protected string iTimeInterval = "60s";
        protected int QueryId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id;
                int.TryParse(Request["Iden"], out id);

                QueryId = id;

                var dtQuery = QueryHelper.GetScheduleQuery(id);
                if (dtQuery.Rows.Count > 0)
                {
                    iTimeInterval = dtQuery.Rows[0]["iTimeInterval"].ToString() + "s";
                }
            }
        }
    }
}