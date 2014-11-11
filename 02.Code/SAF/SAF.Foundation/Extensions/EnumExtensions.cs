using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Resources;
using System.ComponentModel.DataAnnotations;

namespace SAF.Foundation
{
    /// <summary>
    /// Enum Extensions
    /// </summary>
    public static class EnumExtensions
    {
        private static Dictionary<Type, object> EnumDic = new Dictionary<Type, object>();

        public static IList<KeyValuePair<T, string>> ToList<T>(this Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be enum!");
            }

            if (EnumDic.ContainsKey(enumType.GetType()))
            {
                return EnumDic[enumType.GetType()] as IList<KeyValuePair<T, string>>;
            }

            IList<KeyValuePair<T, string>> list = new List<KeyValuePair<T, string>>();

            //查看枚举类型中的每项，如果有DisplayAttribute，则使用其本地化的字符串资源，否则，直接使用枚举的默认名称
            T[] enumValues = Enum.GetValues(enumType) as T[];
            foreach (T v in enumValues)
            {
                string enumName = Enum.GetName(enumType, v);
                DisplayAttribute[] attributes = enumType.GetField(enumName).GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if (attributes == null || attributes.Length < 1)
                {
                    list.Add(new KeyValuePair<T, string>(v, enumName));
                }
                else
                {
                    //ResourceManager mgr = new ResourceManager(attributes[0].ResourceType);
                    //string str = mgr.GetString(attributes[0].Name);

                    var str = attributes[0].Name;

                    list.Add(new KeyValuePair<T, string>(v, string.IsNullOrWhiteSpace(str) ? enumName : str.Trim()));
                }
            }
            EnumDic.Add(enumType.GetType(), list);
            return list;
        }

        /// <summary>
        /// 判断枚举集合中是否包含指定枚举值
        /// </summary>
        /// <param name="aEnumSet">枚举集合</param>
        /// <param name="enums">指定枚举值</param>
        /// <returns>包含返回True</returns>
        public static bool IncludeEnum(this object aEnumSet, object aEnum)
        {
            int data1 = (int)aEnumSet;
            int data2 = (int)aEnum;
            return (data1 & data2) == data2;
        }

        /// <summary>
        /// 判断集合枚举值是否包含参数枚举值
        /// </summary>
        /// <typeparam name="T">集合枚举类型</typeparam>
        /// <param name="aEnumSet">集合枚举</param>
        /// <returns>包含任意一个返回true</returns>
        public static bool IncludeAnyEnum<T>(this T aEnumSet, params T[] aEnum)
        {
            int data1 = aEnumSet.To<int>();
            foreach (T a in aEnum)
            {
                int i = a.To<int>();
                if ((data1 & i) == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断某个枚举值是否在枚举集合中
        /// </summary>
        /// <param name="aEnum">指定枚举值</param>
        /// <param name="aEnumSet">枚举集合</param>
        /// <returns>包含返回True</returns>
        public static bool InEnum(this object aEnum, params object[] aEnumSet)
        {
            int i = (int)aEnum;
            foreach (object a in aEnumSet)
            {
                int j = (int)a;
                if (i == j)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 枚举值加法
        /// </summary>
        /// <param name="aEnum">指定枚举值</param>
        /// <param name="aEnumSet">要累加的枚举值</param>
        public static T AddEnum<T>(this object aEnum, params T[] aEnumSet)
        {
            int i = (int)aEnum;
            foreach (object a in aEnumSet)
            {
                i += (int)a;
            }
            return (T)(object)i;
        }

        /// <summary>
        /// 枚举值减法
        /// </summary>
        /// <param name="aEnum">指定枚举值</param>
        /// <param name="aEnumSet">要减去的枚举值</param>
        public static T DecEnum<T>(this object aEnum, params T[] aEnumSet)
        {
            int i = (int)aEnum;
            foreach (object a in aEnumSet)
            {
                if (aEnum.IncludeEnum(a))
                    i -= (int)a;
            }
            return (T)(object)i;
        }
    }
}
