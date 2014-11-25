using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Globalization;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Linq.Expressions;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Base class for all draw objects
    /// </summary>
    [Serializable]
    public abstract class DrawObject
    {
        public DrawObject()
        {
            this.Selected = false;
            this.GUID = Guid.NewGuid();
            this.iStatus = 0;
            this.Name = string.Empty;
            this.Text = string.Empty;
            this.Status = string.Empty;
            this.Description = string.Empty;
            this.OwnerId = Guid.Empty;

            Initialize();
        }

        #region Properties

        public Guid OwnerId { get; set; }

        [Browsable(false)]
        public virtual GraphicsType Type
        {
            get { return GraphicsType.Pointer; }
        }

        private bool selected = false;

        /// <summary>
        /// Number of handles
        /// </summary>
        protected virtual int HandleCount
        {
            get
            {
                return 0;
            }
        }

        protected Color PenColor
        {
            get
            {
                return Color.Black;
            }
        }

        protected int PenWidth
        {
            get
            {
                return 1;
            }
        }

        private Font font = new Font("宋体", 9);

        protected Font Font
        {
            get { return font; }
        }

        protected StringFormat DefaultStringFormat
        {
            get
            {
                StringFormat sf = new StringFormat(StringFormatFlags.LineLimit);
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisWord;
                return sf;
            }
        }
        #endregion

        /// <summary>
        /// Object GUID
        /// </summary>
        [Browsable(false)]
        public Guid GUID { get; set; }

        /// <summary>
        /// Selection flag
        /// </summary>
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected == value) return;
                selected = value;
            }
        }

        [Browsable(true), Category(Strings.Normal)]
        private string _Name = string.Empty;
        public string Name
        {
            get { return this._Name; }
            set { _Name = value == null ? string.Empty : value.Trim(); }
        }

        [Browsable(true), Category(Strings.Normal)]
        public string Text { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        [Browsable(true), Category(Strings.Normal)]
        public string Status { get; set; }

        private int _iStatus = 0;
        /// <summary>
        ///  状态
        /// </summary>
        [Browsable(true), Category(Strings.Normal)]
        public int iStatus
        {
            get { return _iStatus; }
            set
            {
                _iStatus = value;

                SetiStatus(value);
            }
        }

        protected virtual void SetiStatus(int iStatus)
        {

        }

        [Browsable(false)]
        public string Description { get; set; }

        [Browsable(false)]
        public object Tag { get; set; }

        #region Virtual Functions

        [Browsable(true), Category(Strings.Layout)]
        public virtual int Left { get; set; }
        [Browsable(true), Category(Strings.Layout)]
        public virtual int Top { get; set; }

        [Browsable(true), Category(Strings.Layout)]
        public virtual int Width { get; set; }
        [Browsable(true), Category(Strings.Layout)]
        public virtual int Height { get; set; }


        public string Dump()
        {
            RichTextBox text = new RichTextBox();
            text.Rtf = this.Description;
            return string.Format("{{{0}Name:{1}{0}Text:{2}{0}BillType:{3}{0}iStatus:{6}{0}Description:{4}{0}Guid:{5}{0}}}{0}", Environment.NewLine, this.Name, this.Text, this.Status, text.Text, this.GUID, this.iStatus);
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        public abstract DrawObject Clone();

        /// <summary>
        /// Draw object
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// Get handle point by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// Get handle rectangle by 1-based number
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// Draw tracker for selected object
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;

            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 1; i <= HandleCount; i++)
            {
                g.FillRectangle(brush, GetHandleRectangle(i));
            }

            brush.Dispose();
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit;
        ///                0 - hit anywhere;
        ///                > 1 - handle number;
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }


        /// <summary>
        /// Test whether point is inside of the object
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }


        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="handleNumber"></param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// Test whether object intersects with rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary>
        /// Move object
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// Move handle to the point
        /// </summary>
        /// <param name="point"></param>
        /// <param name="handleNumber"></param>
        public virtual void MoveHandleTo(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// Normalize object.
        /// Call this function in the end of object resizing.
        /// </summary>
        public virtual void Normalize()
        {
        }

        #endregion



        #region Other functions

        /// <summary>
        /// Initialization
        /// </summary>
        protected void Initialize()
        {

        }

        /// <summary>
        /// Copy fields from this instance to cloned instance drawObject.
        /// Called from Clone functions of derived classes.
        /// </summary>
        protected virtual void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.Selected = this.Selected;
            drawObject.GUID = this.GUID;
            drawObject.Text = this.Text;
            drawObject.Name = this.Name;
            drawObject.Status = this.Status;
            drawObject.iStatus = this.iStatus;

            drawObject.Tag = this.Tag;
            drawObject.Description = this.Description;
        }

        #endregion

        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param> 
        public virtual void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(this.SerializationName(p => p.GUID, orderNumber), this.GUID);
            info.AddValue(this.SerializationName(p => p.Selected, orderNumber), this.Selected);

            info.AddValue(this.SerializationName(p => p.Left, orderNumber), this.Left);
            info.AddValue(this.SerializationName(p => p.Top, orderNumber), this.Top);
            info.AddValue(this.SerializationName(p => p.Width, orderNumber), this.Width);
            info.AddValue(this.SerializationName(p => p.Height, orderNumber), this.Height);

            info.AddValue(this.SerializationName(p => p.Text, orderNumber), this.Text);
            info.AddValue(this.SerializationName(p => p.Name, orderNumber), this.Name);
            info.AddValue(this.SerializationName(p => p.Status, orderNumber), this.Status);
            info.AddValue(this.SerializationName(p => p.Description, orderNumber), this.Description);
            info.AddValue(this.SerializationName(p => p.Tag, orderNumber), this.Tag);
            info.AddValue(this.SerializationName(p => p.iStatus, orderNumber), this.iStatus);

        }

        /// <summary>
        /// Load object from serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public virtual void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            this.GUID = (Guid)info.GetValue(this.SerializationName(p => p.GUID, orderNumber), typeof(Guid));
            this.selected = info.GetBoolean(this.SerializationName(p => p.Selected, orderNumber));

            this.Left = info.GetInt32(this.SerializationName(p => p.Left, orderNumber));
            this.Top = info.GetInt32(this.SerializationName(p => p.Top, orderNumber));
            this.Width = info.GetInt32(this.SerializationName(p => p.Width, orderNumber));
            this.Height = info.GetInt32(this.SerializationName(p => p.Height, orderNumber));

            this.Text = info.GetString(this.SerializationName(p => p.Text, orderNumber));
            this.Name = info.GetString(this.SerializationName(p => p.Name, orderNumber));
            this.Status = info.GetString(this.SerializationName(p => p.Status, orderNumber));

            this.Description = info.GetString(this.SerializationName(p => p.Description, orderNumber));
            this.Tag = info.GetValue(this.SerializationName(p => p.Tag, orderNumber), typeof(object));

            try
            {
                this.iStatus = info.GetInt32(this.SerializationName(p => p.iStatus, orderNumber));
            }
            catch
            {
                this.iStatus = 0;
            }
        }

        /// <summary>
        /// 只取左上角所在泳道的GUID,而且当有多层时,只取最上一层
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="graphicsCollection"></param>
        /// <returns></returns>
        public static Guid GetOwnerGuid(DrawRectangle rect, GraphicsCollection graphicsCollection)
        {
            if (rect == null || graphicsCollection == null) return Guid.Empty;

            var listOwner = new List<Swimlane>();
            for (int i = 0; i < graphicsCollection.Count; i++)
            {
                if (graphicsCollection[i].GUID == rect.GUID) continue;

                Swimlane lane = graphicsCollection[i] as Swimlane;
                if (lane == null) continue;

                if (lane.Rectangle.Contains(rect.Left, rect.Top))
                {
                    listOwner.Add(lane);
                }
            }

            if (listOwner.Count > 0)
                return listOwner[0].GUID;
            return Guid.Empty;
        }

    }
}
