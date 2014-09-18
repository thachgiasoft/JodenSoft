using SAF.Foundation.ComponentModel;
using SAF.Foundation.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SAF.Foundation;

namespace SAF.Foundation.Security
{
    public static class RegisterHelper
    {
        public static string CalcPollCode(string code)
        {
            if (!code.IsGuid())
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

        public static bool Validate(string pollCode, string productId)
        {
            var code = CalcPollCode(productId);
            return code.Equals(pollCode, StringComparison.InvariantCulture);
        }
    }
}
