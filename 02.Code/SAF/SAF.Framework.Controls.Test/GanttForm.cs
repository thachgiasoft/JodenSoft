using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Framework.Controls.GanttChart;

namespace SAF.Framework.Controls.Test
{
    public partial class GanttForm : Form
    {
        public GanttForm()
        {
            InitializeComponent();    
            InitControl();
        }

        private void InitControl()
        {
            this.ganttControl1.ShowTooltip = true;
            this.ganttControl1.StartTime = DateTime.Now.AddHours(-3);
            this.ganttControl1.TotalScale = 24 * 4;
            Random ran = new Random();
            for (int i = 0; i < 10; i++)
            {
                var taskCenter = this.ganttControl1.AddTaskCenter(i.ToString(), "测试机台" + i);

                for (int j = 0; j < 10; j++)
                {
                    var hour = ran.Next(1, 10);
                    var task = new Task((i * 100 + j).ToString(), "测试任务" + (i * 100 + j).ToString(), DateTime.Now.AddHours(-1), new TimeSpan(hour, 0, 0));
                    if (i == 0)
                    {
                        task.IsCustomerLock = true;
                    }
                    taskCenter.AddTask(task);
                }

            }
        }

    }
}
