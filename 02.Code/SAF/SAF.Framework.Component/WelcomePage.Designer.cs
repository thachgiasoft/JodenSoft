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
            this.components = new System.ComponentModel.Container();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.widgetView1 = new DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView(this.components);
            this.NoticeDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.ToDoListDocument = new DevExpress.XtraBars.Docking2010.Views.Widget.Document(this.components);
            this.stackGroup1 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            this.stackGroup2 = new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.ShowThumbnailsInTaskBar = DevExpress.Utils.DefaultBoolean.False;
            this.documentManager1.View = this.widgetView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.widgetView1});
            // 
            // widgetView1
            // 
            this.widgetView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.NoticeDocument,
            this.ToDoListDocument});
            this.widgetView1.StackGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup[] {
            this.stackGroup1,
            this.stackGroup2});
            // 
            // NoticeDocument
            // 
            this.NoticeDocument.Caption = "系统公告";
            this.NoticeDocument.ControlName = "Notice";
            this.NoticeDocument.ControlTypeName = "SAF.Framework.Component.WelcomePageControl.Notice";
            this.NoticeDocument.Height = 429;
            this.NoticeDocument.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.NoticeDocument.Width = 325;
            // 
            // ToDoListDocument
            // 
            this.ToDoListDocument.Caption = "待办事项";
            this.ToDoListDocument.ControlName = "ToDo";
            this.ToDoListDocument.ControlTypeName = "SAF.Framework.Component.WelcomePageControl.ToDoList";
            this.ToDoListDocument.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            // 
            // stackGroup1
            // 
            this.stackGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.Document[] {
            this.NoticeDocument});
            // 
            // stackGroup2
            // 
            this.stackGroup2.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Widget.Document[] {
            this.ToDoListDocument});
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "WelcomePage";
            this.Size = new System.Drawing.Size(692, 388);
            this.Text = "起始页";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widgetView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToDoListDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stackGroup2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.WidgetView widgetView1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document NoticeDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.Document ToDoListDocument;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Widget.StackGroup stackGroup2;
    }
}
