﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.Controls;
using SAF.Foundation;

namespace SAF.CommonConfig.CommonBill
{
    [ToolboxItem(true)]
    public partial class QueryConfigControl : BaseUserControl
    {
        private QueryConfig _QueryConfig = new QueryConfig();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public QueryConfig QueryConfig
        {
            get { return _QueryConfig; }
            set
            {
                if (value == null)
                    _QueryConfig = new QueryConfig();
                else
                    _QueryConfig = value;

                this.bsQuickQuery.DataSource = _QueryConfig.QuickQuery;
                this.bsQuickQueryFields.DataSource = _QueryConfig.QuickQuery.QueryFields;

                this.bsQuickQuery.ResetBindings(false);
                this.bsQuickQueryFields.ResetBindings(false);
            }
        }

        public void ResetBinding()
        {
            this.bsQuickQuery.ResetBindings(false);
            this.bsQuickQueryFields.ResetBindings(false);
        }

        public QueryConfigControl()
        {
            InitializeComponent();

            Init();
        }

        protected override void OnInit()
        {
            base.OnInit();

            Converter<QuickQueryType, string> conveter = p =>
            {
                switch (p)
                {
                    case QuickQueryType.Exact:
                        return "精确查找";
                    case QuickQueryType.Fuzzy:
                        return "模糊匹配";
                    case QuickQueryType.Combinatorial:
                        return "组合查找";
                    case QuickQueryType.LeftMatch:
                        return "左匹配";
                    default:
                        return string.Empty;
                }
            };
            cbxQuickQueryType.Properties.Items.AddEnum(conveter);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.bsQuickQueryFields.AddNew();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.bsQuickQueryFields.Count > 0)
                this.bsQuickQueryFields.RemoveCurrent();
        }

        private void btnUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grvFields.PostEditor();
            this.bsQuickQueryFields.MoveCurrentUp();
        }

        private void btnDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grvFields.PostEditor();
            this.bsQuickQueryFields.MoveCurrentDown();
        }
    }
}
