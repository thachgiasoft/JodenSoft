
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using System.IO;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars;
using System.Reflection;
using SAF.Framework.Controls.Charts.ChartControlActions;


namespace SAF.Framework.Controls.Charts
{
    [ToolboxItem(true)]
    public partial class MenuChartControl : BaseUserControl, IChartControl
    {
        public MenuChartControl()
        {
            InitializeComponent();

            this._ActiveDrawArea = new DrawArea(this);

            this.Controls.Add(_ActiveDrawArea);
            _ActiveDrawArea.Dock = DockStyle.Fill;

            GenerateDefaultActions();

            this.Load += new EventHandler(MenuChartControl_Load);

        }

        public void HideMenu()
        {
            barTools.Visible = false;
        }

        /// <summary>
        /// 是否可以导出图片
        /// </summary>
        public void SetAllowExportImage(bool enabled)
        {
            this.bbiExportJpg.Enabled = enabled;
        }

        public bool ReadOnly
        {
            set
            {
                this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.Pointer;
                this.ActiveDrawArea.Cursor = Cursors.Default;
                this.ActiveDrawArea.ReadOnly = value;
                this.Refresh();
                this.SetStateOfMenuItem();
            }
            get
            {
                return this.ActiveDrawArea.ReadOnly;
            }
        }

        public event EventHandler ContextMenuBeforePop;

        public void ContextMenuBeforePopExecute()
        {
            var handler = ContextMenuBeforePop;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private DrawArea _ActiveDrawArea = null;
        public DrawArea ActiveDrawArea
        {
            get
            {
                return _ActiveDrawArea;
            }
        }


        private Dictionary<Keys, IChartControlEditAction> editactions = new Dictionary<Keys, IChartControlEditAction>();

        protected virtual void GenerateDefaultActions()
        {
        }

        public bool AddHandler(Keys keys, IChartControlEditAction action)
        {
            if (action == null) return false;
            if (editactions.ContainsKey(keys)) return false;
            editactions[keys] = action;
            return true;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return ExecuteDialogKey(keyData) || base.ProcessDialogKey(keyData);
        }

        private bool ExecuteDialogKey(Keys keyData)
        {
            IChartControlEditAction action = GetEditAction(keyData);

            if (action != null)
            {
                action.Execute(this);
                return true;
            }
            return false;
        }

        internal bool IsEditAction(Keys keyData)
        {
            return editactions.ContainsKey(keyData);
        }

        internal IChartControlEditAction GetEditAction(Keys keyData)
        {
            if (!IsEditAction(keyData))
            {
                return null;
            }
            return (IChartControlEditAction)editactions[keyData];
        }

        public new ContextMenuStrip ContextMenuStrip { get; set; }

        public event EventHandler<ChartControlSelectionChangedEventArg> SelectionChanged;

        private void FireChartControlSelectionChanged(IEnumerable<DrawObject> list)
        {
            var handler = SelectionChanged;
            if (handler != null)
            {
                handler(this, new ChartControlSelectionChangedEventArg(list));
            }
        }

        void drawArea_SelectionChanged(object sender, EventArgs e)
        {
            if (this.ActiveDrawArea == null) return;


            int _SelectionCount = this.ActiveDrawArea.GraphicsCollection.SelectionCount;
            if (_SelectionCount > 0)
            {
                var list = ActiveDrawArea.GraphicsCollection.Selection;

                FireChartControlSelectionChanged(list);
            }
            else
            {

                FireChartControlSelectionChanged(null);
            }

        }

        void MenuChartControl_Load(object sender, EventArgs e)
        {
            this.SetAllowExportImage(true);
            this.ReadOnly = true;

            // Submit to Idle event to set controls state at idle time
            Application.Idle += Application_Idle;

        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.SetStateOfMenuItem();
        }

        public void SetStateOfMenuItem()
        {
            bool activeAreaNotNull = this.ActiveDrawArea != null;
            bool hasObjects = (activeAreaNotNull && this.ActiveDrawArea.GraphicsCollection.Count > 0);
            bool hasSelectedObjects = (activeAreaNotNull && this.ActiveDrawArea.GraphicsCollection.SelectionCount > 0);

            this.bsiBringToFront.Enabled = hasSelectedObjects;
            this.bsiSendToBack.Enabled = hasSelectedObjects;

            // Undo, Redo
            this.bsiUndo.Enabled = activeAreaNotNull && this.ActiveDrawArea.CanUndo && !this.ActiveDrawArea.ReadOnly;
            this.bsiRedo.Enabled = activeAreaNotNull && this.ActiveDrawArea.CanRedo && !this.ActiveDrawArea.ReadOnly;

            this.bsiZoomOut.Enabled = activeAreaNotNull && this.ActiveDrawArea.Zoom > 0.2f;
            this.bsiZoomIn.Enabled = activeAreaNotNull;

            this.btnSaveAs.Enabled = activeAreaNotNull;

            this.bbiExportJpg.Enabled = activeAreaNotNull;

        }



        /// <summary>
        /// Save file
        /// </summary>
        private void CommandSaveAs()
        {
            var drawArea = this.ActiveDrawArea;

            string fileName = GetSaveFileName();
            if (string.IsNullOrWhiteSpace(fileName)) return;

            var bytes = drawArea.SaveToStream();
            File.WriteAllBytes(fileName, bytes);

        }

        private void CommandBringToFront()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.MoveSelectionToFront();
        }

