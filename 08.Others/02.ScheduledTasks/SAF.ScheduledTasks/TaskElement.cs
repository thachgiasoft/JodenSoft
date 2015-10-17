using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace SAF.ScheduledTasks
{
    public class TaskElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("type",IsRequired=true)]
        public string Type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("interval", IsRequired = false, DefaultValue=60000)]
        public int Interval
        {
            get { return (int)base["interval"]; }
            set { base["interval"] = value; }
        }
    }
}
