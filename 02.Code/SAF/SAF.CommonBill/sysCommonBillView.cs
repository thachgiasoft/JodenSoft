using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework;
using SAF.Foundation.MetaAttributes;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SAF.Foundation;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using SAF.EntityFramework;
using DevExpress.Utils;
using SAF.Framework.Controls.ViewConfig;
using SAF.CommonBill.Entities;

namespace SAF.CommonBill
{
    [BusinessObject("通用单据")]
    public partial class sysCommonBillView : MasterDetailView
    {
        public sysCommonBillView()
        {
            InitializeComponent();

            this.Shown += sysCommonBillView_Shown;
        }

        [Browsable(false)]
        [ViewParam("通用单据配置ID")]
        public virtual int CommonBillConfigId
        {
            get { return Convert.ToInt32(this.GetViewParam("CommonBillConfigId")); }
            set { this.SetViewParam("CommonBillConfigId", value.ToString()); }
        }

        protected override Framework.ViewModel.IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonBillViewViewModel() { View = this };
        }

        public new sysCommonBillViewViewModel ViewModel
        {
            get { return base.ViewModel as sysCommonBillViewViewModel; }
        }

        private List<GridView> gridViews = new List<GridView>();

        void sysCommonBillView_Shown(object sender, EventArgs e)
        {
            foreach (var grv in gridViews)
            {
                if (grv != null)
                    grv.BestFitColumns();
            }
        }

        private CommonBillConfig config = new CommonBillConfig();

        protected override void OnInitCommonBill()
        {
            base.OnInitCommonBill();

            var config = QueryBillConfg(this.CommonBillConfigId);

            CreateIndexControl(config.IndexEntitySetConfig);

            CreateMainControl(config.MainEntitySetConfig);

            CreateDetailsControl(config.DetailEntitySetConfigs);
        }

