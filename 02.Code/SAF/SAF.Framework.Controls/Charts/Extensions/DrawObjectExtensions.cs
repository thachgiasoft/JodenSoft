using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SAF.Framework.Controls.Charts
{
    public static class DrawObjectExtensions
    {
        public static string SerializationName<T, TProperty>(this T drawObject, Expression<Func<T, TProperty>> expression, int orderNumber) where T : DrawObject
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                string propertyName = memberExpression.Member.Name;
                return String.Format(CultureInfo.InvariantCulture, "{0}{1}", propertyName, orderNumber);
            }
            else
                throw new NotImplementedException();
        }
    }
}
