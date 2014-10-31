using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntityBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        string DbTableName { get; }
        /// <summary>
        /// 主键名称
        /// </summary>
        string PrimaryKeyName { get; }
        /// <summary>
        /// 数据权限
        /// </summary>
        BillDataRight BillDataRight { get; }

        /// <summary>
        /// 
        /// </summary>
        DataRowView DataRowView { get; set; }
        /// <summary>
        /// 拥有此实体的实体集
        /// </summary>
        EntitySetBase EntitySet { get; }
        /// <summary>
        /// 实体状态
        /// </summary>
        DataRowState EntityState { get; }
        /// <summary>
        /// 给字段赋值
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        void SetFieldValue(string fieldName, object value);
        /// <summary>
        /// 取字段值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        TResult GetFieldValue<TResult>(string fieldName);
        /// <summary>
        /// 取字段值,当字段值为Null或Empty时,返回默认值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        TResult GetFieldValue<TResult>(string fieldName, TResult defaultValue);

        /// <summary>
        /// 判断字段是否为空
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool FieldIsNull(string fieldName);
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        void Delete();
        /// <summary>
        /// 取消
        /// </summary>
        void Cancel();
        /// <summary>
        /// 复制
        /// </summary>
        void Copy(IEntityBase sourceEntity);

        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool FieldIsExists(string fieldName);
        /// <summary>
        /// 字段是否可为空
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool FieldAllowDBNull(string fieldName);
        /// <summary>
        /// 字段的数据类型
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        Type FieldDataType(string fieldName);

    }
}
