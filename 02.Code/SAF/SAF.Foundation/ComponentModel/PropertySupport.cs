using SAF.Foundation.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    ///  Provides support for extracting property information based on a property expression.
    /// </summary>
    public static class PropertySupport
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new System.ArgumentNullException("propertyExpression");
            }
            MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new System.ArgumentException(Resources.PropertySupport_NotMemberAccessExpression_Exception, "propertyExpression");
            }
            System.Reflection.PropertyInfo property = memberExpression.Member as System.Reflection.PropertyInfo;
            if (property == null)
            {
                throw new System.ArgumentException(Resources.PropertySupport_ExpressionNotProperty_Exception, "propertyExpression");
            }
            System.Reflection.MethodInfo getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
            {
                throw new System.ArgumentException(Resources.PropertySupport_StaticExpression_Exception, "propertyExpression");
            }
            return memberExpression.Member.Name;
        }
    }
}
