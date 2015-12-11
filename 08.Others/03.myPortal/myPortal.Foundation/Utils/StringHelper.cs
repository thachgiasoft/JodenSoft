using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.Foundation.Utils
{
    public static class StringHelper
    {
        public static string CalcBankAccount(string sBankAccount)
        {
            if(string.IsNullOrWhiteSpace(sBankAccount)) return string.Empty;
            return sBankAccount.Length > 6 ? sBankAccount.Substring(0, 2) + "*".PadLeft(sBankAccount.Length - 6, '*') + sBankAccount.Substring(sBankAccount.Length - 4, 4) : sBankAccount;
        }
    }
}
