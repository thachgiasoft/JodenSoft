using DevExpress.XtraEditors;
using SAF.EntityFramework;
using SAF.Foundation.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls
{
    public partial class fmRegister : XtraForm
    {
        private fmRegister()
        {
            InitializeComponent();

            this.txtProductId.EditValue = Session.Current.ProductId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!RegisterHelper.Validate(this.txtPollCode.Text.Trim()))
            {
                var message = string.Format("注册码错误!{0}请联系系统供应商获取注册码.", Environment.NewLine);
                XtraMessageBox.Show(message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XtraMessageBox.Show("注册成功!", "注册成功", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static DialogResult ShowRegister()
        {
            using (var frm = new fmRegister())
            {
                frm.ShowInTaskbar = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                return frm.ShowDialog();
            }
        }
    }
}
