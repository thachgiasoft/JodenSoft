using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace SAF.Framework.Controls.GanttChart
{
    /// <summary>
    /// 任务中心
    /// </summary>
    [Serializable]
    public class TaskCenter : IEnumerable<Task>
    {
        /// <summary>
        /// 唯一值
        /// </summary>
        public Guid UniqueId { get; private set; }

        public string Id { get; private set; }

        public string Name { get; set; }

        public string TaskCenterGroup { get; set; }

        public GanttControl OwnerGannt { get; internal set; }

        public bool Visible { get; set; }

        internal bool AutoAdjustTask { get; set; }

        private TaskCollection Tasks { get; set; }

        public Task this[int index]
        {
            get { return this.Tasks[index]; }
        }

        public void AddTask(Task task)
        {
            this.Tasks.Add(task);
        }

        public void RemoveTask(string taskId)
        {
            this.Tasks.Remove(taskId);
        }

        public object CustomData { get; set; }

        internal Rectangle ClientRectangle { get; set; }

        internal TaskCenter(GanttControl ganntControl, string id, string name)
        {
            if (ganntControl == null)
                throw new ArgumentNullException("TaskCenter构造函数中参数 ganntControl 不能为空.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("TaskCenter构造函数中参数 name 不能为空.");
            this.OwnerGannt = ganntControl;
            this.Id = id;
            this.Name = name;
            this.Tasks = new TaskCollection(this);
            this.Visible = true;

            this.UniqueId = Guid.NewGuid();

            this.TaskCenterGroup = string.Empty;
            this.Visible = true;

            this.AutoAdjustTask = true;
        }

        public void AdjustTasks()
        {
            if (!AutoAdjustTask) return;

            Tasks.Sort();
            _MoveTask();
        }

        private void _MoveTask()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task preTask = i == 0 ? null : Tasks[i - 1];
                Task task = Tasks[i];
                if (preTask != null && task.StartTime < preTask.EndTime)
                {
                    task.StartTime = preTask.EndTime;
                }
            }
        }

        #region IEnumerable<Task> 成员

        public IEnumerator<Task> GetEnumerator()
        {
            return this.Tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

    }
}
