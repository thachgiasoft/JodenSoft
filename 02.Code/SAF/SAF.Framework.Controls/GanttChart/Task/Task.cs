using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.ComponentModel;

namespace SAF.Framework.Controls.GanttChart
{
    /// <summary>
    /// 任务
    /// </summary>
    [Serializable]
    public sealed class Task
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 工作时长
        /// </summary>
        public TimeSpan WorkTimeSpan { get; set; }

        /// <summary>
        /// 任务数量
        /// </summary>
        public decimal Qty { get; set; }
        /// <summary>
        /// 任务交期
        /// </summary>
        public DateTime? DeliveryTime { get; set; }

        public DateTime EndTime
        {
            get
            {
                return this.StartTime.Add(this.WorkTimeSpan);
            }
        }

        /// <summary>
        /// 完成百分比,小数表示
        /// </summary>
        public double Percent { get; set; }

        public string ToolTip { get; set; }

        /// <summary>
        /// 用户锁定
        /// </summary>
        public bool IsCustomerLock { get; set; }

        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public Color BorderColor { get; set; }

        /// <summary>
        /// 所属机台
        /// </summary>
        public TaskCenter TaskCenter { get; set; }

        internal Rectangle ClientRectangle { get; set; }

        public bool IsDirty { get; internal set; }

        public void SetDirty()
        {
            this.IsDirty = true;
        }

        public void SetUnDirty()
        {
            this.IsDirty = false;
        }

        public Task(string id, string name, DateTime startTime, TimeSpan workTimeSpan)
        {
            BackColor = Color.White;
            ForeColor = Color.Black;
            BorderColor = Color.Black;

            this.Id = id;
            this.Name = name;
            this.StartTime = startTime;
            this.WorkTimeSpan = workTimeSpan;
        }
    }

}
