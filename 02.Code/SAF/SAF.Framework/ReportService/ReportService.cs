using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using System.Data;
using SAF.Framework.View;
using SAF.Framework.Entity;

namespace SAF.Framework
{
    /// <summary>
    /// 报表服务
    /// </summary>
    public sealed class ReportService
    {
        private EntitySet<sysReport> reportEntitySet = new EntitySet<sysReport>();
        private EntitySet<sysReportFormat> reportFormatEntitySet = new EntitySet<sysReportFormat>();

        private BarButtonItem bbiReport;
        private IBaseView view;
        private string reportIds;
        private RibbonControl mainRibbonControl;

        private PopupMenu reportPopupMenu = new PopupMenu();
        private BarButtonItem bbiReport_Print = new BarButtonItem();

        private List<BarSubItem> listReportBarItems = new List<BarSubItem>();
        private List<BarCheckItem> listReportFormatBarItems = new List<BarCheckItem>();

        public sysReportFormat CurrReportFormat
        {
            get
            {
                var format = this.listReportFormatBarItems.FirstOrDefault(p => p.Checked);
                if (format == null)
                    throw new Exception("未找到默认报表");
                return format.Tag as sysReportFormat;
            }
        }

        private sysReport CurrReport
        {
            get
            {
                if (this.CurrReportFormat != null)
                    return reportEntitySet.FirstOrDefault(p => p.Iden == this.CurrReportFormat.ReportId);
                return null;
            }
        }

        public ReportService(IBaseView view, BarButtonItem bbiReport, string reportIds)
        {
            if (bbiReport == null)
                throw new ArgumentNullException("bbiReport");

            if (reportIds.IsEmpty())
                throw new ArgumentNullException("reportIds");

            this.view = view;
            this.bbiReport = bbiReport;
            this.reportIds = reportIds;
        }

        private void Initialize()
        {
            if (!(this.bbiReport.Manager is RibbonBarManager))
                throw new Exception("参数bbiReport必须包含在RibbonControl中.");

            QueryReport();
            QueryReportFormat();

            mainRibbonControl = (this.bbiReport.Manager as RibbonBarManager).Ribbon;
            InitializeReportPopupMenu();

            this.bbiReport.ButtonStyle = BarButtonStyle.DropDown;
            this.bbiReport.DropDownControl = reportPopupMenu;
        }

        private void QueryReport()
        {
            const string sql = @"
SELECT a.Iden,a.Name,a.SqlScript,a.DataSetAlias,a.ParamList,a.ParamValueList
FROM dbo.sysReport a WITH(NOLOCK)
JOIN dbo.SplitString(:Idens,',') b ON A.Iden=b.Item
WHERE IsActive=1";
            reportEntitySet.Query(sql, this.reportIds);
        }

        private void QueryReportFormat()
        {
            const string sql = @"
SELECT a.Iden,a.ReportId,a.OrderIndex,a.Name,a.IsDefault,a.Remark,FormatData=CAST(NULL AS VARBINARY)
FROM dbo.sysReportFormat a WITH(NOLOCK)
JOIN dbo.SplitString(:Idens,',') b ON A.ReportId=b.Item
WHERE a.IsActive=1
Order by a.OrderIndex";

            reportFormatEntitySet.Query(sql, this.reportIds);
        }

        private void InitializeReportPopupMenu()
        {
            reportPopupMenu.Name = "popupMenu_Rerort";
            reportPopupMenu.Ribbon = this.mainRibbonControl;

            bbiReport.ItemClick += bbiReport_Priview_ItemClick;

            bbiReport_Print = new BarButtonItem();
            bbiReport_Print.Name = "bbiReport_Print";
            bbiReport_Print.Glyph = Properties.Resources.Action_Print_16x16;
            bbiReport_Print.ItemClick += bbiReport_Print_ItemClick;
            this.mainRibbonControl.Items.Add(bbiReport_Print);
            reportPopupMenu.ItemLinks.Add(bbiReport_Print);

            //生成报表菜单
            foreach (var subItem in this.reportEntitySet)
            {
                var formatList = reportFormatEntitySet.Where(p => p.ReportId == subItem.Iden);
                bool hasDefaultFormat = reportFormatEntitySet.Any(p => p.IsDefault);

                if (formatList.Count() <= 0) continue;

                var barSubItem = new BarSubItem();
                barSubItem.Caption = subItem.Name;
                barSubItem.Glyph = Properties.Resources.BO_Report;
                this.mainRibbonControl.Items.Add(barSubItem);
                reportPopupMenu.ItemLinks.Add(barSubItem);
                listReportBarItems.Add(barSubItem);

                foreach (var item in formatList)
                {
                    var barCheckItem = new BarCheckItem();
                    barCheckItem.Caption = item.Name;
                    barCheckItem.Name = "bbiReport_ReportFormatList_{0}".FormatEx(item.Iden);
                    barCheckItem.GroupIndex = 100000;
                    barCheckItem.Checked = item.IsDefault;
                    barCheckItem.Tag = item;

                    barCheckItem.CheckedChanged += barCheckItem_CheckedChanged;
                    this.mainRibbonControl.Items.Add(barCheckItem);
                    barSubItem.ItemLinks.Add(barCheckItem);

                    listReportFormatBarItems.Add(barCheckItem);
                }

                if (!hasDefaultFormat && listReportFormatBarItems.Count > 0)
                {
                    listReportFormatBarItems[0].Checked = true;
                }
            }

            RefreshReportBarItemCaption();
        }

