using System;
using System.Collections.Generic;
using System.Text;
using SAF.ScheduledTasks;
using System.Windows.Forms;

namespace SAF.TestJob
{
    public class JobTest : ITask
    {
        public void Work()
        {
           // MessageBox.Show("JobTest Start");
        }

        public void WorkCompleted()
        {
           // MessageBox.Show("JobTest WorkCompleted");
        }
    }
}
