namespace SAF.Framework.Controls.Charts
{
    partial class ChartControl
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
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDrawTools = new DevExpress.XtraBars.Bar();
            this.bbiPointer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRectangle = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEllipse = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLine = new DevExpress.XtraBars.BarButtonItem();
            this.barActions = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.bbiUndo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRedo = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDrawTools,
            this.barActions});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiPointer,
            this.bbiRectangle,
            this.bbiEllipse,
            this.bbiLine,
            this.bbiUndo,
            this.bbiRedo});
            this.barManager.MaxItemId = 8;
            // 
            // barDrawTools
            // 
            this.barDrawTools.BarName = "Tools";
            this.barDrawTools.DockCol = 0;
            this.barDrawTools.DockRow = 0;
            this.barDrawTools.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDrawTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPointer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRectangle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEllipse),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLine)});
            this.barDrawTools.Text = "Tools";
            // 
            // bbiPointer
            // 
            this.bbiPointer.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiPointer.Caption = "光标";
            this.bbiPointer.Down = true;
            this.bbiPointer.Glyph = global::SAF.Framework.Controls.Properties.Resources.StandardArrow;
            this.bbiPointer.GroupIndex = 1;
            this.bbiPointer.Id = 2;
            this.bbiPointer.Name = "bbiPointer";
            this.bbiPointer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPointer_ItemClick);
            // 
            // bbiRectangle
            // 
            this.bbiRectangle.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiRectangle.Caption = "正方形";
            this.bbiRectangle.Glyph = global::SAF.Framework.Controls.Properties.Resources.DrawRectangle;
            this.bbiRectangle.GroupIndex = 1;
            this.bbiRectangle.Id = 3;
            this.bbiRectangle.Name = "bbiRectangle";
            this.bbiRectangle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRectangle_ItemClick);
            // 
            // bbiEllipse
            // 
            this.bbiEllipse.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiEllipse.Caption = "椭圆";
            this.bbiEllipse.Glyph = global::SAF.Framework.Controls.Properties.Resources.DrawEllipse;
            this.bbiEllipse.GroupIndex = 1;
            this.bbiEllipse.Id = 4;
            this.bbiEllipse.Name = "bbiEllipse";
            this.bbiEllipse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEllipse_ItemClick);
            // 
            // bbiLine
            // 
            this.bbiLine.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiLine.Caption = "直线";
            this.bbiLine.Glyph = global::SAF.Framework.Controls.Properties.Resources.Connection;
            this.bbiLine.GroupIndex = 1;
            this.bbiLine.Id = 5;
            this.bbiLine.Name = "bbiLine";
            this.bbiLine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLine_ItemClick);
            // 
            // barActions
            // 
            this.barActions.BarName = "Actions";
            this.barActions.DockCol = 1;
            this.barActions.DockRow = 0;
            this.barActions.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barActions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRedo)});
            this.barActions.Text = "Actions";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(664, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 422);
            this.barDockControlBottom.Size = new System.Drawing.Size(664, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 391);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(664, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 391);
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.MenuManager = this.barManager;
            this.documentManager.View = this.tabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});
            // 
            // bbiUndo
            // 
            this.bbiUndo.Caption = "撤消";
            this.bbiUndo.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Undo;
            this.bbiUndo.Id = 6;
            this.bbiUndo.Name = "bbiUndo";
            this.bbiUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUndo_ItemClick);
            // 
            // bbiRedo
            // 
            this.bbiRedo.Caption = "重做";
            this.bbiRedo.Glyph = global::SAF.Framework.Controls.Properties.Resources.Action_Redo;
            this.bbiRedo.Id = 7;
            this.bbiRedo.Name = "bbiRedo";
            this.bbiRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRedo_ItemClick);
            // 
            // ChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ChartControl";
            this.Size = new System.Drawing.Size(664, 422);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barDrawTools;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Bar barActions;
        private DevExpress.XtraBars.BarButtonItem bbiPointer;
        private DevExpress.XtraBars.BarButtonItem bbiRectangle;
        private DevExpress.XtraBars.BarButtonItem bbiEllipse;
        private DevExpress.XtraBars.BarButtonItem bbiLine;
        private DevExpress.XtraBars.BarButtonItem bbiUndo;
        private DevExpress.XtraBars.BarButtonItem bbiRedo;

    }
}
