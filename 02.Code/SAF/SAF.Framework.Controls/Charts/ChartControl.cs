
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using System.Runtime.Serialization;
using System.Security;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraTab;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraBars;
using System.Security.AccessControl;
using System.Reflection;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using SAF.Framework.Controls.Charts.ChartControlActions;


namespace SAF.Framework.Controls.Charts
{
    [ToolboxItem(true)]
    public partial class ChartControl : BaseUserControl
    {
        /// <summary>
        /// 是否可以保存
        /// </summary>
        internal void SetAllowSave(bool enabled)
        {
            this.bsiSave.Enabled = enabled;
        }

        /// <summary>
        /// 是否可以导出图片
        /// </summary>
        internal void SetAllowExportImage(bool enabled)
        {
            this.bbiExportJpg.Enabled = enabled;
        }

        internal void SetReadOnly(bool value)
        {
            if (this.ActiveDrawArea != null)
            {
                this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.Pointer;
                this.ActiveDrawArea.Cursor = Cursors.Default;
            }

            if (value)
            {

                GetTopDockPanel(this.dpToolbox).Close();
                GetTopDockPanel(this.dpProperty).Close();

            }
            else
            {

                GetTopDockPanel(this.dpProperty).Close();

                GetTopDockPanel(this.dpToolbox).Visibility = DockVisibility.Visible;
                GetTopDockPanel(this.dpToolbox).Width = 120;

            }
            this.Refresh();

            this.SetStateOfMenuItem();
        }

        public event EventHandler ContextMenuBeforePop;

