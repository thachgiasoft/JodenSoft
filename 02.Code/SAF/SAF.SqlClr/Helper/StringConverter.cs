using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.SqlClr.Helper
{
    public static class StringConverter
    {
        #region ��ȡ����ƴ������ĸ

        /// <summary>
        /// ��ȡ����ƴ������ĸ
        /// </summary>
        /// <param name="s">����</param>
        /// <returns>����ƴ������ĸ�������ַ�ԭ������</returns>
        public static string GetChineseSpell(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;

            int len = s.Length;
            StringBuilder reVal = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                reVal.Append(_GetChineseSpell(s.Substring(i, 1)));
            }
            return reVal.ToString();
        }

        /// <summary>
        /// ��ȡһ�����������ֵ�ƴ������ĸ
        /// </summary>
        /// <param name="cn">һ������������</param>
        /// <returns>ƴ������ĸ</returns>
        private static string _GetChineseSpell(string cn)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cn);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "?";
            }
            else return cn;
        }
        #endregion
    }
}
