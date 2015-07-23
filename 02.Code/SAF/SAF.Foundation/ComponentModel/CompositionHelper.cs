using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Diagnostics;
using SAF.Foundation;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 全局MEF Composition Container
    /// </summary>
    public class CompositionHelper
    {
        private CompositionContainer _CompositionContainer;
        private AggregateCatalog _AggregateCatalog = new AggregateCatalog();

        private CompositionHelper()
        {
            _CompositionContainer = new CompositionContainer(_AggregateCatalog);

        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="fileName"></param>
        public void AddFile(string fileName)
        {
            _AggregateCatalog.Catalogs.Add(new AssemblyCatalog(fileName));
        }
        /// <summary>
        /// 添加程序集
        /// </summary>
        /// <param name="assembly"></param>
        public void AddAssembly(Assembly assembly)
        {
            _AggregateCatalog.Catalogs.Add(new AssemblyCatalog(assembly));
        }

        #region Singleton

        private static object lockObj = new object();
        private static CompositionHelper _CompositionHelper = null;

        public static CompositionHelper Current
        {
            get
            {
                if (_CompositionHelper == null)
                {
                    lock (lockObj)
                    {
                        if (_CompositionHelper == null)
                            _CompositionHelper = new CompositionHelper();
                    }
                }
                return _CompositionHelper;
            }
        }

        #endregion

        /// <summary>
        /// 从特性化对象的数组创建可组合部件，并在指定的组合容器中组合这些部件。
        /// </summary>
        /// <param name="attributedParts">要组合的特性化对象的数组。</param>
        public void ComposeParts(params object[] attributedParts)
        {
            _CompositionContainer.ComposeParts(attributedParts);
        }
        /// <summary>
        /// 获取具有从指定的类型参数派生的协定名称的所有已导出对象。
        /// </summary>
        /// <typeparam name="T">要返回的已导出对象的类型。协定名称也派生自此类型参数。</typeparam>
        /// <returns>如果找到匹配项，则为具有从指定的类型参数派生的协定名称的已导出对象；
        /// <para>否则为空的对象。</para>
        /// </returns>
        public IEnumerable<T> GetExportedValues<T>()
        {
            try
            {
                return _CompositionContainer.GetExportedValues<T>();
            }
            catch (Exception ex)
            {
                throw new CoreException(string.Format("无法获取指定类型的已导出对象"), ex);
            }
        }
        /// <summary>
        /// 返回具有从指定的类型参数派生的协定名称的已导出对象。如果不是正好有一个匹配的已导出对象，则将引发异常。
        /// </summary>
        /// <typeparam name="T">要返回的已导出对象的类型。</typeparam>
        /// <param name="contractName">要返回的已导出对象的协定名称，或者为 null 或空字符串 ("") 以使用默认的协定名称。</param>
        /// <returns>具有指定的协定名称的已导出对象。</returns>
        public T GetExportedValue<T>(string contractName)
        {
            try
            {
                return _CompositionContainer.GetExportedValue<T>(contractName);
            }
            catch (Exception ex)
            {
                throw new CoreException(string.Format("未找到具有指定的协定名称为{0}的已导出对象。", contractName), ex);
            }
        }
    }
}
