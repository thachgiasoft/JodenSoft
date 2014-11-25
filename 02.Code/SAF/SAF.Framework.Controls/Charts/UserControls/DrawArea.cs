using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using System.Xml.Serialization;
using DevExpress.XtraEditors;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Drawing.Imaging;
using SAF.Framework.Controls.Charts.Actions;


namespace SAF.Framework.Controls.Charts
{
    [ToolboxItem(false)]
    public partial class DrawArea : BaseUserControl
    {
        private GraphicsCollection graphicsCollection = null;

        public GraphicsCollection GraphicsCollection
        {
            get { return graphicsCollection; }
            set
            {
                if (graphicsCollection != value)
                {
                    graphicsCollection = value;
                    // Create undo manager
                    UndoManager = new UndoManager(graphicsCollection);
                }
            }
        }

        public event EventHandler<DiagramTypeChangedEventArg> DiagramTypeChanged;

        private DiagramType _DiagramType = DiagramType.None;
        public DiagramType DiagramType
        {
            get { return _DiagramType; }
            set
            {
                _DiagramType = value;
                this.GraphicsCollection.DiagramType = value;
                var handler = DiagramTypeChanged;
                if (handler != null)
                {
                    handler(this, new DiagramTypeChangedEventArg(value, this));
                }
            }
        }

