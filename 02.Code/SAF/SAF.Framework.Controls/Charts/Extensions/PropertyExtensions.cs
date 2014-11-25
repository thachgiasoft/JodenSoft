using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace SAF.Framework.Controls.Charts
{
    /// <summary>
    /// Property的扩展方法
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// 获取Property的字段名称
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string PropertyName<TObject, TProperty>(this TObject helper, Expression<Func<TObject, TProperty>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            else
            {
                throw new NotImplementedException("PropertyExtensions.GetPropertyName内部expression.Body为空！");
            }
        }
    }
}
