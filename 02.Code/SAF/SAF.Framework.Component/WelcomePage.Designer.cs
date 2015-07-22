namespace SAF.Framework.Component
{
    partial class WelcomePage
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomePage));
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager();
            this.widgetView1 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView();
            this.NoticeDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document();
            this.ToDoListDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document();
            this.AuditListDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document();
            this.rowDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.rowDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.columnDefinition1 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition2 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            this.columnDefinition3 = new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditListDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.Images = this.imageCollection;
            this.documentManager.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.documentManager.View = this.widgetView1;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetView1});
            // 
            // widgetView1
            // 
            this.widgetView1.Columns.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition[] {
            this.columnDefinition1,
            this.columnDefinition2,
            this.columnDefinition3});
            this.widgetView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.NoticeDocument,
            this.ToDoListDocument,
            this.AuditListDocument});
            this.widgetView1.LayoutMode = DevExpress.XtraBars.Docking2010.Views.Widget.LayoutMode.TableLayout;
            this.widgetView1.Rows.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition[] {
            this.rowDefinition1,
            this.rowDefinition2});
            // 
            // NoticeDocument
            // 
            this.NoticeDocument.Caption = "系统公告";
            this.NoticeDocument.ColumnSpan = 2;
            this.NoticeDocument.ControlName = "Notice";
            this.NoticeDocument.ControlTypeName = "SAF.Framework.Component.WelcomePageControl.Notice";
            this.NoticeDocument.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("刷新", null, 0, DevExpress.XtraBars.Docking2010.HorizontalImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, serializableAppearanceObject4, null, null, -1)});
            this.NoticeDocument.Height = 300;
            this.NoticeDocument.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.NoticeDocument.Width = 325;
            // 
            // ToDoListDocument
            // 
            this.ToDoListDocument.Caption = "待办事项";
            this.ToDoListDocument.ColumnIndex = 2;
            this.ToDoListDocument.ControlName = "ToDo";
            this.ToDoListDocument.ControlTypeName = "SAF.Framework.Component.WelcomePageControl.ToDoList";
            this.ToDoListDocument.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("刷新", null, 0, DevExpress.XtraBars.Docking2010.HorizontalImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, serializableAppearanceObject5, null, null, -1)});
            this.ToDoListDocument.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            // 
            // AuditListDocument
            // 
            this.AuditListDocument.Caption = "待审单据";
            this.AuditListDocument.ColumnSpan = 3;
            this.AuditListDocument.ControlName = "AuditList";
            this.AuditListDocument.ControlTypeName = "SAF.Framework.Component.WelcomePageControl.AuditList";
            this.AuditListDocument.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("刷新", null, 0, DevExpress.XtraBars.Docking2010.HorizontalImageLocation.Default, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", false, -1, true, null, true, false, true, serializableAppearanceObject6, null, null, -1)});
            this.AuditListDocument.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.AuditListDocument.RowIndex = 1;
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.InsertImage(global::SAF.Framework.Component.Properties.Resources.Action_Refresh_16x16, "Action_Refresh_16x16", typeof(global::SAF.Framework.Component.Properties.Resources), 0);
            this.imageCollection.Images.SetKeyName(0, "Action_Refresh_16x16");
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WelcomePage";
            this.Size = new System.Drawing.Size(692, 453);
            this.Text = "起始页";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AuditListDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnDefinition3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document NoticeDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document ToDoListDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document AuditListDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition rowDefinition1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.RowDefinition rowDefinition2;
        private DevExpress.Utils.ImageCollection imageCollection;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition2;
        private DevExpress.XtraBars.Docking2010.Views.Widget.ColumnDefinition columnDefinition3;
    }
}
