namespace SAF.CommonConfig.CommonBill
{
    partial class DetailEntitySetConfigControl
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lbxDetailEntities = new DevExpress.XtraEditors.ListBoxControl();
            this.standaloneDetail = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.detailConfigControl = new SAF.CommonConfig.CommonBill.EntitySetConfigControl();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDetail = new DevExpress.XtraBars.Bar();
            this.btnAddNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnUp = new DevExpress.XtraBars.BarButtonItem();
            this.btnDown = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bsDetail = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbxDetailEntities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lbxDetailEntities);
            this.splitContainerControl1.Panel1.Controls.Add(this.standaloneDetail);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.detailConfigControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(816, 346);
            this.splitContainerControl1.SplitterPosition = 153;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // lbxDetailEntities
            // 
            this.lbxDetailEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDetailEntities.Location = new System.Drawing.Point(1, 31);
            this.lbxDetailEntities.Name = "lbxDetailEntities";
            this.lbxDetailEntities.Size = new System.Drawing.Size(152, 314);
            this.lbxDetailEntities.TabIndex = 1;
            // 
            // standaloneDetail
            // 
            this.standaloneDetail.CausesValidation = false;
            this.standaloneDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneDetail.Location = new System.Drawing.Point(1, 0);
            this.standaloneDetail.Name = "standaloneDetail";
            this.standaloneDetail.Size = new System.Drawing.Size(152, 31);
            this.standaloneDetail.Text = "standaloneBarDockControl1";
            // 
            // detailConfigControl
            // 
            this.detailConfigControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailConfigControl.Location = new System.Drawing.Point(0, 0);
            this.detailConfigControl.Name = "detailConfigControl";
            this.detailConfigControl.Size = new System.Drawing.Size(658, 346);
            this.detailConfigControl.TabIndex = 0;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDetail});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockControls.Add(this.standaloneDetail);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddNew,
            this.btnDelete,
            this.btnUp,
            this.btnDown});
            this.barManager.MaxItemId = 4;
            // 
            // barDetail
            // 
            this.barDetail.BarName = "DetailTools";
            this.barDetail.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Standalone;
            this.barDetail.DockCol = 0;
            this.barDetail.DockRow = 0;
            this.barDetail.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barDetail.FloatLocation = new System.Drawing.Point(62, 147);
            this.barDetail.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUp, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDown)});
            this.barDetail.OptionsBar.AllowQuickCustomization = false;
            this.barDetail.OptionsBar.DrawDragBorder = false;
            this.barDetail.OptionsBar.UseWholeRow = true;
            this.barDetail.StandaloneBarDockControl = this.standaloneDetail;
            this.barDetail.Text = "Tools";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Caption = "新增";
            this.btnAddNew.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_New_16x16;
            this.btnAddNew.Id = 0;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddNew_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "删除";
            this.btnDelete.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Delete_16x16;
            this.btnDelete.Id = 1;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnUp
            // 
            this.btnUp.Caption = "上移";
            this.btnUp.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Up_16x16;
            this.btnUp.Id = 2;
            this.btnUp.Name = "btnUp";
            this.btnUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUp_ItemClick);
            // 
            // btnDown
            // 
            this.btnDown.Caption = "下移";
            this.btnDown.Glyph = global::SAF.CommonConfig.Properties.Resources.Action_Down_16x16;
            this.btnDown.Id = 3;
            this.btnDown.Name = "btnDown";
            this.btnDown.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDown_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(816, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 346);
            this.barDockControlBottom.Size = new System.Drawing.Size(816, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 346);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(816, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 346);
            // 
            // DetailEntitySetConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DetailEntitySetConfigControl";
            this.Size = new System.Drawing.Size(816, 346);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbxDetailEntities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ListBoxControl lbxDetailEntities;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneDetail;
        private EntitySetConfigControl detailConfigControl;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barDetail;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAddNew;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private System.Windows.Forms.BindingSource bsDetail;
        private DevExpress.XtraBars.BarButtonItem btnUp;
        private DevExpress.XtraBars.BarButtonItem btnDown;
    }
}
