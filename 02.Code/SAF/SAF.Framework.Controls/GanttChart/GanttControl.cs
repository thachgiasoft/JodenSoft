using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SAF.Framework.Controls.GanttChart
{
    [ToolboxItem(true)]
    public class GanttControl : Control, IEnumerable<TaskCenter>
    {
        #region private

        private System.Windows.Forms.VScrollBar _vScrollbar;
        private System.Windows.Forms.HScrollBar _hScrollbar;

        private int _scaleHeaderHeight = 25;
        private int _scaleHeight = 25;

        private int _taskVerticalInterval = 4;

        private int HeaderHeight
        {
            get { return _scaleHeaderHeight + _scaleHeight; }
        }

        private ContextMenuStrip _ContextMenu;

        #endregion

        #region TaskCenters & Tasks

        private TaskCenterCollection TaskCenters { get; set; }

        #endregion

        #region Scroll

        internal void AdjustScrollbar()
        {
            _hScrollbar.Maximum = (_scaleWidth * (_totalScale + 2)) + this.TaskCenterWidth + this._vScrollbar.Width - this.Width + 10;
            _hScrollbar.Minimum = 0;

            _vScrollbar.Maximum = this.TaskCenters.Where(p => p.Visible).Count() - (int)((this.Height - this.HeaderHeight - this._hScrollbar.Height) / this._taskCenterHeight) + 1;
            _vScrollbar.Minimum = 0;
        }

        public void hScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        public void vScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        #endregion

        #region TaskCenterHeight

        private int _taskCenterHeight = 24;
        [System.ComponentModel.DefaultValue(24)]
        public int TaskCenterHeight
        {
            get
            {
                return _taskCenterHeight;
            }
            set
            {
                _taskCenterHeight = value;
                Refresh();
            }
        }

        #endregion

        #region ScaleWidth

        private int _scaleWidth = 24;
        [System.ComponentModel.DefaultValue(24)]
        public int ScaleWidth
        {
            get
            {
                return _scaleWidth;
            }
            set
            {
                _scaleWidth = value;
                Refresh();
            }
        }

        #endregion

        #region RefreshGannt

        public override void Refresh()
        {
            base.Refresh();
            AdjustScrollbar();
            Invalidate();
        }

        #endregion

        #region TaskCenterWidth

        internal void CalcTaskCenterWidth()
        {
            if (this.TaskCenters == null)
            {
                TaskCenterWidth = 80;
                return;
            }
            var maxLength = 0;
            if (this.TaskCenters.Count > 0)
                maxLength = this.TaskCenters.Max(a => a.Name.Length);

            var taskCenter = this.TaskCenters.FirstOrDefault(p => p.Name.Length == maxLength);
            if (taskCenter == null)
                TaskCenterWidth = 80;
            else
            {
                var g = this.CreateGraphics();
                var size = g.MeasureString(taskCenter.Name, this.Renderer.Font);
                TaskCenterWidth = (int)size.Width + 40;
            }
        }

        [Browsable(false)]
        public int TaskCenterWidth
        {
            get;
            private set;
        }

        #endregion

        #region TotalScale

        private int _totalScale = 48;
        [System.ComponentModel.DefaultValue(48)]
        public int TotalScale
        {
            get
            {
                return _totalScale;
            }
            set
            {
                _totalScale = value;
                Refresh();
            }
        }

        #endregion

        #region ShowNowLine & ShowTooltip

        private bool _showNowLine = true;
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowNowLine
        {
            get { return _showNowLine; }
            set
            {
                _showNowLine = value;
                this.Refresh();
            }
        }

        public bool ShowTooltip { get; set; }

        private Label _lblTooltip;

        internal void ShowTooltipCore(Task task, Point p)
        {
            if (task != null)
            {
                var args = new CustomTaskTooltipEventArgs(task);
                var handler = this.Events[CustomTaskTooltipEvent] as EventHandler<CustomTaskTooltipEventArgs>;
                if (handler != null)
                {
                    handler(this, args);
                }
                if (string.IsNullOrWhiteSpace(args.Tooltip))
                {
                    this._lblTooltip.Text = string.Format("任务名称: {1}{0}开始时间: {2}{0}结束时间: {3}{0}数量: {4}{0}完成百分比: {5}%",
                        Environment.NewLine, task.Name, task.StartTime, task.StartTime.Add(task.WorkTimeSpan), task.Qty, task.Percent * 100);
                }
                else
                {
                    this._lblTooltip.Text = args.Tooltip;
                }
                this._lblTooltip.Location = new Point(p.X + 10, p.Y + 15);
                this._lblTooltip.Visible = true;
            }
            else
            {
                this._lblTooltip.Hide();
            }
        }

        private bool _ShowDeliveryTimeLine = true;
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowDeliveryTimeLine
        {
            get { return _ShowDeliveryTimeLine; }
            set
            {
                _ShowDeliveryTimeLine = value;
                this.Refresh();
            }
        }

        private bool _ShowTaskCenterGroupColor = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowTaskCenterGroupColor
        {
            get { return _ShowTaskCenterGroupColor; }
            set
            {
                _ShowTaskCenterGroupColor = value;
                this.Refresh();
            }
        }

        #endregion

        #region Render

        private AbstractRenderer _renderer;
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public AbstractRenderer Renderer
        {
            get
            {
                return _renderer;
            }
            set
            {
                _renderer = value;
                this.Font = _renderer.Font;
                this.Refresh();
            }
        }

        #endregion

        #region StartTime

        private DateTime _startTime = DateTime.Now;
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public DateTime StartTime
        {
            get
            {
                if (this.GanntView == GanttView.HourView)
                    return new DateTime(this._startTime.Year, this._startTime.Month, this._startTime.Day, this._startTime.Hour, 0, 0);
                else
                    return new DateTime(this._startTime.Year, this._startTime.Month, this._startTime.Day, 0, 0, 0);
            }
            set
            {
                _startTime = value;
                this.Refresh();
            }
        }

        #endregion

        #region  SelectionTaskCenter & SelectionTask

        private TaskCenter _SelectionTaskCenter = null;
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public TaskCenter SelectionTaskCenter
        {
            get { return this._SelectionTaskCenter; }
            set
            {
                this._SelectionTaskCenter = value;
                this.Invalidate();
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public List<Task> SelectionTasks { get; internal set; }

        #endregion

        #region GanntView

        private GanttView _ganntView = GanttView.HourView;
        public GanttView GanntView
        {
            get { return _ganntView; }
            set
            {
                _ganntView = value;
                Refresh();
            }
        }

        #endregion

        #region ShowPercent

        private bool _showPercent = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowPercent
        {
            get { return _showPercent; }
            set
            {
                _showPercent = value;
                this.Refresh();
            }
        }

        #endregion

        public bool IsReadOnly { get; set; }

        #region ShowHorizontalLine

        private bool _showHorizontalLine = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool ShowHorizontalLine
        {
            get { return _showHorizontalLine; }
            set
            {
                _showHorizontalLine = value;
                this.Refresh();
            }
        }

        #endregion

        private Color _LineColor
        {
            get
            {
                return Color.FromArgb(104, 147, 204);
            }
        }

        public IEnumerable<Task> GetChangedTasks()
        {
            var list = new List<Task>();

            foreach (var taskCenter in this.TaskCenters)
            {
                var changed = taskCenter.Where(p => p.IsDirty);
                if (changed != null && changed.Count() > 0)
                    list.AddRange(changed);
            }

            return list;
        }

        public GanttControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            CalcTaskCenterWidth();

            _InitContextMenu();

            _lblTooltip = new Label();
            _lblTooltip.BackColor = Color.LightYellow;
            _lblTooltip.BorderStyle = BorderStyle.FixedSingle;
            _lblTooltip.AutoSize = true;
            _lblTooltip.Padding = new Padding(5);
            _lblTooltip.Visible = false;
            this.Controls.Add(_lblTooltip);

            _hScrollbar = new HScrollBar();
            _hScrollbar.SmallChange = _scaleWidth;
            _hScrollbar.LargeChange = _scaleWidth * 2;
            _hScrollbar.Dock = DockStyle.Bottom;
            _hScrollbar.Visible = true;
            _hScrollbar.Scroll += new ScrollEventHandler(hScrollbar_Scroll);

            _vScrollbar = new VScrollBar();
            _vScrollbar.SmallChange = 1;
            _vScrollbar.LargeChange = 2;
            _vScrollbar.Dock = DockStyle.Right;
            _vScrollbar.Visible = true;
            _vScrollbar.Scroll += new ScrollEventHandler(vScrollbar_Scroll);

            _hScrollbar.Value = 0;
            _vScrollbar.Value = 0;

            this.Controls.Add(_hScrollbar);
            this.Controls.Add(_vScrollbar);

            this.TaskCenters = new TaskCenterCollection(this);
            this.SelectionTasks = new List<Task>();

            AdjustScrollbar();

            this.Renderer = new DefaultRenderer();

            this.GanntView = GanttView.HourView;
        }

        public TaskCenter AddTaskCenter(string id, string name)
        {
            var taskCenter = new TaskCenter(this, id, name);
            this.TaskCenters.Add(taskCenter);
            return taskCenter;
        }

        public bool TaskIsExists(Task item)
        {
            if (item == null) return false;
            foreach (var cl in this.TaskCenters)
            {
                if (cl.Any(p => p.Id == item.Id))
                {
                    return true;
                }
            }
            return false;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);

            this.AdjustScrollbar();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.CalcTaskCenterWidth();

            //填充背景色
            using (SolidBrush backBrush = new SolidBrush(_renderer.BackColor))
            {
                var rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
                e.Graphics.FillRectangle(backBrush, rect);
            }

            //填充Header背景色
            using (SolidBrush backBrush = new SolidBrush(_renderer.HeaderBackColor))
            {
                var rect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.HeaderHeight);
                e.Graphics.FillRectangle(backBrush, rect);
            }

            //填充Resource背景色
            using (SolidBrush backBrush = new SolidBrush(_renderer.ResourceBackColor))
            {
                var rect = new Rectangle(this.ClientRectangle.X, this.HeaderHeight, this.TaskCenterWidth, this.ClientRectangle.Height);
                e.Graphics.FillRectangle(backBrush, rect);
            }

            //画控件边框线
            using (Pen aPen = new Pen(_LineColor, 2))
            {
                e.Graphics.DrawRectangle(aPen, this.ClientRectangle);
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rectangle = new Rectangle(0, 0, this.Width - _vScrollbar.Width, this.Height - _hScrollbar.Height);

            //画资源框
            var resRect = rectangle;
            resRect.Width = this.TaskCenterWidth;
            this._renderer.DrawResourceLabels(e.Graphics, resRect, this.HeaderHeight, this.TaskCenterWidth);

            //处理刻度的头
            Rectangle scaleLabelRectangle = rectangle;
            scaleLabelRectangle.X += this.TaskCenterWidth;
            _DrawScaleHeaderLabels(e, scaleLabelRectangle);

            //处理刻度文字
            scaleLabelRectangle.Y += this._scaleHeaderHeight;
            _DrawScaleLabels(e, scaleLabelRectangle);


            //计算画图区
            Rectangle scalesRectangle = rectangle;
            scalesRectangle.X += this.TaskCenterWidth;
            scalesRectangle.Y += this.HeaderHeight;
            scalesRectangle.Width -= this.TaskCenterWidth;

            //画任务中心
            _DrawTaskCenters(e, scalesRectangle);

            //画当前的时间线
            if (this.ShowNowLine)
            {
                _DrawNowLine(e, scalesRectangle);
            }

            //画交期线
            if (this.ShowDeliveryTimeLine)
            {
                this._DrawDeliveryTimeLine(e, scalesRectangle);
            }

        }

        private void _DrawTaskCenters(PaintEventArgs e, Rectangle rect)
        {
            Rectangle rectangle = rect;
            rectangle.Height = this._taskCenterHeight;

            int i = 0;

            List<string> list = this.TaskCenters.Where(p => p.Visible).Select(p => p.TaskCenterGroup).Distinct().ToList();
            foreach (var taskCenter in this.TaskCenters)
            {
                taskCenter.ClientRectangle = new Rectangle(0, 0, 0, 0);
                if (taskCenter.Visible)
                {
                    rectangle.Y = rect.Y + (this._taskCenterHeight * i++) - _vScrollbar.Value * this._taskCenterHeight;

                    if ((rectangle.Y > rect.Bottom) || (rectangle.Y < 0) || rectangle.Y < rect.Top)
                        continue;

                    if (ShowTaskCenterGroupColor)
                    {
                        if (list.IndexOf(taskCenter.TaskCenterGroup) % 2 == 0)
                        {
                            _DrawTaskCenter(e, rectangle, taskCenter, true);
                        }
                        else
                        {
                            _DrawTaskCenter(e, rectangle, taskCenter, false);
                        }
                    }
                    else
                    {
                        _DrawTaskCenter(e, rectangle, taskCenter, false);
                    }

                }
            }
        }

        private void _DrawTaskCenter(PaintEventArgs e, Rectangle rect, TaskCenter taskCenter, bool newGroup)
        {
            var tempRect = rect;
            tempRect.X = rect.X - this.TaskCenterWidth;
            tempRect.Width = rect.Width + this.TaskCenterWidth;
            taskCenter.ClientRectangle = tempRect;

            //如果是选中的任务中心,要先画背景色,否则会覆盖竖线或任务
            if (this.SelectionTaskCenter != null && taskCenter.UniqueId == this.SelectionTaskCenter.UniqueId)
            {
                e.Graphics.FillRectangle(Brushes.WhiteSmoke, rect);
            }

            if (!newGroup && this.ShowTaskCenterGroupColor)
            {
                e.Graphics.FillRectangle(new SolidBrush(AbstractRenderer.InterpolateColors(Color.FromArgb(183, 208, 219), Color.White, 0.5f)), new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + 1));
            }

            for (int scale = 0; scale < this.TotalScale; scale++)
            {
                int x = rect.Left + (scale * ScaleWidth) - _hScrollbar.Value;

                using (Pen pen = new Pen(_renderer.ScaleSeperatorColor))
                {
                    e.Graphics.DrawLine(pen, x, rect.Top, x, rect.Bottom);

                    if (scale == this._totalScale - 1)
                    {
                        x = rect.Left + (_totalScale * ScaleWidth) - _hScrollbar.Value;
                        e.Graphics.DrawLine(pen, x, rect.Top, x, rect.Bottom);
                    }
                }

                if (x > rect.Right)
                    break;
            }

            _DrawTasks(e, rect, taskCenter);

            var taskCenterRect = rect;
            taskCenterRect.X = 0;
            taskCenterRect.Width += this.TaskCenterWidth;

            if (this.SelectionTaskCenter != null && taskCenter.UniqueId == this.SelectionTaskCenter.UniqueId)
            {
                _renderer.DrawSelectionTaskCenterHeader(e.Graphics, taskCenterRect, this.TaskCenterWidth, taskCenter.Name);
            }
            else
            {
                _renderer.DrawTaskCenterHeader(e.Graphics, taskCenterRect, this.TaskCenterWidth, taskCenter.Name, this.ShowHorizontalLine, newGroup);
            }
        }

        private void _DrawTasks(PaintEventArgs e, Rectangle rect, TaskCenter taskCenter)
        {
            DateTime timeStart = this.StartTime;
            if (taskCenter == null) return;
            var selectedList = new List<Rectangle>();

            for (int i = 0; i < taskCenter.Count(); i++)
            {
                var task = taskCenter[i];
                var taskRect = _GetTaskRangeRectangle(task, rect.Top);
                if (taskRect.Width > 0)
                {
                    var isSelected = SelectionTasks.Any(p => p.Id == task.Id);
                    if (isSelected)
                        selectedList.Add(taskRect);
                    _renderer.DrawTask(e.Graphics, taskRect, task, isSelected, this.ShowPercent);

                }
                task.ClientRectangle = taskRect;
            }

            //Draw Tracker
            foreach (var selectedTaskRect in selectedList)
            {
                _renderer.DrawTracker(e.Graphics, selectedTaskRect);
            }
        }

        private Rectangle _GetTaskRangeRectangle(Task task, int taskTop)
        {
            int startX;
            int taskWidth;

            if (this.GanntView == GanttView.HourView)
            {
                startX = (int)((task.StartTime - this.StartTime).TotalMinutes * this.ScaleWidth / 60.0);

                taskWidth = (int)(task.WorkTimeSpan.TotalMinutes * (float)this.ScaleWidth / 60.0);
            }
            else
            {
                startX = (int)((task.StartTime - this.StartTime).TotalMinutes * this.ScaleWidth / 60.0 / 24);

                taskWidth = (int)(task.WorkTimeSpan.TotalMinutes * (float)this.ScaleWidth / 60.0 / 24);
            }

            var rect = new Rectangle();
            rect.X = startX - _hScrollbar.Value + this.TaskCenterWidth;
            rect.Y = taskTop + this._taskVerticalInterval;
            rect.Width = taskWidth;
            rect.Height = this._taskCenterHeight - _taskVerticalInterval * 2;

            return rect;
        }

        private void _DrawNowLine(PaintEventArgs e, Rectangle rect)
        {
            Rectangle rectangle = rect;

            int nowX = 0;

            if (this.GanntView == GanttView.HourView)
            {
                nowX = (int)((DateTime.Now - this.StartTime).TotalMinutes * this.ScaleWidth / 60.0) + this.TaskCenterWidth - this._hScrollbar.Value;
            }
            else
            {
                nowX = (int)((DateTime.Now - this.StartTime).TotalMinutes * this.ScaleWidth / (24 * 60.0)) + this.TaskCenterWidth - this._hScrollbar.Value;
            }
            if (nowX <= rectangle.Width && nowX > this.TaskCenterWidth)
            {
                _renderer.DrawNowLine(e.Graphics, rectangle, nowX);
            }
        }

        private void _DrawDeliveryTimeLine(PaintEventArgs e, Rectangle rect)
        {
            if (this.SelectionTasks == null || this.SelectionTasks.Count > 1) return;

            var tasks = this.SelectionTasks.Where(p => p.DeliveryTime.HasValue);
            if (tasks == null || tasks.Count() <= 0) return;

            DateTime deliveryTime = tasks.Min(p => p.DeliveryTime.Value);

            Rectangle rectangle = rect;

            int deliveryX = 0;

            if (this.GanntView == GanttView.HourView)
            {
                deliveryX = (int)((deliveryTime - this.StartTime).TotalMinutes * this.ScaleWidth / 60.0) + this.TaskCenterWidth - this._hScrollbar.Value;
            }
            else
            {
                deliveryX = (int)(((deliveryTime - this.StartTime).TotalMinutes) * this.ScaleWidth / (24 * 60.0)) + this.TaskCenterWidth - this._hScrollbar.Value;
            }
            if (deliveryX <= rectangle.Width && deliveryX > this.TaskCenterWidth)
            {
                _renderer.DrawDeliveryTimeLine(e.Graphics, rectangle, deliveryX);
            }
        }

        private void _DrawScaleLabels(PaintEventArgs e, Rectangle rect)
        {
            e.Graphics.SetClip(rect);
            Rectangle scaleRectangle = rect;

            for (int scale = 0; scale <= _totalScale; scale++)
            {
                scaleRectangle = rect;
                scaleRectangle.X = rect.X + (scale * _scaleWidth) - _hScrollbar.Value;
                scaleRectangle.Height = this.HeaderHeight;
                _renderer.DrawScaleLabel(e.Graphics, scaleRectangle, this.StartTime, scale, scale < _totalScale, this.GanntView, _scaleWidth);
            }

            e.Graphics.ResetClip();
        }

        private void _DrawScaleHeaderLabels(PaintEventArgs e, Rectangle rect)
        {
            Rectangle scaleHeaderRectangle = new Rectangle(rect.Left, rect.Top, rect.Width, this._scaleHeaderHeight);
            _renderer.DrawScaleHeader(e.Graphics, scaleHeaderRectangle);

            e.Graphics.SetClip(rect);
            scaleHeaderRectangle = rect;
            scaleHeaderRectangle.Height = this._scaleHeaderHeight;
            scaleHeaderRectangle.Width = 0;

            for (int scale = 0; scale < _totalScale; scale++)
            {
                scaleHeaderRectangle.X = rect.X + (scale * _scaleWidth) - _hScrollbar.Value;
                _renderer.DrawScaleHeaderLabel(e.Graphics, scaleHeaderRectangle, this.StartTime, scale, this.GanntView);
                scaleHeaderRectangle.Width = 0;
            }
            e.Graphics.ResetClip();
        }

        public void GetTaskAndTaskCenterAt(int x, int y, out Task task, out TaskCenter taskCenter)
        {
            task = null;
            taskCenter = null;

            if (y < this.HeaderHeight)
            {
                task = null;
                taskCenter = null;
            }

            foreach (var tc in this.TaskCenters)
            {
                if (tc.ClientRectangle.Contains(x, y))
                    taskCenter = tc;

                var obj = tc.FirstOrDefault(p => p.ClientRectangle.Contains(x, y));
                if (obj != null)
                    task = obj;
            }
        }

        public Task GetTaskAt(int x, int y)
        {
            if (y < this.HeaderHeight)
            {
                return null;
            }

            foreach (var tc in this.TaskCenters)
            {
                var obj = tc.FirstOrDefault(p => p.ClientRectangle.Contains(x, y));
                if (obj != null)
                    return obj;
            }
            return null;
        }

        internal DateTime GetTimeAt(int x, int y)
        {
            double scale = (x - this.TaskCenterWidth + _hScrollbar.Value) * 1.0 / ScaleWidth;

            DateTime date = StartTime;

            if ((scale > 0) && (scale < TotalScale))
            {
                if (this.GanntView == GanttView.HourView)
                {
                    date = date.AddMinutes((int)(scale * 60));
                }
                else
                {
                    date = date.AddMinutes((int)(scale * 60 * 24));
                }
            }
            return date;
        }

        public TaskCenter GetTaskCenterAt(int x, int y)
        {
            if (y < this.HeaderHeight)
            {
                return null;
            }

            foreach (var tc in this.TaskCenters)
            {
                if (tc.ClientRectangle.Contains(x, y))
                    return tc;
            }
            return null;
        }

        #region Mouse

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int i = e.Delta > 0 ? -1 : 1;

            if (this._vScrollbar.Value + i <= this._vScrollbar.Maximum && this._vScrollbar.Value + i >= this._vScrollbar.Minimum)
            {
                this._vScrollbar.Value += i;
                Invalidate();
            }

            base.OnMouseWheel(e);
        }

        private bool _isMove = false;
        private bool _needFireSelectionChanged = false;
        private int _deltaX = 0;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                this.Focus();

                Task task = null;
                TaskCenter taskCenter = null;

                this.GetTaskAndTaskCenterAt(e.X, e.Y, out task, out taskCenter);

                //选中同一个任务不触发事件
                if (task != null && this.SelectionTasks != null && this.SelectionTasks.Any(p => p.Id == task.Id))
                {
                    this._needFireSelectionChanged = false;
                }
                else
                {
                    this._needFireSelectionChanged = true;
                }

                if ((Control.ModifierKeys & Keys.Control) == 0)
                    this.SelectionTasks.Clear();

                if (task != null)
                    this.SelectionTasks.Add(task);

                this.SelectionTaskCenter = taskCenter;

                if (taskCenter != null)
                    _oldTaskCenter = this.TaskCenters.FirstOrDefault(p => p.UniqueId == taskCenter.UniqueId);
                else
                    _oldTaskCenter = null;

                if (task != null)
                    _movingTask = new Task(task.Id, task.Name, task.StartTime, task.WorkTimeSpan) { Qty = task.Qty };
                else
                    _movingTask = null;

                this.Invalidate();

                this.Capture = true;

                _deltaX = 0;
                if (task != null)
                {
                    _deltaX = e.X - task.ClientRectangle.Left;
                }
            }
        }

        private Task _movingTask = null;
        private TaskCenter _oldTaskCenter = null;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                var tasks = this.SelectionTasks;
                if (tasks == null || tasks.Count != 1) return;

                var task = tasks[0];

                if (task.StartTime < DateTime.Now || task.IsCustomerLock) return;

                _isMove = true;
                this.ShowTooltipCore(null, new Point());
                // Get time at mouse position
                TaskCenter newTaskCenter = this.GetTaskCenterAt(e.X - this._deltaX, e.Y);
                DateTime m_Date = this.GetTimeAt(e.X - this._deltaX, e.Y);

                if (m_Date < DateTime.Now)
                    m_Date = DateTime.Now.AddMinutes(1);

                if (!this.IsReadOnly && newTaskCenter != null)
                {
                    task.StartTime = m_Date;
                    if (newTaskCenter.UniqueId != task.TaskCenter.UniqueId)
                    {
                        task.TaskCenter.AutoAdjustTask = false;
                        newTaskCenter.AutoAdjustTask = false;
                        try
                        {
                            task.TaskCenter.RemoveTask(task.Id);
                            newTaskCenter.AddTask(task);
                        }
                        finally
                        {
                            task.TaskCenter.AutoAdjustTask = true;
                            newTaskCenter.AutoAdjustTask = true;
                        }
                    }
                    this.SelectionTaskCenter = newTaskCenter;
                }
                this.Refresh();
            }
            else if (e.Button == MouseButtons.None)
            {
                var task = this.GetTaskAt(e.X, e.Y);
                if (this.ShowTooltip && task != oldTooltipTask)
                {
                    this.ShowTooltipCore(task, new Point(e.X, e.Y));
                    oldTooltipTask = task;
                }
            }
        }

        private Task oldTooltipTask = null;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                if (this._needFireSelectionChanged)
                    this.OnSelectionChanged();

                if (_isMove)
                {
                    var task = this.SelectionTasks[0];
                    //TODO:判定是否是移动到不可移动的任务上


                    var args = new TaskMovingEventArgs(task, _oldTaskCenter);
                    this.OnTaskMoving(args);
                    if (args.Cancel)
                    {
                        TaskCenter newTaskCenter = this.GetTaskCenterAt(e.X, e.Y);

                        task.StartTime = _movingTask.StartTime;
                        newTaskCenter.RemoveTask(task.Id);
                        _oldTaskCenter.AddTask(task);

                        newTaskCenter.AdjustTasks();
                        _oldTaskCenter.AdjustTasks();

                        _isMove = false;
                        _movingTask = null;
                    }
                    else
                    {
                        var taskCenter = this.SelectionTaskCenter;

                        if (taskCenter != null)
                            taskCenter.AdjustTasks();

                        _isMove = false;

                        if (SelectionTasks != null && SelectionTasks.Count == 1)
                        {
                            var arg = new TaskMoveEventArgs(task, _oldTaskCenter);
                            this.OnTaskMove(arg);
                        }
                    }
                }
                this.Refresh();
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.OnContextMenu(e);
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (e.Button == MouseButtons.Left)
            {
                Task task = null;
                TaskCenter taskCenter = null;

                this.GetTaskAndTaskCenterAt(e.X, e.Y, out task, out taskCenter);

                if (task != null)
                {
                    var args = new TaskDoubleClickEventArgs(task);
                    this.OnTaskDoubleClick(args);
                }
                else if (taskCenter != null)
                {
                    var args = new TaskCenterDoubleClickEventArgs(taskCenter);
                    this.OnTaskCenterDoubleClick(args);
                }
            }
        }

        #endregion

        #region Events

        private static readonly object TaskMovingEvent = new object();
        private static readonly object TaskMoveEvent = new object();
        private static readonly object SelectionChangedEvent = new object();
        private static readonly object TaskDoubleClickEvent = new object();
        private static readonly object TaskCenterDoubleClickEvent = new object();
        private static readonly object TaskIsLockChangingEvent = new object();
        private static readonly object CustomTaskTooltipEvent = new object();
        private static readonly object BeforeContextMenuShowEvent = new object();

        /// <summary>
        /// 任务锁定状态改变事件
        /// </summary>
        public event EventHandler<TaskIsLockChangingEventArgs> TaskIsLockChanging
        {
            add { this.Events.AddHandler(TaskIsLockChangingEvent, value); }
            remove { this.Events.RemoveHandler(TaskIsLockChangingEvent, value); }
        }

        internal void OnTaskIsLockChanging(TaskIsLockChangingEventArgs args)
        {
            var handler = this.Events[TaskIsLockChangingEvent] as EventHandler<TaskIsLockChangingEventArgs>;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// 任务双击
        /// </summary>
        public event EventHandler<TaskDoubleClickEventArgs> TaskDoubleClick
        {
            add { this.Events.AddHandler(TaskDoubleClickEvent, value); }
            remove { this.Events.RemoveHandler(TaskDoubleClickEvent, value); }
        }

        private void OnTaskDoubleClick(TaskDoubleClickEventArgs args)
        {
            var handler = this.Events[TaskDoubleClickEvent] as EventHandler<TaskDoubleClickEventArgs>;
            if (handler != null)
                handler(this, args);
        }
        /// <summary>
        /// 机台双击
        /// </summary>
        public event EventHandler<TaskCenterDoubleClickEventArgs> TaskCenterDoubleClick
        {
            add { this.Events.AddHandler(TaskCenterDoubleClickEvent, value); }
            remove { this.Events.RemoveHandler(TaskCenterDoubleClickEvent, value); }
        }

        private void OnTaskCenterDoubleClick(TaskCenterDoubleClickEventArgs args)
        {
            var handler = this.Events[TaskCenterDoubleClickEvent] as EventHandler<TaskCenterDoubleClickEventArgs>;
            if (handler != null)
                handler(this, args);
        }
        /// <summary>
        /// 选择改变
        /// </summary>
        public event EventHandler SelectionChanged
        {
            add { this.Events.AddHandler(SelectionChangedEvent, value); }
            remove { this.Events.RemoveHandler(SelectionChangedEvent, value); }
        }

        private void OnSelectionChanged()
        {
            var handler = this.Events[SelectionChangedEvent] as EventHandler;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        /// <summary>
        /// 任务移动前
        /// </summary>
        public event EventHandler<TaskMovingEventArgs> TaskMoving
        {
            add { this.Events.AddHandler(TaskMovingEvent, value); }
            remove { this.Events.RemoveHandler(TaskMovingEvent, value); }
        }

        private void OnTaskMoving(TaskMovingEventArgs args)
        {
            var handler = this.Events[TaskMovingEvent] as EventHandler<TaskMovingEventArgs>;
            if (handler != null)
            {
                handler(this, args);
            }
        }
        /// <summary>
        /// 任务移动
        /// </summary>
        public event EventHandler<TaskMoveEventArgs> TaskMove
        {
            add { this.Events.AddHandler(TaskMoveEvent, value); }
            remove { this.Events.RemoveHandler(TaskMoveEvent, value); }
        }

        private void OnTaskMove(TaskMoveEventArgs args)
        {
            var handler = this.Events[TaskMoveEvent] as EventHandler<TaskMoveEventArgs>;
            if (handler != null)
                handler(this, args);
        }
        /// <summary>
        /// 自定义提示事件
        /// </summary>
        public event EventHandler<CustomTaskTooltipEventArgs> CustomTaskTooltip
        {
            add { this.Events.AddHandler(CustomTaskTooltipEvent, value); }
            remove { this.Events.RemoveHandler(CustomTaskTooltipEvent, value); }
        }
        /// <summary>
        /// 快捷菜单弹出前事件
        /// </summary>
        public event EventHandler BeforeContextMenuShow
        {
            add { this.Events.AddHandler(BeforeContextMenuShowEvent, value); }
            remove { this.Events.RemoveHandler(BeforeContextMenuShowEvent, value); }
        }

        private void OnBeforeContextMenuShow()
        {
            var handler = this.Events[BeforeContextMenuShowEvent] as EventHandler;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion

        #region ContextMenu
        /// <summary>
        /// 覆盖原生的ContextMenuStrip
        /// </summary>
        public new ContextMenuStrip ContextMenuStrip { get; set; }

        private void _InitContextMenu()
        {
            _ContextMenu = new System.Windows.Forms.ContextMenuStrip();
        }

        /// <summary>
        ///  Right-click handler
        /// </summary>
        /// <param name="e"></param>
        internal void OnContextMenu(MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);

            OnBeforeContextMenuShow();

            _MarginContextMenu();

            if (_ContextMenu.Items.Count <= 0) return;

            _ContextMenu.Show(this, point);
            _ContextMenu.Closed += new ToolStripDropDownClosedEventHandler(m_ContextMenu_Closed);

        }

        void m_ContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            for (int i = this._ContextMenu.Items.Count - 1; i >= 0; i--)
            {
                if (this._ContextMenu.Items[i].Tag != null && this._ContextMenu.Items[i].Tag.ToString() == "AutoCreate")
                {
                    this._ContextMenu.Items.RemoveAt(i);
                }
            }
        }

        private void _MarginContextMenu()
        {
            if (this.ContextMenuStrip != null)
            {
                var list = new List<ToolStripItem>();
                foreach (ToolStripItem item in this.ContextMenuStrip.Items)
                {
                    if (!item.Enabled) continue;
                    list.Add(item);
                }

                if (list.Count > 0)
                {
                    foreach (ToolStripItem item in list)
                    {
                        if (!item.Enabled) continue;

                        if (item is ToolStripSeparator)
                        {
                            var strip = new ToolStripSeparator();
                            strip.Tag = "AutoCreate";
                            this._ContextMenu.Items.Add(strip);
                        }
                        else if (item is ToolStripMenuItem)
                        {
                            var strip = new ToolStripMenuItem(item.Text);
                            strip.Tag = "AutoCreate";
                            strip.Click += (sender, args) => { item.PerformClick(); };
                            this._ContextMenu.Items.Add(strip);
                        }
                    }
                }
            }
        }

        #endregion


        #region IEnumerable<TaskCenter> 成员

        public IEnumerator<TaskCenter> GetEnumerator()
        {
            return this.TaskCenters.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }

}
