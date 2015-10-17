using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.ScheduledTasks
{
    public interface ITask
    {
        void Work();
        void WorkCompleted();
    }
}
