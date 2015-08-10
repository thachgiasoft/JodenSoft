using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SAF.Framework.Controls.GanttChart
{
    /// <summary>
    /// 任务集合
    /// </summary>
    [Serializable]
    public class TaskCollection : ICollection<Task>
    {
        private TaskCenter _taskCenter = null;

        private List<Task> _innerList = new List<Task>();

        public TaskCollection(TaskCenter taskCenter)
        {
            this._taskCenter = taskCenter;
        }

        public void Add(Task item)
        {
            if (item == null)
            {
                MessageBox.Show("TaskCollection类的Add方法参数item不能为空.", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this._taskCenter.OwnerGannt.TaskIsExists(item))
            {
                MessageBox.Show(string.Format("名称为'{0}.{1}'的任务已经存在,不能重复添加.", item.Id, item.Name), "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            item.TaskCenter = this._taskCenter;

            _innerList.Add(item);

            this._taskCenter.AdjustTasks();
        }

        public void Sort()
        {
            this._innerList = this._innerList.OrderBy(p => p.StartTime).ToList();
        }

        public void Insert(int index, Task item)
        {
            this._innerList.Insert(index, item);
            this._taskCenter.AdjustTasks();
        }

        public void Clear()
        {
            this._innerList.Clear();
        }

        public bool Contains(Task item)
        {
            if (item == null) return false;

            return this.Contains(item.Id);
        }

        public bool Contains(string id)
        {
            return this._innerList.Any(p => p.Id == id);
        }

        public void CopyTo(Task[] array, int arrayIndex)
        {
            this._innerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this._innerList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Task item)
        {
            if (item == null) return false;
            return this.Remove(item.Id);
        }

        public bool Remove(string id)
        {
            var count = this.RemoveAll(p => p.Id == id);
            return count > 0;
        }

        public void RemoveAt(int index)
        {
            this._innerList.RemoveAt(index);
        }

        public int RemoveAll(Predicate<Task> match)
        {
            return this._innerList.RemoveAll(match);
        }

        public void ForEach(Action<Task> action)
        {
            this._innerList.ForEach(action);
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return this._innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._innerList.GetEnumerator();
        }

        public Task this[int index]
        {
            get
            {
                return this._innerList[index];
            }
        }
    }
}
