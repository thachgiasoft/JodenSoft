
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace SAF.Keygen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtProductId.Text))
            {
                MessageBox.Show("请输入产品码!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPollCode.Clear();
                return;
            }

            var code = this.txtProductId.Text.Trim();

            this.txtPollCode.Text = CalcPollCode(code);

        }

        public static bool IsGuid(string s)
        {
            Regex GuidPattern = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$", RegexOptions.Compiled | RegexOptions.Singleline);
            return !string.IsNullOrWhiteSpace(s) && GuidPattern.IsMatch(s);
        }

        public static string CalcPollCode(string code)
        {
            if (!IsGuid(code))
            {
                MessageBox.Show("产品码格式错误!", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }

            code = MD5Helper.Hash(code);
            code = SHA1Helper.Hash(code);
            code = MD5Helper.Hash(code);
            code = SHA1Helper.Hash(code);
            code = MD5Helper.Hash(code);
            code = SHA1Helper.Hash(code);

            return code;
        }
    }
}
