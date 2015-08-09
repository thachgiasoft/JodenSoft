using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace SAF.Framework.Controls.Chart
{
    public partial class DrawArea : XtraUserControl, IEnumerable<DrawObject>, ISerializable, IGraphicsList
    {
        private UndoManager undoManager;

        private GraphicsList GraphicsList { get; set; }

        public DrawToolType ActiveDrawTool { get; set; }

        public ChartControl Owner { get; private set; }

        private Dictionary<DrawToolType, Tool> tools = new Dictionary<DrawToolType, Tool>();

        private DrawArea()
        {
            InitializeComponent();
        }

        public DrawArea(ChartControl owner)
            : this()
        {
            this.Owner = owner;
            Initialize();
        }

        private void Initialize()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.Paint += DrawArea_Paint;
            this.MouseDown += DrawArea_MouseDown;
            this.MouseMove += DrawArea_MouseMove;
            this.MouseUp += DrawArea_MouseUp;
            base.MouseDoubleClick += DrawArea_MouseDoubleClick;

            GraphicsList = new GraphicsList();

            // Create undo manager
            undoManager = new UndoManager(this);

            // set default tool
            this.ActiveDrawTool = DrawToolType.Pointer;

            // create array of drawing tools
            tools.Add(DrawToolType.Pointer, new ToolPointer());
            tools.Add(DrawToolType.Rectangle, new ToolRectangle());
            tools.Add(DrawToolType.Ellipse, new ToolEllipse());
            tools.Add(DrawToolType.Rhombus, new ToolRhombus());
            tools.Add(DrawToolType.Lane, new ToolLane());
            tools.Add(DrawToolType.Line, new ToolLine());
        }

        public static readonly object MouseDoubleEvent = new object();

        public new event EventHandler<MouseDoubleClickEventArgs> MouseDoubleClick
        {
            add { this.Events.AddHandler(MouseDoubleEvent, value); }
            remove { this.Events.RemoveHandler(MouseDoubleEvent, value); }
        }

        private void OnMouseDoubleClick()
        {
            var handler = this.Events[MouseDoubleEvent] as EventHandler<MouseDoubleClickEventArgs>;
            if (handler != null)
            {
                handler(this, new MouseDoubleClickEventArgs(this.Selection));
            }
        }

        void DrawArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick();
        }

        void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[ActiveDrawTool].OnMouseUp(this, e);
        }

        void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.None)
                tools[ActiveDrawTool].OnMouseMove(this, e);
            else
                this.Cursor = Cursors.Default;
        }

        void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tools[ActiveDrawTool].OnMouseDown(this, e);
            //else if (e.Button == MouseButtons.Right)
            //    OnContextMenu(e);
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
                this.Invalidate();
            }
        }

        //private Size oldAutoScrollMinSize;
        void DrawArea_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255)))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PageUnit = GraphicsUnit.Pixel; //GraphicsUnit.Pixel才支持缩放与偏移绘制。

                //if (MouseButtons != MouseButtons.Left)
                //{
                //    Rectangle b = Rectangle.Round(SumRectangles());
                //    AutoScrollMinSize = new Size((int)((b.Size.Width + 50) * this.Zoom), (int)((b.Size.Height + 50) * this.Zoom));
                //    oldAutoScrollMinSize = AutoScrollMinSize;
                //}
                //else
                //{
                //    AutoScrollMinSize = oldAutoScrollMinSize;
                //}

                e.Graphics.FillRectangle(brush, this.ClientRectangle);

                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.ScaleTransform(Zoom, Zoom, MatrixOrder.Prepend);

                int n = GraphicsList.Count;
                DrawObject o;
                // Enumerate list in reverse order to get first
                // object on the top of Z-order.
                for (int i = n - 1; i >= 0; i--)
                {
                    o = GraphicsList[i];
                    o.Draw(e.Graphics);
                    if (o.Selected == true)
                        o.DrawTracker(e.Graphics);
                }


            }
        }

        /// <summary>
        /// Returns the union of the bounding rectangles of all entities
        /// </summary>
        private RectangleF SumRectangles()
        {
            RectangleF r = RectangleF.Empty;

            // for each shape in mShapes of the abstract
            foreach (DrawObject obj in this.GraphicsList)
            {
                if (obj is DrawRectangle)
                {
                    r = RectangleF.Union(r, (obj as DrawRectangle).Rectangle);
                }
            }
            return r;
        }

        /// <summary>
        /// Return True if Undo operation is possible
        /// </summary>
        public bool CanUndo
        {
            get
            {
                if (undoManager != null)
                {
                    return undoManager.CanUndo;
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
                if (undoManager != null)
                {
                    return undoManager.CanRedo;
                }

                return false;
            }
        }

        public void Undo()
        {
            undoManager.Undo();
            Refresh();
        }

        public void Redo()
        {
            undoManager.Redo();
            Refresh();
        }

        #region IEnumerable<DrawObject> 成员

        public IEnumerator<DrawObject> GetEnumerator()
        {
            return this.GraphicsList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region ISerializable 成员

        private const string entryCount = "Count";
        private const string entryType = "Type";

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(entryCount, GraphicsList.Count);

            int i = 0;

            foreach (DrawObject o in GraphicsList)
            {
                info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryType, i), o.GetType().FullName);

                o.SaveToStream(info, i);

                i++;
            }
        }

        #endregion

        #region IGraphicsList 成员

        public bool Clear()
        {
            return this.GraphicsList.Clear();
        }

        public int Count
        {
            get { return GraphicsList.Count; }
        }

        public DrawObject this[int index]
        {
            get { return GraphicsList[index]; }
        }

        public int SelectionCount
        {
            get { return GraphicsList.SelectionCount; }
        }

        public IEnumerable<DrawObject> Selection
        {
            get { return GraphicsList.Selection; }
        }

        public void Add(DrawObject obj)
        {
            this.GraphicsList.Add(obj);
        }

        public void Insert(int index, DrawObject obj)
        {
            this.GraphicsList.Insert(index, obj);
        }

        public void Replace(int index, DrawObject obj)
        {
            this.GraphicsList.Replace(index, obj);
        }

        public void RemoveAt(int index)
        {
            this.GraphicsList.RemoveAt(index);
        }

        public void DeleteLastAddedObject()
        {
            this.GraphicsList.DeleteLastAddedObject();
        }

        public void SelectInRectangle(Rectangle rectangle)
        {
            this.GraphicsList.SelectInRectangle(rectangle);
        }

        public void UnselectAll()
        {
            this.GraphicsList.UnselectAll();
        }

        public void SelectAll()
        {
            this.GraphicsList.SelectAll();
        }

        public bool DeleteSelection()
        {
            return this.GraphicsList.DeleteSelection();
        }

        public bool MoveSelectionToFront()
        {
            return this.GraphicsList.MoveSelectionToFront();
        }

        public bool MoveSelectionToBack()
        {
            return this.GraphicsList.MoveSelectionToBack();
        }

        #endregion


        private bool IsDirty { get; set; }

        public void SetDirty()
        {
            IsDirty = true;
        }

        /// <summary>
        /// Add command to history.
        /// </summary>
        /// <param name="command"></param>
        public void AddCommandToHistory(Command command)
        {
            undoManager.AddCommandToHistory(command);
        }

        /// <summary>
        /// Clear Undo history.
        /// </summary>
        public void ClearHistory()
        {
            undoManager.ClearHistory();
        }
    }
}