        private void CreateDetailsControl(IList<DetailEntitySetConfig> dtlConfigs)
        {
            this.tcDtl.TabPages.Clear();

            if (dtlConfigs == null || dtlConfigs.Count <= 0)
            {
                this.splitRight.PanelVisibility = SplitPanelVisibility.Panel1;
                return;
            }

            this.splitRight.PanelVisibility = SplitPanelVisibility.Both;

            if (dtlConfigs.Count <= 1)
                this.tcDtl.ShowTabHeader = DefaultBoolean.False;
            else
                this.tcDtl.ShowTabHeader = DefaultBoolean.True;


            for (int i = 0; i < dtlConfigs.Count; i++)
            {
                var config = dtlConfigs[i];

                var page = this.tcDtl.TabPages.Add();
                page.Padding = new System.Windows.Forms.Padding(1);
                page.Text = config.Caption.IsEmpty() ? "明细数据" + i : config.Caption;
                var bsDtl = new BindingSource();

                var dtlEntity = new EntitySet<QueryEntity>(this.ViewModel.ExecuteCache);
                dtlEntity.IsReadOnly = config.IsReadOnly;
                this.dtlEntitys.Add(dtlEntity);
                dtlEntity.SetBindingSource(bsDtl);

                if (config.ControlType == EntitySetControlType.GridControl)
                {
                    var grdDtl = new GridControl() { Name = "grdDtl_" + i };
                    var grvDtl = new GridView(grdDtl) { Name = "grvDtl_" + i };
                    gridViews.Add(grvDtl);
                    grvDtl.OptionsView.ColumnAutoWidth = false;
                    grvDtl.OptionsBehavior.Editable = true;

                    grdDtl.ViewCollection.Add(grvDtl);
                    grdDtl.MainView = grvDtl;

                    page.Controls.Add(grdDtl);
                    grdDtl.Dock = DockStyle.Fill;
                    grdDtl.DataSource = bsDtl;
                    this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);

                    foreach (var field in config.Fields)
                    {
                        var column = grvDtl.Columns.AddField(field.FieldName);
                        column.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                        column.OptionsColumn.ReadOnly = field.IsReadOnly;
                        column.OptionsColumn.AllowEdit = !field.IsReadOnly;
                        column.Visible = true;
                    }

                }
            }
        }

        private void CreateMainControl(EntitySetConfig mainConfig)
        {
            if (mainConfig == null) return;

            this.ViewModel.MainEntitySet.DbTableName = mainConfig.DbTableName;
            this.ViewModel.MainEntitySet.PrimaryKeyName = mainConfig.PrimaryKeyName;
            this.ViewModel.MainEntitySet.IsReadOnly = mainConfig.IsReadOnly;

            this.ViewModel.MainEntitySet.SetBindingSource(this.bsMain);

            int i = 0;
            foreach (var field in mainConfig.Fields)
            {
                LayoutControlItem lci = this.lcMain.Root.AddItem(field.Caption);
                i++;
                lci.Name = "lci_" + i;
                var edt = new TextEdit() { Name = "edt_" + i };
                edt.DataBindings.Add("EditValue", this.bsMain, field.FieldName);
                lci.Control = edt;
            }

        }

        private void CreateIndexControl(EntitySetConfig indexConfig)
        {
            if (indexConfig == null) return;

            this.ViewModel.IndexEntitySet.DbTableName = indexConfig.DbTableName;
            this.ViewModel.IndexEntitySet.PrimaryKeyName = indexConfig.PrimaryKeyName;
            this.ViewModel.IndexEntitySet.IsReadOnly = indexConfig.IsReadOnly;

            if (indexConfig.ControlType == EntitySetControlType.GridControl)
            {
                var grdIndex = new GridControl() { Name = "grdIndex" };
                var grvIndex = new GridView(grdIndex) { Name = "grvIndex" };
                gridViews.Add(grvIndex);
                grvIndex.OptionsView.ColumnAutoWidth = false;
                grvIndex.OptionsBehavior.Editable = false;

                grvIndex.FocusedRowChanged += (s, e) => { this.IndexRowChange(); };

                grdIndex.ViewCollection.Add(grvIndex);
                grdIndex.MainView = grvIndex;

                this.splitMain.Panel1.Controls.Add(grdIndex);
                grdIndex.Dock = DockStyle.Fill;
                grdIndex.DataSource = this.bsIndex;
                this.ViewModel.IndexEntitySet.SetBindingSource(this.bsIndex);

                foreach (var field in indexConfig.Fields)
                {
                    var column = grvIndex.Columns.AddField(field.FieldName);
                    column.Caption = field.Caption.IsEmpty() ? field.FieldName : field.Caption;
                    column.Visible = true;
                }
            }
        }
        /// <summary>
        /// 通用单据配置
        /// </summary>
        public CommonBillConfig CommonBillConfig = new CommonBillConfig();
        /// <summary>
        /// 通用单据查询实体
        /// </summary>
        public EntitySet<sysCommonBillConfig> CommonBillConfigEntitySet = new EntitySet<sysCommonBillConfig>();
        /// <summary>
        /// 所有明细实体集列表
        /// </summary>
        public List<EntitySet<QueryEntity>> dtlEntitys = new List<EntitySet<QueryEntity>>();
        /// <summary>
        /// 查询通用单据配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public CommonBillConfig QueryBillConfg(object key)
        {
            //            string sql = @"
            //SELECT a.Iden,a.Config,a.CreatedBy,a.CreatedOn,a.ModifiedBy,a.ModifiedOn,a.VersionNumber
            //FROM dbo.sysCommonBillConfig a WITH(NOLOCK)
            //WHERE Iden=:Iden";
            //            IndexEntitySet.Query(sql, key);
            //            if (IndexEntitySet.CurrentEntity == null || IndexEntitySet.CurrentEntity.Config.IsEmpty())
            //                return null;
            //            return XmlSerializerHelper.Deserialize<CommonBillConfig>(IndexEntitySet.CurrentEntity.Config);

            CommonBillConfig.QueryConfig.QuickQuery.QueryFields.Add(new QueryField("OrderNo", "订单号"));

            CommonBillConfig.IndexEntitySetConfig.DbTableName = "sdOrder";
            CommonBillConfig.IndexEntitySetConfig.PrimaryKeyName = "Iden";
            CommonBillConfig.IndexEntitySetConfig.Sql = "SELECT * FROM dbo.sdOrder with(nolock)";
            CommonBillConfig.IndexEntitySetConfig.IsReadOnly = true;
            CommonBillConfig.IndexEntitySetConfig.Fields.Add(new EntitySetField("Iden", "序号"));
            CommonBillConfig.IndexEntitySetConfig.Fields.Add(new EntitySetField("OrderNo", "订单号"));

            CommonBillConfig.MainEntitySetConfig.DbTableName = "sdOrder";
            CommonBillConfig.MainEntitySetConfig.PrimaryKeyName = "Iden";
            CommonBillConfig.MainEntitySetConfig.Sql = "SELECT * FROM dbo.sdOrder with(nolock) where Iden=:Iden";
            CommonBillConfig.MainEntitySetConfig.Fields.Add(new EntitySetField("Iden", "序号"));
            CommonBillConfig.MainEntitySetConfig.Fields.Add(new EntitySetField("OrderNo", "订单号"));

            //var dtlConfig = new DetailEntitySetConfig();
            //dtlConfig.DbTableName = "sdOrderDtl";
            //dtlConfig.PrimaryKeyName = "Iden";
            //dtlConfig.Caption = "订单明细";
            //dtlConfig.Sql = " SELECT * FROM [dbo].[sdOrderDtl] WITH(NOLOCK) WHERE OrderId=:Iden";
            //dtlConfig.Fields.Add(new EntitySetField("Iden", "序号", true));
            //dtlConfig.Fields.Add(new EntitySetField("Qty", "数量"));
            //CommonBillConfig.DetailEntitySetConfigs.Add(dtlConfig);

            //dtlConfig = new DetailEntitySetConfig();
            //dtlConfig.DbTableName = "sdOrderDtl";
            //dtlConfig.PrimaryKeyName = "Iden";
            //dtlConfig.Caption = "订单明细2";
            //dtlConfig.Sql = " SELECT * FROM [dbo].[sdOrderDtl] WITH(NOLOCK) WHERE OrderId=:Iden";
            //dtlConfig.Fields.Add(new EntitySetField("Iden", "序号", true));
            //dtlConfig.Fields.Add(new EntitySetField("Qty", "数量"));
            //CommonBillConfig.DetailEntitySetConfigs.Add(dtlConfig);

            return CommonBillConfig;

        }

    }
}
