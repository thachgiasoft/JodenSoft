using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using myPortal.IDAL;
using myPortal.Cache;

namespace myPortal.DALFactory
{
    /// <summary>
    /// 数据访问类创建工厂
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];

        private DataAccess() { }

        /// <summary>
        /// 使用缓存创建数据访问对象
        /// </summary>
        /// <param name="AssemblyPath"></param>
        /// <param name="classNamespace"></param>
        /// <returns></returns>
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = CacheService.Current.RetriveObject("DALFactory_" + classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    CacheService.Current.AddObject("DALFactory_" + classNamespace, objType);
                }
                catch
                {
                    throw;
                }
            }
            return objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IDbServer CreateDbServer()
        {
            string classNamespace = AssemblyPath + ".DbServer";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IDbServer)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IIdenGenerator CreateIdenGenerator()
        {
            string classNamespace = AssemblyPath + ".IdenGenerator";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IIdenGenerator)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IsaBulletin CreatesaBulletin()
        {
            string classNamespace = AssemblyPath + ".saBulletin";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IsaBulletin)objType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IsaBulletinType CreatesaBulletinType()
        {
            string classNamespace = AssemblyPath + ".saBulletinType";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IsaBulletinType)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IsaMenu CreatesaMenu()
        {
            string classNamespace = AssemblyPath + ".saMenu";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IsaMenu)objType;
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IsaRole CreatesaRole()
        {
            string classNamespace = AssemblyPath + ".saRole";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IsaRole)objType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static myPortal.IDAL.IsaUser CreatesaUser()
        {
            string classNamespace = AssemblyPath + ".saUser";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (myPortal.IDAL.IsaUser)objType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IsaUserRole CreatesaUserRole()
        {
            string classNamespace = AssemblyPath + ".saUserRole";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (IsaUserRole)objType;
        }

    }
}
