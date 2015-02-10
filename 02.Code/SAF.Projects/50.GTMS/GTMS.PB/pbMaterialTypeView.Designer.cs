namespace GTMS.PB
{
    partial class pbMaterialTypeView
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
            this.treeMenu = new DevExpress.XtraTreeList.TreeList();
            this.colMaterialTypeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.treeList = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            // 
            // splitMain
            // 
            this.splitMain.Panel1.Controls.Add(this.treeMenu);
            // 
            // bsIndex
            // 
            this.bsIndex.DataSource = typeof(GTMS.EntitySet.pbMaterialType);
            // 
            // bsMain
            // 
            this.bsMain.DataSource = typeof(GTMS.EntitySet.pbMaterialType);
            // 
            // pcMain
            // 
            this.pcMain.Size = new System.Drawing.Size(778, 26);
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.lcMain);
            // 
            // treeMenu
            // 
            this.treeMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colMaterialTypeName});
            this.treeMenu.CustomizationFormBounds = new System.Drawing.Rectangle(115, 373, 216, 190);
            this.treeMenu.DataSource = this.bsIndex;
            this.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMenu.KeyFieldName = "Iden";
            this.treeMenu.Location = new System.Drawing.Point(0, 2);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.OptionsBehavior.AutoChangeParent = false;
            this.treeMenu.OptionsBehavior.AutoNodeHeight = false;
            this.treeMenu.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeMenu.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeMenu.OptionsBehavior.Editable = false;
            this.treeMenu.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeMenu.OptionsBehavior.ResizeNodes = false;
            this.treeMenu.OptionsBehavior.SmartMouseHover = false;
            this.treeMenu.OptionsMenu.EnableFooterMenu = false;
            this.treeMenu.OptionsPrint.PrintHorzLines = false;
            this.treeMenu.OptionsPrint.PrintVertLines = false;
            this.treeMenu.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeMenu.OptionsView.ShowFocusedFrame = false;
            this.treeMenu.OptionsView.ShowHorzLines = false;
            this.treeMenu.OptionsView.ShowIndicator = false;
            this.treeMenu.OptionsView.ShowVertLines = false;
            this.treeMenu.ParentFieldName = "MaterialTypeId";
            this.treeMenu.Size = new System.Drawing.Size(282, 284);
            this.treeMenu.TabIndex = 2;
            this.treeMenu.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeMenu_FocusedNodeChanged_1);
            // 
            // colMaterialTypeName
            // 
            this.colMaterialTypeName.Caption = "全部物料类别";
            this.colMaterialTypeName.FieldName = "MaterialCode";
            this.colMaterialTypeName.Name = "colMaterialTypeName";
            this.colMaterialTypeName.Visible = true;
            this.colMaterialTypeName.VisibleIndex = 0;
            this.colMaterialTypeName.Width = 20;
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.treeList);
            this.lcMain.Controls.Add(this.checkEdit1);
            this.lcMain.Controls.Add(this.textEdit3);
            this.lcMain.Controls.Add(this.textEdit2);
            this.lcMain.Controls.Add(this.textEdit1);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(282, 214, 250, 350);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(489, 278);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "layoutControl1";
            // 
            // treeList
            // 
            this.treeList.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MaterialTypeId", true));
            this.treeList.EditValue = "";
            this.treeList.Location = new System.Drawing.Point(87, 60);
            this.treeList.MenuManager = this.ribbonMain;
            this.treeList.Name = "treeList";
            this.treeList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.treeList.Properties.NullText = "";
            this.treeList.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.treeList.Size = new System.Drawing.Size(390, 20);
            this.treeList.StyleController = this.lcMain;
            this.treeList.TabIndex = 9;
            this.treeList.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.treeList_ParseEditValue);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(192, 134);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // checkEdit1
            // 
            this.checkEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "Usabled", true));
            this.checkEdit1.Location = new System.Drawing.Point(12, 108);
            this.checkEdit1.MenuManager = this.ribbonMain;
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "是否可用";
            this.checkEdit1.Size = new System.Drawing.Size(465, 19);
            this.checkEdit1.StyleController = this.lcMain;
            this.checkEdit1.TabIndex = 7;
            // 
            // textEdit3
            // 
            this.textEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "sDescription", true));
            this.textEdit3.Location = new System.Drawing.Point(87, 84);
            this.textEdit3.MenuManager = this.ribbonMain;
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(390, 20);
            this.textEdit3.StyleController = this.lcMain;
            this.textEdit3.TabIndex = 6;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MaterialTypeName", true));
            this.textEdit2.Location = new System.Drawing.Point(87, 36);
            this.textEdit2.MenuManager = this.ribbonMain;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(390, 20);
            this.textEdit2.StyleController = this.lcMain;
            this.textEdit2.TabIndex = 5;
            // 
            // textEdit1
            // 
            this.textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bsMain, "MaterialTypeCode", true));
            this.textEdit1.Location = new System.Drawing.Point(87, 12);
            this.textEdit1.MenuManager = this.ribbonMain;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(390, 20);
            this.textEdit1.StyleController = this.lcMain;
            this.textEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(489, 278);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textEdit1;
            this.layoutControlItem1.CustomizationFormText = "物料类型编号";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem1.Text = "物料类型编号";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textEdit2;
            this.layoutControlItem2.CustomizationFormText = "物料类型名称";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem2.Text = "物料类型名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textEdit3;
            this.layoutControlItem3.CustomizationFormText = "描述";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem3.Text = "描述";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkEdit1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(469, 162);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.treeList;
            this.layoutControlItem5.CustomizationFormText = "上级物料";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem5.Text = "上级物料";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // pbMaterialTypeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "pbMaterialTypeView";
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
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeMenu;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraEditors.TreeListLookUpEdit treeList;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMaterialTypeName;
    }
}
