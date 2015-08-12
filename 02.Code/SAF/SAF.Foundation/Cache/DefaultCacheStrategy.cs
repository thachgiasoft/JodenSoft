using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using SAF.Foundation.Properties;
using System.Threading;

namespace SAF.Foundation.Cache
{
    /// <summary>
    /// Class DefaultCacheStrategy
    /// </summary>
    public class DefaultCacheStrategy : ICacheStrategy
    {
        private HybridDictionary CacheDic = new HybridDictionary();

        private static void ValidateKey(string key)
        {
            if (key.IsEmpty())
            {
                throw new ArgumentException(Resources.Cache_EmptyParameterName_Exception, "key");
            }
        }
        /// <summary>
        /// 将object添加至缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存项</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddObject(string key, object value)
        {
            DefaultCacheStrategy.ValidateKey(key);
            object syncRoot;
            Monitor.Enter(syncRoot = this.CacheDic.SyncRoot);
            try
            {
                if (CacheDic.Contains(key))
                {
                    CacheDic[key] = value;
                }
                else
                {
                    CacheDic.Add(key, value);
                }
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns>获取成功返回TRUE,否则返回FALSE</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object RetriveObject(string key)
        {
            DefaultCacheStrategy.ValidateKey(key);
            object syncRoot;
            Monitor.Enter(syncRoot = this.CacheDic.SyncRoot);
            try
            {
                if (CacheDic.Contains(key))
                {
                    return CacheDic[key];
                }
                return null;
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveObject(string key)
        {
            DefaultCacheStrategy.ValidateKey(key);
            object syncRoot;
            Monitor.Enter(syncRoot = this.CacheDic.SyncRoot);
            try
            {
                if (CacheDic.Contains(key))
                {
                    CacheDic.Remove(key);
                }
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Clear()
        {
            this.CacheDic.Clear();
            this.CacheDic = new HybridDictionary();
        }
    }
}
