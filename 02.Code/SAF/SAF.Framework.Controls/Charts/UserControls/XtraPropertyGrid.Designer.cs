using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Frames;
using DevExpress.XtraEditors.Controls;

namespace SAF.Framework.Controls.Charts
{
    partial class XtraPropertyGrid
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
            this.pnlHint = new NotePanelEx();
            this.barManager1 = new BarManager(this.components);
            this.bMain = new Bar();
            this.bciCategories = new BarCheckItem();
            this.bciAlphabetical = new BarCheckItem();
            this.biDescription = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.lbCaption = new System.Windows.Forms.Label();
            this.pncDescription = new PanelControl();
            this.propertyGridControl1 = new PropertyGridControl();
            this.repositoryItemCheckEdit1 = new RepositoryItemCheckEdit();
            this.repositoryItemColorEdit1 = new RepositoryItemColorEdit();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pncDescription)).BeginInit();
            this.pncDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHint
            // 
            this.pnlHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHint.ForeColor = System.Drawing.Color.Black;
            this.pnlHint.Location = new System.Drawing.Point(3, 30);
            this.pnlHint.MaxRows = 10;
            this.pnlHint.Name = "pnlHint";
            this.pnlHint.Size = new System.Drawing.Size(266, 23);
            this.pnlHint.TabIndex = 0;
            this.pnlHint.TabStop = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new Bar[] {
            this.bMain});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] {
            this.bciCategories,
            this.bciAlphabetical,
            this.biDescription});
            this.barManager1.MaxItemId = 3;
            // 
            // bMain
            // 
            this.bMain.BarName = "Main";
            this.bMain.DockCol = 0;
            this.bMain.DockRow = 0;
            this.bMain.DockStyle = BarDockStyle.Top;
            this.bMain.LinksPersistInfo.AddRange(new LinkPersistInfo[] {
            new LinkPersistInfo(this.bciCategories),
            new LinkPersistInfo(this.bciAlphabetical),
            new LinkPersistInfo(this.biDescription, true)});
            this.bMain.OptionsBar.AllowDelete = true;
            this.bMain.OptionsBar.AllowQuickCustomization = false;
            this.bMain.OptionsBar.DrawDragBorder = false;
            this.bMain.OptionsBar.UseWholeRow = true;
            this.bMain.Text = "Main";
            // 
            // bciCategories
            // 
            this.bciCategories.GroupIndex = 1;
            this.bciCategories.Hint = "Categorized";
            this.bciCategories.Id = 0;
            this.bciCategories.ImageIndex = 0;
            this.bciCategories.Name = "bciCategories";
            this.bciCategories.CheckedChanged += new ItemClickEventHandler(this.bci_CheckedChanged);
            // 
            // bciAlphabetical
            // 
            this.bciAlphabetical.GroupIndex = 1;
            this.bciAlphabetical.Hint = "Alphabetic";
            this.bciAlphabetical.Id = 1;
            this.bciAlphabetical.ImageIndex = 1;
            this.bciAlphabetical.Name = "bciAlphabetical";
            this.bciAlphabetical.CheckedChanged += new ItemClickEventHandler(this.bci_CheckedChanged);
            // 
            // biDescription
            // 
            this.biDescription.ButtonStyle = BarButtonStyle.Check;
            this.biDescription.Hint = "Show Description";
            this.biDescription.Id = 2;
            this.biDescription.ImageIndex = 2;
            this.biDescription.Name = "biDescription";
            this.biDescription.DownChanged += new ItemClickEventHandler(this.biDescription_DownChanged);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(272, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 400);
            this.barDockControlBottom.Size = new System.Drawing.Size(272, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 369);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(272, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 369);
            // 
            // lbCaption
            // 
            this.lbCaption.BackColor = System.Drawing.SystemColors.Info;
            this.lbCaption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbCaption.Location = new System.Drawing.Point(3, 6);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(266, 24);
            this.lbCaption.TabIndex = 5;
            this.lbCaption.Text = "(PropertyName)";
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pncDescription
            // 
            this.pncDescription.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.pncDescription.Appearance.Options.UseBackColor = true;
            this.pncDescription.Controls.Add(this.lbCaption);
            this.pncDescription.Controls.Add(this.pnlHint);
            this.pncDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pncDescription.Location = new System.Drawing.Point(0, 344);
            this.pncDescription.LookAndFeel.Style = LookAndFeelStyle.Flat;
            this.pncDescription.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pncDescription.Name = "pncDescription";
            this.pncDescription.Size = new System.Drawing.Size(272, 56);
            this.pncDescription.TabIndex = 6;
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.DefaultEditors.AddRange(new DefaultEditor[] {
            new DefaultEditor(typeof(bool), this.repositoryItemCheckEdit1),
            new DefaultEditor(typeof(System.Drawing.Color), this.repositoryItemColorEdit1)});
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 33);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.RepositoryItems.AddRange(new RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemColorEdit1});
            this.propertyGridControl1.Size = new System.Drawing.Size(272, 309);
            this.propertyGridControl1.TabIndex = 7;
            this.propertyGridControl1.FocusedRowChanged += new FocusedRowChangedEventHandler(this.propertyGridControl1_FocusedRowChanged);
            this.propertyGridControl1.CellValueChanging += new CellValueChangedEventHandler(this.propertyGridControl1_CellValueChanging);
            this.propertyGridControl1.CellValueChanged += new CellValueChangedEventHandler(this.propertyGridControl1_CellValueChanged);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            this.repositoryItemColorEdit1.TextEditStyle = TextEditStyles.Standard;
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 31);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(272, 2);
            this.pnlTop.TabIndex = 8;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 342);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(272, 2);
            this.pnlBottom.TabIndex = 9;
            // 
            // XtraPropertyGrid
            // 
            this.Controls.Add(this.propertyGridControl1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pncDescription);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "XtraPropertyGrid";
            this.Size = new System.Drawing.Size(272, 400);
            this.Resize += new System.EventHandler(this.XtraPropertyGrid_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pncDescription)).EndInit();
            this.pncDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        private NotePanelEx pnlHint;
        private BarManager barManager1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private Bar bMain;
        private System.Windows.Forms.Label lbCaption;
        private PanelControl pncDescription;
        private PropertyGridControl propertyGridControl1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private BarCheckItem bciCategories;
        private BarCheckItem bciAlphabetical;
        private BarButtonItem biDescription;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemColorEdit repositoryItemColorEdit1;
    }
}
