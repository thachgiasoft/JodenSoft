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
using SAF.Foundation.ServiceModel;

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

            if (ApplicationService.Current.MainForm != null)
            {
                this.Icon = ApplicationService.Current.MainForm.Icon;
            }

            this.StartPosition = FormStartPosition.CenterScreen;
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

        public static bool Show(ref string value, Predicate<string> predicate = null)
        {
            return Show("请输入数据", "请输入：", ref value, predicate);
        }

        public static bool Show(string caption, ref string value, Predicate<string> predicate = null)
        {
            return Show("请输入数据", caption, ref value, predicate);
        }

        public static bool Show(string title, string caption, ref string value, Predicate<string> predicate = null)
        {
            using (var inputBox = new InputBox())
            {
                inputBox.Text = title;
                inputBox.lciText.Text = caption;
                inputBox.lciMemo.Visibility = LayoutVisibility.Never;
                inputBox._predicate = predicate;
                inputBox.Height = 140;
                inputBox.txtMessage.EditValue = value ?? string.Empty;
                var dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    value = inputBox.txtMessage.EditValue.ToStringEx();
                    inputBox._predicate = null;
                    return true;
                }
                else
                {
                    value = string.Empty;
                    inputBox._predicate = null;
                    return false;
                }
            }
        }

        #endregion

        #region ShowMemo

        public static bool ShowMemo(ref string value, Predicate<string> predicate = null)
        {
            return ShowMemo("请输入数据", "请输入：", ref value, predicate);
        }

        public static bool ShowMemo(string caption, ref string value, Predicate<string> predicate = null)
        {
            return ShowMemo("请输入数据", caption, ref value, predicate);
        }

        public static bool ShowMemo(string title, string caption, ref string value, Predicate<string> predicate = null)
        {
            using (var inputBox = new InputBox())
            {
                inputBox.Text = title;
                inputBox.lciMemo.Text = caption;
                inputBox.lciText.Visibility = LayoutVisibility.Never;
                inputBox._predicate = predicate;
                inputBox.Height = 200;
                inputBox.txtMessage.EditValue = value ?? string.Empty;
                var dr = inputBox.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    value = inputBox.menoMessage.EditValue.ToStringEx();
                    inputBox._predicate = null;
                    return true;
                }
                else
                {
                    value = string.Empty;
                    inputBox._predicate = null;
                    return false;
                }
            }
        }

        #endregion

    }
}