        internal void ContextMenuBeforePopExecute()
        {
            var handler = ContextMenuBeforePop;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void SetDiagramType(DiagramType diagramType)
        {
            ClearToolbar();
            if (diagramType != DiagramType.None)
            {
                CreateToolbar();
            }
        }

        public ChartControl()
        {
            InitializeComponent();

            GenerateDefaultActions();

            this.Load += new EventHandler(FlowChartControl_Load);
            this.MaxDocumentCount = 50;

            Application.Idle += Application_Idle;

        }

        private int _MaxDocumentCount = 50;
        /// <summary>
        /// 打开的最多文档数
        /// </summary>
        public int MaxDocumentCount
        {
            get { return this._MaxDocumentCount; }
            set
            {
                if (value <= 0) value = 1;
                this._MaxDocumentCount = value;
            }
        }

        public DrawArea ActiveDrawArea
        {
            get
            {
                if (this.tabbedView.ActiveDocument == null) return null;
                return this.tabbedView.ActiveDocument.Control as DrawArea;
            }
        }
        /// <summary>
        /// 获取打开的文件列表
        /// </summary>
        public IEnumerable<DrawArea> DrawAreas
        {
            get
            {
                var list = new List<DrawArea>();
                if (this.tabbedView.Documents != null)
                {
                    foreach (var item in this.tabbedView.Documents)
                    {
                        var area = item.Control as DrawArea;
                        list.Add(area);
                    }
                }
                return list;
            }
        }

        private Dictionary<Keys, IChartControlEditAction> editactions = new Dictionary<Keys, IChartControlEditAction>();

        protected virtual void GenerateDefaultActions()
        {
            editactions[Keys.S | Keys.Control] = new SaveAction();

            editactions[Keys.S | Keys.Shift | Keys.Control] = new SaveAllAction();

            editactions[Keys.E | Keys.Control] = new EditAction();
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
                action.m_Execute(this);
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

            this.cttPropertyGrid1.PropertyGrid.SelectedObjects = null;
            this.cttPropertyGrid1.PropertyGrid.SelectedObject = null;
            int _SelectionCount = this.ActiveDrawArea.GraphicsCollection.SelectionCount;
            if (_SelectionCount > 0)
            {
                var list = ActiveDrawArea.GraphicsCollection.Selection;
                this.cttPropertyGrid1.PropertyGrid.SelectedObjects = list.ToArray();

                FireChartControlSelectionChanged(list);
            }
            else
            {
                this.cttPropertyGrid1.PropertyGrid.Rows.Clear();

                FireChartControlSelectionChanged(null);
            }

        }

        private Document _AddDocument(int id, string header)
        {
            int count = this.tabbedView.Documents == null ? 0 : this.tabbedView.Documents.Count;
            if (count + 1 > this.MaxDocumentCount)
            {
                MessageBox.Show("打开的文档数量超出了最大文档数,请关闭一些文档后再打开新的文档.", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var drawArea = new DrawArea(this);
            drawArea.DiagramTypeChanged += drawArea_DiagramTypeChanged;
            drawArea.DirtyChanged += drawArea_DirtyChanged;
            drawArea.Dock = DockStyle.Fill;
            drawArea.ReadOnly = true;

            drawArea.ID = id;
            drawArea.Caption = string.IsNullOrWhiteSpace(header) ? id.ToString() : header;

            DocumentSettings settings = new DocumentSettings();
            settings.Caption = GetDocumentCaption(drawArea);

            DocumentSettings.Attach(drawArea, settings);

            var doc = tabbedView.AddDocument(drawArea) as Document;
            doc.Tooltip = drawArea.Caption;
            tabbedView.ActivateDocument(drawArea);

            return doc;
        }

        void drawArea_DirtyChanged(object sender, DirtyChangedEventArg e)
        {
            if (e.DrawArea == null) return;
            if (this.tabbedView.Documents == null) return;

            //var doc = this.tabbedView.Documents.FirstOrDefault(p => (p.Control as DrawArea).ID == e.DrawArea.ID);

            BaseDocument doc = null;
            this.tabbedView.Documents.TryGetValue(e.DrawArea, out doc);

            if (doc == null) return;

            if (e.Dirty)
            {
                if (!doc.Caption.EndsWith("*"))
                    doc.Caption = doc.Caption + " *";
            }
            else
            {
                if (doc.Caption.EndsWith("*"))
                    doc.Caption = doc.Caption.Substring(0, doc.Caption.Length - 1);
            }
        }

        void FlowChartControl_Load(object sender, EventArgs e)
        {
            tabbedView.DocumentProperties.AllowFloat = false;
            tabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;
            tabbedView.DocumentClosing += tabbedView_DocumentClosing;
            tabbedView.DocumentClosed += tabbedView_DocumentClosed;
            tabbedView.DocumentActivated += tabbedView_DocumentActivated;

            this.bbiDrag.Enabled = false;
            this.bbiDrag.Visibility = BarItemVisibility.Never;

            this.SetAllowSave(true);
            this.SetAllowExportImage(true);
            this.SetReadOnly(true);

            this.cttPropertyGrid1.PropertyValueChanged += cttPropertyGrid1_PropertyValueChanged;
            this.cttPropertyGrid1.PropertyValueChanging += cttPropertyGrid1_PropertyValueChanging;
            // Submit to Idle event to set controls state at idle time
            Application.Idle += Application_Idle;

        }

        void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
        {
            if (this.ActiveDrawArea != null)
            {
                this.ActiveDrawArea.Focus();
            }
            else
            {
                this.Focus();
            }

            if (this.ActiveDrawArea == null)
            {
                var panel = GetTopDockPanel(this.dpToolbox);
                if (panel != null && panel.Visibility != DockVisibility.Hidden)
                    panel.Close();

                panel = GetTopDockPanel(this.dpProperty);
                if (panel != null && panel.Visibility != DockVisibility.Hidden)
                    panel.Close();
            }
        }

        public event DocumentEventHandler DocumentActivated;

        public void ActivateDocument(int iDiagramId)
        {
            var obj = this.DrawAreas.FirstOrDefault(p => p.ID == iDiagramId && p.ID != int.MinValue);
            if (obj != null)
                this.tabbedView.ActivateDocument(obj);
        }

        void tabbedView_DocumentActivated(object sender, DocumentEventArgs e)
        {
            if (this.ActiveDrawArea != null)
            {
                this.SetReadOnly(this.ActiveDrawArea.ReadOnly);
                this.SetAllowSave(this.ActiveDrawArea.AllowSaveAs);
                this.SetAllowExportImage(this.ActiveDrawArea.AllowExportImage);
                this.SetDiagramType(this.ActiveDrawArea.DiagramType);
            }

            var handler = DocumentActivated;
            if (handler != null)
            {
                handler(sender, e);
            }

            if (this.ActiveDrawArea != null)
            {
                this.ActiveDrawArea.SelectionChanged -= drawArea_SelectionChanged;
                this.ActiveDrawArea.SelectionChanged += drawArea_SelectionChanged;

                this.ActiveDrawArea.FireSelectionChanged();
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.SetStateOfMenuItem();
        }

        private CommandChangeState commandChangeState;

        void cttPropertyGrid1_PropertyValueChanging(object sender, EventArgs e)
        {
            if (this.ActiveDrawArea != null)
            {
                commandChangeState = new CommandChangeState(ActiveDrawArea.GraphicsCollection);
            }
        }

        void cttPropertyGrid1_PropertyValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveDrawArea != null)
            {
                commandChangeState.NewState(ActiveDrawArea.GraphicsCollection);
                ActiveDrawArea.AddCommandToHistory(commandChangeState);
                commandChangeState = null;
                ActiveDrawArea.SetDirty();
                this.ActiveDrawArea.Refresh();
            }
        }


        /// <summary>
        /// 初始化工具栏
        /// </summary>
        private void CreateToolbar()
        {
            if (this.ActiveDrawArea == null) return;

            NavBarItem nbiItem = null;

            nbiItem = CreateNodeItem("指针", GraphicsType.Pointer);
            this.nbgGraphics.ItemLinks.Add(new NavBarItemLink(nbiItem));

            var fields = typeof(GraphicsType).GetFields(BindingFlags.Static | BindingFlags.Public);

            Dictionary<NavBarItem, int> dic = new Dictionary<NavBarItem, int>();

            foreach (var fi in fields)
            {
                var arr = Attribute.GetCustomAttributes(fi, typeof(GraphicsDisplayAttribute), false);
                if (arr != null && arr.Length > 0)
                {
                    if (arr.Any(p => ((GraphicsDisplayAttribute)p).DiagramType == this.ActiveDrawArea.DiagramType))
                    {
                        var gdAttr = arr.First(p => ((GraphicsDisplayAttribute)p).DiagramType == this.ActiveDrawArea.DiagramType) as GraphicsDisplayAttribute;

                        var value = fi.GetValue(null);
                        string caption = value.ToString();

                        caption = gdAttr.Name;
                        nbiItem = CreateNodeItem(caption, (GraphicsType)value);
                        dic.Add(nbiItem, gdAttr.Index);
                    }
                }
            }

            foreach (var item in dic.OrderBy(p => p.Value))
            {
                this.nbgGraphics.ItemLinks.Add(new NavBarItemLink(item.Key));
            }

        }

        private void ClearToolbar()
        {
            this.nbgGraphics.ItemLinks.Clear();
        }

        private NavBarItem CreateNodeItem(string caption, GraphicsType nodeType)
        {
            var item = new NavBarItem();
            item.Caption = caption;
            this.navToolBox.Items.Add(item);
            item.Tag = nodeType;
            item.LinkClicked += (sender, args) =>
            {
                if (args.Link.Item.Tag == null) return;
                GraphicsType nt = (GraphicsType)args.Link.Item.Tag;
                if (this.ActiveDrawArea != null)
                {
                    this.ActiveDrawArea.CurrentGraphicsType = nt;
                    this.ActiveDrawArea.LastGraphicsType = nt;
                }
            };
            return item;
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

            this.btnEdit.Enabled = activeAreaNotNull && this.ActiveDrawArea.ReadOnly;

            this.bsiSave.Enabled = activeAreaNotNull && this.ActiveDrawArea.Dirty && !this.ActiveDrawArea.ReadOnly;

            this.btnSaveAll.Enabled = this.DrawAreas.Any(p => p.Dirty && !p.ReadOnly);

            this.btnSaveAs.Enabled = activeAreaNotNull && this.ActiveDrawArea.AllowSaveAs;

            this.bbiExportJpg.Enabled = activeAreaNotNull && this.ActiveDrawArea.AllowExportImage;

            this.btnRefresh.Enabled = activeAreaNotNull;

            this.bsiPropertyWindow.Enabled = activeAreaNotNull;
            this.bsiDescriptionWindow.Enabled = activeAreaNotNull;
            this.bsiToolboxWindow.Enabled = activeAreaNotNull;

            //if (!activeAreaNotNull)
            //{
            //    var panel = GetTopDockPanel(this.dpToolbox);
            //    if (panel != null && panel.Visibility != DockVisibility.Hidden)
            //        panel.Close();

            //    panel = GetTopDockPanel(this.dpProperty);
            //    if (panel != null && panel.Visibility != DockVisibility.Hidden)
            //        panel.Close();

            //    panel = GetTopDockPanel(this.dpDescription);
            //    if (panel != null && panel.Visibility != DockVisibility.Hidden)
            //        panel.Close();
            //}
        }

        private List<IChartPad> chartPadList = new List<IChartPad>();

        public void AddChartPad(IChartPad chartPad)
        {
            bool hasChanged = false;
            if (chartPadList.All(p => p.Id != chartPad.Id))
            {
                chartPadList.Add(chartPad);
                hasChanged = true;
            }
            if (hasChanged)
            {
                InitialChartPads();
            }
        }

        private void InitialChartPads()
        {
            foreach (var item in chartPadList)
            {
                var dockPanel = this.dockManager.AddPanel(DockingStyle.Right);
                dockPanel.Controls.Add(item.View);
                item.View.Dock = DockStyle.Fill;
                dockPanel.ID = item.Id;
                dockPanel.Location = new System.Drawing.Point(0, 0);
                dockPanel.Name = "{0}_{1}".FormatEx2("chartPad", item.Id.ToString().Replace("-", "").Replace("{", "").Replace("}", ""));
                dockPanel.Options.AllowDockBottom = false;
                dockPanel.Options.AllowDockLeft = false;
                dockPanel.Options.AllowDockTop = false;
                dockPanel.Options.AllowFloating = false;
                dockPanel.Options.FloatOnDblClick = false;
                dockPanel.Text = item.Caption;
                //dockPanel.Visibility = DockVisibility.AutoHide;
            }
        }

        private string GetDocumentCaption(DrawArea drawArea)
        {
            if (drawArea == null || string.IsNullOrWhiteSpace(drawArea.Caption)) return string.Empty;

            return (drawArea.Caption.Length > 6 ? drawArea.Caption.Substring(0, 6) + "..." : drawArea.Caption.PadRight(6, ' ')) + (drawArea.Dirty ? "*" : "");
        }

        /// <summary>
        /// Save file
        /// </summary>
        private void CommandSaveAs(DrawArea drawArea)
        {
            if (drawArea == null) return;

            string fileName = GetSaveUMLFileName(drawArea);
            if (string.IsNullOrWhiteSpace(fileName)) return;

            if (Path.GetExtension(fileName).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                var bytes = drawArea.SaveToXml();
                File.WriteAllText(fileName, bytes, Encoding.UTF8);
            }
            else
            {
                var bytes = drawArea.SaveToStream();
                File.WriteAllBytes(fileName, bytes);
            }
            //如果是本地文件的话,另存后,改文件名及修改状态和只读状态
            if (drawArea.ID == int.MinValue)
            {
                drawArea.FileName = fileName;
                drawArea.Dirty = false;
                drawArea.ReadOnly = true;
            }

        }

        private void CommandOpen()
        {
            string fileName = GetOpenUMLFileName();
            if (string.IsNullOrWhiteSpace(fileName)) return;

            if (Path.GetExtension(fileName).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                var xml = File.ReadAllText(fileName, Encoding.UTF8);
                var area = this.LoadFromXml(xml, int.MinValue, Path.GetFileNameWithoutExtension(fileName));
                if (area != null)
                {
                    area.FileName = fileName;
                }
            }
            else
            {
                var bytes = File.ReadAllBytes(fileName);
                var area = this.LoadFromStream(bytes, int.MinValue, Path.GetFileNameWithoutExtension(fileName));
                if (area != null)
                {
                    area.FileName = fileName;
                }
            }

        }

        private void CommandBringToFront()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.MoveSelectionToFront();

            //SetStateOfMenuItem();
        }

        private void CommandSendToBack()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.MoveSelectionToBack();

            //SetStateOfMenuItem();
        }

