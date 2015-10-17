using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SAF.ScheduledTasks;
using System.Configuration;

namespace SAF.TaskCenter
{
    public partial class Shell : Form
    {
        private TaskSection sec;
        private DataTable table = new DataTable();

        public Shell()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Resize += Shell_Resize;

            notifyIcon.Text = "任务调度中心";
            notifyIcon.Visible = true;

            InintTaskView();
        }

        void Shell_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void InintTaskView()
        {
            table.Columns.Add("任务名称", typeof(string));
            table.Columns.Add("任务间隔(秒)", typeof(decimal));
            table.Columns.Add("任务状态", typeof(string));

            sec = (TaskSection)ConfigurationManager.GetSection("tasksConfiguration");
            foreach (TaskElement task in sec.Tasks)
            {
                table.Rows.Add(task.Name, task.Interval, "未启动");
            }

            this.dgvTaskView.DataSource = table.DefaultView;
            this.dgvTaskView.AutoResizeColumns();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.btnStart.Text == "启动")
            {
                if (MessageBox.Show("确定要启动任务吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TaskController controller = new TaskController();
                    foreach (TaskElement task in sec.Tasks)
                    {
                        TaskMonitor monitor = new TaskMonitor(task);
                        controller.Start(monitor);
                    }

                    this.btnStart.Image = TaskCenter.Properties.Resources.ServiceStop;
                    this.btnStart.Text = "停止";

                    foreach (DataRow item in table.Rows)
                    {
                        item["任务状态"] = "正在执行...";
                    }
                    this.dgvTaskView.AutoResizeColumns();
                }
            }
            else
            {
                if (MessageBox.Show("确定要停止任务吗?(注:停止任务会关闭程序.)", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出任务调度中心吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                Environment.Exit(0);
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

            this.Show();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            var About = new AboutBox();
            About.ShowDialog(this);
        }

    }
}
