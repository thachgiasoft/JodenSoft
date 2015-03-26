using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using SAF.EntityFramework;
using SAF.Framework.Controls.Entities;
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

namespace SAF.Framework.Controls
{
    /// <summary>
    /// 报表服务
    /// </summary>
    public sealed class ReportService
    {
        private EntitySet<sysReportConfig> reportConfigEntitySet = new EntitySet<sysReportConfig>();
        private EntitySet<sysReportConfigFormat> reportConfigFormatEntitySet = new EntitySet<sysReportConfigFormat>();

        private BarButtonItem bbiReport;
        private int reportConfigId;
        private RibbonControl mainRibbonControl;

        private PopupMenu reportPopupMenu = new PopupMenu();
        private BarButtonItem bbiReport_Print = new BarButtonItem();
        private BarButtonItem bbiReport_Priview = new BarButtonItem();
        private BarSubItem bbiReport_ReportFormatList = new BarSubItem();

        private sysReportConfigFormat currReportFormat = null;


        public sysReportConfig CurrReport
        {
            get { return reportConfigEntitySet[0]; }
        }

        public ReportService(BarButtonItem bbiReport, int reportConfigId)
        {
            this.bbiReport = bbiReport;
            this.reportConfigId = reportConfigId;
        }

        private void Initialize()
        {
            if (!(this.bbiReport.Manager is RibbonBarManager))
                throw new Exception("参数bbiReport必须包含在RibbonControl中.");

            QueryReportConfig();
            QueryReportConfigFormat();

            mainRibbonControl = (this.bbiReport.Manager as RibbonBarManager).Ribbon;
            InitializeReportPopupMenu();

            this.bbiReport.ButtonStyle = BarButtonStyle.DropDown;
            this.bbiReport.DropDownControl = reportPopupMenu;
        }

        private void QueryReportConfigFormat()
        {
            const string sql = @"
SELECT Iden,Name,SqlScript,TableList,ParamList,ParamValueList
FROM dbo.sysReportConfig WITH(NOLOCK)
WHERE Iden=:Iden AND IsActive=1";
            reportConfigEntitySet.Query(sql, this.reportConfigId);

        }

        private void QueryReportConfig()
        {
            const string sql = @"
SELECT Iden,ReportConfigId,RowNo,Name,IsDefault,Remark,FormatData=CAST(NULL AS IMAGE)
FROM dbo.sysReportConfigFormat WITH(NOLOCK)
WHERE ReportConfigId=:ReportConfigId
Order by RowNo";

            reportConfigFormatEntitySet.Query(sql, this.reportConfigId);
        }

        private void InitializeReportPopupMenu()
        {
            reportPopupMenu.Name = "popupMenu_RerortConfig";
            reportPopupMenu.Ribbon = this.mainRibbonControl;

            string defaultFormatName = string.Empty;
            if (this.reportConfigFormatEntitySet.Count > 0)
            {
                var defaultFormat = this.reportConfigFormatEntitySet.FirstOrDefault(p => p.IsDefault);
                if (defaultFormat == null)
                    defaultFormat = this.reportConfigFormatEntitySet.First();

                defaultFormatName = defaultFormat.Name;
            }

            bbiReport.ItemClick += bbiReport_Priview_ItemClick;

            bbiReport_Print = new BarButtonItem();
            bbiReport_Print.Caption = "打印 {0}".FormatEx(defaultFormatName);
            bbiReport_Print.Name = "bbiReport_Print";
            bbiReport_Print.ItemClick += bbiReport_Print_ItemClick;
            this.mainRibbonControl.Items.Add(bbiReport_Print);
            reportPopupMenu.ItemLinks.Add(bbiReport_Print);

            bbiReport_Priview = new BarButtonItem();
            bbiReport_Priview.Caption = "预览 {0}".FormatEx(defaultFormatName);
            bbiReport_Priview.Name = "bbiReport_Priview";
            bbiReport_Priview.ItemClick += bbiReport_Priview_ItemClick;
            this.mainRibbonControl.Items.Add(bbiReport_Priview);
            reportPopupMenu.ItemLinks.Add(bbiReport_Priview);

            if (reportConfigFormatEntitySet.Count > 0)
            {
                //初始化报表格式
                bbiReport_ReportFormatList.Caption = "报表格式";
                bbiReport_ReportFormatList.Name = "bbiReport_ReportFormatList";
                this.mainRibbonControl.Items.Add(bbiReport_ReportFormatList);
                reportPopupMenu.ItemLinks.Add(bbiReport_ReportFormatList, true);

                foreach (var item in reportConfigFormatEntitySet)
                {
                    var barCheckItem = new BarCheckItem();
                    barCheckItem.Caption = item.Name;
                    barCheckItem.Name = "bbiReport_ReportFormatList_{0}".FormatEx(item.Iden);
                    barCheckItem.GroupIndex = 12345678;
                    barCheckItem.Checked = item.IsDefault;
                    barCheckItem.Tag = item;
                    if (item.IsDefault)
                    {
                        currReportFormat = item;
                        bbiReport.Hint = item.Name;
                    }
                    barCheckItem.CheckedChanged += barCheckItem_CheckedChanged;
                    this.mainRibbonControl.Items.Add(barCheckItem);
                    bbiReport_ReportFormatList.ItemLinks.Add(barCheckItem);
                }
            }

        }

