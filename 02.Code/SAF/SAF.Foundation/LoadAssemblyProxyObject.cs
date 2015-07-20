using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SAF.Foundation.MetaAttributes;
using System.IO;

namespace SAF.Foundation
{
    /// <summary>
    /// 需要先执行LoadAssembly
    /// </summary>
    public class LoadAssemblyProxyObject : MarshalByRefObject
    {
        private Assembly assembly = null;

        public bool LoadAssembly(string fileName)
        {
            if (!File.Exists(fileName))
            {
                assembly = null;
                return false;
            }

            try
            {
                this.assembly = Assembly.LoadFrom(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Type> GetAllTypeMarked<TAttribute>() where TAttribute : Attribute
        {
            if (assembly == null)
                return new List<Type>();

            return assembly.GetAllTypeMarked<TAttribute>().ToList();
        }

        public Type GetType(string name)
        {
            return assembly.GetType(name, false, true);
        }

        public bool IsComposeModule()
        {
            try
            {
                if (assembly != null && assembly.HasMarked<IsComposeModuleAttribute>())
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string AssemblyFileName
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }

        public static string ProxyObjectTypeName
        {
            get
            {
                return "SAF.Foundation.LoadAssemblyProxyObject";
            }
        }
    }
}
