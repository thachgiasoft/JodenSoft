using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace SAF.Foundation.Reflection
{
    /// <summary>
    /// Provides methods to dynamically find and call methods.
    /// </summary>
    public static class MethodCaller
    {
        private const BindingFlags ctorFlags
            = BindingFlags.Instance
            | BindingFlags.Public
            | BindingFlags.NonPublic
            ;

        #region Create Instance

        /// <summary>
        /// Uses reflection to create an object using its 
        /// default constructor.
        /// </summary>
        /// <param name="objectType">Type of object to create.</param>
        public static object CreateInstance(Type objectType)
        {
            var ctor = GetCachedConstructor(objectType);
            if (ctor == null)
                throw new NotImplementedException("Default Constructor not implemented.");
            return ctor.Invoke();
        }

        #endregion

        #region Dynamic Constructor Cache

        private static Dictionary<Type, DynamicCtorDelegate> _ctorCache = new Dictionary<Type, DynamicCtorDelegate>();

        private static DynamicCtorDelegate GetCachedConstructor(Type objectType)
        {
            DynamicCtorDelegate result = null;
            if (!_ctorCache.TryGetValue(objectType, out result))
            {
                lock (_ctorCache)
                {
                    if (!_ctorCache.TryGetValue(objectType, out result))
                    {

                        ConstructorInfo info = objectType.GetConstructor(ctorFlags, null, Type.EmptyTypes, null);

                        if (info == null)
                            throw new NotSupportedException(string.Format(
                              CultureInfo.CurrentCulture,
                              "Cannot create instance of Type '{0}'. No public parameterless constructor found.",
                              objectType));

                        result = DynamicMethodHandlerFactory.CreateConstructor(info);
                        _ctorCache.Add(objectType, result);
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
