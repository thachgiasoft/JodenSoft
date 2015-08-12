using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation.Cache;

namespace SAF.Foundation
{
    /// <summary>
    /// Class CacheService
    /// </summary>
    public static class CacheService
    {
        #region 单例

        private static ICacheStrategy DefaultCacheStrategy = null;
        private static object lockObj = new object();
        private static ICacheStrategy Current
        {
            get
            {
                if (DefaultCacheStrategy == null)
                {
                    lock (lockObj)
                    {
                        if (DefaultCacheStrategy == null)
                            DefaultCacheStrategy = new DefaultCacheStrategy();
                    }
                }
                return DefaultCacheStrategy;
            }
        }
        #endregion

        /// <summary>
        /// 将object添加至缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存项</param>
        public static void AddObject(string key, object value)
        {
            Current.AddObject(key, value);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>获取成功返回TRUE,否则返回FALSE</returns>
        public static object RetriveObject(string key)
        {
            return Current.RetriveObject(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        public static void RemoveObject(string key)
        {
            Current.RemoveObject(key);
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void Clear()
        {
            Current.Clear();
        }
    }
}
