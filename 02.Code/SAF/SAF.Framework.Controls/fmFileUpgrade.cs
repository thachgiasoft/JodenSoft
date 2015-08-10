using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using SAF.EntityFramework;
using SAF.Foundation;
using System.Diagnostics;     
using DevExpress.XtraEditors;   
using SAF.Foundation.ServiceModel;

namespace SAF.Framework.Controls
{
    public partial class fmFileUpgrade : XtraForm
    {
        private IList<string> files = new List<string>();

        private BackgroundWorker worker = new BackgroundWorker();

        private fmFileUpgrade()
        {
            InitializeComponent();

            this.Shown += FileUpdaterControl_Shown;
            this.StartPosition = FormStartPosition.CenterParent;

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        public static void ShowForm()
        {
            var frm = new fmFileUpgrade();
            frm.Owner = ApplicationService.Current.MainForm;
            frm.ShowDialog();
        }

        void FileUpdaterControl_Shown(object sender, EventArgs e)
        {
            this.files = FileUpgradeHelper.GetNeedUpgradeFiles();

            if (files.Count <= 0)
            {
                this.lblMessage.Text = "系统是最新版本,无需升级.";
                this.progress.Visible = false;
                this.btnUpgrade.Visible = false;
                this.btnUpgrade.Enabled = false;
            }
            else
            {
                this.lblMessage.Text = "系统共有 {0} 个文件需要更新.".FormatWith(files.Count);
                this.progress.Visible = false;
                this.btnUpgrade.Visible = true;
                this.btnUpgrade.Enabled = true;
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblMessage.Text = "系统已升级至最新版.";
            this.progress.Visible = false;
            this.btnUpgrade.Visible = false;
            this.btnUpgrade.Enabled = false;

            MessageService.ShowMessage("系统已升级至最新版,点击确定重启程序.");
            ApplicationService.Current.RestartApplication();
        }


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileUpgradeHelper.UpgradeFiles(this.files, ShowMessage);
        }

        private void ShowMessage(string message)
        {
            if (this.lblMessage.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowMessage), message);
            }
            else
            {
                this.lblMessage.Text = message;
            }
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {
            this.progress.Visible = true;
            this.btnUpgrade.Enabled = false;

            worker.RunWorkerAsync();
        }
    }
}
