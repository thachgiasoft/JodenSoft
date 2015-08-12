using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.Cache
{
    /// <summary>
    /// 缓存策略接口
    /// </summary>
    public interface ICacheStrategy
    {
        /// <summary>
        /// 将object添加至缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存项</param>
        void AddObject(string key, object value);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>获取成功返回TRUE,否则返回FALSE</returns>
        object RetriveObject(string key);
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        void RemoveObject(string key);
        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void Clear();
    }
}
