using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Base class for all draw objects
    /// </summary>
    public abstract class DrawObject
    {
        // Entry names for serialization
        private const string entryID = "ID";
        private const string entryColor = "Color";
        private const string entryPenWidth = "PenWidth";

        public DrawObject()
        {
            ID = Guid.NewGuid();

            Initialize();
        }

        #region Properties

        /// <summary>
        /// Object ID
        /// </summary>
        public Guid ID { get; set; }

        public string Caption { get; set; }

        public string Text { get; set; }


        private Font font = new Font("宋体", 9);
        protected Font Font
        {
            get { return font; }
        }

        private StringFormat stringFormat = null;
        protected StringFormat StringFormat
        {
            get
            {
                if (stringFormat == null)
                {
                    stringFormat = new StringFormat(StringFormatFlags.LineLimit);
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.EllipsisWord;
                }
                return stringFormat;
            }
        }

        /// <summary>
        /// Selection flag
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public Color PenColor { get; set; }

        /// <summary>
        /// Pen width
        /// </summary>
        public int PenWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Color BackColor { get; set; }

        /// <summary>
        /// Number of handles
        /// </summary>
        public virtual int HandleCount
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region Virtual Functions

        /// <summary>
        /// Clone this instance.
        /// </summary>
        public abstract DrawObject Clone();

        /// <summary>
        /// Draw object
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawGraph(g);
            DrawContent(g);
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawGraph(Graphics g)
        {

        }
        /// <summary>
        /// 绘制图形内容
        /// </summary>
        /// <param name="g"></param>
        protected virtual void DrawContent(Graphics g)
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

            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                for (int i = 1; i <= HandleCount; i++)
                {
                    g.FillRectangle(brush, GetHandleRectangle(i));
                }
            }
        }

        /// <summary>
        /// Hit test.
        /// Return value: -1 - no hit
        ///                0 - hit anywhere
        ///                > 1 - handle number
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
        /// Dump (for debugging)
        /// </summary>
        public virtual void Dump()
        {
            Trace.WriteLine(this.GetType().Name);
            Trace.WriteLine("Selected = " +
                Selected.ToString(CultureInfo.InvariantCulture)
                + " ID = " + ID.ToString("D", CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Normalize object.
        /// Call this function in the end of object resizing.
        /// </summary>
        public virtual void Normalize()
        {
        }


        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public virtual void SaveToStream(SerializationInfo info, int orderNumber)
        {
            info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryID, orderNumber), ID.ToString("D"));

            info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryColor, orderNumber), PenColor.ToArgb());

            info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryPenWidth, orderNumber), PenWidth);
        }

        /// <summary>
        /// Load object from serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="orderNumber"></param>
        public virtual void LoadFromStream(SerializationInfo info, int orderNumber)
        {
            string id = info.GetString(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryID, orderNumber));
            ID = new Guid(id);

            int n = info.GetInt32(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryColor, orderNumber));
            PenColor = Color.FromArgb(n);

            PenWidth = info.GetInt32(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryPenWidth, orderNumber));

        }

        #endregion

        /// <summary>
        /// Initialization
        /// </summary>
        protected void Initialize()
        {
            PenColor = Color.Black;
            PenWidth = 1;
            BackColor = Color.Linen;
        }

        /// <summary>
        /// Copy fields from this instance to cloned instance drawObject.
        /// Called from Clone functions of derived classes.
        /// </summary>
        protected void FillDrawObjectFields(DrawObject drawObject)
        {
            drawObject.Selected = this.Selected;
            drawObject.PenColor = this.PenColor;
            drawObject.PenWidth = this.PenWidth;
            drawObject.ID = this.ID;
        }

    }
}
