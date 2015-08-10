using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SAF.Foundation
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// 程序集是否标记了指定的Attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static bool HasMarked<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            return Attribute.IsDefined(assembly, typeof(TAttribute));
        }
        /// <summary>
        /// 找到assembly的指定Attribute的第一个标记实例
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static TAttribute GetCustomAttribute<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            var attributes = assembly.GetCustomAttributes(typeof(TAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0] as TAttribute;
            }
            return null;
        }

        /// <summary>
        /// 获取所有标记了指定特性的类型
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllTypeMarked<TAttribute>(this Assembly assembly) where TAttribute : Attribute
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            return assembly.GetTypes().Where(t => t.HasMarked<TAttribute>());
        }
    }
}
