using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SAF.ScheduledTasks
{
    public class TaskSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public TaskCollection Tasks
        {
            get
            {
                return (TaskCollection)base[""];
            }
        }
    }
}
