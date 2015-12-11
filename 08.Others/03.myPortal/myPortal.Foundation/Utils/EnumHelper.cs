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
        //        throw new Exception("ToDataTable只能用于Enum类型.");
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
        /// 获得Enum类型的绑定列表,返回一个DataTable.
        /// <para>DataTable有两列:</para>
        /// <para>"Value": System.String;</para>
        /// <para>"Text": System.String. </para>    
        /// </summary>
        /// <typeparam name="T">Enum值的数据类型</typeparam>
        /// <param name="enumType">Enum类型.用typeof()获取.</param>
        /// <returns>返回一个DataTable</returns>
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

            //查看枚举类型中的每项，如果有DisplayAttribute，则使用其本地化的字符串资源，否则，直接使用枚举的默认名称
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
        /// 获取枚举值 的描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">枚举值</param>
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
