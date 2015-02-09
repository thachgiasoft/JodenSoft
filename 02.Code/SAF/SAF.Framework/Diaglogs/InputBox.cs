using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Framework.Diaglogs
{
    /// <summary>
    /// TODO:InputBox
    /// </summary>
    public partial class InputBox : XtraForm
    {
        #region InputBox

        private Predicate<string> _predicate = null;

        private InputBox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this._predicate != null)
            {
                var flag = false;
                if (this.lciText.Visibility != LayoutVisibility.Never)
                {
                    flag = this._predicate(this.txtMessage.EditValue.ToStringEx());
                }
                else
                {
                    flag = this._predicate(this.menoMessage.EditValue.ToStringEx());
                }
                if (!flag) return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Show

        public static bool Show(out string value, Predicate<string> predicate = null)
        {
            return Show("请输入数据", "请输入：", out value, predicate);
        }

        public static bool Show(string caption, out string value, Predicate<string> predicate = null)
        {
            return Show("请输入数据", caption, out value, predicate);
        }

        public static bool Show(string title, string caption, out string value, Predicate<string> predicate = null)
        {
            using (var inputBox = new InputBox())
            {
                inputBox.Text = title;
                inputBox.lciText.Text = caption;
                inputBox.lciMemo.Visibility = LayoutVisibility.Never;
                inputBox._predicate = predicate;
                inputBox.Height = 140;
                var dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    value = inputBox.txtMessage.EditValue.ToStringEx();
                    return true;
                }
                else
                {
                    value = string.Empty;
                    return false;
                }
            }
        }

        #endregion

        #region ShowMemo

        public static bool ShowMemo(out string value, Predicate<string> predicate = null)
        {
            return ShowMemo("请输入数据", "请输入：", out value, predicate);
        }

        public static bool ShowMemo(string caption, out string value, Predicate<string> predicate = null)
        {
            return ShowMemo("请输入数据", caption, out value, predicate);
        }

        public static bool ShowMemo(string title, string caption, out string value, Predicate<string> predicate = null)
        {
            using (var inputBox = new InputBox())
            {
                inputBox.Text = title;
                inputBox.lciMemo.Text = caption;
                inputBox.lciText.Visibility = LayoutVisibility.Never;
                inputBox._predicate = predicate;
                var dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    value = inputBox.menoMessage.EditValue.ToStringEx();
                    return true;
                }
                else
                {
                    value = string.Empty;
                    return false;
                }
            }
        }

        #endregion

    }
}
