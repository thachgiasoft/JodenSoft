namespace JNHT_ProdSys
{
    partial class BomTreeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BomTreeList));
            this.tlBom = new DevExpress.XtraTreeList.TreeList();
            this.BomChildId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BomChildDesc = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.UseQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.TotalUseQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgl = new System.Windows.Forms.ImageList(this.components);
            this.bsTl = new System.Windows.Forms.BindingSource(this.components);
            this.imgl1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tlBom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTl)).BeginInit();
            this.SuspendLayout();
            // 
            // tlBom
            // 
            this.tlBom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tlBom.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.BomChildId,
            this.BomChildDesc,
            this.UseQty,
            this.TotalUseQty});
            this.tlBom.ColumnsImageList = this.imgl;
            this.tlBom.DataSource = this.bsTl;
            this.tlBom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlBom.Location = new System.Drawing.Point(0, 0);
            this.tlBom.Name = "tlBom";
            this.tlBom.OptionsBehavior.Editable = false;
            this.tlBom.OptionsBehavior.PopulateServiceColumns = true;
            this.tlBom.OptionsFind.AllowFindPanel = true;
            this.tlBom.OptionsFind.FindNullPrompt = "";
            this.tlBom.OptionsPrint.AutoWidth = false;
            this.tlBom.OptionsView.AutoWidth = false;
            this.tlBom.OptionsView.ShowHorzLines = false;
            this.tlBom.OptionsView.ShowIndicator = false;
            this.tlBom.OptionsView.ShowVertLines = false;
            this.tlBom.SelectImageList = this.imgl1;
            this.tlBom.Size = new System.Drawing.Size(364, 580);
            this.tlBom.StateImageList = this.imgl;
            this.tlBom.TabIndex = 0;
            this.tlBom.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
            this.tlBom.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlBom_FocusedNodeChanged);
            this.tlBom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlBom_MouseDown);
            // 
            // BomChildId
            // 
            this.BomChildId.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.BomChildId.AppearanceCell.Options.UseBorderColor = true;
            this.BomChildId.Caption = "图号";
            this.BomChildId.FieldName = "BomChildId";
            this.BomChildId.MinWidth = 49;
            this.BomChildId.Name = "BomChildId";
            this.BomChildId.Visible = true;
            this.BomChildId.VisibleIndex = 0;
            this.BomChildId.Width = 186;
            // 
            // BomChildDesc
            // 
            this.BomChildDesc.Caption = "名称";
            this.BomChildDesc.FieldName = "BomChildDesc";
            this.BomChildDesc.Name = "BomChildDesc";
            this.BomChildDesc.Visible = true;
            this.BomChildDesc.VisibleIndex = 1;
            this.BomChildDesc.Width = 94;
            // 
            // UseQty
            // 
            this.UseQty.Caption = "单量";
            this.UseQty.FieldName = "UseQty";
            this.UseQty.Name = "UseQty";
            this.UseQty.Visible = true;
            this.UseQty.VisibleIndex = 2;
            this.UseQty.Width = 44;
            // 
            // TotalUseQty
            // 
            this.TotalUseQty.Caption = "总量";
            this.TotalUseQty.FieldName = "TotalUseQty";
            this.TotalUseQty.Name = "TotalUseQty";
            this.TotalUseQty.Visible = true;
            this.TotalUseQty.VisibleIndex = 3;
            this.TotalUseQty.Width = 37;
            // 
            // imgl
            // 
            this.imgl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl.ImageStream")));
            this.imgl.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl.Images.SetKeyName(0, "Icon_Form_16x16.png");
            this.imgl.Images.SetKeyName(1, "Folder_Closed.png");
            this.imgl.Images.SetKeyName(2, "Folder_Opened.png");
            // 
            // imgl1
            // 
            this.imgl1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl1.ImageStream")));
            this.imgl1.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl1.Images.SetKeyName(0, "Folder_Closed.png");
            // 
            // BomTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlBom);
            this.Name = "BomTreeList";
            this.Size = new System.Drawing.Size(364, 580);
            ((System.ComponentModel.ISupportInitialize)(this.tlBom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsTl;
        private DevExpress.XtraTreeList.Columns.TreeListColumn BomChildDesc;
        private DevExpress.XtraTreeList.Columns.TreeListColumn BomChildId;
        private System.Windows.Forms.ImageList imgl;
        private System.Windows.Forms.ImageList imgl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn UseQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn TotalUseQty;
        public DevExpress.XtraTreeList.TreeList tlBom;
    }
}
