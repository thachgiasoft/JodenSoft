using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Data;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 实体类接口
    /// </summary>
    public interface IEntity<T> : IEntityBase
    {
       /// <summary>
        /// 取字段值
       /// </summary>
       /// <typeparam name="TResult"></typeparam>
       /// <param name="propertyLambdaExpression"></param>
       /// <returns></returns>
        TResult GetFieldValue<TResult>(Expression<Func<T, object>> propertyLambdaExpression);
        /// <summary>
        /// 取字段值,当字段值为Null或Empty时,返回默认值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="propertyLambdaExpression"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        TResult GetFieldValue<TResult>(Expression<Func<T, object>> propertyLambdaExpression, TResult defaultValue);
        /// <summary>
        /// 给字段赋值
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <param name="value"></param>
        void SetFieldValue(Expression<Func<T, object>> propertyLambdaExpression, object value);

    }
}
