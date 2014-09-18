#region CopyRight (C) 2013 上海环思信息技术有限公司 版权所有。
//
// 文 件 名：ICacheStrategy.cs
// 功能描述：
// 
// 创建标识：wanglj 2013/8/21 9:21:02
// 
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//
#endregion

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
