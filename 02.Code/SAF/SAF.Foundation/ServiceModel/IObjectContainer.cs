using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    /// <summary>
    /// 对象容器接口
    /// </summary>
    public interface IObjectContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        T Get<T>(string tag);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsRegistered<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        bool IsRegistered<T>(string tag);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aItem"></param>
        void Register<T>(object aItem);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aItem"></param>
        /// <param name="tag"></param>
        void Register<T>(object aItem, string tag);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        void Remove<T>(string tag);
        /// <summary>
        /// 
        /// </summary>
        void RemoveAll();
    }
}
