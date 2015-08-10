using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls.GanttChart
{
    /// <summary>
    /// 任务移动前事件参数
    /// </summary>
    public class TaskMovingEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public bool Cancel { get; set; }

        public bool IsTaskCenterChanged { get; private set; }
        public TaskCenter OriginalTaskCenter { get; private set; }

        public TaskMovingEventArgs(Task task, TaskCenter originalTaskCenter)
        {
            this.Task = task;
            Cancel = false;
            this.OriginalTaskCenter = originalTaskCenter;
            IsTaskCenterChanged = (task.TaskCenter.UniqueId == originalTaskCenter.UniqueId);
        }
    }
    /// <summary>
    /// 任务移动事件参数
    /// </summary>
    public class TaskMoveEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public bool IsTaskCenterChanged { get; private set; }
        public TaskCenter OriginalTaskCenter { get; private set; }
        public TaskMoveEventArgs(Task task, TaskCenter originalTaskCenter)
        {
            this.Task = task;
            this.OriginalTaskCenter = originalTaskCenter;
            IsTaskCenterChanged = (task.TaskCenter.UniqueId == originalTaskCenter.UniqueId);
        }
    }
    /// <summary>
    /// 任务双击事件参数
    /// </summary>
    public class TaskDoubleClickEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public TaskDoubleClickEventArgs(Task task)
        {
            this.Task = task;
        }
    }
    /// <summary>
    /// 任务中心双击事件参数
    /// </summary>
    public class TaskCenterDoubleClickEventArgs : EventArgs
    {
        public TaskCenter TaskCenter { get; private set; }
        public TaskCenterDoubleClickEventArgs(TaskCenter taskCenter)
        {
            this.TaskCenter = taskCenter;
        }
    }
    /// <summary>
    /// 任务锁定状态改变前事件参数
    /// </summary>
    public class TaskIsLockChangingEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public bool IsLock { get; private set; }
        public bool Cancel { get; set; }

        public TaskIsLockChangingEventArgs(Task task, bool isLock)
        {
            this.Task = task;
            this.IsLock = IsLock;
            this.Cancel = false;
        }
    }
    /// <summary>
    /// 自定义提示事件参数
    /// </summary>
    public class CustomTaskTooltipEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public string Tooltip { get; set; }
        public CustomTaskTooltipEventArgs(Task task)
        {
            this.Task = task;
            this.Tooltip = string.Empty;
        }
    }
}
