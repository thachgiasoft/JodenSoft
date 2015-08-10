using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.View;
using SAF.Framework.ViewModel;
using SAF.Foundation.MetaAttributes;
using SAF.Framework;
using SAF.EntityFramework;
using DevExpress.XtraEditors;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraReports.UserDesigner;
using SAF.CommonConfig.CommonReport;
using DevExpress.XtraPrinting;
using DevExpress.XtraBars.Docking;
using SAF.Foundation;
using System.Text.RegularExpressions;

namespace SAF.CommonConfig
{
    [BusinessObject("报表设计")]
    public partial class sysCommonReportView : MasterDetailView
    {
        public sysCommonReportView()
        {
            InitializeComponent();
        }

        protected override void OnInitEvent()
        {
            base.OnInitEvent();

            this.treeIndex.SelectImageList = this.ReportImages;
            this.treeIndex.GetSelectImage += treeIndex_GetSelectImage;
        }

        void treeIndex_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            treeIndex.BeginUpdate();
            try
            {
                var drv = this.treeIndex.GetDataRecordByNode(e.Node) as DataRowView;

                if (!drv.IsEmpty())
                {
                    if (drv["NodeType"].IsEmpty())
                    {
                        e.NodeImageIndex = 0;
                    }
                    else
                    {
                        var menuType = (NodeType)Convert.ToInt32(drv["NodeType"]);
                        if (menuType.In(NodeType.Folder))
                            e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
                        else
                            e.NodeImageIndex = 2;
                    }
                }
                else
                {
                    e.NodeImageIndex = e.Node.Expanded ? 1 : 0;
                }
            }
            finally
            {
                this.treeIndex.EndUpdate();
            }
        }

        protected override IBaseViewViewModel OnCreateViewModel()
        {
            return new sysCommonReportConfigViewViewModel();
        }

        public new sysCommonReportConfigViewViewModel ViewModel
        {
            get
            {
                return base.ViewModel as sysCommonReportConfigViewViewModel;
            }
        }

        protected override void OnRefreshUI()
        {
            base.OnRefreshUI();

            UIController.RefreshControl(txtIden, false);
            UIController.RefreshControl(txtParamList, false);

            this.txtParamList.Properties.Buttons[0].Enabled = !this.IsBrowse;
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();

            this.cbxParent.QueryPopUp += cbxParent_QueryPopUp;

            this.treeIndex.FocusedNodeChanged += treeIndex_FocusedNodeChanged;
        }

