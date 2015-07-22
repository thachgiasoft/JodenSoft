using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.Globalization;
using System.Security.Permissions;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.ComponentModel;
using SAF.Foundation;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// List of graphic objects
    /// </summary>
    [Serializable]
    public class GraphicsCollection : IList<DrawObject>, ISerializable
    {
        private List<DrawObject> innerList { get; set; }

        public GraphicsCollection()
        {
            innerList = new List<DrawObject>();
        }

        #region Other functions

        internal void CalcOwnerId()
        {
            foreach (var item in this)
            {
                if (item is DrawRectangle)
                    item.OwnerId = DrawObject.GetOwnerGuid(item as DrawRectangle, this);
            }
        }

        public void Draw(Graphics g, DrawArea drawArea)
        {
            int n = innerList.Count;
            DrawObject o;

            // Enumerate list in reverse order to get first
            // object on the top of Z-order.
            for (int i = n - 1; i >= 0; i--)
            {
                o = innerList[i];

                if (o is DrawLine)
                {
                    (o as DrawLine).CurrentDrawArea = drawArea;
                }

                o.Draw(g);

                if (o.Selected == true)
                {
                    o.DrawTracker(g);
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        internal void ReplaceDrawLine()
        {
            int n = innerList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                var o = innerList[i];
                var line = o as DrawLine;
                if (o.Type == GraphicsType.Line)
                {
                    if (line.ArrowType == ArrowType.Empty)
                    {
                        var temp = new InheritLine();
                        CopyLine(temp, line);
                        innerList[i] = temp;
                    }
                    else if (line.ArrowType == ArrowType.None)
                    {
                        var temp = new UseLine();
                        CopyLine(temp, line);
                        innerList[i] = temp;
                    }
                    else if (line.ArrowType == ArrowType.Fill)
                    {
                        if (this.DiagramType == DiagramType.State)
                        {
                            var temp = new Transition();
                            CopyLine(temp, line);
                            innerList[i] = temp;
                        }
                        else if (this.DiagramType == DiagramType.HSEntitySet)
                        {
                            var temp = new Reference();
                            CopyLine(temp, line);
                            innerList[i] = temp;
                        }
                        else if (this.DiagramType == DiagramType.UserCase)
                        {
                            var temp = new InvokesLine();
                            CopyLine(temp, line);
                            innerList[i] = temp;
                        }
                        else if (this.DiagramType == DiagramType.Workflow)
                        {
                            var temp = new FlowLine();
                            CopyLine(temp, line);
                            innerList[i] = temp;
                        }
                    }
                }
            }
        }

        private void CopyLine(DrawLine temp, DrawLine line)
        {
            temp.CurrentDrawArea = line.CurrentDrawArea;
            temp.StartPoint = line.StartPoint;
            temp.EndPoint = line.EndPoint;
            temp.StartDrawObjectID = line.StartDrawObjectID;
            temp.EndDrawObjectID = line.EndDrawObjectID;
            temp.IsDotLine = line.IsDotLine;
            temp.StartOffsetSize = line.StartOffsetSize;
            temp.EndOffsetSize = line.EndOffsetSize;
            temp.ArrowType = line.ArrowType;

            temp.Selected = line.Selected;
            temp.GUID = line.GUID;
            temp.Text = line.Text;
            temp.Name = line.Name;
            temp.Status = line.Status;
            temp.iStatus = line.iStatus;

            temp.Tag = line.Tag;
            temp.Description = line.Description;
        }

        /// <summary>
        /// SelectedCount and GetSelectedObject allow to read
        /// selected objects in the loop
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawObject o in Selection)
                {
                    n++;
                }

                return n;
            }
        }


        /// <summary>
        /// Returns INumerable object which may be used for enumeration
        /// of selected objects.
        /// Note: returning IEnumerable<DrawObject> breaks CLS-compliance
        /// (assembly CLSCompliant = true is removed from AssemblyInfo.cs).
        /// m_To make this program CLS-compliant, replace 
        /// IEnumerable<DrawObject> with IEnumerable. This requires
        /// casting to object at runtime.
        /// </summary>
        public IEnumerable<DrawObject> Selection
        {
            get
            {
                foreach (DrawObject o in innerList)
                {
                    if (o.Selected)
                    {
                        yield return o;
                    }
                }
            }
        }

        /// <summary>
        /// Replace object in specified place.
        /// Used for Undo.
        /// </summary>
        public void Replace(int index, DrawObject obj)
        {
            if (index >= 0 && index < innerList.Count)
            {
                innerList.RemoveAt(index);
                innerList.Insert(index, obj);
                CalcOwnerId();
            }
        }

        /// <summary>
        /// Delete last added object from the list
        /// (used for Undo operation).
        /// </summary>
        public void DeleteLastAddedObject()
        {
            if (innerList.Count > 0)
            {
                innerList.RemoveAt(0);
                CalcOwnerId();
            }
        }

        public void SelectInRectangle(Rectangle rectangle)
        {
            UnselectAll();

            foreach (DrawObject o in innerList)
            {
                if (o.IntersectsWith(rectangle))
                    o.Selected = true;
            }
        }

        public void MoveSwimlane(Swimlane swimLane, int dx, int dy, Guid parentID)
        {
            if (swimLane == null) return;

            foreach (DrawObject o in innerList)
            {
                if (o.GUID != parentID && o.Selected == false)
                {
                    if (o.OwnerId == parentID)
                    {
                        int x = o.Left;
                        int y = o.Top;

                        if (x + dx < 0 || y + dy < 0)
                        {
                            dx = Math.Min(Math.Abs(x), Math.Abs(dx));
                            dy = Math.Min(Math.Abs(y), Math.Abs(dy));
                            o.Move(dx, dy);
                        }
                        else
                        {
                            o.Move(dx, dy);
                        }

                        if (o is Swimlane)
                            MoveSwimlane(o as Swimlane, dx, dy, o.GUID);
                    }


                }
            }
        }


        public void UnselectAll()
        {
            foreach (DrawObject o in innerList)
            {
                o.Selected = false;
            }
        }

        public void SelectAll()
        {
            foreach (DrawObject o in innerList)
            {
                o.Selected = true;
            }

        }

        /// <summary>
        /// Delete selected items
        /// </summary>
        /// <returns>
        /// true if at least one object is deleted
        /// </returns>
        public bool DeleteSelection()
        {
            bool result = false;

            int n = innerList.Count;

            List<DrawObject> delList = new List<DrawObject>();

            for (int i = n - 1; i >= 0; i--)
            {
                if (innerList[i].Selected)
                {
                    foreach (var item in innerList)
                    {
                        var line = item as DrawLine;
                        if (line != null)
                        {
                            if (line.StartDrawObjectID == innerList[i].GUID || line.EndDrawObjectID == innerList[i].GUID)
                            {
                                if (delList.IndexOf(line) < 0)
                                {
                                    delList.Add(line);
                                }
                            }
                        }
                    }
                    delList.Add(innerList[i]);
                }
            }

            foreach (var item in delList)
            {
                this.Remove(item);
                result = true;
            }

            CalcOwnerId();
            return result;
        }

        public bool MoveLineToFront()
        {
            int n;
            int i;
            List<DrawObject> tempList;

            tempList = new List<DrawObject>();
            n = innerList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if ((innerList[i]) is DrawLine)
                {
                    tempList.Add(innerList[i]);
                    innerList.RemoveAt(i);
                }
            }

            // Read temporary list in direct order and insert every item
            // to the beginning of the source list
            n = tempList.Count;

            for (i = 0; i < n; i++)
            {
                innerList.Insert(0, tempList[i]);
            }

            CalcOwnerId();

            return (n > 0);
        }

        public bool MoveSwimlaneToBack()
        {
            int n;
            int i;
            List<DrawObject> tempList;

            tempList = new List<DrawObject>();
            n = innerList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if ((innerList[i]) is Swimlane)
                {
                    tempList.Add(innerList[i]);
                    innerList.RemoveAt(i);
                }
            }

            // Read temporary list in reverse order and add every item
            // to the end of the source list
            n = tempList.Count;

            for (i = n - 1; i >= 0; i--)
            {
                innerList.Add(tempList[i]);
            }

            CalcOwnerId();
            return (n > 0);
        }
        /// <summary>
        /// Move selected items to front (beginning of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToFront()
        {
            int n;
            int i;
            List<DrawObject> tempList;

            tempList = new List<DrawObject>();
            n = innerList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if ((innerList[i]).Selected)
                {
                    tempList.Add(innerList[i]);
                    innerList.RemoveAt(i);
                }
            }

            // Read temporary list in direct order and insert every item
            // to the beginning of the source list
            n = tempList.Count;

            for (i = 0; i < n; i++)
            {
                innerList.Insert(0, tempList[i]);
            }

            CalcOwnerId();
            return (n > 0);
        }

        /// <summary>
        /// Move selected items to back (end of the list)
        /// </summary>
        /// <returns>
        /// true if at least one object is moved
        /// </returns>
        public bool MoveSelectionToBack()
        {
            int n;
            int i;
            List<DrawObject> tempList;

            tempList = new List<DrawObject>();
            n = innerList.Count;

            // Read source list in reverse order, add every selected item
            // to temporary list and remove it from source list
            for (i = n - 1; i >= 0; i--)
            {
                if ((innerList[i]).Selected)
                {
                    tempList.Add(innerList[i]);
                    innerList.RemoveAt(i);
                }
            }

            // Read temporary list in reverse order and add every item
            // to the end of the source list
            n = tempList.Count;

            for (i = n - 1; i >= 0; i--)
            {
                innerList.Add(tempList[i]);
            }

            CalcOwnerId();

            return (n > 0);
        }

        /// <summary>
        /// Get properties from selected objects and fill GraphicsProperties instance
        /// </summary>
        /// <returns></returns>
        private GraphicsProperties GetProperties()
        {
            GraphicsProperties properties = new GraphicsProperties();

            var obj = Selection.FirstOrDefault();
            if (obj != null)
            {
                properties.Name = obj.Name;
                properties.Text = obj.Text;
                properties.Status = obj.Status;
                properties.iStatus = obj.iStatus;
                properties.Description = obj.Description;
                properties.IsColorObject = obj is UserCase || obj is HSEntitySet;
                var rect = obj as DrawRectangle;
                if (rect != null && rect.CanChangeBackColor)
                {
                    properties.BackColor = (obj as DrawRectangle).BackColor;
                }
            }

            return properties;
        }

        /// <summary>
        /// Apply properties for all selected objects.
        /// Returns TRue if at least one property is changed.
        /// </summary>
        private bool ApplyProperties(GraphicsProperties properties)
        {
            bool changed = false;

            foreach (DrawObject o in innerList)
            {
                if (o.Selected)
                {
                    if (properties.BackColor.HasValue)
                    {
                        if (o is DrawRectangle)
                        {
                            (o as DrawRectangle).BackColor = properties.BackColor.Value;
                            changed = true;
                        }
                    }

                    if (o.Name.m_IsEmpty() || !o.Name.Equals(properties.Name, StringComparison.CurrentCulture))
                    {
                        o.Name = properties.Name;
                        changed = true;
                    }

                    if (o.Text.m_IsEmpty() || !o.Text.Equals(properties.Text, StringComparison.CurrentCulture))
                    {
                        o.Text = properties.Text;
                        changed = true;
                    }

                    if (o.Status.m_IsEmpty() || !o.Status.Equals(properties.Status, StringComparison.CurrentCulture))
                    {
                        o.Status = properties.Status;
                        changed = true;
                    }

                    if (o.iStatus != properties.iStatus)
                    {
                        o.iStatus = properties.iStatus;
                        changed = true;
                    }

                    if (o.Description.m_IsEmpty() || !o.Description.Equals(properties.Description, StringComparison.CurrentCulture))
                    {
                        o.Description = properties.Description;
                        changed = true;
                    }

                }
            }

            return changed;
        }

        /// <summary>
        /// Show Properties dialog. Return true if list is changed
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool ShowPropertiesDialog(DrawArea parent)
        {
            if (SelectionCount != 1)
                return false;

            GraphicsProperties properties = GetProperties();
            properties.ReadOnly = parent.ReadOnly;

            if (parent.GraphicsCollection.Selection.First() is DrawLine)
                properties.ShowiStatus = false;

            PropertiesDialog dlg = new PropertiesDialog(properties);

            CommandChangeState c = new CommandChangeState(this);

            if (dlg.ShowDialog(parent) != DialogResult.OK || properties.ReadOnly)
                return false;

            if (ApplyProperties(properties))
            {
                c.NewState(this);
                parent.AddCommandToHistory(c);
                parent.SetDirty();
            }

            return true;
        }

        public bool LineCancelMove()
        {
            bool flag = false;
            foreach (DrawObject o in innerList)
            {
                if (o.Selected && o is DrawLine)
                {
                    (o as DrawLine).StartOffsetSize = new Size(0, 0);
                    (o as DrawLine).EndOffsetSize = new Size(0, 0);
                    flag = true;
                }
            }

            return flag;
        }

        #endregion

        #region IList

        public int IndexOf(DrawObject item)
        {
            int index = -1;
            for (int i = 0; i < innerList.Count; i++)
            {
                if (innerList[i].GUID == item.GUID)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, DrawObject item)
        {
            if (index >= 0)
            {
                this.innerList.Insert(index, item);
            }
            else
            {
                throw new OverflowException("index必须大于0.");
            }
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public DrawObject this[int index]
        {
            get
            {
                return this.innerList[index];
            }
            set
            {
                this.innerList[index] = value;
            }
        }

        public void Add(DrawObject item)
        {
            Insert(0, item);

            CalcOwnerId();
        }

        public bool Contains(DrawObject item)
        {
            return innerList.Any(p => p.GUID == item.GUID);
        }

        public void CopyTo(DrawObject[] array, int arrayIndex)
        {
            this.innerList.CopyTo(array, arrayIndex); 
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(DrawObject item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                CalcOwnerId();
                return true;
            }
            return false;
        }

        public void Clear()
        {
            this.innerList.Clear();
        }

        public int Count
        {
            get { return innerList.Count; }
        }

        public IEnumerator<DrawObject> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion

        #region 二进制序列化支持

        private const string entryCount = "Count";
        private const string entryType = "Type";
        private const string entryZoom = "Zoom";
        private const string entryDiagramType = "DiagramType";
        private const string entryReadOnly = "ReadOnly";

        /// <summary>
        /// 仅供序列化时保存与恢复使用
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal float Zoom { get; set; }

        /// <summary>
        /// 仅供序列化时保存与恢复使用
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal DiagramType DiagramType { get; set; }

        protected GraphicsCollection(SerializationInfo info, StreamingContext context)
        {
            innerList = new List<DrawObject>();

            int n = info.GetInt32(entryCount);
            this.Zoom = (float)info.GetDouble(entryZoom);
            this.DiagramType = (DiagramType)info.GetInt32(entryDiagramType);

            string typeName;
            DrawObject drawObject;

            for (int i = n - 1; i >= 0; i--)
            {
                typeName = info.GetString(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryType, i));

                drawObject = (DrawObject)Assembly.GetExecutingAssembly().CreateInstance(typeName);

                if (drawObject == null)
                    throw new Exception("类型 {0} 创建实例失败.".FormatWith(typeName));

                drawObject.LoadFromStream(info, i);

                this.Add(drawObject);
            }

        }

        /// <summary>
        /// Save object to serialization stream
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(entryCount, this.Count);
            info.AddValue(entryZoom, this.Zoom);
            info.AddValue(entryDiagramType, (int)this.DiagramType);

            int i = 0;
            foreach (DrawObject o in this.innerList)
            {
                info.AddValue(String.Format(CultureInfo.InvariantCulture, "{0}{1}", entryType, i), o.GetType().FullName);

                o.SaveToStream(info, i);

                i++;
            }
        }

        #endregion



        public string Dump()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in innerList)
            {
                sb.Append(item.Dump());
            }
            return sb.ToString();
        }
    }
}
