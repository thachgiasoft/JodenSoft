﻿namespace SAF.Framework.View
{
    partial class SingleView
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
            this.components = new System.ComponentModel.Container();
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExitView = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSend = new DevExpress.XtraBars.BarButtonItem();
            this.bbiApprove = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPreview = new DevExpress.XtraBars.BarButtonItem();
            this.pmuReport = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiReject = new DevExpress.XtraBars.BarButtonItem();
            this.systemPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupData = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupCooperation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupCustom = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupOperation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitRight = new DevExpress.XtraEditors.SplitContainerControl();
            this.tcMain = new DevExpress.XtraTab.XtraTabControl();
            this.pageMain = new DevExpress.XtraTab.XtraTabPage();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.bsIndex = new System.Windows.Forms.BindingSource(this.components);
            this.bsMain = new System.Windows.Forms.BindingSource(this.components);
            this.pnlQueryControl = new DevExpress.XtraEditors.PanelControl();
            this.qcMain = new SAF.Framework.Controls.QueryControl();
            this.pnlPageControl = new DevExpress.XtraEditors.PanelControl();
            this.pcMain = new SAF.Framework.Controls.PageControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).BeginInit();
            this.tcMain.SuspendLayout();
            this.pageMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).BeginInit();
            this.pnlQueryControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).BeginInit();
            this.pnlPageControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.bbiAddNew,
            this.bbiEdit,
            this.bbiSave,
            this.bbiDelete,
            this.bbiCancel,
            this.bbiExitView,
            this.bbiSend,
            this.bbiApprove,
            this.bbiPreview,
            this.bbiReject});
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 14;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.systemPage});
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(767, 145);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // bbiAddNew
            // 
            this.bbiAddNew.Caption = "新增";
            this.bbiAddNew.Id = 1;
            this.bbiAddNew.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_New_32x32;
            this.bbiAddNew.Name = "bbiAddNew";
            this.bbiAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "编辑";
            this.bbiEdit.Id = 2;
            this.bbiEdit.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Edit_32x32;
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "保存";
            this.bbiSave.Id = 3;
            this.bbiSave.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Save_32x32;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "删除";
            this.bbiDelete.Id = 6;
            this.bbiDelete.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Delete_32x32;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiCancel
            // 
            this.bbiCancel.Caption = "取消";
            this.bbiCancel.Id = 8;
            this.bbiCancel.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Cancel_32x32;
            this.bbiCancel.Name = "bbiCancel";
            this.bbiCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCancel_ItemClick);
            // 
            // bbiExitView
            // 
            this.bbiExitView.Caption = "关闭";
            this.bbiExitView.Description = "关闭当前窗口";
            this.bbiExitView.Id = 9;
            this.bbiExitView.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Close_32x32;
            this.bbiExitView.Name = "bbiExitView";
            this.bbiExitView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExit_ItemClick);
            // 
            // bbiSend
            // 
            this.bbiSend.Caption = "送审";
            this.bbiSend.Id = 10;
            this.bbiSend.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_SendToAudit_32x32;
            this.bbiSend.Name = "bbiSend";
            this.bbiSend.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSend_ItemClick);
            // 
            // bbiApprove
            // 
            this.bbiApprove.Caption = "通过";
            this.bbiApprove.Id = 11;
            this.bbiApprove.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Approvel_32x32;
            this.bbiApprove.Name = "bbiApprove";
            this.bbiApprove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiApprove_ItemClick);
            // 
            // bbiPreview
            // 
            this.bbiPreview.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiPreview.Caption = "预览";
            this.bbiPreview.DropDownControl = this.pmuReport;
            this.bbiPreview.Id = 12;
            this.bbiPreview.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Preview_32x32;
            this.bbiPreview.Name = "bbiPreview";
            // 
            // pmuReport
            // 
            this.pmuReport.Name = "pmuReport";
            this.pmuReport.Ribbon = this.ribbonMain;
            // 
            // bbiReject
            // 
            this.bbiReject.Caption = "驳回";
            this.bbiReject.Id = 13;
            this.bbiReject.LargeGlyph = global::SAF.Framework.Properties.Resources.Action_Reject_32x32;
            this.bbiReject.Name = "bbiReject";
            this.bbiReject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReject_ItemClick);
            // 
            // systemPage
            // 
            this.systemPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.groupData,
            this.groupCooperation,
            this.groupReport,
            this.groupCustom,
            this.groupOperation});
            this.systemPage.Name = "systemPage";
            this.systemPage.Text = "系统";
            // 
            // groupData
            // 
            this.groupData.AllowTextClipping = false;
            this.groupData.ItemLinks.Add(this.bbiAddNew);
            this.groupData.ItemLinks.Add(this.bbiEdit);
            this.groupData.ItemLinks.Add(this.bbiCancel);
            this.groupData.ItemLinks.Add(this.bbiDelete);
            this.groupData.ItemLinks.Add(this.bbiSave);
            this.groupData.MergeOrder = 10;
            this.groupData.Name = "groupData";
            this.groupData.ShowCaptionButton = false;
            this.groupData.Text = "数据";
            // 
            // groupCooperation
            // 
            this.groupCooperation.AllowTextClipping = false;
            this.groupCooperation.ItemLinks.Add(this.bbiSend);
            this.groupCooperation.ItemLinks.Add(this.bbiApprove);
            this.groupCooperation.ItemLinks.Add(this.bbiReject);
            this.groupCooperation.MergeOrder = 20;
            this.groupCooperation.Name = "groupCooperation";
            this.groupCooperation.ShowCaptionButton = false;
            this.groupCooperation.Text = "协作";
            // 
            // groupReport
            // 
            this.groupReport.AllowTextClipping = false;
            this.groupReport.ItemLinks.Add(this.bbiPreview);
            this.groupReport.MergeOrder = 30;
            this.groupReport.Name = "groupReport";
            this.groupReport.ShowCaptionButton = false;
            this.groupReport.Text = "报表";
            // 
            // groupCustom
            // 
            this.groupCustom.AllowTextClipping = false;
            this.groupCustom.MergeOrder = 70;
            this.groupCustom.Name = "groupCustom";
            this.groupCustom.ShowCaptionButton = false;
            this.groupCustom.Text = "自定义";
            // 
            // groupOperation
            // 
            this.groupOperation.AllowTextClipping = false;
            this.groupOperation.ItemLinks.Add(this.bbiExitView);
            this.groupOperation.MergeOrder = 100;
            this.groupOperation.Name = "groupOperation";
            this.groupOperation.ShowCaptionButton = false;
            this.groupOperation.Text = "操作";
            // 
            // splitMain
            // 
            this.splitMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 173);
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.splitMain.Panel1.Text = "Panel1";
            this.splitMain.Panel2.Controls.Add(this.splitRight);
            this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.splitMain.Panel2.Text = "Panel2";
            this.splitMain.Size = new System.Drawing.Size(767, 271);
            this.splitMain.SplitterPosition = 282;
            this.splitMain.TabIndex = 0;
            this.splitMain.Text = "splitContainerControl1";
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Horizontal = false;
            this.splitRight.Location = new System.Drawing.Point(0, 2);
            this.splitRight.Name = "splitRight";
            this.splitRight.Panel1.Controls.Add(this.tcMain);
            this.splitRight.Panel1.Text = "Panel1";
            this.splitRight.Panel2.Text = "Panel2";
            this.splitRight.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1;
            this.splitRight.Size = new System.Drawing.Size(480, 267);
            this.splitRight.SplitterPosition = 132;
            this.splitRight.TabIndex = 1;
            this.splitRight.Text = "splitContainerControl1";
            // 
            // tcMain
            // 
            this.tcMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcMain.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedTabPage = this.pageMain;
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.tcMain.Size = new System.Drawing.Size(480, 267);
            this.tcMain.TabIndex = 0;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageMain});
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Name = "pageMain";
            this.pageMain.Size = new System.Drawing.Size(474, 261);
            this.pageMain.Text = "主数据";
            // 
            // lcMain
            // 
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(474, 261);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // lcgMain
            // 
            this.lcgMain.CustomizationFormText = "lcgMain";
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgMain.Size = new System.Drawing.Size(474, 261);
            this.lcgMain.Text = "lcgMain";
            this.lcgMain.TextVisible = false;
            // 
            // pnlQueryControl
            // 
            this.pnlQueryControl.Controls.Add(this.qcMain);
            this.pnlQueryControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueryControl.Location = new System.Drawing.Point(0, 145);
            this.pnlQueryControl.Name = "pnlQueryControl";
            this.pnlQueryControl.Size = new System.Drawing.Size(767, 28);
            this.pnlQueryControl.TabIndex = 2;
            // 
            // qcMain
            // 
            this.qcMain.AdditionalCondition = null;
            this.qcMain.Location = new System.Drawing.Point(2, 3);
            this.qcMain.MaximumSize = new System.Drawing.Size(250, 22);
            this.qcMain.MinimumSize = new System.Drawing.Size(250, 22);
            this.qcMain.Name = "qcMain";
            this.qcMain.Size = new System.Drawing.Size(250, 22);
            this.qcMain.TabIndex = 0;
            // 
            // pnlPageControl
            // 
            this.pnlPageControl.Controls.Add(this.pcMain);
            this.pnlPageControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPageControl.Location = new System.Drawing.Point(0, 444);
            this.pnlPageControl.Name = "pnlPageControl";
            this.pnlPageControl.Size = new System.Drawing.Size(767, 31);
            this.pnlPageControl.TabIndex = 3;
            // 
            // pcMain
            // 
            this.pcMain.CurrentPageIndex = 1;
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.IsSimpleMode = false;
            this.pcMain.Location = new System.Drawing.Point(2, 2);
            this.pcMain.MaximumSize = new System.Drawing.Size(0, 26);
            this.pcMain.MinimumSize = new System.Drawing.Size(410, 26);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(763, 26);
            this.pcMain.TabIndex = 0;
            this.pcMain.TotalPageCount = 0;
            this.pcMain.TotalRecordCount = 0;
            // 
            // SingleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlPageControl);
            this.Controls.Add(this.pnlQueryControl);
            this.Controls.Add(this.ribbonMain);
            this.Name = "SingleView";
            this.Size = new System.Drawing.Size(767, 475);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmuReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcMain)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.pageMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQueryControl)).EndInit();
            this.pnlQueryControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPageControl)).EndInit();
            this.pnlPageControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        protected DevExpress.XtraEditors.SplitContainerControl splitMain;
        protected System.Windows.Forms.BindingSource bsIndex;
        protected System.Windows.Forms.BindingSource bsMain;
        protected DevExpress.XtraEditors.PanelControl pnlQueryControl;
        protected DevExpress.XtraBars.Ribbon.RibbonPage systemPage;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupData;
        protected DevExpress.XtraBars.BarButtonItem bbiAddNew;
        protected DevExpress.XtraBars.BarButtonItem bbiEdit;
        protected DevExpress.XtraBars.BarButtonItem bbiSave;
        protected DevExpress.XtraBars.BarButtonItem bbiDelete;
        protected DevExpress.XtraBars.BarButtonItem bbiCancel;
        protected DevExpress.XtraEditors.PanelControl pnlPageControl;
        protected Controls.PageControl pcMain;
        protected Controls.QueryControl qcMain;
        protected DevExpress.XtraLayout.LayoutControl lcMain;
        protected DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupOperation;
        protected DevExpress.XtraBars.BarButtonItem bbiExitView;
        protected DevExpress.XtraEditors.SplitContainerControl splitRight;
        protected DevExpress.XtraTab.XtraTabControl tcMain;
        protected DevExpress.XtraTab.XtraTabPage pageMain;
        protected DevExpress.XtraBars.BarButtonItem bbiSend;
        protected DevExpress.XtraBars.BarButtonItem bbiApprove;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupCooperation;
        protected DevExpress.XtraBars.BarButtonItem bbiPreview;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupReport;
        protected DevExpress.XtraBars.PopupMenu pmuReport;
        protected DevExpress.XtraBars.Ribbon.RibbonPageGroup groupCustom;
        private DevExpress.XtraBars.BarButtonItem bbiReject;
    }
}
