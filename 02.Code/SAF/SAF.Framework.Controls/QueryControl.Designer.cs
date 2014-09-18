namespace SAF.Framework.Controls
{
    partial class QueryControl
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
            this.btnQuery = new DevExpress.XtraEditors.DropDownButton();
            this.popQucikFields = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bmQueryControl = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtSearchText = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popQucikFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmQueryControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Image = global::SAF.Framework.Controls.Properties.Resources.Action_Search_16x16;
            this.btnQuery.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnQuery.Location = new System.Drawing.Point(201, 1);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(48, 20);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.ToolTip = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // popQucikFields
            // 
            this.popQucikFields.Manager = this.bmQueryControl;
            this.popQucikFields.Name = "popQucikFields";
            // 
            // bmQueryControl
            // 
            this.bmQueryControl.DockControls.Add(this.barDockControlTop);
            this.bmQueryControl.DockControls.Add(this.barDockControlBottom);
            this.bmQueryControl.DockControls.Add(this.barDockControlLeft);
            this.bmQueryControl.DockControls.Add(this.barDockControlRight);
            this.bmQueryControl.Form = this;
            this.bmQueryControl.MaxItemId = 8;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(250, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 22);
            this.barDockControlBottom.Size = new System.Drawing.Size(250, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 22);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(250, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 22);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(1, 1);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Size = new System.Drawing.Size(199, 20);
            this.txtSearchText.TabIndex = 1;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSearchText);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximumSize = new System.Drawing.Size(250, 22);
            this.MinimumSize = new System.Drawing.Size(250, 22);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(250, 22);
            ((System.ComponentModel.ISupportInitialize)(this.popQucikFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmQueryControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DropDownButton btnQuery;
        private DevExpress.XtraEditors.TextEdit txtSearchText;
        private DevExpress.XtraBars.PopupMenu popQucikFields;
        private DevExpress.XtraBars.BarManager bmQueryControl;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
