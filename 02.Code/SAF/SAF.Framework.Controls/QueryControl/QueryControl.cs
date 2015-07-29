using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SAF.Foundation;
using DevExpress.XtraBars;
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.Controls
{
    [ToolboxItem(true)]
    public partial class QueryControl : BaseUserControl
    {
        public QueryControl()
        {
            InitializeComponent();

            this.txtSearchText.EditValueChanged += txtSearchText_EditValueChanged;
            this.txtSearchText.KeyDown += txtSearchText_KeyDown;
        }

        void txtSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.FireQueryEvent();
            }
        }

        void txtSearchText_EditValueChanged(object sender, EventArgs e)
        {
            if (this.txtSearchText.EditValue.IsEmpty())
                this.txtSearchText.EditValue = null;
        }

        public void Init(QueryConfig queryConfig)
        {
            this.popQucikFields.ClearLinks();
            if (queryConfig == null || queryConfig.QuickQuery == null || queryConfig.QuickQuery.QueryFields.IsEmpty())
            {
                this.btnQuery.DropDownControl = null;

                this.txtSearchText.Enabled = false;

                return;
            }
            //计算默认字段
            CalcQuickQueryDefaultField(queryConfig);
            //初始化速查字段
            InitQuickQueryFields(queryConfig);
            //添加速查方式
            InitQuickQueryType(queryConfig);

            this.btnQuery.DropDownControl = this.popQucikFields;
            this.txtSearchText.Enabled = true;

        }

        private void InitQuickQueryType(QueryConfig queryConfig)
        {
            BarCheckItem bbi = new BarCheckItem(bmQueryControl, queryConfig.QuickQuery.QuickQueryType == QuickQueryType.Exact);
            bbi.GroupIndex = 2;
            bbi.Name = "bbiQueryType_" + Guid.NewGuid().ToString("N");
            bbi.Caption = "精确查找";
            bbi.Tag = (int)QuickQueryType.Exact;
            bbi.ItemClick += bbi_ItemClick;
            if (bbi.Checked)
                btnQuery.Tag = bbi.Tag;
            popQucikFields.LinksPersistInfo.Add(new LinkPersistInfo(bbi, true));


            bbi = new BarCheckItem(bmQueryControl, queryConfig.QuickQuery.QuickQueryType == QuickQueryType.LeftMatch);
            bbi.GroupIndex = 2;
            bbi.Name = "bbiQueryType_" + Guid.NewGuid().ToString("N");
            bbi.Caption = "左匹配";
            bbi.Tag = (int)QuickQueryType.LeftMatch;
            bbi.ItemClick += bbi_ItemClick;
            if (bbi.Checked)
                btnQuery.Tag = bbi.Tag;
            popQucikFields.LinksPersistInfo.Add(new LinkPersistInfo(bbi));

            bbi = new BarCheckItem(bmQueryControl, queryConfig.QuickQuery.QuickQueryType == QuickQueryType.Fuzzy);
            bbi.GroupIndex = 2;
            bbi.Name = "bbiQueryType_" + Guid.NewGuid().ToString("N");
            bbi.Caption = "模糊查找";
            bbi.Tag = (int)QuickQueryType.Fuzzy;
            bbi.ItemClick += bbi_ItemClick;
            if (bbi.Checked)
                btnQuery.Tag = bbi.Tag;
            popQucikFields.LinksPersistInfo.Add(new LinkPersistInfo(bbi));

            bbi = new BarCheckItem(bmQueryControl, queryConfig.QuickQuery.QuickQueryType == QuickQueryType.Combinatorial);
            bbi.GroupIndex = 2;
            bbi.Name = "bbiQueryType_" + Guid.NewGuid().ToString("N");
            bbi.Caption = "组合查找";
            bbi.Tag = (int)QuickQueryType.Combinatorial;
            bbi.ItemClick += bbi_ItemClick;
            if (bbi.Checked)
                btnQuery.Tag = bbi.Tag;
            popQucikFields.LinksPersistInfo.Add(new LinkPersistInfo(bbi));

        }

        void bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnQuery.Tag = e.Item.Tag;
        }
        /// <summary>
        /// 计算默认字段
        /// </summary>
        /// <param name="queryConfig"></param>
        private static void CalcQuickQueryDefaultField(QueryConfig queryConfig)
        {
            if (queryConfig.QuickQuery.QueryFields.Count(p => p.IsDefault) > 1)
            {
                bool hasFind = false;
                foreach (var item in queryConfig.QuickQuery.QueryFields)
                {
                    if (item.IsDefault && !hasFind)
                    {
                        hasFind = true;
                    }
                    else
                    {
                        item.IsDefault = false;
                    }
                }
            }

            if (!queryConfig.QuickQuery.QueryFields.Any(p => p.IsDefault))
            {
                queryConfig.QuickQuery.QueryFields.First().IsDefault = true;
            }
        }
        /// <summary>
        /// 初始化速查字段
        /// </summary>
        /// <param name="queryConfig"></param>
        private void InitQuickQueryFields(QueryConfig queryConfig)
        {
            foreach (var item in queryConfig.QuickQuery.QueryFields)
            {
                var bbi = new BarCheckItem(bmQueryControl, item.IsDefault);
                bbi.GroupIndex = 1;
                bbi.Name = "bbiFields_" + Guid.NewGuid().ToString("N");
                bbi.Caption = item.Caption;
                bbi.Tag = item.FieldName;
                string nullText = "按 \"{0}\" 进行查询".FormatWith(item.Caption);
                if (item.IsDefault)
                {
                    this.txtSearchText.Properties.NullText = nullText;
                    this.txtSearchText.ToolTip = nullText;
                    this.btnQuery.ToolTip = nullText;
                    this.txtSearchText.Tag = item.FieldName;
                }

                bbi.ItemClick += (sender, args) =>
                {
                    this.txtSearchText.Properties.NullText = nullText;
                    this.txtSearchText.ToolTip = nullText;
                    this.btnQuery.ToolTip = nullText;
                    this.txtSearchText.Tag = args.Item.Tag;
                };
                this.popQucikFields.AddItem(bbi);
            }
        }

        public event EventHandler<QueryEventArgs> Query;

        private void FireQueryEvent()
        {
            var handler = Query;
            if (handler != null)
            {
                var args = new QueryEventArgs(GetSqlConditions());
                handler(this, args);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            FireQueryEvent();
        }

        private string GetSqlConditions()
        {
            if (this.btnQuery.DropDownControl == null || this.txtSearchText.Text.IsEmpty())
                return string.Empty;

            return QueryControlHelper.GenerateQuickQueryCondition(this.txtSearchText.Tag.ToString(), this.txtSearchText.EditValue.ToStringEx().Trim(), (QuickQueryType)btnQuery.Tag);
        }
        /// <summary>
        /// 附加条件
        /// </summary>
        public string AdditionalCondition { get; set; }
    }

    public class QueryEventArgs : EventArgs
    {
        public string Conditions { get; private set; }

        public QueryEventArgs(string conditions)
        {
            this.Conditions = conditions;
        }
    }
}
