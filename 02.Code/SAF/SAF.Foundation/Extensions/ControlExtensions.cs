using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Foundation
{
    public static class ControlExtensions
    {
        /// <summary>
        /// 查找第一个符合要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static T FindChild<T>(this Control parent) where T : Control
        {
            return parent.FindChild<T>(child => true);
        }
        /// <summary>
        /// 查找第一个符合要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FindChild<T>(this Control parent, Func<T, bool> predicate) where T : Control
        {
            return parent.FindChildren<T>(predicate).First();
        }
        /// <summary>
        /// 测试是否可以找到符合要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="foundChild"></param>
        /// <returns></returns>
        public static bool TryFindChild<T>(this Control parent, out T foundChild) where T : Control
        {
            return parent.TryFindChild<T>(child => true, out foundChild);
        }
        /// <summary>
        /// 测试是否可以找到符合要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="predicate"></param>
        /// <param name="foundChild"></param>
        /// <returns></returns>
        public static bool TryFindChild<T>(this Control parent, Func<T, bool> predicate, out T foundChild) where T : Control
        {
            foundChild = null;
            var results = parent.FindChildren<T>(predicate);
            if (results.Count() == 0)
                return false;

            foundChild = results.First();
            return true;
        }
        /// <summary>
        /// 查找符合要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindChildren<T>(this Control parent, Func<T, bool> predicate)
            where T : Control
        {
            var children = new List<Control>();

            var result = new List<T>();

            foreach (Control item in parent.Controls)
            {
                children.Add(item);
            }

            foreach (var child in children)
            {
                var typedChild = child as T;
                if ((typedChild != null) && predicate.Invoke(typedChild))
                {
                    if (!result.Contains(typedChild))
                        result.Add(typedChild);
                }
                //递归
                var tempList = child.FindChildren(predicate);
                foreach (var foundDescendant in tempList)
                {
                    if (!result.Contains(foundDescendant))
                        result.Add(foundDescendant);
                }
            }
            return result;
        }
        /// <summary>
        /// 查找符合所有要求的项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindChildren<T>(this Control parent) where T : Control
        {
            return parent.FindChildren<T>(p => true);
        }
    }
}
