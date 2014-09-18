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
                    ResourceManager mgr = new ResourceManager(attributes[0].ResourceType);
                    string str = mgr.GetString(attributes[0].Name);
                    list.Add(new KeyValuePair<T, string>(v, string.IsNullOrWhiteSpace(str) ? enumName : str.Trim()));
                }
            }
            EnumDic.Add(enumType.GetType(), list);
            return list;
        }


    }
}
