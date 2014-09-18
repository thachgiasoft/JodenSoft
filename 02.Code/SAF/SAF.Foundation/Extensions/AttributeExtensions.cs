using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SAF.Foundation
{
    /// <summary>
    /// Attribute Extensions
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// 是否标记了指定的Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static bool HasMarked<T>(this MemberInfo member) where T : Attribute
        {
            if (member == null) throw new ArgumentNullException("member");
            return Attribute.IsDefined(member, typeof(T));
        }
        /// <summary>
        /// 找到member的指定Attribute的第一个标记实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static T GetCustomAttribute<T>(this MemberInfo member) where T : Attribute
        {
            if (member == null) throw new ArgumentNullException("member");

            var attributes = member.GetCustomAttributes(typeof(T), false);
            if (attributes.Length > 0)
            {
                return attributes[0] as T;
            }
            return null;
        }
        /// <summary>
        /// 获取所有标记了指定特性的属性
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetAllPropertyMarked<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return type.GetProperties().Where(p => p.HasMarked<TAttribute>());
        }
    }
}
