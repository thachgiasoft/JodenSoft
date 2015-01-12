using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using SAF.Foundation;
using System.Threading;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 实体的基类
    /// </summary>
    /// <typeparam name="T">Type of the Entity being defined.</typeparam>
    [Serializable]
    public class Entity<T> : EntityBase, IEntity<T> where T : Entity<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public Entity()
        {
            OnInit();
        }
        /// <summary>
        /// 初始化实体
        /// </summary>
        protected virtual void OnInit()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="propertyLambdaExpression"></param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(Expression<Func<T, object>> propertyLambdaExpression)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return GetFieldValue<TResult>(fieldName);
        }

        /// <summary>
        /// 取字段值,当字段值为Null或Empty时,返回默认值
        /// </summary>
        /// <typeparam name="TResult">返回值的类型</typeparam>
        /// <param name="propertyLambdaExpression"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(Expression<Func<T, object>> propertyLambdaExpression, TResult defaultValue)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return GetFieldValue<TResult>(fieldName, defaultValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <param name="value"></param>
        public void SetFieldValue(Expression<Func<T, object>> propertyLambdaExpression, object value)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            SetFieldValue(fieldName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        protected void NotifyPropertyChanged(Expression<Func<T, object>> propertyLambdaExpression)
        {
            string propertyName = EntityHelper.GetFieldName(propertyLambdaExpression);
            NotifyPropertyChanged(propertyName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <returns></returns>
        public bool FieldIsNull(Expression<Func<T, object>> propertyLambdaExpression)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return this.FieldIsNull(fieldName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <returns></returns>
        public bool FieldIsExists(Expression<Func<T, object>> propertyLambdaExpression)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return this.FieldIsExists(fieldName);
        }
        /// <summary>
        /// 字段数据类型
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <returns></returns>
        public Type FieldDataType(Expression<Func<T, object>> propertyLambdaExpression)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return this.FieldDataType(fieldName);
        }

        public override bool VersionNumberIsSync
        {
            get
            {
                //TODO:VersionNumberIsSync
                return false;
            }
        }
    }
}