        void treeIndex_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.IndexRowChange();
        }

        void cbxParent_QueryPopUp(object sender, CancelEventArgs e)
        {
            InitEditor();
        }

        protected override void OnInitUI()
        {
            base.OnInitUI();

            this.cbxNodeType.Properties.Items.AddEnum(typeof(NodeType), true);

            InitEditor();

            this.pnlPageControl.Visible = false;
        }

        private void InitEditor()
        {
            var sql = @"
with result as
(
SELECT A.Iden,A.Name,A.ParentId 
FROM dbo.sysReport A WITH(NOLOCK) 
WHERE A.NodeType=1
UNION ALL
SELECT Iden=-1,Name='无',ParentId=-1
)

SELECT * FROM result 
ORDER BY ParentId, Iden
";
            var es = new EntitySet<QueryEntity>();
            es.Query(sql);
            this.cbxParent.Properties.SetDataSource(es.DefaultView, "Iden", "Name", "ParentId");
        }

        public override string InitCondition
        {
            get
            {
                return "1=1";
            }
        }

        private void cbxNodeType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (this.IsEdit && Convert.ToInt32(e.NewValue) == (int)NodeType.Folder)
            {
                if (this.ViewModel.DetailEntitySet.Count > 0)
                {
                    if (MessageService.AskQuestion("切换类型会删除已有的报表格式,确定要切换类型吗"))
                        this.ViewModel.DetailEntitySet.DeleteAll();
                    else
                        e.Cancel = true;
                }
            }

        }

        private void cbxNodeType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cbxNodeType.EditValue != null && Convert.ToInt32(this.cbxNodeType.EditValue) == (int)NodeType.Report)
            {
                this.lcMain.BeginUpdate();
                this.lciSqlScript.Visibility = LayoutVisibility.Always;
                this.lciDataSetAlias.Visibility = LayoutVisibility.Always;
                lciParamList.Visibility = LayoutVisibility.Always;
                lciParamValues.Visibility = LayoutVisibility.Always;
                this.lcMain.EndUpdate();

                this.splitRight.PanelVisibility = SplitPanelVisibility.Both;
            }
            else
            {
                this.splitRight.PanelVisibility = SplitPanelVisibility.Panel1;

                this.lcMain.BeginUpdate();
                this.lciSqlScript.Visibility = LayoutVisibility.Never;
                this.lciDataSetAlias.Visibility = LayoutVisibility.Never;
                lciParamList.Visibility = LayoutVisibility.Never;
                lciParamValues.Visibility = LayoutVisibility.Never;
                this.lcMain.EndUpdate();

                txtSqlScript.Clear();
                txtDataSetAlias.Clear();
                txtParamList.Clear();
                txtParamValues.Clear();
            }

        }

        private void bbiDesignReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reportBytes = this.ViewModel.DetailEntitySet.CurrentEntity.FormatData;
            XtraReport report = null;
            if (reportBytes == null || reportBytes.Length <= 0)
                report = new XtraReport();
            else
                report = XtraReport.FromStream(new MemoryStream(reportBytes), true);

            report.DisplayName = this.ViewModel.DetailEntitySet.CurrentEntity.Name;

            report.DataSource = GetReportDefaultDataSource();


            DesignReport(report);
        }

        private object GetReportDefaultDataSource()
        {
            var CurrReport = this.ViewModel.MainEntitySet.CurrentEntity;

            var ds = new DataSet("ReportDataSet");
            var tableNames = CurrReport.DataSetAlias.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //解析表名和关系
            var listReleation = new List<TableReleation>();
            foreach (var item in tableNames)
            {
                listReleation.Add(new TableReleation(item));
            }

            //解析参数
            var QueryParams = CurrReport.ParamList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var ParamValues = CurrReport.ParamValueList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var QueryParamValues = new Dictionary<string, object>();
            for (int i = 0; i < QueryParams.Length; i++)
            {
                object value = ParamValues.Length > i ? QueryParams[i] : null;
                if (value.ToStringEx().Trim() == "null")
                    value = null;
                QueryParamValues.Add(QueryParams[i], value);
            }

            var tables = listReleation.Select(p => p.PrimaryTableName.Trim()).ToArray();
            //加载数据
            DataPortal.LoadReportDataSet(ConfigContext.DefaultConnection, ds, tables, CurrReport.SqlScript, QueryParamValues.Select(p => p.Value).ToArray());

            //创建报表数据源表之间的关系.
            foreach (var releation in listReleation)
            {
                if (releation.FieldCount == 4)
                {
                    var primaryTable = ds.Tables[releation.PrimaryTableName];
                    var primaryColumn = primaryTable == null ? null : primaryTable.Columns[releation.PrimaryTableKeyName];

                    var ForeignTable = ds.Tables[releation.ForeignTableName];
                    var ForeignColumn = ForeignTable == null ? null : ForeignTable.Columns[releation.ForeignTableKeyName];

                    if (primaryColumn != null && ForeignColumn != null)
                    {
                        var name = "{0}_{1}".FormatWith(releation.ForeignTableName, releation.PrimaryTableName);
                        ds.Relations.Add(name, ForeignColumn, primaryColumn);
                    }
                }
            }

            //添加当前用户信息
            var dt = new DataTable("UserInfo");
            dt.Columns.Add("UserId", typeof(string));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("UserFullName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TelephoneNo", typeof(string));
            dt.Columns.Add("UserImage", typeof(byte[]));
            dt.Columns.Add("UserSignImage", typeof(byte[]));
            dt.Rows.Add(Session.UserInfo.UserId, Session.UserInfo.UserName, Session.UserInfo.UserFullName
                , Session.UserInfo.Email, Session.UserInfo.TelephoneNo
                , Session.UserInfo.UserImage, Session.UserInfo.UserSignImage);

            ds.Tables.Add(dt);

            return ds;

        }

        private void DesignReport(XtraReport report)
        {
            XRDesignRibbonForm desinger = new XRDesignRibbonForm();
            desinger.OpenReport(report);
            XRDesignPanel panel = desinger.ActiveDesignPanel;

            // Add a new command handler which saves a report in a custom way.
            panel.AddCommandHandler(new SaveCommandHandler(panel, this));
            panel.AddCommandHandler(new ClosingCommandHandler(panel));

            panel.SetCommandVisibility(ReportCommand.NewReportWizard, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);
            panel.SetCommandVisibility(ReportCommand.NewReport, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);
            panel.SetCommandVisibility(ReportCommand.ShowHTMLViewTab, DevExpress.XtraReports.UserDesigner.CommandVisibility.None);

            // Hide the dock panels.
            desinger.SetWindowVisibility(DesignDockPanelType.ToolBox, false);
            desinger.DesignDockManager[DesignDockPanelType.GroupAndSort].Visibility = DockVisibility.AutoHide;
            desinger.DesignDockManager[DesignDockPanelType.ErrorList].Visibility = DockVisibility.Hidden;
            desinger.DesignDockManager[DesignDockPanelType.ReportExplorer].Visibility = DockVisibility.Hidden;

            panel.Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Save, DevExpress.XtraPrinting.CommandVisibility.None);
            var pageGroup = desinger.RibbonControl.GetGroupByName("Document");
            if (pageGroup != null)
            {
                pageGroup.Visible = false;
            }

            desinger.ShowDialog();
        }

        protected override void OnRefreshDetailToolBar()
        {
            base.OnRefreshDetailToolBar();

            if (this.ViewModel == null) return;

            var count = this.ViewModel.DetailEntitySet.Count;
            UIController.RefreshControl(this.btnDesignReport, count > 0 && this.IsBrowse);

            UIController.RefreshControl(this.bbiDtlImport, false);
            UIController.ShowBarItem(false, this.bbiDtlImport);
        }

        private void txtParamList_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.ViewModel.ParaseParameters();
        }



    }

    public enum NodeType
    {
        /// <summary>
        /// 报表
        /// </summary>
        [Description("报表")]
        Report = 0,
        /// <summary>
        /// 目录
        /// </summary>
        [Description("目录")]
        Folder = 1
    }


}
