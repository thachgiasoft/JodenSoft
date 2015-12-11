using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myPortal.Cache;
using myPortal.Foundation.Utils;
using myPortal.Foundation.Extensions;

namespace myPortal.Web.WWWRoot.Setting
{
    public partial class CacheManage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData(false);
            }
            else if (Request.RequestType.ToUpper().Equals("POST"))
            {
                btnDelete_Click(null, null);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData(bool isQuery)
        {
            var list = GetList();

            if (isQuery)
            {
                this.grid.DataSource = list.Where(p => p.Name.ToLower().Contains(this.txtName.Text.ToLower().Trim())).ToList();
            }
            else
            {
                this.grid.DataSource = list;
            }
            this.grid.DataBind();

        }

        private IList<CacheItem> GetList()
        {
            var list = new List<CacheItem>();
            AddCacheToList(list, CacheKey.DicOrganization, "组织结构");
            AddCacheToList(list, CacheKey.DicRole, "角色");
            AddCacheToList(list, CacheKey.DicBulletinType, "公告类型");
            return list;
        }

        private void AddCacheToList(IList<CacheItem> list, string cacheKey, string cacheName)
        {
            if (CacheService.Current.RetriveObject(cacheKey) != null)
            {
                var obj = list.FirstOrDefault(p => p.Key == cacheKey);
                if (obj == null)
                    list.Add(new CacheItem(cacheKey, cacheName));
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["cb_bid"]))
            {
                string[] ids = Request["cb_bid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    foreach (var item in ids)
                    {
                        CacheService.Current.RemoveObject(item);
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), string.Empty,
                        "<script type=\"text/javascript\">alert('{0}');location.href='{1}';</script>".FormatEx("删除成功！", "CacheManage.aspx"));
                }
                catch (Exception ex)
                {
                    this.hasError = true;
                    this.errorMsg = ex.Message;
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindData(true);
        }
    }
}