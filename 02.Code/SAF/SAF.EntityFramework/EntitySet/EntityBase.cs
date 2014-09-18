using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using SAF.Foundation;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class EntityBase : DisposableObject, IEntityBase
    {
        /// <summary>
        /// 数据库表名
        /// </summary>
        public virtual string DbTableName { get; set; }

        private string _PrimaryKey = "Iden";
        /// <summary>
        /// 数据库表的主键
        /// </summary>
        public virtual string PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }
        /// <summary>
        /// 对应数据集的行
        /// </summary>
        public DataRowView DataRowView { get; set; }

        private EntitySetBase _EntitySetBase;
        /// <summary>
        /// 
        /// </summary>
        public EntitySetBase EntitySet
        {
            get { return _EntitySetBase; }
            internal set { this._EntitySetBase = value; }
        }

        #region 设置字段值
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        public void SetFieldValue(string fieldName, object value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                if (value == null || value == DBNull.Value)
                {
                    if (this.DataRowView.Row.Table.Columns[fieldName].AllowDBNull)
                    {
                        this.DataRowView.Row.SetField(fieldName, value);
                    }
                    else
                    {
                        var t = this.DataRowView.Row.Table.Columns[fieldName].DataType;
                        this.DataRowView.Row.SetField(fieldName, t.DefaultValue());
                    }
                }
                else
                {
                    this.DataRowView.Row.SetField(fieldName, value);
                }
                this.DataRowView.EndEdit();
                NotifyPropertyChanged(fieldName);
            }
            else
            {
                throw new FieldNotFoundException(string.Format("字段\"{0}\"未找到,请检查字段名是否正确", fieldName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                return (DataRowView == null || DataRowView.Row == null || DataRowView.Row.RowState.In(DataRowState.Deleted, DataRowState.Detached) || DataRowView.Row.IsNull(fieldName)) ? default(TResult) : DataRowView.Row.Field<TResult>(fieldName);
            }
            else
            {
                throw new FieldNotFoundException(string.Format("字段{0}未找到,请检查字段名是否正确", fieldName));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public TResult GetFieldValue<TResult>(string fieldName, TResult defaultValue)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("fieldName Is Null Or WhiteSpace.");
            if (this.FieldIsExists(fieldName))
            {
                return GetFieldValue<TResult>(fieldName);
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion


        /// <summary>
        /// 判断字段是否为空
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldIsNull(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("FieldIsNull: fieldName Is Null Or WhiteSpace.");
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldIsNull: DataRowView is null.");
            if (!EntitySet.FieldIsExists(fieldName)) return false;
            return this.DataRowView.Row.IsNull(fieldName);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Delete()
        {
            if (this.EntitySet != null)
            {
                this.EntitySet.DeleteEntity(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            if (this.EntitySet != null)
            {
                this.EntitySet.CancelEditEntity(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public EntityState EntityState
        {
            get
            {
                return EntityStateConverter.DataRowStateToEntityState(this.DataRowView.Row.RowState);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && !string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Dispose
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.DataRowView = null;
            }

            base.Dispose(disposing);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceEntity"></param>
        public void Copy(IEntityBase sourceEntity)
        {
            if (sourceEntity == null) return;

            foreach (DataColumn item in DataRowView.Row.Table.Columns)
            {
                if (!item.ColumnName.Equals("ROWSTAT", StringComparison.InvariantCultureIgnoreCase) && sourceEntity.FieldIsExists(item.ColumnName))
                {
                    this.SetFieldValue(item.ColumnName, sourceEntity.GetFieldValue<object>(item.ColumnName));
                }
            }
        }

        /// <summary>
        /// 判断字段是否存在
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldIsExists(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new NullReferenceException("FieldIsExists: fieldName Is Null Or WhiteSpace.");

            if (this.DataRowView == null || this.DataRowView.Row==null|| this.DataRowView.Row.Table == null)
                return false;
            return this.DataRowView.Row.Table.Columns.Contains(fieldName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public bool FieldAllowDBNull(string fieldName)
        {
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldAllowDBNull: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatEx(fieldName));
            return this.DataRowView.Row.Table.Columns[fieldName].AllowDBNull;
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public Type FieldDataType(string fieldName)
        {
            if (this.DataRowView == null || this.DataRowView.Row == null || this.DataRowView.Row.Table == null)
                throw new Exception("FieldDataType: DataRowView is null.");
            if (!FieldIsExists(fieldName))
                throw new FieldNotFoundException("字段\"{0}\"不存在.".FormatEx(fieldName));
            return this.DataRowView.Row.Table.Columns[fieldName].DataType;
        }
    }
}