        private void CommandSendToBack()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.MoveSelectionToBack();
        }

        /// <summary>
        /// Undo
        /// </summary>
        private void CommandUndo()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.Undo();
        }

        /// <summary>
        /// Redo
        /// </summary>
        private void CommandRedo()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.Redo();
        }

        private string GetExceptionMessage(Exception ex)
        {
            if (ex == null) return string.Empty;
            var tempEx = ex;
            StringBuilder sb = new StringBuilder();
            while (tempEx != null)
            {
                sb.AppendLine(tempEx.Message);
                tempEx = tempEx.InnerException;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Handle exception in OpenDocument function
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private void HandleLoadException(Exception ex)
        {
            MessageBox.Show("加载文件时出错." + "\n" + "出错原因: " + GetExceptionMessage(ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle exception in SaveDocument function
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private void HandleSaveException(Exception ex)
        {
            MessageBox.Show("保存文件时出错.\n" + "出错原因: " + GetExceptionMessage(ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandSaveAs();
        }

        private void bsiBringToFront_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandBringToFront();
        }

        private void bsiSendToBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandSendToBack();
        }

        private void bsiUndo_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandUndo();
        }

        private void bsiRedo_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandRedo();
        }

        private void bsiZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ZoomIn();
        }

        private void bsiZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ZoomOut();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Bindable(true)]
        public byte[] Data
        {
            get
            {
                if (this.ActiveDrawArea.GraphicsCollection.Count >= 0)
                    return this.ActiveDrawArea.SaveToStream();
                else
                    return default(byte[]);
            }
            set { this.ActiveDrawArea.LoadFromStream(value); }
        }

        public Point ConvertPointToClient(Point pt)
        {
            pt = this.ActiveDrawArea.PointToClient(pt);
            pt = ToolObject.UnzoomPoint(pt, this.ActiveDrawArea.Zoom);
            return pt;
        }

        private void bbiExportJpg_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea == null) return;

            string fileName = GetImageFileName();
            ActiveDrawArea.ExportToPng(fileName);
        }

        private string GetImageFileName()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存到图片...";
            dlg.Filter = "图片文件（*.png）|*.png";
            dlg.DefaultExt = "png";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName.ToString();
            }
            return string.Empty;

        }

        public string GetOpenFileName()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择图形文件...";
                openFileDialog.Filter = "苏州聚达图形文件(*.jdd)|*.jdd";
                openFileDialog.CheckFileExists = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DefaultExt = "jdd";
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public string GetSaveFileName()
        {
            var drawArea = this.ActiveDrawArea;

            string fileName = string.IsNullOrWhiteSpace(drawArea.Caption) ? "未命名" : drawArea.Caption.Trim() + ".jdd";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "保存文件...";
                saveFileDialog.Filter = "苏州聚达图形文件(*.jdd)|*.jdd";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "jdd";
                saveFileDialog.CheckPathExists = true;
                if (!string.IsNullOrWhiteSpace(fileName))
                    saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public UserControl View
        {
            get { return this; }
        }

        private void bbiCurror_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.Pointer;
        }

        private void bbiLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.InheritLine;
        }

        private void bbiRect_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.Swimlane;
        }
    }
}
