using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.IO;

namespace SAF.Foundation
{
    /// <summary>
    /// String的扩展方法
    /// </summary>
    public static class StringExtensions
    {
        #region GUID
        /// <summary>
        /// Determines whether the input string is a global unique identifier.
        /// </summary>
        /// <param name="s">An input string to check.</param>
        /// <returns>True if string is a GUID; otherwise false.</returns>
        public static bool IsGuid(this string s)
        {
            Regex GuidPattern = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$", RegexOptions.Compiled | RegexOptions.Singleline);
            return !s.IsEmpty() && GuidPattern.IsMatch(s);
        }
        #endregion

        #region Email
        /// <summary>
        /// Determines whether the input string is an email.
        /// </summary>
        /// <param name="s">An input string to check.</param>
        /// <returns>True if string is an email; otherwise false.</returns>
        public static bool IsEmail(this string s)
        {
            Regex EmailPattern = new Regex(@"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+", RegexOptions.Compiled | RegexOptions.Singleline);
            return !s.IsEmpty() && EmailPattern.IsMatch(s);
        }
        #endregion

        /// <summary>
        /// 是否是IP4地址
        /// </summary>
        public static bool IsIP4(this string value)
        {
            if (value.IsEmpty())
                return false;

            const string pattern = @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))";
            return Regex.IsMatch(value, pattern);
        }

        #region FormatEx
        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatEx(this string s, params object[] args)
        {
            if (s.IsEmpty()) return s;
            return string.Format(s, args);
        }

        /// <summary>
        /// 以指定字符串作为分隔符将指定字符串分隔成数组
        /// </summary>
        /// <param name="value">要分割的字符串</param>
        /// <param name="strSplit">字符串类型的分隔符</param>
        /// <param name="removeEmptyEntries">是否移除数据中元素为空字符串的项</param>
        /// <returns>分割后的数据</returns>
        public static string[] Split(this string value, string strSplit, bool removeEmptyEntries = false)
        {
            return value.Split(new[] { strSplit }, removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }
        #endregion

        #region substring
        /// <summary>
        /// Trims an input string to required length.
        /// </summary>
        /// <param name="s">An input string.</param>
        /// <param name="length">The required lenght.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimToLength(this string s, int length)
        {
            return (s.IsEmpty() || s.Length <= length) ? s : s.Substring(0, length);
        }

        /// <summary>
        /// 返回字符串左侧指定长度,长度不足返回原字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string s, int length)
        {
            return (s.IsEmpty() || s.Length <= length) ? s : s.Substring(0, length);
        }
        /// <summary>
        /// 返回字符串右侧指定长度
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string s, int length)
        {
            return (s.IsEmpty() || s.Length <= length) ? s : s.Substring(s.Length - length, length);
        }

        public static string Substring(this string source, string startWord, string endWord)
        {
            if (source.IsEmpty())
                throw new ArgumentNullException("source", "源字符串不能为Null或string.Empty");

            if (startWord.IsEmpty())
                throw new ArgumentNullException("startWord", "字符串startWord不能为Null或string.Empty");

            if (endWord.IsEmpty())
                throw new ArgumentNullException("endWord", "字符串endWord不能为Null或string.Empty");

            int startIndex = source.IndexOf(startWord, StringComparison.CurrentCultureIgnoreCase);
            if (startIndex < 0) return string.Empty;
            startIndex += +startWord.Length;

            int endIndex = source.IndexOf(endWord, startIndex, StringComparison.CurrentCultureIgnoreCase);
            if (endIndex < 0) endIndex = source.Length;
            if (startIndex >= endIndex) return string.Empty;

            string result = source.Substring(startIndex, endIndex - startIndex);
            return result.Trim();
        }

        public static string After(this string s, string word, bool bIncludeSelf)
        {
            int num = s.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            string result;
            if (num == -1)
            {
                result = string.Empty;
            }
            else
            {
                if (bIncludeSelf)
                {
                    result = s.Substring(num, s.Length - num);
                }
                else
                {
                    result = s.Substring(num + word.Length, s.Length - num - word.Length);
                }
            }
            return result;
        }

        public static string After(this string s, string word)
        {
            return s.After(word, false);
        }

        public static string Before(this string s, string word, bool bIncludeSelf)
        {
            int num = s.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            string result;
            if (num == -1)
            {
                result = string.Empty;
            }
            else
            {
                if (bIncludeSelf)
                {
                    result = s.Substring(0, num + word.Length);
                }
                else
                {
                    result = s.Substring(0, num);
                }
            }
            return result;
        }

        public static string Before(this string s, string word)
        {
            return s.Before(word, false);
        }

        #endregion

        #region Match

        public static bool IsMatch(this string s, string pattern)
        {
            if (s == null) return false;
            else return Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            if (s == null) return "";
            return Regex.Match(s, pattern).Value;
        }

        #endregion

        #region ToCamel/ToPascal

        public static string ToCamel(this string s)
        {
            if (s.IsEmpty()) return s;
            return s[0].ToString().ToLower() + s.Substring(1);
        }

        public static string ToPascal(this string s)
        {
            if (s.IsEmpty()) return s;
            return s[0].ToString().ToUpper() + s.Substring(1);
        }

        #endregion

        #region 全角/半角
        /// <summary>
        /// 转全角(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        public static string ToSBC(this string input)
        {
            if (input.IsEmpty()) return input;
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }
        /// <summary>
        /// 转半角(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        public static string ToDBC(this string input)
        {
            if (input.IsEmpty()) return input;
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region 获取汉字拼音首字母

        /// <summary>
        /// 获取汉字拼音首字母
        /// </summary>
        /// <param name="s">输入</param>
        /// <returns>汉字拼音首字母，其它字符原样返回</returns>
        public static string GetChineseSpell(this string s)
        {
            if (s.IsEmpty()) return s;

            int len = s.Length;
            StringBuilder reVal = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                reVal.Append(_GetChineseSpell(s.Substring(i, 1)));
            }
            return reVal.ToString();
        }

        /// <summary>
        /// 获取一个简体中文字的拼音首字母
        /// </summary>
        /// <param name="cn">一个简体中文字</param>
        /// <returns>拼音首字母</returns>
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

        #region  简繁体转换
        /// <summary>
        /// 简体转繁体
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToTraditionalChinese(this string s)
        {
            if (s.IsEmpty()) return s;
            return Microsoft.VisualBasic.Strings.StrConv(s, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
        }
        /// <summary>
        /// 繁体转简体
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToSimplifiedChinese(this string s)
        {
            if (s.IsEmpty()) return s;
            return Microsoft.VisualBasic.Strings.StrConv(s, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
        }
        #endregion

        #region 保存至文件

        public static void Save(this string data, string path)
        {
            data.Save(path, Encoding.Default);
        }

        public static void Save(this string data, string path, Encoding encoding)
        {
            File.WriteAllText(path, data, encoding);
        }
        #endregion

        #region Reverse
        /// <summary>
        /// 返回一个字符串，在该字符串中指定字符串的字符顺序被颠倒
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Reverse(this string s)
        {
            if (s.IsEmpty()) return s;
            return Microsoft.VisualBasic.Strings.StrReverse(s);
        }

        #endregion

        public static string Between(this string s, string preWord, string afterWord, bool bIncludeSelf, ref int iStart)
        {
            if (preWord.IsEmpty() && afterWord.IsEmpty())
                return string.Empty;
            else if (preWord.IsEmpty())
                return Before(s, afterWord, bIncludeSelf);
            else if (afterWord.IsEmpty())
                return After(s, preWord, bIncludeSelf);
            else
            {
                if (iStart < 0)
                    iStart = 0;
                int iLen = preWord.Length;
                iStart = s.IndexOf(preWord, iStart, StringComparison.OrdinalIgnoreCase);
                int j = s.IndexOf(afterWord, iStart + iLen, StringComparison.OrdinalIgnoreCase);
                if (iStart == -1 && j == -1)
                    return string.Empty;
                else if (iStart == -1 && j != -1)
                    return Before(s, afterWord, bIncludeSelf);
                else if (iStart != -1 && j == -1)
                    return After(s, preWord, bIncludeSelf);
                else if (bIncludeSelf)
                    return s.Substring(iStart, j - iStart + afterWord.Length);
                else
                    return s.Substring(iStart + iLen, j - iStart - iLen);
            }
        }
    }
}