        private XtraReport GetReport()
        {
            XtraReport report = null;
            if (currReportFormat == null)
                report = new XtraReport();
            else if (currReportFormat.FormatData == null || currReportFormat.FormatData.Length < 1)
            {
                var es = new EntitySet<sysReportConfigFormat>();
                es.Query("SELECT FormatData FROM dbo.sysReportConfigFormat WITH(NOLOCK) WHERE Iden=:Iden", currReportFormat.Iden);
                if (es.Count > 0)
                    currReportFormat.FormatData = es[0].FormatData;
            }

            if (currReportFormat.FormatData == null || currReportFormat.FormatData.Length < 1)
                report = new XtraReport();
            else
                report = XtraReport.FromStream(new MemoryStream(currReportFormat.FormatData), true);
            report.DisplayName = currReportFormat.Name;

            report.DataSource = GetReportDataSource();
            return report;
        }

        private DataSet GetReportDataSource()
        {
            var ds = new DataSet("报表数据源");
            var tableNames = CurrReport.TableList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //解析表名和关系

            //解析参数
            var QueryParams = CurrReport.ParamList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var QueryParamValues = new List<object>();
            foreach (var item in QueryParams)
            {
                //从数据集中获取数据
            }

            //加载数据
            DataPortal.LoadReportDataSet(ConfigContext.DefaultConnection, ds, tableNames, CurrReport.SqlScript, null);

            //TODO:创建报表数据源表之间的关系.

            //
            var dt = new DataTable("图片");
            dt.Columns.Add("UserId", typeof(string));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("UserFullName", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TelephoneNo", typeof(string));

            dt.Columns.Add("UserImage", typeof(byte[]));
            dt.Columns.Add("UserSignImage", typeof(byte[]));
            dt.Rows.Add(Session.Current.UserId, Session.Current.UserName, Session.Current.UserFullName, Session.Current.Email, Session.Current.TelephoneNo,
                Session.Current.UserImage, Session.Current.UserSignImage);

            ds.Tables.Add(dt);

            return ds;
        }


        void barCheckItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            var checkItem = sender as BarCheckItem;
            var format = checkItem.Tag as sysReportConfigFormat;

            this.bbiReport_Print.Caption = "打印 {0}".FormatEx(format.Name);
            this.bbiReport_Priview.Caption = "预览 {0}".FormatEx(format.Name);

            currReportFormat = format;
            bbiReport.Hint = format.Name;
        }

        void bbiReport_Priview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var report = GetReport();
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
            var report = GetReport();

            if (report != null)
            {
                report.PrintDialog();
            }
            else
            {
                MessageService.ShowError("选中的报表为空，无法打印！");
            }
        }

        public static ReportService InitializeReport(BarButtonItem bbiReport, int reportConfigId)
        {
            var reportService = new ReportService(bbiReport, reportConfigId);
            reportService.Initialize();
            return reportService;
        }

    }
}
