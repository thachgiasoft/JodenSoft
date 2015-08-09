using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SAF.Framework.Controls.GanttChart
{
    /// <summary>
    /// 任务中心集合
    /// </summary>
    [Serializable]
    public class TaskCenterCollection : ICollection<TaskCenter>
    {
        private GanttControl _ganntControl = null;
        private List<TaskCenter> _innerList = new List<TaskCenter>();

        public TaskCenterCollection(GanttControl ganntControl)
        {
            if (ganntControl == null)
                throw new ArgumentNullException("ganntControl");
            this._ganntControl = ganntControl;
        }

        public void Add(TaskCenter item)
        {
            if (item == null)
                throw new ArgumentNullException("TaskCenterCollection类的Add方法参数item不能为空.");

            //if (_innerList.Any(p => p.Id == item.Id))
            //    throw new Exception(string.Format("ID为'{0}'的任务中心已经存在,不能重复添加.", item.Id));

            if (string.IsNullOrWhiteSpace(item.Name))
                throw new Exception("TaskCenter的Name不能为空.");

            item.OwnerGannt = _ganntControl;
            item.AdjustTasks();
            _innerList.Add(item);
            this._ganntControl.Refresh();
        }

        public void Clear()
        {
            this._innerList.Clear();
            this._ganntControl.Refresh();
        }

        public bool Contains(TaskCenter item)
        {
            if (item == null) return false;

            return this._innerList.Any(p => p.Name.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void CopyTo(TaskCenter[] array, int arrayIndex)
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

        public bool Remove(TaskCenter item)
        {
            if (item == null) return false;
            var count = this.RemoveAll(p => p.Name.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase));
            this._ganntControl.Refresh();
            return count > 0;
        }

        public bool Remove(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            var count = this.RemoveAll(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            this._ganntControl.Refresh();
            return count > 0;
        }

        public void RemoveAt(int index)
        {
            this._innerList.RemoveAt(index);
            this._ganntControl.CalcTaskCenterWidth();
            this._ganntControl.Refresh();
        }

        public int RemoveAll(Predicate<TaskCenter> match)
        {
            var obj = this._innerList.RemoveAll(match);
            this._ganntControl.Refresh();
            return obj;
        }

        public void ForEach(Action<TaskCenter> action)
        {
            this._innerList.ForEach(action);
        }

        public IEnumerator<TaskCenter> GetEnumerator()
        {
            return this._innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._innerList.GetEnumerator();
        }

        public TaskCenter this[int index]
        {
            get
            {
                return this._innerList[index];
            }
        }
    }
}
