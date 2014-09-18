using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SAF.Foundation
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 返回当前对象的string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringEx(this object obj)
        {
            return (obj == null || obj == DBNull.Value) ? string.Empty : obj.ToString();
        }
        /// <summary>
        /// 判断对象是否为NULL,string.Empty或空格,或元素个数为0
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object obj)
        {
            if (obj == null || obj == DBNull.Value) return true;

            if (obj is string)
            {
                return string.IsNullOrWhiteSpace(obj.ToStringEx());
            }

            if (obj is IEnumerable)
            {
                var list = obj as IEnumerable;
                IEnumerator i = list.GetEnumerator();
                if (!i.MoveNext())
                    return true;
                else
                    return false;
            }
            return false;

        }
        /// <summary>
        /// 判断对象是否非空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this object obj)
        {
            return !obj.IsEmpty();
        }

        /// <summary>
        /// Converts the input string to specified type.
        /// </summary>
        /// <typeparam name="T">The target type to convert.</typeparam>
        /// <param name="s">An input string.</param>
        /// <returns>If convertation successfull, returns the converted value with required type; otherwise returns default for specified type.</returns>
        public static T To<T>(this object obj)
        {
            return To<T>(obj, default(T));
        }

        /// <summary>
        /// Converts the input string to specified type.
        /// </summary>
        /// <typeparam name="T">The target type to convert.</typeparam>
        /// <param name="s">An input object.</param>
        /// <param name="defaultValue">The default value to return is convertation fails.</param>
        /// <returns>If convertation successfull, returns the converted value with required type; otherwise returns default value.</returns>
        public static T To<T>(this object obj, T defaultValue)
        {
            string s = obj.ToStringEx();
            T result = defaultValue;
            try
            {
                if (!s.IsEmpty())
                {
                    Type t = typeof(T);
                    Type nut = Nullable.GetUnderlyingType(t);

                    if (t.IsEnum || (nut != null && nut.IsEnum))
                    {
                        result = (T)Enum.Parse(nut != null ? nut : t, s, true);
                    }
                    else
                    {
                        TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                        if (tc.IsValid(s))
                        {
                            result = (T)tc.ConvertFromString(s);
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 判断对象是否在值列表中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, params T[] c)
        {
            if (t.IsEmpty()) return false;
            if (c.IsEmpty() || c.Length <= 0) return false;

            return c.Any(i => i.Equals(t));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="bIncludeSubClass"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetProperties<T>(this object obj, bool bIncludeSubClass)
        {
            Type t = typeof(T);
            return
                from PropertyInfo x in obj.GetType().GetProperties()
                where x.PropertyType == t || (bIncludeSubClass && x.PropertyType.IsSubclassOf(t))
                select (T)((object)x.GetValue(obj, null));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aObject"></param>
        /// <param name="sPropertyName"></param>
        /// <returns></returns>
        public static bool HasProperty(this object aObject, string sPropertyName)
        {
            return aObject.GetType().GetProperties().Any((PropertyInfo x) => x.Name == sPropertyName) || aObject.GetType().GetFields().Any((FieldInfo x) => x.Name == sPropertyName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aObject"></param>
        /// <param name="sPropertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(this object aObject, string sPropertyName)
        {
            PropertyInfo propertyInfo = aObject.GetType().GetProperties().FirstOrDefault((PropertyInfo x) => x.Name == sPropertyName);
            object value;
            if (propertyInfo != null)
            {
                value = propertyInfo.GetValue(aObject, null);
            }
            else
            {
                FieldInfo fieldInfo = aObject.GetType().GetFields().FirstOrDefault((FieldInfo x) => x.Name == sPropertyName);
                if (!(fieldInfo != null))
                {
                    throw new ArgumentNullException(sPropertyName, string.Format("属性[{0}]不存在", sPropertyName));
                }
                value = fieldInfo.GetValue(aObject);
            }
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aObject"></param>
        /// <param name="sPropertyName"></param>
        /// <param name="aPropertyValue"></param>
        public static void SetPropertyValue(this object aObject, string sPropertyName, object aPropertyValue)
        {
            PropertyInfo propertyInfo = aObject.GetType().GetProperties().FirstOrDefault((PropertyInfo x) => x.Name == sPropertyName);
            if (propertyInfo != null)
            {
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(aObject, aPropertyValue, null);
                }
            }
            else
            {
                FieldInfo fieldInfo = aObject.GetType().GetFields().FirstOrDefault((FieldInfo x) => x.Name == sPropertyName);
                if (!(fieldInfo != null))
                {
                    throw new ArgumentNullException(sPropertyName, string.Format("属性[{0}]不存在", sPropertyName));
                }
                fieldInfo.SetValue(aObject, aPropertyValue);
            }
        }
    }
}