        private bool readOnly = false;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                Owner.SetReadOnly(value);
            }
        }
        private bool _AllowSaveAs = true;
        /// <summary>
        /// 是否允许另存为
        /// </summary>
        public bool AllowSaveAs
        {
            get { return _AllowSaveAs; }
            set
            {
                _AllowSaveAs = value;
                Owner.SetAllowSave(value);
            }
        }
        private bool _AllowExportImage = true;
        /// <summary>
        /// 是否可以导出图片
        /// </summary>
        public bool AllowExportImage
        {
            get { return _AllowExportImage; }
            set
            {
                _AllowExportImage = value;
                Owner.SetAllowExportImage(value);
            }
        }

        private GraphicsType _CurrentGraphicsType = GraphicsType.Pointer;

        public GraphicsType CurrentGraphicsType
        {
            get { return _CurrentGraphicsType; }
            set
            {
                _CurrentGraphicsType = value;
            }
        }

        private ChartControl Owner { get; set; }

        private UndoManager UndoManager { get; set; }

        public string Caption { get; set; }

        private Dictionary<int, Tool> tools = new Dictionary<int, Tool>();

        private Dictionary<Keys, IEditAction> editactions = new Dictionary<Keys, IEditAction>();

        public event EventHandler SelectionChanged;

        public event EventHandler ZoomChanged;

        public string Dump()
        {
            return this.GraphicsCollection.Dump();
        }

        private DrawArea()
        {
            InitializeComponent();

            //ToolTip.AutoPopDelay = 15000;
            //ToolTip.InitialDelay = 250;
            //ToolTip.OwnerDraw = true;

            //ToolTip.Draw += ToolTip_Draw;
            //ToolTip.Popup += ToolTip_Popup;
        }

        private int i = 0;
        public int NameIndex
        {
            get
            {
                return i++;
            }
        }

        #region ToolTip

        //private ToolTip ToolTip = new ToolTip();

        //private Point _ToolTipPoint;

        //private string _toolTipText;
        //public string ToolTipText
        //{
        //    get
        //    {
        //        return this._toolTipText;
        //    }
        //    set
        //    {
        //        this._toolTipText = value;
        //        Point point = this.PointToClient(Cursor.Position);
        //        if (point != this._ToolTipPoint)
        //        {
        //            this._ToolTipPoint = point;
        //            if (value == null)
        //            {
        //                this.ToolTip.RemoveAll();
        //            }
        //            else
        //            {
        //                this.ToolTip.SetToolTip(this, ".");
        //            }
        //        }
        //    }
        //}

        //public string ToolTipTextTitle { get; set; }

        //void ToolTip_Popup(object sender, PopupEventArgs e)
        //{
        //    using (StringFormat sf = new StringFormat())
        //    {
        //        using (Graphics g = e.AssociatedControl.CreateGraphics())
        //        {
        //            sf.Alignment = StringAlignment.Center;
        //            sf.LineAlignment = StringAlignment.Center;
        //            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
        //            using (Font font = new Font(Font, FontStyle.Bold))
        //            {
        //                if (ToolTipTextTitle.m_IsEmpty()) ToolTipTextTitle = " ";
        //                float height = g.MeasureString(this.ToolTipTextTitle, font, 200, sf).Height;
        //                using (Font font2 = new Font(Font, FontStyle.Regular))
        //                {
        //                    height = height + g.MeasureString(this.ToolTipText, font2, 200, sf).Height;
        //                    height += 10;

        //                    Size toolTipSize = new Size(200, (int)height);
        //                    e.ToolTipSize = toolTipSize;
        //                }
        //            }
        //        }
        //    }
        //}

        //void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        //{
        //    e.Graphics.FillRectangle(Brushes.Ivory, e.Bounds);
        //    e.DrawBorder();

        //    using (StringFormat sf = new StringFormat())
        //    {
        //        sf.Alignment = StringAlignment.Center;
        //        sf.LineAlignment = StringAlignment.Center;
        //        sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;

        //        RectangleF titleRect;

        //        using (Font font = new Font(e.Font, FontStyle.Bold))
        //        {
        //            if (ToolTipTextTitle.m_IsEmpty()) ToolTipTextTitle = " ";
        //            var size = e.Graphics.MeasureString(this.ToolTipTextTitle, font, e.Bounds.Width, sf);

        //            e.Graphics.DrawLine(Pens.Black, 0, size.Height, e.Bounds.Width, size.Height);

        //            titleRect = new RectangleF();
        //            titleRect.Location = e.Bounds.Location;
        //            titleRect.Size = size;

        //            e.Graphics.DrawString(this.ToolTipTextTitle, font, Brushes.Black, titleRect, sf);
        //        }

        //        sf.Alignment = StringAlignment.Near;
        //        sf.LineAlignment = StringAlignment.Near;
        //        using (Font font = new Font(e.Font, FontStyle.Regular))
        //        {
        //            var size = e.Graphics.MeasureString(this.ToolTipText, font, e.Bounds.Width, sf);
        //            var rect = new RectangleF();
        //            rect.Location = new PointF(titleRect.Left, titleRect.Top + titleRect.Height + 5);
        //            rect.Size = size;

        //            e.Graphics.DrawString(this.ToolTipText, font, Brushes.Black, rect, sf);
        //        }
        //    }

        //}

        #endregion

        public DrawArea(ChartControl owner)
            : this()
        {
            this.Paint += new PaintEventHandler(DrawArea_Paint);
            this.MouseDown += new MouseEventHandler(DrawArea_MouseDown);
            this.MouseMove += new MouseEventHandler(DrawArea_MouseMove);
            this.MouseUp += new MouseEventHandler(DrawArea_MouseUp);
            this.Resize += new EventHandler(DrawArea_Resize);

            GenerateDefaultActions();

            this.Initialize(owner);

            this.AutoScroll = true;
        }

        public string SaveToXml()
        {
            return string.Empty;
            //var diagram = this.ToDiagram();

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    XmlSerializer formatter = new XmlSerializer(typeof(Diagram));
            //    formatter.Serialize(ms, diagram);
            //    ms.Position = 0;
            //    using (StreamReader sr = new StreamReader(ms))
            //    {
            //        var xmlstring = sr.ReadToEnd();
            //        xmlstring = xmlstring.m_After("?>");
            //        xmlstring = xmlstring.Trim();
            //        return xmlstring;
            //    }
            //}
        }

        public void LoadFromXml(string xmlString)
        {
            //this.ClearHistory();
            //if (!string.IsNullOrWhiteSpace(xmlString))
            //{
            //    using (StringReader sr = new StringReader(xmlString))
            //    {
            //        XmlSerializer xmldes = new XmlSerializer(typeof(Diagram));
            //        var diagram = xmldes.Deserialize(sr) as Diagram;

            //        if (diagram == null)
            //            throw new Exception("反序列化时出错了.可能不是有效的xml字符串.{0}{1}".m_FormatEx(Environment.NewLine, xmlString));

            //        this.GraphicsCollection = CreateGraphicsCollection(diagram.Items);

            //        this.Zoom = diagram.dZoom <= 0 ? 1f : diagram.dZoom;
            //        this.DiagramType = (DiagramType)diagram.iDiagramType;

            //        this.iProductId = diagram.iProductId;
            //        this.iProjectId = diagram.iProjectId;
            //        //this.ID = diagram.iIden;
            //        this.Caption = diagram.sName;

            //        //GraphicsCollection.ReplaceDrawLine();
            //    }
            //}
            //else
            //{
            //    this.GraphicsCollection = new GraphicsCollection();
            //    this.Zoom = 1f;

            //    this.DiagramType = this.DiagramType;

            //    this.iProductId = 0;
            //    this.iProjectId = 0;
            //    this.ID = int.MinValue;
            //}

            //this.Dirty = false;
            ////将画布移至第一个图形
            //if (this.GraphicsCollection.Count > 0)
            //{
            //    //drawArea.SetAutoScrollMinSize();
            //    int x = this.GraphicsCollection.Min(p => p.Left);
            //    int y = this.GraphicsCollection.Min(p => p.Top);

            //    if (x < this.Width / 3) x = 0;
            //    if (y < this.Height / 3) y = 0;
            //    this.AutoScrollPosition = new Point(x, y);
            //}
            //this.FireSelectionChanged();
            //this.Refresh();
        }

       

        public byte[] SaveToStream()
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            this.GraphicsCollection.Zoom = this.Zoom;

            formatter.Serialize(ms, GraphicsCollection);
            return ms.GetBuffer();
        }

        public void LoadFromStream(byte[] bytes)
        {
            this.ClearHistory();
            if (bytes != null)
            {
                Stream serializationStream = new MemoryStream(bytes);
                // Deserialize object from text format
                IFormatter formatter = new BinaryFormatter();
                this.GraphicsCollection = (GraphicsCollection)formatter.Deserialize(serializationStream);
                this.Zoom = this.GraphicsCollection.Zoom;

                if (this.GraphicsCollection.DiagramType != DiagramType.None)
                    this.DiagramType = this.GraphicsCollection.DiagramType;
                else
                    this.DiagramType = this.DiagramType;

                //GraphicsCollection.ReplaceDrawLine();
            }
            else
            {
                this.GraphicsCollection = new GraphicsCollection();
                this.Zoom = 1f;

                this.DiagramType = this.DiagramType;
            }

            this.Dirty = false;
            //将画布移至第一个图形
            if (this.GraphicsCollection.Count > 0)
            {
                //drawArea.SetAutoScrollMinSize();
                int x = this.GraphicsCollection.Min(p => p.Left);
                int y = this.GraphicsCollection.Min(p => p.Top);

                if (x < this.Width / 3) x = 0;
                if (y < this.Height / 3) y = 0;
                this.AutoScrollPosition = new Point(x, y);
            }
            this.FireSelectionChanged();
            this.Refresh();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            HandleMouseWheel(e);
        }

        MouseWheelHandler mouseWheelHandler = new MouseWheelHandler();

        private void HandleMouseWheel(MouseEventArgs e)
        {
            int scrollDistance = mouseWheelHandler.GetScrollAmount(e);
            if (scrollDistance == 0)
                return;
            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                if (scrollDistance > 0)
                {
                    this.ZoomIn();
                }
                else
                {
                    this.ZoomOut();
                }
            }
            else
            {
                this.Invalidate();
            }
        }

        void DrawArea_Resize(object sender, EventArgs e)
        {
            this.Refresh();
            //this.SetAutoScrollMinSize();
        }

        protected virtual void GenerateDefaultActions()
        {
            editactions[Keys.Left] = new CaretLeftAction();
            editactions[Keys.Right] = new CaretRightAction();
            editactions[Keys.Up] = new CaretUpAction();
            editactions[Keys.Down] = new CaretDownAction();

            editactions[Keys.A | Keys.Control] = new SelectWholeDocumentAction();
            editactions[Keys.Escape] = new ClearAllSelectionsAction();

            editactions[Keys.Delete] = new DeleteAction();
            editactions[Keys.X | Keys.Control] = new CutAction();
            editactions[Keys.C | Keys.Control] = new CopyAction();
            editactions[Keys.V | Keys.Control] = new PasteAction();

            editactions[Keys.Z | Keys.Control] = new UndoAction();
            editactions[Keys.Y | Keys.Control] = new RedoAction();

            editactions[Keys.F | Keys.Control] = new SearchAction();

            editactions[Keys.D0 | Keys.Control] = new ZoomRestoreAction();
            editactions[Keys.Oemplus | Keys.Control] = new ZoomInAction();
            editactions[Keys.OemMinus | Keys.Control] = new ZoomOutAction();

            editactions[Keys.Z | Keys.Alt] = new BestFitAction();
            editactions[Keys.X | Keys.Alt] = new AutoDrawLineAction();

        }

        public bool IsPointer
        {
            get { return this.CurrentGraphicsType == GraphicsType.Pointer; }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return ExecuteDialogKey(keyData) || base.ProcessDialogKey(keyData);
        }

        private bool ExecuteDialogKey(Keys keyData)
        {
            IEditAction action = GetEditAction(keyData);

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

        internal IEditAction GetEditAction(Keys keyData)
        {
            if (!IsEditAction(keyData))
            {
                return null;
            }
            return (IEditAction)editactions[keyData];
        }

        void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;

            if (e.Button == MouseButtons.Left)
            {
                tools[(int)CurrentGraphicsType].OnMouseUp(this, e);
            }
            this.FireSelectionChanged();
        }

        public void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.None))
            {
                if (Control.ModifierKeys == Keys.Shift && !this.ReadOnly)
                {
                    tools[(int)LastGraphicsType].OnMouseMove(this, e);
                }
                else
                {
                    tools[(int)CurrentGraphicsType].OnMouseMove(this, e);
                }
            }
            else
                this.Cursor = Cursors.Default;
        }

        private GraphicsType _LastGraphicsType = GraphicsType.Pointer;

        public GraphicsType LastGraphicsType
        {
            get { return _LastGraphicsType; }
            set { _LastGraphicsType = value; }
        }


        void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Shift && !this.ReadOnly)
                {
                    this.CurrentGraphicsType = _LastGraphicsType;
                }
                tools[(int)CurrentGraphicsType].OnMouseDown(this, e);
            }
            else if (e.Button == MouseButtons.Right)
                OnContextMenu(e);
        }

        /// <summary>
        /// the currentZoomFactor factor
        /// </summary>
        protected float currentZoomFactor = 1F;
        [Browsable(false)]
        public float Zoom
        {
            get
            {
                return Math.Round(currentZoomFactor, 4) <= 0 ? 0.1f : currentZoomFactor;
            }
            set
            {
                if (value == currentZoomFactor) return;
                currentZoomFactor = value;
                var _zoomChanged = ZoomChanged;
                if (_zoomChanged != null)
                {
                    _zoomChanged(this, EventArgs.Empty);
                }
                this.Invalidate();
            }
        }

        public Rectangle ActualClientRectangle
        {
            get
            {
                var rect = Rectangle.Round(SumRectangles());
                rect.Width = rect.Width + 100;
                rect.Height = rect.Height + 100;
                return rect;
            }
        }

        private Size oldAutoScrollMinSize;
        void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.PageUnit = GraphicsUnit.Pixel; //GraphicsUnit.Pixel才支持缩放与偏移绘制。

            //SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));

            if (MouseButtons != MouseButtons.Left)
            {
                Rectangle b = Rectangle.Round(SumRectangles());
                AutoScrollMinSize = new Size((int)((b.Size.Width + 50) * this.Zoom), (int)((b.Size.Height + 50) * this.Zoom));
                oldAutoScrollMinSize = AutoScrollMinSize;
            }
            else
            {
                AutoScrollMinSize = oldAutoScrollMinSize;
            }

            var brush = new LinearGradientBrush(this.ClientRectangle, Color.LightSteelBlue, Color.White, LinearGradientMode.ForwardDiagonal);

            e.Graphics.FillRectangle(brush,
                this.ClientRectangle);

            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            e.Graphics.ScaleTransform(Zoom, Zoom, MatrixOrder.Prepend);

            if (GraphicsCollection != null)
            {
                GraphicsCollection.Draw(e.Graphics, this);
            }

            brush.Dispose();
        }

        /// <summary>
        /// Returns the union of the bounding rectangles of all entities
        /// </summary>
        private RectangleF SumRectangles()
        {
            RectangleF r = RectangleF.Empty;

            // for each shape in mShapes of the abstract
            foreach (DrawObject obj in GraphicsCollection)
            {
                if (obj is DrawRectangle)
                {
                    r = RectangleF.Union(r, (obj as DrawRectangle).Rectangle);
                }
            }
            return r;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        public void FireSelectionChanged()
        {
            if (this.SelectionChanged != null)
            {
                this.SelectionChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="docManager"></param>
        protected void Initialize(ChartControl owner)
        {
            //开启双缓冲
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Keep reference to owner form
            this.Owner = owner;

            // set default tool
            this.CurrentGraphicsType = GraphicsType.Pointer;

            // create list of graphic objects
            GraphicsCollection = new GraphicsCollection();

            // Create undo manager
            UndoManager = new UndoManager(GraphicsCollection);

            tools.Add((int)GraphicsType.Pointer, new ToolPointer());
            tools.Add((int)GraphicsType.Drag, new ToolDrag());
            //tools.Add(new ToolLine(false, true));
            //tools.Add(new ToolLine(true, true));
            //tools.Add(new ToolRectangle(false));
            //tools.Add(new ToolRectangle(true));
            //tools.Add((int)GraphicsType.Ellipse, new ToolEllipse());
            //tools.Add(new ToolRhombus());
            //tools.Add(new ToolPolygon());


            tools.Add((int)GraphicsType.Initial, new ToolInitial());
            tools.Add((int)GraphicsType.Final, new ToolFinal());
            tools.Add((int)GraphicsType.ExitPoint, new ToolExitPoint());
            tools.Add((int)GraphicsType.EntryPoint, new ToolEntryPoint());
            tools.Add((int)GraphicsType.Transition, new ToolTransition());
            tools.Add((int)GraphicsType.State, new ToolState());
            tools.Add((int)GraphicsType.Terminate, new ToolTerminate());
            tools.Add((int)GraphicsType.Choice, new ToolChoice());
            tools.Add((int)GraphicsType.Note, new ToolNote());
            tools.Add((int)GraphicsType.Objects, new ToolObjects());
            tools.Add((int)GraphicsType.Actor, new ToolActor());
            tools.Add((int)GraphicsType.UserCase, new ToolUserCase());
            tools.Add((int)GraphicsType.Use, new ToolUseLine());
            tools.Add((int)GraphicsType.Invokes, new ToolInvokesLine());
            tools.Add((int)GraphicsType.FlowNode, new ToolFlowNode());
            tools.Add((int)GraphicsType.FlowLine, new ToolFlowLine());
            tools.Add((int)GraphicsType.HSEntitySet, new ToolEntitySet());
            tools.Add((int)GraphicsType.Reference, new ToolReference());
            tools.Add((int)GraphicsType.Swimlane, new ToolSwimlane());
            tools.Add((int)GraphicsType.InheritLine, new ToolInheritLine());
        }

        /// <summary>
        /// Set dirty flag (file is changed after last save operation)
        /// </summary>
        public void SetDirty()
        {
            Dirty = true;
        }

        public event EventHandler<DirtyChangedEventArg> DirtyChanged;

        private bool _Dirty = false;
        /// <summary>
        /// Dirty property (true when document has unsaved changes).
        /// </summary>
        [Browsable(false)]
        public bool Dirty
        {
            get { return _Dirty; }
            set
            {
                _Dirty = value;
                var handler = DirtyChanged;
                if (handler != null)
                {
                    handler(this, new DirtyChangedEventArg(this, value));
                }
            }
        }

        internal void AddCommandToHistory(Command command)
        {
            UndoManager.AddCommandToHistory(command);
        }

        public void Clear()
        {
            this.ClearHistory();
            this.GraphicsCollection.Clear();
            this.Refresh();
        }

        /// <summary>
        /// Clear Undo history.
        /// </summary>
        public void ClearHistory()
        {
            UndoManager.ClearHistory();
        }

        /// <summary>
        /// Undo
        /// </summary>
        public void Undo()
        {
            if (CanUndo)
            {
                UndoManager.Undo();
                SetDirty();
                Refresh();
            }
        }

        /// <summary>
        /// Redo
        /// </summary>
        public void Redo()
        {
            if (CanRedo)
            {
                UndoManager.Redo();
                SetDirty();
                Refresh();
            }
        }

        /// <summary>
        /// Return True if Undo operation is possible
        /// </summary>
        public bool CanUndo
        {
            get
            {
                if (UndoManager != null)
                {
                    return UndoManager.CanUndo;
                }

                return false;
            }
        }

        /// <summary>
        /// Return True if Redo operation is possible
        /// </summary>
        public bool CanRedo
        {
            get
            {
                if (UndoManager != null)
                {
                    return UndoManager.CanRedo;
                }

                return false;
            }
        }

        public void DeleteSelection()
        {
            CommandDelete command = new CommandDelete(GraphicsCollection);

            if (GraphicsCollection.DeleteSelection())
            {
                SetDirty();
                Refresh();
                AddCommandToHistory(command);

                FireSelectionChanged();
            }
        }

        /// <summary>
        /// Right-click handler
        /// </summary>
        /// <param name="e"></param>
        private void OnContextMenu(MouseEventArgs e)
        {
            // Change current selection if necessary

            Point point = new Point(e.X, e.Y);
            Point point2 = ToolObject.TranslatePoint(this, point);
            point2 = ToolObject.UnzoomPoint(point2, this.Zoom);

            int n = this.GraphicsCollection.Count;
            DrawObject o = null;

            for (int i = 0; i < n; i++)
            {
                if (GraphicsCollection[i].HitTest(point2) == 0)
                {
                    o = GraphicsCollection[i];
                    break;
                }
            }

            if (o != null)
            {
                if (!o.Selected)
                    GraphicsCollection.UnselectAll();

                // Select clicked object
                o.Selected = true;
            }
            else
            {
                GraphicsCollection.UnselectAll();
            }

            Refresh();      // in the case selection was changed

            // Show context menu for owner form, so that it handles items selection.
            // Convert point from this window coordinates to owner's coordinates.
            point.X += this.Left;
            point.Y += this.Top;

            Owner.ContextMenuBeforePopExecute();

            FillStatusMenuItem();

            MarginContextMenu(Owner);
            m_ContextMenu.Show(Owner, point);
            m_ContextMenu.Closed += m_ContextMenu_Closed;

            Owner.SetStateOfMenuItem();
            SetStateOfContextMenuItem();
        }

        private void FillStatusMenuItem()
        {
            if (this.iStatusSource != null && this.iStatusSource.Count() > 0)
            {
                if (!this.iStatusToolStripMenuItem.HasDropDownItems)
                {
                    foreach (var item in this.iStatusSource)
                    {
                        var strip = new ToolStripMenuItem(item.Value);
                        strip.Tag = item.Key;
                        strip.Click += (sender, args) =>
                        {
                            var commandChangeState = new CommandChangeState(GraphicsCollection);
                            foreach (var obj in this.GraphicsCollection.Selection)
                            {
                                obj.iStatus = Convert.ToInt32((sender as ToolStripMenuItem).Tag);
                            }
                            commandChangeState.NewState(GraphicsCollection);
                            this.AddCommandToHistory(commandChangeState);
                            this.SetDirty();
                            Refresh();
                        };
                        this.iStatusToolStripMenuItem.DropDownItems.Add(strip);
                    }
                }
            }
        }


        void m_ContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            for (int i = this.m_ContextMenu.Items.Count - 1; i >= 0; i--)
            {
                if (this.m_ContextMenu.Items[i].Tag != null && this.m_ContextMenu.Items[i].Tag.ToString() == "AutoCreate")
                {
                    this.m_ContextMenu.Items.RemoveAt(i);
                }
            }
        }

        private void MarginContextMenu(ChartControl owner)
        {
            if (owner.ContextMenuStrip != null)
            {
                var list = new List<ToolStripItem>();
                foreach (ToolStripMenuItem item in owner.ContextMenuStrip.Items)
                {
                    if (!item.Enabled) continue;
                    list.Add(item);
                }

                if (m_ContextMenu.Items.Count > 0 && list.Count > 0)
                {
                    if (!(m_ContextMenu.Items[m_ContextMenu.Items.Count - 1] is ToolStripSeparator))
                    {
                        var strip = new ToolStripSeparator();
                        strip.Tag = "AutoCreate";
                        this.m_ContextMenu.Items.Add(strip);
                    }
                    foreach (ToolStripMenuItem item in list)
                    {
                        if (!item.Enabled) continue;

                        var strip = new ToolStripMenuItem(item.Text);
                        strip.Tag = "AutoCreate";
                        strip.Click += (sender, args) => { item.PerformClick(); };
                        this.m_ContextMenu.Items.Add(strip);
                    }
                }
            }
        }

        private void SetStateOfContextMenuItem()
        {
            bool objects = (this.GraphicsCollection.Count > 0);
            bool selectedObjects = (this.GraphicsCollection.SelectionCount > 0);

            BringToFrontToolStripMenuItem.Enabled = selectedObjects && !this.ReadOnly;

            SendToBackToolStripMenuItem.Enabled = selectedObjects && !this.ReadOnly;

            PropertyToolStripMenuItem.Enabled = this.GraphicsCollection.SelectionCount == 1 && !this.ReadOnly;
            PropertyToolStripMenuItem.Visible = PropertyToolStripMenuItem.Enabled;

            spPropertyToolStripMenuItem.Visible = PropertyToolStripMenuItem.Visible;

            bool hasSelectedLine = this.GraphicsCollection.Any(p => p.Selected && p is DrawLine);

            AutoDrawLineToolStripMenuItem.Enabled = hasSelectedLine && !this.ReadOnly;
            AutoDrawLineToolStripMenuItem.Visible = hasSelectedLine && !this.ReadOnly;

            spCancelMoveToolStripMenuItem.Visible = hasSelectedLine;

            DeleteSelectionToolStripMenuItem.Enabled = selectedObjects && !this.ReadOnly;

            bool hasSelectedDrawRectangle = this.GraphicsCollection.Any(p => p.Selected && p is DrawRectangle);
            AutoSizeToolStripMenuItem.Enabled = hasSelectedDrawRectangle && !this.ReadOnly;
            AutoSizeToolStripMenuItem.Visible = hasSelectedDrawRectangle && !this.ReadOnly;

            this.iStatusToolStripMenuItem.Enabled = selectedObjects && !this.ReadOnly && this.iStatusSource != null && this.iStatusSource.Count() > 0;
            this.iStatusToolStripMenuItem.Visible = this.iStatusToolStripMenuItem.Enabled;

        }

        public void MoveSelectionToFront()
        {
            if (GraphicsCollection.MoveSelectionToFront())
            {
                SetDirty();
                Refresh();
            }
        }

        public void MoveSelectionToBack()
        {
            if (GraphicsCollection.MoveSelectionToBack())
            {
                SetDirty();
                Refresh();
            }
        }

        private void BringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveSelectionToFront();
        }

        private void SendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveSelectionToBack();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphicsCollection.ShowPropertiesDialog(this))
            {
                Refresh();
            }
        }

        public void AutoDrawLine()
        {
            if (GraphicsCollection.LineCancelMove())
            {
                SetDirty();
                Refresh();
            }
        }

        private void CancelMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoDrawLine();
        }

        private void DeleteSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DeleteSelection();
        }

        private void AutoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BestFitDrawObject();
        }

        public void Search()
        {
            using (SearchDialog dlg = new SearchDialog(this.GraphicsCollection))
            {
                var result = dlg.ShowDialog(this.TopLevelControl);
                if (result != DialogResult.OK)
                    return;
                var guid = dlg.SelectedGuid;
                var sel = this.GraphicsCollection.FirstOrDefault(p => p.GUID == guid);
                if (sel != null)
                {
                    this.GraphicsCollection.UnselectAll();
                    sel.Selected = true;
                    //将画布移至第一个图形
                    if (GraphicsCollection.Count > 0)
                    {
                        //SetAutoScrollMinSize();
                        int x = sel.Left;
                        int y = sel.Top;

                        if (x < Width / 3) x = 0;
                        if (y < Height / 3) y = 0;
                        AutoScrollPosition = new Point(x, y);
                    }

                    Refresh();
                    FireSelectionChanged();
                }
            }
        }

        internal void ZoomIn()
        {
            this.Zoom += 0.1f;
        }

        internal void ZoomOut()
        {
            this.Zoom -= 0.1f;
        }

        public void AddDrawObject(DrawObject obj)
        {
            if (this.GraphicsCollection.All(p => p.GUID != obj.GUID))
            {
                this.GraphicsCollection.Add(obj);

                obj.Normalize();
                AddCommandToHistory(new CommandAdd(obj));

                CurrentGraphicsType = GraphicsType.Pointer;
                SetDirty();
                Capture = false;
                Refresh();
            }
        }

        private void DrawArea_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        public void CutSelection()
        {
            CopySelection();
            DeleteSelection();
        }

        public void CopySelection()
        {
            if (this.GraphicsCollection.SelectionCount <= 0) return;

            Clipboard.Clear();
            GraphicsCollection list = new GraphicsCollection();
            foreach (var item in this.GraphicsCollection.Selection)
            {
                if (item is DrawLine) continue;
                list.Add(item.Clone());
            }

            var selectlist = this.GraphicsCollection.Selection;
            //强制拷贝对象之间的线
            foreach (var item in this.GraphicsCollection)
            {
                var line = item as DrawLine;
                if (line != null)
                {
                    if (selectlist.Any(p => p.GUID == line.StartDrawObjectID) && selectlist.Any(p => p.GUID == line.EndDrawObjectID))
                        list.Add(line.Clone());
                }
            }

            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, list);
            string str = Convert.ToBase64String(ms.GetBuffer());
            Clipboard.SetText(str, TextDataFormat.Text);
        }

        public void PasteSelection()
        {
            if (!Clipboard.ContainsText(TextDataFormat.Text)) return;

            string serializationString = Clipboard.GetText(TextDataFormat.Text);
            if (string.IsNullOrWhiteSpace(serializationString)) return;

            var bytes = Convert.FromBase64String(serializationString);
            Stream serializationStream = new MemoryStream(bytes);

            // Deserialize object from text format
            IFormatter formatter = new BinaryFormatter();
            GraphicsCollection _GraphicsCollection = null;
            try
            {
                _GraphicsCollection = (GraphicsCollection)formatter.Deserialize(serializationStream);
            }
            catch
            {
                _GraphicsCollection = null;
            }
            if (_GraphicsCollection == null) return;

            //删除断篇的线
            for (int i = _GraphicsCollection.Count - 1; i >= 0; i--)
            {
                var line = _GraphicsCollection[i] as DrawLine;
                if (line != null)
                {
                    if (!_GraphicsCollection.Any(p => p.GUID == line.StartDrawObjectID) || !_GraphicsCollection.Any(p => p.GUID == line.EndDrawObjectID))
                        _GraphicsCollection.RemoveAt(i);
                }
            }

            foreach (var item in _GraphicsCollection)
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                var oldId = item.GUID;
                item.GUID = Guid.NewGuid();
                item.Left += rand.Next(10, 100);
                item.Top += rand.Next(10, 100);
                item.Selected = true;

                foreach (var line in _GraphicsCollection.Where(p => p is DrawLine))
                {
                    if ((line as DrawLine).StartDrawObjectID == oldId)
                        (line as DrawLine).StartDrawObjectID = item.GUID;
                    if ((line as DrawLine).EndDrawObjectID == oldId)
                        (line as DrawLine).EndDrawObjectID = item.GUID;
                }
            }

            this.GraphicsCollection.UnselectAll();

            CurrentGraphicsType = GraphicsType.Pointer;
            foreach (var obj in _GraphicsCollection)
            {
                this.GraphicsCollection.Add(obj);
                obj.Normalize();
                Capture = false;
            }
            AddCommandToHistory(new CommandAddList(_GraphicsCollection));
            this.GraphicsCollection.MoveSwimlaneToBack();

            SetDirty();
            Refresh();

            FireSelectionChanged();

            int x = _GraphicsCollection.Min(p => p.Left);
            int y = _GraphicsCollection.Min(p => p.Top);
            if (x < this.Width / 3) x = 0;
            if (y < this.Height / 3) y = 0;
            this.AutoScrollPosition = new Point(x, y);
            this.Invalidate();
        }

        internal void BestFitDrawObject()
        {

            foreach (var item in GraphicsCollection.Selection)
            {
                if (item.Selected && (item is DrawRectangle) && !(item is Swimlane))
                {
                    (item as DrawRectangle).AllowBestFit = true;
                }
            }

            SetDirty();
            Refresh();
        }

        public int ID { get; set; }
        public int iProductId { get; set; }
        public int iProjectId { get; set; }
        public string FileName { get; set; }

        public IEnumerable<KeyValuePair<int, string>> iStatusSource
        {
            get
            {
                return Owner == null ? null : Owner.iStatusSource;
            }
        }

        public void ExportToPng(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                MessageBox.Show("文件名为空.", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var rect = this.ActualClientRectangle;
            using (Bitmap bitMap = new Bitmap(rect.Width, rect.Height))
            {
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.FillRectangle(Brushes.LightSteelBlue, rect);
                    g.DrawImage(bitMap, rect);

                    this.GraphicsCollection.MoveSwimlaneToBack();
                    this.GraphicsCollection.MoveLineToFront();

                    for (int i = this.GraphicsCollection.Count - 1; i >= 0; i--)
                    {
                        var item = this.GraphicsCollection[i];
                        item.Draw(g);
                    }
                    bitMap.Save(fileName, ImageFormat.Png);
                }
            }
        }

    }
}