        /// <summary>
        /// Undo
        /// </summary>
        private void CommandUndo()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.Undo();

            //SetStateOfMenuItem();
        }

        /// <summary>
        /// Redo
        /// </summary>
        private void CommandRedo()
        {
            if (this.ActiveDrawArea != null)
                ActiveDrawArea.Redo();

            //SetStateOfMenuItem();
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
            MessageBox.Show("Load File operation failed." + "\n" + "Reason: " + GetExceptionMessage(ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle exception in SaveDocument function
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private void HandleSaveException(Exception ex)
        {
            MessageBox.Show("Save File operation failed.\n" + "Reason: " + GetExceptionMessage(ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public event EventHandler<SaveEventArgs> Save;
        public event EventHandler<ReloadEventArgs> Reload;
        public event EventHandler<BeforeEditEventArgs> BeforeEdit;

        private void btnEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandEdit();
        }

        public void CommandEdit()
        {
            if (this.ActiveDrawArea != null)
            {
                if (this.ActiveDrawArea.ID != int.MinValue)
                {
                    var args = new BeforeEditEventArgs(this.ActiveDrawArea) { AllowEdit = true };
                    var handler = BeforeEdit;
                    if (handler != null)
                    {
                        handler(this, args);
                    }

                    if (args.AllowEdit)
                    {
                        this.ActiveDrawArea.ReadOnly = false;
                    }
                    else
                    {
                        this.ActiveDrawArea.ReadOnly = true;
                    }
                }
                else
                {
                    this.ActiveDrawArea.ReadOnly = false;
                }
            }
        }


        private void bsiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null && !this.ActiveDrawArea.ReadOnly && this.ActiveDrawArea.Dirty)
            {
                CommandSave(new List<DrawArea>() { this.ActiveDrawArea });
            }
            else
            {
                CommandSave(new List<DrawArea>());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawAreas">有更新的画图区</param>
        public void CommandSave(IEnumerable<DrawArea> drawAreas)
        {
            if (drawAreas != null)
            {
                foreach (var drawArea in drawAreas)
                {
                    //本地文件
                    if (drawArea.ID == int.MinValue)
                    {
                        if (!string.IsNullOrWhiteSpace(drawArea.FileName) && File.Exists(drawArea.FileName))
                        {
                            var fileName = Path.ChangeExtension(drawArea.FileName, "xml");
                            drawArea.FileName = fileName;
                            var bytes = drawArea.SaveToXml();
                            File.WriteAllText(fileName, bytes, Encoding.UTF8);
                        }
                        else
                        {
                            CommandSaveAs(drawArea);
                        }
                        drawArea.ClearHistory();
                        drawArea.Dirty = false;
                        drawArea.ReadOnly = true;
                    }
                }

                var handler = Save;
                if (handler != null)
                {
                    var args = new SaveEventArgs();
                    foreach (var item in drawAreas)
                    {
                        if (item.ID != int.MinValue)
                            args.DrawAreaList.Add(item);
                    }

                    handler(this, args);
                    var list = this.DrawAreas;

                    foreach (var item in drawAreas)
                    {
                        var temp = list.FirstOrDefault(p => p.ID == item.ID && p.ID != int.MinValue);
                        if (temp != null)
                        {
                            temp.Dirty = false;
                            temp.ReadOnly = true;
                            temp.ClearHistory();
                            CommandReload(temp);
                        }
                    }

                }

            }

        }

        private void btnSaveAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandSaveAll();
        }

        public void CommandSaveAll()
        {
            CommandSave(this.DrawAreas.Where(p => !p.ReadOnly && p.Dirty));
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandReload(this.ActiveDrawArea);
        }

        public void CommandReload(DrawArea drawArea)
        {
            if (drawArea == null) return;

            //本地文件
            if (drawArea.ID == int.MinValue)
            {
                if (drawArea.Dirty)
                {
                    if (MessageBox.Show("重新加载数据会丢失文档中所有未保存的更改,确定要重新加载吗?", "确认",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                }

                if (!string.IsNullOrWhiteSpace(drawArea.FileName) && File.Exists(drawArea.FileName))
                {
                    string fileName = Path.ChangeExtension(drawArea.FileName, "xml");
                    if (!File.Exists(fileName))
                    {
                        MessageBox.Show(string.Format("文件{0}不存在,无法重新加载.", fileName), "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    drawArea.FileName = fileName;
                    drawArea.LoadFromXml(File.ReadAllText(fileName, Encoding.UTF8));
                    drawArea.ReadOnly = true;
                    drawArea.ClearHistory();
                }
            }
            else
            {
                var handler = Reload;
                if (handler != null)
                {
                    if (drawArea.Dirty)
                    {
                        if (MessageBox.Show("重新加载数据会丢失文档中所有未保存的更改,确定要重新加载吗?", "确认",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                    }

                    var args = new ReloadEventArgs(drawArea.ID, drawArea.Tag);
                    handler(this, args);
                    if (!string.IsNullOrWhiteSpace(args.Xml))
                    {
                        drawArea.LoadFromXml(args.Xml);
                    }
                    else
                    {
                        drawArea.LoadFromStream(args.Data);
                    }
                    drawArea.Tag = args.Tag;

                    drawArea.ClearHistory();
                    drawArea.ReadOnly = true;
                }
            }
        }

        private void bbiOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandOpen();
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            CommandSaveAs(this.ActiveDrawArea);
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

        protected DockPanel GetTopDockPanelCore(DockPanel panel)
        {
            if (panel.ParentPanel != null)
                return GetTopDockPanel(panel.ParentPanel);
            return panel;
        }

        protected DockPanel GetTopDockPanel(DockPanel panel)
        {
            DockPanel floatPanelCandidate = GetTopDockPanelCore(panel);
            if (floatPanelCandidate.Dock == DockingStyle.Float)
                return floatPanelCandidate;
            else return panel;
        }

        private void bsiToolboxWindow_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetTopDockPanel(this.dpToolbox).Show();
        }

        private void bsiPropertyWindow_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetTopDockPanel(this.dpProperty).Show();
        }


        private void bsiZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ZoomIn();

            //SetStateOfMenuItem();
        }

        private void bsiZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.ZoomOut();

            //SetStateOfMenuItem();
        }

        /// <summary>
        /// 加载本地文件时用
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public DrawArea LoadFromStream(byte[] bytes, string header)
        {
            return this.LoadFromStream(bytes, int.MinValue, header);
        }

        /// <summary>
        /// 加载数据库文件时用
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="id"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public DrawArea LoadFromStream(byte[] bytes, int id, string header)
        {
            return LoadFromStream(bytes, id, header, false);
        }

        public DrawArea LoadFromStream(byte[] bytes, int id, string header, bool single)
        {
            BaseDocument doc = null;
            if (this.tabbedView.Documents != null)
            {
                doc = this.tabbedView.Documents.FirstOrDefault(p => (p.Control as DrawArea).ID == id && id != int.MinValue);
            }

            DrawArea drawArea = doc == null ? null : doc.Control as DrawArea;

            if (drawArea == null)
            {
                doc = _AddDocument(id, header);
                if (doc != null)
                    drawArea = doc.Control as DrawArea;

                if (drawArea == null)
                    return null;

                // Read the data
                try
                {
                    drawArea.LoadFromStream(bytes);
                }
                catch (Exception ex)
                {
                    HandleLoadException(ex);
                    tabbedView.RemoveDocument(drawArea);
                    try
                    {
                        drawArea.Dispose();
                    }
                    catch { }
                    return null;
                }
            }
            else
            {
                drawArea.Caption = header;

                if (single)
                {
                    // Read the data
                    try
                    {
                        if (drawArea.Dirty)
                        {
                            if (MessageBox.Show("数据已经修改但没有保存,确定要打开新的文件吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                return null;
                        }
                        drawArea.LoadFromStream(bytes);
                        doc.Caption = GetDocumentCaption(drawArea);
                        tabbedView.ActivateDocument(doc.Control);
                    }
                    catch (Exception ex)
                    {
                        HandleLoadException(ex);
                        tabbedView.RemoveDocument(drawArea);
                        try
                        {
                            drawArea.Dispose();
                        }
                        catch { }
                        return null;
                    }
                }


            }
            //SetStateOfMenuItem();
            return drawArea;
        }


        /// <summary>
        /// 加载本地文件时用
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public DrawArea LoadFromXml(string xml, string header)
        {
            return this.LoadFromXml(xml, int.MinValue, header);
        }

        /// <summary>
        /// 加载数据库文件时用
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="id"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public DrawArea LoadFromXml(string xml, int id, string header)
        {
            return LoadFromXml(xml, id, header, false);
        }

        public DrawArea LoadFromXml(string xml, int id, string header, bool single)
        {
            BaseDocument doc = null;
            if (this.tabbedView.Documents != null)
            {
                doc = this.tabbedView.Documents.FirstOrDefault(p => (p.Control as DrawArea).ID == id && id != int.MinValue);
            }

            DrawArea drawArea = doc == null ? null : doc.Control as DrawArea;

            if (drawArea == null)
            {
                doc = _AddDocument(id, header);
                if (doc != null)
                    drawArea = doc.Control as DrawArea;

                if (drawArea == null)
                    return null;

                // Read the data
                try
                {
                    drawArea.LoadFromXml(xml);
                }
                catch (Exception ex)
                {
                    HandleLoadException(ex);
                    tabbedView.RemoveDocument(drawArea);
                    try
                    {
                        drawArea.Dispose();
                    }
                    catch { }

                    return null;
                }
            }
            else
            {
                drawArea.Caption = header;

                if (single)
                {
                    // Read the data
                    try
                    {
                        if (drawArea.Dirty)
                        {
                            if (MessageBox.Show("数据已经修改但没有保存,确定要打开新的文件吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                                return null;
                        }
                        drawArea.LoadFromXml(xml);
                        doc.Caption = GetDocumentCaption(drawArea);
                        tabbedView.ActivateDocument(doc.Control);
                    }
                    catch (Exception ex)
                    {
                        HandleLoadException(ex);

                        tabbedView.RemoveDocument(drawArea);
                        try
                        {
                            drawArea.Dispose();
                        }
                        catch { }
                        return null;
                    }
                }
            }
            //SetStateOfMenuItem();
            return drawArea;
        }

        private int GetImageByDiagramType(DiagramType diagramType)
        {
            int img = 0;
            switch (diagramType)
            {
                case DiagramType.None:
                    img = 0;
                    break;
                case DiagramType.State:
                    img = 2;
                    break;
                case DiagramType.UserCase:
                    img = 1;
                    break;
                case DiagramType.HSEntitySet:
                    img = 3;
                    break;
                case DiagramType.Workflow:
                    img = 2;
                    break;
                default:
                    img = 0;
                    break;
            }
            return img;
        }

        void drawArea_DiagramTypeChanged(object sender, DiagramTypeChangedEventArg e)
        {
            SetDiagramType(e.DiagramType);

            if (e.DrawArea == null) return;
            if (this.tabbedView.Documents == null) return;

            BaseDocument document = null;
            this.tabbedView.Documents.TryGetValue(e.DrawArea, out document);

            if (document != null)
            {
                if (e.DrawArea.ID != int.MinValue)
                    document.ImageIndex = GetImageByDiagramType(e.DrawArea.DiagramType);
                else
                    document.ImageIndex = GetImageByDiagramType(DiagramType.None);
            }
            //SetStateOfMenuItem();
        }

        public byte[] SaveToStream()
        {
            if (this.ActiveDrawArea == null) return null;

            return this.ActiveDrawArea.SaveToStream();
        }

        public string SaveToXml()
        {
            if (this.ActiveDrawArea == null) return string.Empty;

            return this.ActiveDrawArea.SaveToXml();
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

        public string GetOpenUMLFileName()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "选择环思UML图形文件...";
                openFileDialog.Filter = "环思UML图形文件(*.xml)|*.xml|环思UML图形文件(*.hsuml)|*.hsuml";
                openFileDialog.CheckFileExists = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.DefaultExt = "xml";
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

        private void bbiDrag_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveDrawArea != null)
                this.ActiveDrawArea.CurrentGraphicsType = GraphicsType.Drag;
        }

        private void tabbedView_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document != null && (e.Document.Control is DrawArea))
            {
                var area = e.Document.Control as DrawArea;
                if (area.Dirty)
                {
                    string caption = string.Format(@"文档 ""{0}"" 已修改,关闭后将丢失更改,确定要关闭窗口吗?", area.Caption);
                    e.Cancel = (MessageBox.Show(caption, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
                }
            }
        }

        private List<KeyValuePair<int, string>> _iStatusSource = new List<KeyValuePair<int, string>>();
        public List<KeyValuePair<int, string>> iStatusSource { get { return _iStatusSource; } }

        public string GetSaveUMLFileName(DrawArea drawArea = null)
        {
            if (drawArea == null)
                drawArea = this.ActiveDrawArea;

            if (drawArea == null)
                return string.Empty;

            string fileName = string.IsNullOrWhiteSpace(drawArea.Caption) ? "未命名" : drawArea.Caption.Trim() + ".xml";

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "保存环思UML图形文件...";
                saveFileDialog.Filter = "环思UML图形文件(*.xml)|*.xml|环思UML图形文件(*.hsuml)|*.hsuml";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "xml";
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

        public void RemoveDrawArea(DrawArea area)
        {
            if (area == null) return;
            this.tabbedView.RemoveDocument(area);
            try
            {
                area.Dispose();
            }
            catch { }


        }
    }
}
