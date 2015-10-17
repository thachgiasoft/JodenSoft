using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.ScheduledTasks
{
    public class TaskController
    {
        private Dictionary<string, TaskMonitor> _taskDic = new Dictionary<string, TaskMonitor>();

        public void Start(TaskMonitor monitor)
        {
            this._taskDic.Add(monitor.Name, monitor);
            monitor.Start();            
        }
    }
}
