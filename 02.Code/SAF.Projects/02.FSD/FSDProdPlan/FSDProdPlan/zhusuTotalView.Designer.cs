namespace FSDProdPlan
{
    partial class zhusuTotalView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraCharts.GanttDiagram ganttDiagram1 = new DevExpress.XtraCharts.GanttDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView1 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView2 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView3 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView4 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.SideBySideGanttSeriesView sideBySideGanttSeriesView5 = new DevExpress.XtraCharts.SideBySideGanttSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).BeginInit();
            this.pnlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).BeginInit();
            this.pnlPageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(ganttDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView5)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // tcMain
            // 
            this.tcMain.SelectedTabPage = this.pageMain;
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.chartControl1);
            // 
            // chartControl1
            // 
            this.chartControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.chartControl1.DataSource = this.bsIndex;
            ganttDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            ganttDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = ganttDiagram1;
            this.chartControl1.Location = new System.Drawing.Point(66, 36);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Chameleon";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.DataSource = this.bsMain;
            series1.Name = "Series 1";
            series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
            series1.View = sideBySideGanttSeriesView1;
            series2.Name = "Series 2";
            series2.View = sideBySideGanttSeriesView2;
            series3.Name = "Series 3";
            series3.View = sideBySideGanttSeriesView3;
            series4.Name = "Series 4";
            series4.View = sideBySideGanttSeriesView4;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
            this.chartControl1.SeriesTemplate.View = sideBySideGanttSeriesView5;
            this.chartControl1.Size = new System.Drawing.Size(373, 175);
            this.chartControl1.TabIndex = 0;
            chartTitle1.Text = "注塑车间机台使用状况";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // zhusuTotalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "zhusuTotalView";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).EndInit();
            this.pnlQueryControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).EndInit();
            this.pnlPageControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(ganttDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideGanttSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
    }
}