        private void RefreshReportBarItemCaption()
        {
            bbiReport_Print.Caption = "打印 {0}".FormatEx(CurrReportFormat.Name);
            bbiReport.Caption = "预览\n{0}".FormatEx(CurrReportFormat.Name);
        }

        private XtraReport GetCurrentReportFormat()
        {
            XtraReport report = null;
            if (CurrReportFormat == null)
            {
                report = new XtraReport();
                return report;
            }

            if (CurrReportFormat.FormatData == null || CurrReportFormat.FormatData.Length < 1)
            {
                var es = new EntitySet<sysReportFormat>();
                es.Query("SELECT FormatData FROM dbo.sysReportFormat WITH(NOLOCK) WHERE Iden=:Iden", CurrReportFormat.Iden);
                if (es.Count > 0)
                    CurrReportFormat.FormatData = es[0].FormatData;
            }

            if (CurrReportFormat.FormatData == null || CurrReportFormat.FormatData.Length < 1)
                report = new XtraReport();
            else
                report = XtraReport.FromStream(new MemoryStream(CurrReportFormat.FormatData), true);
            report.DisplayName = CurrReportFormat.Name;

            report.DataSource = GetReportDataSource();
            return report;
        }

        private DataSet GetReportDataSource()
        {
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
            var QueryParamValues = new List<object>();
            //从数据集中获取参数值
            var outParameters = view == null ? new ParameterDictionary() : view.OutParameters;
            outParameters.Add("session_UserId", Session.UserInfo.UserId);
            outParameters.Add("session_UserName", Session.UserInfo.UserName);
            outParameters.Add("session_UserFullName", Session.UserInfo.UserFullName);

            foreach (var item in QueryParams)
            {
                QueryParamValues.Add(outParameters[item.Trim()]);
            }

            var tables = listReleation.Select(p => p.PrimaryTableName.Trim()).ToArray();
            //加载数据
            DataPortal.LoadReportDataSet(ConfigContext.DefaultConnection, ds, tables, CurrReport.SqlScript, QueryParamValues.ToArray());

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
                        var name = "{0}_{1}".FormatEx(releation.ForeignTableName, releation.PrimaryTableName);
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


        void barCheckItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            RefreshReportBarItemCaption();
        }

        void bbiReport_Priview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = GetCurrentReportFormat();
            if (report != null)
            {
                PrintPreviewRibbonFormEx PreviewRibbonForm = new PrintPreviewRibbonFormEx();
                PreviewRibbonForm.Text = report.DisplayName + " - 预览";
                PreviewRibbonForm.PrintingSystem = report.PrintingSystem;
                PreviewRibbonForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Save, DevExpress.XtraPrinting.CommandVisibility.None);
                PreviewRibbonForm.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Open, DevExpress.XtraPrinting.CommandVisibility.None);
                var pageGroup = PreviewRibbonForm.RibbonControl.GetGroupByName("Close");
                if (pageGroup != null)
                {
                    pageGroup.Visible = false;
                    pageGroup.Enabled = false;
                }
                pageGroup = PreviewRibbonForm.RibbonControl.GetGroupByName("Document");
                if (pageGroup != null)
                {
                    pageGroup.Visible = false;
                    pageGroup.Enabled = false;
                }
                report.CreateDocument(true);
                PreviewRibbonForm.ShowDialog();
            }
            else
            {
                MessageService.ShowError("选中的报表为空，无法预览！");
            }
        }

        void bbiReport_Print_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = GetCurrentReportFormat();

            if (report != null)
            {
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.PrintDialog();
            }
            else
            {
                MessageService.ShowError("选中的报表为空，无法打印！");
            }
        }

        public static ReportService InitializeReport(IBaseView view, BarButtonItem bbiReport, string reportIds)
        {
            if (reportIds.IsEmpty())
                return null;

            var reportService = new ReportService(view, bbiReport, reportIds);
            reportService.Initialize();
            return reportService;
        }

    }
}
