using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.ComponentModel;

namespace SAF.ScheduledTasks
{
    public class TaskMonitor
    {
        private TaskElement _task;
        private Timer _tmr = new Timer();
        private ITask _Tasker;

        public TaskMonitor(TaskElement task)
        {
            this._task = task;
            var type = Type.GetType(_task.Type);
            if (type == null)
            {
                throw new Exception("任务为空。");
            }
            _Tasker = (ITask)Activator.CreateInstance(type);
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _Tasker.WorkCompleted();
            _tmr.Start();
        }

        public string Name { get { return _task.Name; } }

        public void Start()
        {
            _tmr.Stop();
            _tmr.Interval = _task.Interval * 1000;
            _tmr.Elapsed += new ElapsedEventHandler(tmr_Elapsed);
            _tmr.Start();
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _tmr.Stop();
            _Tasker.Work();
        }

        void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            BackgroundWorker _worker = new BackgroundWorker();
         
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
            _worker.RunWorkerAsync();
        }

    }
}
