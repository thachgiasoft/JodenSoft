using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// 对象容器（对象管理器）
    /// </summary>
    public class ObjectContainer : IObjectContainer
    {
        private Dictionary<string, object> _Dic = null;

        public ObjectContainer()
        {
            _Dic = new Dictionary<string, object>();
        }

        protected string UnionName(string fullTypeName, string tag)
        {
            if (string.IsNullOrWhiteSpace(fullTypeName))
                throw new ArgumentNullException("fullTypeName");
            return fullTypeName + (string.IsNullOrWhiteSpace(tag) ? string.Empty : tag);
        }
        /// <summary>
        /// 返回容器内一个对象的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>()
        {
            return Get<T>(null);
        }
        /// <summary>
        /// 返回容器内一个对象的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        public T Get<T>(string tag)
        {
            string name = UnionName(typeof(T).ToString(), tag);
            if (this._Dic.ContainsKey(name))
            {
                return (T)_Dic[name];
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// 判断一个对象是否存在于容器内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsRegistered<T>()
        {
            return IsRegistered<T>(string.Empty);
        }
        /// <summary>
        /// 判断一个对象是否存在于容器内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool IsRegistered<T>(string tag)
        {
            return _Dic.ContainsKey(UnionName(typeof(T).ToString(), tag));
        }
        /// <summary>
        /// 将一个对象送入容器内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Register<T>(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("注册的对象不能为空!");
            if (IsRegistered<T>())
            {
                Remove<T>();
            }
            this._Dic.Add(UnionName(typeof(T).ToString(), null), obj);
        }
        /// <summary>
        /// 将一个对象送入容器内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="tag"></param>
        public void Register<T>(object obj, string tag)
        {
            if (obj == null)
                throw new ArgumentNullException("注册的对象obj不能为空!");
            if (IsRegistered<T>())
            {
                Remove<T>();
            }
            this._Dic.Add(UnionName(typeof(T).ToString(), null), obj);
        }
        /// <summary>
        /// 从容器内移除指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Remove<T>()
        {
            Remove<T>(null);
        }
        /// <summary>
        /// 从容器内移除指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        public void Remove<T>(string tag)
        {
            if (IsRegistered<T>(tag))
            {
                _Dic.Remove(UnionName(typeof(T).ToString(), tag));
            }
        }
        /// <summary>
        /// 移除所有对象
        /// </summary>
        public void RemoveAll()
        {
            this._Dic.Clear();
        }
    }
}
