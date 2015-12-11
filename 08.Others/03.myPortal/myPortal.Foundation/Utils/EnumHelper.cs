using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace myPortal.Foundation.Utils
{
    /// <summary>
    /// EnumHelper
    /// </summary>
    public static class EnumHelper
    {
        //public static DataTable ToDataTable<T>(Type enumType)
        //{
        //    if (!enumType.IsEnum)
        //    {
        //        throw new Exception("ToDataTableֻ������Enum����.");
        //    }

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Value", typeof(string));
        //    dt.Columns.Add("Text", typeof(string));

        //    Type typeDescription = typeof(DescriptionAttribute);
        //    FieldInfo[] fields = enumType.GetFields();
        //    foreach (FieldInfo field in fields)
        //    {
        //        if (field.FieldType.IsEnum)
        //        {
        //            DataRow dr = dt.NewRow();
        //            object obj = enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null);
        //            dr["Value"] = (T)obj;
        //            object[] arr = field.GetCustomAttributes(typeDescription, true);
        //            if (arr.Length > 0)
        //            {
        //                DescriptionAttribute da = (DescriptionAttribute)arr[0];
        //                dr["Text"] = da.Description;
        //            }
        //            else
        //            {
        //                dr["Text"] = field.Name;
        //            }
        //            dt.Rows.Add(dr);
        //        }
        //    }
        //    return dt;
        //}

        private static Dictionary<Type, DataTable> m_EnumDic = new Dictionary<Type, DataTable>();
        /// <summary>
        /// ���Enum���͵İ��б�,����һ��DataTable.
        /// <para>DataTable������:</para>
        /// <para>"Value": System.String;</para>
        /// <para>"Text": System.String. </para>    
        /// </summary>
        /// <typeparam name="T">Enumֵ����������</typeparam>
        /// <param name="enumType">Enum����.��typeof()��ȡ.</param>
        /// <returns>����һ��DataTable</returns>
        public static DataTable ToDataTable<T>(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be enum!");
            }

            if (m_EnumDic.ContainsKey(enumType))
            {
                return m_EnumDic[enumType] as DataTable;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Value", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            //�鿴ö�������е�ÿ������DisplayAttribute����ʹ���䱾�ػ����ַ�����Դ������ֱ��ʹ��ö�ٵ�Ĭ������
            T[] enumValues = Enum.GetValues(enumType) as T[];
            foreach (T v in enumValues)
            {
                string enumName = Enum.GetName(enumType, v);
                DisplayAttribute[] attributes = enumType.GetField(enumName).GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (attributes == null || attributes.Length < 1)
                {
                    dt.Rows.Add(v, enumName);
                }
                else
                {
                    string str = attributes[0].Name;
                    dt.Rows.Add(v, string.IsNullOrWhiteSpace(str) ? enumName : str.Trim());
                }
            }
            m_EnumDic.Add(enumType, dt);
            return dt;
        }

        /// <summary>
        /// ��ȡö��ֵ ������
        /// </summary>
        /// <typeparam name="T">ö������</typeparam>
        /// <param name="value">ö��ֵ</param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(object value) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type must be enum!");
            }

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return string.Empty;

            Type t = typeof(T);
            T var = (T)value;

            FieldInfo fi = t.GetField(var.ToString());
            if (fi != null)
            {
                DisplayAttribute[] attr = fi.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (attr.Length > 0)
                {
                    return attr[0].Name;
                }
                else
                {
                    return var.ToString();
                }
            }

            return var.ToString();
        }

    }
}
