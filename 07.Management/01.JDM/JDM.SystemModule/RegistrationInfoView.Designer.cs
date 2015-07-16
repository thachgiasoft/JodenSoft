namespace JDM.SystemModule
{
    partial class RegistrationInfoView
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
            this.grdIndex = new DevExpress.XtraGrid.GridControl();
            this.grvIndex = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegistrationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMachineCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pageResponse = new DevExpress.XtraTab.XtraTabPage();
            this.txtActivationResponse = new SAF.Framework.Controls.TextEditor.TextEditorControl();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.txtExpriedDate = new DevExpress.XtraEditors.DateEdit();
            this.txtRegistrationData = new DevExpress.XtraEditors.DateEdit();
            this.txtOnLineLimit = new DevExpress.XtraEditors.SpinEdit();
            this.cbxVersion = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtMachineCode = new DevExpress.XtraEditors.TextEdit();
            this.txtMachineName = new DevExpress.XtraEditors.TextEdit();
            this.cbxCustomer = new SAF.Framework.Controls.GridSearchEdit();
            this.txtIden = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).BeginInit();
            this.pageResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpriedDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpriedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationData.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnLineLimit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxVersion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.grdIndex);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(JDM.Entity.sysRegistrationInfo);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(JDM.Entity.sysRegistrationInfo);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // tcMain
            // 
            this.tcMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.Default;
            this.tcMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageResponse});
            this.tcMain.Controls.SetChildIndex(this.pageResponse, 0);
            this.tcMain.Controls.SetChildIndex(this.pageMain, 0);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            this.pageMain.Size = new System.Drawing.Size(489, 255);
            this.pageMain.Text = "注册信息";
            // 
            // grdIndex
            // 
            this.grdIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdIndex.DataSource = this.bsIndex;
            this.grdIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIndex.Location = new System.Drawing.Point(0, 2);
            this.grdIndex.MainView = this.grvIndex;
            this.grdIndex.MenuManager = this.ribbonMain;
            this.grdIndex.Name = "grdIndex";
            this.grdIndex.Size = new System.Drawing.Size(282, 284);
            this.grdIndex.TabIndex = 0;
            this.grdIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvIndex});
            // 
            // grvIndex
            // 
            this.grvIndex.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerName,
            this.colRegistrationDate,
            this.colMachineCode});
            this.grvIndex.GridControl = this.grdIndex;
            this.grvIndex.Name = "grvIndex";
            this.grvIndex.OptionsBehavior.Editable = false;
            this.grvIndex.OptionsBehavior.ReadOnly = true;
            this.grvIndex.OptionsView.ColumnAutoWidth = false;
            this.grvIndex.OptionsView.ShowGroupPanel = false;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户名称";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            // 
            // colRegistrationDate
            // 
            this.colRegistrationDate.Caption = "注册日期";
            this.colRegistrationDate.FieldName = "RegistrationDate";
            this.colRegistrationDate.Name = "colRegistrationDate";
            this.colRegistrationDate.Visible = true;
            this.colRegistrationDate.VisibleIndex = 1;
            // 
            // colMachineCode
            // 
            this.colMachineCode.Caption = "机器码";
            this.colMachineCode.FieldName = "MachineCode";
            this.colMachineCode.Name = "colMachineCode";
            this.colMachineCode.Visible = true;
            this.colMachineCode.VisibleIndex = 2;
            // 
            // pageResponse
            // 
            this.pageResponse.Controls.Add(this.txtActivationResponse);
            this.pageResponse.Name = "pageResponse";
            this.pageResponse.Size = new System.Drawing.Size(489, 255);
            this.pageResponse.Text = "授权文件";
            // 
            // txtActivationResponse
            // 
            this.txtActivationResponse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMain, "ActivationResponse", true));
            this.txtActivationResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActivationResponse.IsReadOnly = false;
            this.txtActivationResponse.Location = new System.Drawing.Point(0, 0);
            this.txtActivationResponse.Name = "txtActivationResponse";
            this.txtActivationResponse.Size = new System.Drawing.Size(489, 255);
            this.txtActivationResponse.TabIndex = 0;
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.txtExpriedDate);
            this.lcMain.Controls.Add(this.txtRegistrationData);
            this.lcMain.Controls.Add(this.txtOnLineLimit);
            this.lcMain.Controls.Add(this.cbxVersion);
            this.lcMain.Controls.Add(this.txtMachineCode);
            this.lcMain.Controls.Add(this.txtMachineName);
            this.lcMain.Controls.Add(this.cbxCustomer);
            this.lcMain.Controls.Add(this.txtIden);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(489, 255);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // txtExpriedDate
            // 
            this.txtExpriedDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "ExpiredDate", true));
            this.txtExpriedDate.EditValue = null;
            this.txtExpriedDate.Location = new System.Drawing.Point(297, 108);
            this.txtExpriedDate.MenuManager = this.ribbonMain;
            this.txtExpriedDate.Name = "txtExpriedDate";
            this.txtExpriedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExpriedDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExpriedDate.Size = new System.Drawing.Size(180, 20);
            this.txtExpriedDate.StyleController = this.lcMain;
            this.txtExpriedDate.TabIndex = 11;
            // 
            // txtRegistrationData
            // 
            this.txtRegistrationData.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "RegistrationDate", true));
            this.txtRegistrationData.EditValue = null;
            this.txtRegistrationData.Location = new System.Drawing.Point(63, 108);
            this.txtRegistrationData.MenuManager = this.ribbonMain;
            this.txtRegistrationData.Name = "txtRegistrationData";
            this.txtRegistrationData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRegistrationData.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtRegistrationData.Size = new System.Drawing.Size(179, 20);
            this.txtRegistrationData.StyleController = this.lcMain;
            this.txtRegistrationData.TabIndex = 10;
            // 
            // txtOnLineLimit
            // 
            this.txtOnLineLimit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "OnLineLimit", true));
            this.txtOnLineLimit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOnLineLimit.Location = new System.Drawing.Point(297, 84);
            this.txtOnLineLimit.MenuManager = this.ribbonMain;
            this.txtOnLineLimit.Name = "txtOnLineLimit";
            this.txtOnLineLimit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtOnLineLimit.Size = new System.Drawing.Size(180, 20);
            this.txtOnLineLimit.StyleController = this.lcMain;
            this.txtOnLineLimit.TabIndex = 9;
            // 
            // cbxVersion
            // 
            this.cbxVersion.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Version", true));
            this.cbxVersion.Location = new System.Drawing.Point(63, 84);
            this.cbxVersion.MenuManager = this.ribbonMain;
            this.cbxVersion.Name = "cbxVersion";
            this.cbxVersion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxVersion.Size = new System.Drawing.Size(179, 20);
            this.cbxVersion.StyleController = this.lcMain;
            this.cbxVersion.TabIndex = 8;
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MachineCode", true));
            this.txtMachineCode.Location = new System.Drawing.Point(63, 60);
            this.txtMachineCode.MenuManager = this.ribbonMain;
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Size = new System.Drawing.Size(414, 20);
            this.txtMachineCode.StyleController = this.lcMain;
            this.txtMachineCode.TabIndex = 7;
            // 
            // txtMachineName
            // 
            this.txtMachineName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MachineName", true));
            this.txtMachineName.Location = new System.Drawing.Point(63, 36);
            this.txtMachineName.MenuManager = this.ribbonMain;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(414, 20);
            this.txtMachineName.StyleController = this.lcMain;
            this.txtMachineName.TabIndex = 6;
            // 
            // cbxCustomer
            // 
            this.cbxCustomer.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "CustomerName", true));
            this.cbxCustomer.Location = new System.Drawing.Point(63, 12);
            this.cbxCustomer.MenuManager = this.ribbonMain;
            this.cbxCustomer.Name = "cbxCustomer";
            this.cbxCustomer.Properties.AutoClearSearchFiledsValue = true;
            this.cbxCustomer.Properties.AutoFillEntitySet = null;
            this.cbxCustomer.Properties.AutoFillFieldNames = null;
            this.cbxCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.cbxCustomer.Properties.ColumnHeaders = null;
            this.cbxCustomer.Properties.CommandText = null;
            this.cbxCustomer.Properties.ConnectionName = "Default";
            this.cbxCustomer.Properties.DisplayMember = null;
            this.cbxCustomer.Properties.PageSize = 50;
            this.cbxCustomer.Properties.PopupFormMinSize = new System.Drawing.Size(420, 380);
            this.cbxCustomer.Properties.SearchFileds = "";
            this.cbxCustomer.Properties.ShowPageControl = true;
            this.cbxCustomer.Properties.ShowPopupCloseButton = false;
            this.cbxCustomer.Size = new System.Drawing.Size(290, 20);
            this.cbxCustomer.StyleController = this.lcMain;
            this.cbxCustomer.TabIndex = 5;
            // 
            // txtIden
            // 
            this.txtIden.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Iden", true));
            this.txtIden.Location = new System.Drawing.Point(408, 12);
            this.txtIden.MenuManager = this.ribbonMain;
            this.txtIden.Name = "txtIden";
            this.txtIden.Size = new System.Drawing.Size(69, 20);
            this.txtIden.StyleController = this.lcMain;
            this.txtIden.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(489, 255);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtIden;
            this.layoutControlItem1.CustomizationFormText = "序号";
            this.layoutControlItem1.Location = new System.Drawing.Point(345, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(124, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(124, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(124, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "序号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbxCustomer;
            this.layoutControlItem2.CustomizationFormText = "客户";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(345, 24);
            this.layoutControlItem2.Text = "客户";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbxVersion;
            this.layoutControlItem5.CustomizationFormText = "软件版本";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(234, 24);
            this.layoutControlItem5.Text = "软件版本";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtOnLineLimit;
            this.layoutControlItem6.CustomizationFormText = "在线人数";
            this.layoutControlItem6.Location = new System.Drawing.Point(234, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem6.Text = "在线人数";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtRegistrationData;
            this.layoutControlItem7.CustomizationFormText = "注册日期";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(234, 139);
            this.layoutControlItem7.Text = "注册日期";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtExpriedDate;
            this.layoutControlItem8.CustomizationFormText = "到期日期";
            this.layoutControlItem8.Location = new System.Drawing.Point(234, 96);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(235, 139);
            this.layoutControlItem8.Text = "到期日期";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMachineName;
            this.layoutControlItem3.CustomizationFormText = "机器名";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem3.Text = "机器名";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtMachineCode;
            this.layoutControlItem4.CustomizationFormText = "机器码";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem4.Text = "机器码";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // RegistrationInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RegistrationInfoView";
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
            ((System.ComponentModel.ISupportInitialize)(this.grdIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvIndex)).EndInit();
            this.pageResponse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtExpriedDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpriedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationData.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRegistrationData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnLineLimit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxVersion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdIndex;
        private DevExpress.XtraGrid.Views.Grid.GridView grvIndex;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colRegistrationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineCode;
        private DevExpress.XtraTab.XtraTabPage pageResponse;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private SAF.Framework.Controls.TextEditor.TextEditorControl txtActivationResponse;
        private SAF.Framework.Controls.GridSearchEdit cbxCustomer;
        private DevExpress.XtraEditors.TextEdit txtIden;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit txtExpriedDate;
        private DevExpress.XtraEditors.DateEdit txtRegistrationData;
        private DevExpress.XtraEditors.SpinEdit txtOnLineLimit;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbxVersion;
        private DevExpress.XtraEditors.TextEdit txtMachineCode;
        private DevExpress.XtraEditors.TextEdit txtMachineName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
