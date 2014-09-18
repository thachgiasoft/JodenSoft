#region Copyright © 2014 Libra. All rights reserved.
/*
 * 文 件 名：StringHelper
 * 功能描述：
 * 
 * 当前版本: V1.0
 * 作    者: 利建
 * 创建时间：2014/1/10 14:29:13
 *
 * 修改标识：
 * 修改描述：
 *
 */
#endregion

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SAF.Foundation.ComponentModel
{
    public static class StringHelper
    {
        private static readonly Regex regex_0 = new Regex("(?<keep>[^aeiou])y$", RegexOptions.Compiled);
        private static readonly Regex regex_1 = new Regex("(?<keep>[aeiou]y)$", RegexOptions.Compiled);
        private static readonly Regex regex_2 = new Regex("(?<keep>[sxzh])$", RegexOptions.Compiled);
        private static readonly Regex regex_3 = new Regex("(?<keep>[^sxzhy])$", RegexOptions.Compiled);
        private static readonly Regex regex_4 = new Regex("(?<keep>[^aeiou])ies$", RegexOptions.Compiled);
        private static readonly Regex regex_5 = new Regex("(?<keep>[aeiou]y)s$", RegexOptions.Compiled);
        private static readonly Regex regex_6 = new Regex("(?<keep>[sxzh])es$", RegexOptions.Compiled);
        private static readonly Regex regex_7 = new Regex("(?<keep>[^sxzhy])s$", RegexOptions.Compiled);
        private static readonly Regex regex_8 = new Regex("[\\W_]+", RegexOptions.Compiled);
        private static readonly Regex regex_9 = new Regex("([A-Z][a-z]*)|([0-9]+)", RegexOptions.Compiled);

        public static string CalculateMd5Hash(string text)
        {
            return StringHelper.CalculateMd5Hash(text, Encoding.UTF8);
        }
        public static string CalculateMd5Hash(string text, Encoding encoding)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] bytes = encoding.GetBytes(text);
            byte[] inArray = mD.ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
        public static int GetHashCode(string s)
        {
            int num = 0;
            int i;
            for (i = 0; i < s.Length - 1; i += 2)
            {
                num = (num << 5) - num + (int)s[i];
                num = (num << 5) - num + (int)s[i + 1];
            }
            if (i < s.Length)
            {
                num = (num << 5) - num + (int)s[i];
            }
            return num;
        }
        public static string CalculateSafeDirectoryName(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string text2 = Convert.ToBase64String(bytes, bytes.Length - 9, 8).ToLower(CultureInfo.InvariantCulture);
            text2 = text2.Replace('/', '-');
            text2 = text2.Replace('+', '_');
            return text2.Replace('=', '-');
        }
        public static int LineCount(string text, int offset, int newoffset)
        {
            int num = 0;
            while (offset < newoffset)
            {
                if (text[offset] == '\r' || (text[offset] == '\n' && (offset == 0 || text[offset - 1] != '\r')))
                {
                    num++;
                }
                offset++;
            }
            return num;
        }
        public static string GetFileContent(string path)
        {
            return StringHelper.GetFileContent(path, null);
        }
        public static string GetFileContent(string path, Encoding encoding)
        {
            if (!File.Exists(path))
            {
                return string.Empty;
            }
            string result = string.Empty;
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte b = 0;
            while (b < 3)
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(path, encoding, true))
                    {
                        result = streamReader.ReadToEnd();
                        break;
                    }
                }
                catch
                {
                    b += 1;
                    Thread.Sleep(50);
                }
            }
            return result;
        }
        public static string HtmlDecode(string text)
        {
            if (text == null)
            {
                return null;
            }
            text = text.Replace("&quot;", "\"");
            text = text.Replace("&lt;", "<");
            text = text.Replace("&gt;", ">");
            text = text.Replace("&amp;", "&");
            text = text.Replace("&nbsp;", " ");
            return text;
        }
        public static bool ParseBoolean(string value)
        {
            return string.Compare(value, "true", true) == 0 || string.Compare(value, "yes", true) == 0;
        }
        public static string XmlEncode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            value = value.Replace("&", "&amp;");
            value = value.Replace("\"", "&quot;");
            value = value.Replace("'", "&apos;");
            value = value.Replace("<", "&lt;");
            value = value.Replace(">", "&gt;");
            return value;
        }
        public static string PrepareStatement(string statement)
        {
            statement = statement.Replace("\"", "\" + Convert.ToChar(34) + \"");
            statement = statement.Replace("\\", "\" + Convert.ToChar(92) + \"");
            statement = statement.Replace("<%%", "<%");
            statement = statement.Replace("%%>", "%>");
            return statement;
        }
        public static bool IsPlural(string value)
        {
            return StringHelper.regex_4.IsMatch(value) || StringHelper.regex_5.IsMatch(value) || StringHelper.regex_6.IsMatch(value) || StringHelper.regex_7.IsMatch(value);
        }
        public static bool IsSingular(string value)
        {
            return !StringHelper.IsPlural(value);
        }
        //public static string ToPlural(string value)
        //{

        //}

        //public static string ToSingular(string value)
        //{

        //}

        public static string ToCamelCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            string text = StringHelper.ToPascalCase(value);
            if (text.Length > 2)
            {
                return char.ToLower(text[0]) + text.Substring(1);
            }
            return text.ToLower();
        }
        public static string ToPascalCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            bool flag = false;
            bool flag2 = false;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if (char.IsUpper(c))
                {
                    flag = true;
                }
                if (char.IsLower(c))
                {
                    flag2 = true;
                }
            }
            bool flag3 = flag2 && flag;
            string[] array = StringHelper.regex_8.Split(value);
            StringBuilder stringBuilder = new StringBuilder();
            if (array.Length > 1)
            {
                string[] array2 = array;
                for (int j = 0; j < array2.Length; j++)
                {
                    string text = array2[j];
                    if (text.Length > 1)
                    {
                        stringBuilder.Append(char.ToUpper(text[0]));
                        if (flag3)
                        {
                            stringBuilder.Append(text.Substring(1));
                        }
                        else
                        {
                            stringBuilder.Append(text.Substring(1).ToLower());
                        }
                    }
                    else
                    {
                        stringBuilder.Append(text);
                    }
                }
            }
            else
            {
                if (value.Length > 1)
                {
                    stringBuilder.Append(char.ToUpper(value[0]));
                    stringBuilder.Append(flag3 ? value.Substring(1) : value.Substring(1).ToLower());
                }
                else
                {
                    stringBuilder.Append(value.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }
        public static string ToSpacedWords(string value)
        {
            value = StringHelper.ToPascalCase(value);
            MatchCollection matchCollection = StringHelper.regex_9.Matches(value);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Match match in matchCollection)
            {
                stringBuilder.Append(match.Value);
                stringBuilder.Append(' ');
            }
            stringBuilder.Length--;
            return stringBuilder.ToString();
        }
        public static bool ContainsSpace(string value)
        {
            return !string.IsNullOrEmpty(value) && StringHelper.ContainsString(value, new List<string>
			{
				" "
			});
        }
        public static bool ContainsString(string source, IEnumerable<string> wordList)
        {
            return !string.IsNullOrEmpty(source) && wordList != null && wordList.Count<string>() != 0 && wordList.Any(new Func<string, bool>(source.Contains));
        }
        public static bool IsNumeric(string value)
        {
            double num;
            return double.TryParse(value, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out num);
        }
        public static string AppendOrdinalSuffix(string number)
        {
            if (StringHelper.IsNumeric(number))
            {
                int number2 = int.Parse(number);
                return StringHelper.AppendOrdinalSuffix(number2);
            }
            return number;
        }
        public static string AppendOrdinalSuffix(int number)
        {
            int num = number % 100;
            if (num >= 11 && num <= 13)
            {
                return number + "th";
            }
            switch (number % 10)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }
        public static Dictionary<string, string> ParseConfigString(string config)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            string[] array = config.Split(new char[]
			{
				';'
			});
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                string[] array3 = text.Split(new char[]
				{
					'='
				});
                if (array3.Length == 2)
                {
                    dictionary.Add(array3[0].Trim(), array3[1].Trim());
                }
                else
                {
                    dictionary.Add(text.Trim(), null);
                }
            }
            return dictionary;
        }
        public static string NormalizeLineEndings(string text)
        {
            return text.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }
    }
}
