using System;
using System.Collections.Generic;
using System.Text;

namespace SAF.SqlClr.Helper
{
    /// <summary>
    /// ����дת����
    /// </summary>
    internal static class MoneyConverter
    {
        private static readonly String cnNumber = "��Ҽ��������½��ƾ�";
        private static readonly String cnUnit = "�ֽ�Բʰ��Ǫ��ʰ��Ǫ��ʰ��Ǫ��ʰ��Ǫ";

        private static readonly String[] enSmallNumber = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static readonly String[] enLargeNumber = { "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        private static readonly String[] enUnit = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };

        /// <summary>
        /// ���ҽ�����Ĵ�дת������
        /// </summary>
        /// <param name="moneyString">ת�����
        /// <para>���ת�����:9999999999999999.99��16λ����λ��2λС��λ��</para>
        /// </param>
        /// <returns>ת���ɹ��򷵻ط��㳤�ִ�,���򷵻��㳤�ִ�</returns>
        public static String GetCnString(string moneyString)
        {
            if (moneyString == null || string.IsNullOrEmpty(moneyString) || moneyString.Trim() == "0" || Math.Round(Convert.ToDecimal(moneyString), 2) == 0)
            {
                return "��";
            }
            string[] tmpString = moneyString.Split('.');
            string intString = moneyString;   // Ĭ��Ϊ����
            string decString = "";            // ����С�������ִ�
            string rmbCapital = "";            // �������Ĵ�д�ִ�
            int k;
            int j;
            int n;

            if (tmpString.Length > 1)
            {
                intString = tmpString[0];             // ȡ��������
                decString = tmpString[1];             // ȡС������
            }
            decString += "00";
            decString = decString.Substring(0, 2);   // ������λС��λ
            intString += decString;

            try
            {
                k = intString.Length - 1;
                if (k > 0 && k < 18)
                {
                    for (int i = 0; i <= k; i++)
                    {
                        j = (int)intString[i] - 48;
                        // rmbCapital = rmbCapital + cnNumber[j] + cnUnit[k-i];     // �������õ�ֱ��ת��
                        n = i + 1 >= k ? (int)intString[k] - 48 : (int)intString[i + 1] - 48; // ��Ч�� if( ){ }else{ }
                        if (j == 0)
                        {
                            if (k - i == 2 || k - i == 6 || k - i == 10 || k - i == 14)
                            {
                                rmbCapital += cnUnit[k - i];
                            }
                            else
                            {
                                if (n != 0)
                                {
                                    rmbCapital += cnNumber[j];
                                }
                            }
                        }
                        else
                        {
                            rmbCapital = rmbCapital + cnNumber[j] + cnUnit[k - i];
                        }
                    }

                    rmbCapital = rmbCapital.Replace("������", "��");
                    rmbCapital = rmbCapital.Replace("����", "��");
                    rmbCapital = rmbCapital.Replace("����", "��");
                    rmbCapital = rmbCapital.TrimStart('Բ');
                    rmbCapital = rmbCapital.TrimStart('��');

                    return rmbCapital;
                }
                else
                {
                    return "";   // ����ת����Χʱ�������㳤�ִ�
                }
            }
            catch
            {
                return "";   // ���з���ֵ�ַ�ʱ�������㳤�ִ�
            }
        }

        /// <summary>
        /// ���ҽ��Ӣ�Ĵ�дת������
        /// </summary>
        /// <param name="moneyString">ת�����
        /// <para>���ת�����:999999999999999.99��15λ����λ��2λС��λ��</para>
        /// </param>
        /// <returns>ת���ɹ��򷵻ط��㳤�ִ�,���򷵻��㳤�ִ�</returns>
        public static String GetEnString(string moneyString)
        {
            if (moneyString == null || string.IsNullOrEmpty(moneyString) || moneyString.Trim() == "0" || Math.Round(Convert.ToDecimal(moneyString), 2) == 0)
            {
                return "ZERO";
            }
            string[] tmpString = moneyString.Split('.');
            string intString = moneyString;   // Ĭ��Ϊ����
            string decString = "";            // ����С�������ִ�
            string engCapital = "";            // ����Ӣ�Ĵ�д�ִ�
            string strBuff1;
            string strBuff2;
            string strBuff3;
            int curPoint;
            int i1;
            int i2;
            int i3;
            int k;
            int n;

            if (tmpString.Length > 1)
            {
                intString = tmpString[0];             // ȡ��������
                decString = tmpString[1];             // ȡС������
            }
            decString += "00";
            decString = decString.Substring(0, 2);   // ������λС��λ

            try
            {
                // ���´�����������
                curPoint = intString.Length - 1;
                if (curPoint >= 0 && curPoint < 15)
                {
                    k = 0;
                    while (curPoint >= 0)
                    {
                        strBuff1 = "";
                        strBuff2 = "";
                        strBuff3 = "";
                        if (curPoint >= 2)
                        {
                            n = int.Parse(intString.Substring(curPoint - 2, 3));
                            if (n != 0)
                            {
                                i1 = n / 100;            // ȡ��λ��ֵ
                                i2 = (n - i1 * 100) / 10;    // ȡʰλ��ֵ
                                i3 = n - i1 * 100 - i2 * 10;   // ȡ��λ��ֵ
                                if (i1 != 0)
                                {
                                    strBuff1 = enSmallNumber[i1] + " HUNDRED ";
                                }
                                if (i2 != 0)
                                {
                                    if (i2 == 1)
                                    {
                                        strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";
                                    }
                                    else
                                    {
                                        strBuff2 = enLargeNumber[i2 - 2] + " ";
                                        if (i3 != 0)
                                        {
                                            strBuff3 = enSmallNumber[i3] + " ";
                                        }
                                    }
                                }
                                else
                                {
                                    if (i3 != 0)
                                    {
                                        strBuff3 = enSmallNumber[i3] + " ";
                                    }
                                }
                                engCapital = strBuff1 + strBuff2 + strBuff3 + enUnit[k] + " " + engCapital;
                            }
                        }
                        else
                        {
                            n = int.Parse(intString.Substring(0, curPoint + 1));
                            if (n != 0)
                            {
                                i2 = n / 10;      // ȡʰλ��ֵ
                                i3 = n - i2 * 10;   // ȡ��λ��ֵ
                                if (i2 != 0)
                                {
                                    if (i2 == 1)
                                    {
                                        strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";
                                    }
                                    else
                                    {
                                        strBuff2 = enLargeNumber[i2 - 2] + " ";
                                        if (i3 != 0)
                                        {
                                            strBuff3 = enSmallNumber[i3] + " ";
                                        }
                                    }
                                }
                                else
                                {
                                    if (i3 != 0)
                                    {
                                        strBuff3 = enSmallNumber[i3] + " ";
                                    }
                                }
                                engCapital = strBuff2 + strBuff3 + enUnit[k] + " " + engCapital;
                            }
                        }
                        ++k;
                        curPoint -= 3;
                    }
                    engCapital = engCapital.TrimEnd();
                }


                // ���´���С������
                strBuff2 = "";
                strBuff3 = "";
                n = int.Parse(decString);
                if (n != 0)
                {
                    i2 = n / 10;      // ȡʰλ��ֵ
                    i3 = n - i2 * 10;   // ȡ��λ��ֵ
                    if (i2 != 0)
                    {
                        if (i2 == 1)
                        {
                            strBuff2 = enSmallNumber[i2 * 10 + i3] + " ";
                        }
                        else
                        {
                            strBuff2 = enLargeNumber[i2 - 2] + " ";
                            if (i3 != 0)
                            {
                                strBuff3 = enSmallNumber[i3] + " ";
                            }
                        }
                    }
                    else
                    {
                        if (i3 != 0)
                        {
                            strBuff3 = enSmallNumber[i3] + " ";
                        }
                    }
                    // ��С���ִ�׷�ӵ������ִ���
                    if (engCapital.Length > 0)
                    {
                        engCapital = engCapital + " AND CENTS " + strBuff2 + strBuff3;   // ����������ʱ
                    }
                    else
                    {
                        engCapital = "CENTS " + strBuff2 + strBuff3;   // ֻ��С������ʱ
                    }
                }

                engCapital = engCapital.TrimEnd();
                return engCapital;
            }
            catch
            {
                return "";   // ���������ַ�ʱ�������㳤�ִ�
            }
        }
    }
}
