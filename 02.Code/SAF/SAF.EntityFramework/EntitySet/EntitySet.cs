using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using SAF.Foundation;
using System.Collections;
using SAF.EntityFramework.Server.Hosts;
using SAF.EntityFramework.SqlGenerators;
using SAF.EntityFramework.Server;
using System.Linq.Expressions;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    public class EntitySet<TEntity> : EntitySetBase, IEntitySet<TEntity>, IEnumerable<TEntity>
        where TEntity : Entity<TEntity>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EntitySetAddEventArgs<TEntity>> AfterAdd;

        private TEntity innerEntity = default(TEntity);

        #region 构造函数
        /// <summary>
        /// 默认连接,无SQL缓存器,无分页
        /// </summary>
        public EntitySet()
            : this(ConfigContext.DefaultConnection, null, 0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="executeCache"></param>
        public EntitySet(IExecuteCache executeCache)
            : this(ConfigContext.DefaultConnection, executeCache, ConfigContext.DefaultPageSize)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="executeCache"></param>
        public EntitySet(string connectionName, IExecuteCache executeCache)
            : this(connectionName, executeCache, ConfigContext.DefaultPageSize)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="executeCache"></param>
        /// <param name="pageSize"></param>
        public EntitySet(IExecuteCache executeCache, int pageSize)
            : this(ConfigContext.DefaultConnection, executeCache, pageSize)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="executeCache"></param>
        /// <param name="pageSize"></param>
        public EntitySet(string connectionName, IExecuteCache executeCache, int pageSize)
        {
            if (connectionName.IsEmpty())
                this.ConnectionName = ConfigContext.DefaultConnection;
            else
                this.ConnectionName = connectionName;

            this.PageSize = pageSize < 0 ? 0 : pageSize;
            this.TotalPageCount = 1;
            this.TotalRecordCount = 0;

            this.ExecuteCache = executeCache;

            this.innerEntity = new TEntity();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public EntitySet(DataTable dt)
        {
            this._table = dt;
            this.TotalPageCount = 1;
            this.TotalRecordCount = 0;
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        public override IExecuteCache ExecuteCache
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public override int UniqueId
        {
            get
            {
                return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this);
            }
        }

        private TEntity CreateEntity(DataRowView drv)
        {
            if (drv == null) return null;

            TEntity entity = new TEntity();
            entity.EntitySet = this;
            entity.DataRowView = drv;
            return entity;
        }
        /// <summary>
        /// 当前实体
        /// </summary>
        public TEntity CurrentEntity
        {
            get
            {
                DataRowView drv = null;
                if (this.BindingSource != null)
                {
                    drv = BindingSource.Current as DataRowView;
                }
                else if (this.Count > 0)
                {
                    drv = this.DefaultView[0];
                }
                if (drv == null)
                    return null;
                return CreateEntity(drv);
            }
        }

        /// <summary>
        /// 实体集的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TEntity this[int index]
        {
            get
            {
                if (this.Count <= 0) return null;
                var drv = this.DefaultView[index];
                return CreateEntity(drv);
            }
        }

        private DataRowView addNewRow;
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <returns></returns>
        public TEntity AddNew()
        {
            if (this.DataTable == null)
            {
                throw new Exception("数据集的table为null.");
            }

            if (addNewRow != null)
                addNewRow.EndEdit();

            DataRowView originalRowView = null;

            if (this.BindingSource != null)
            {
                originalRowView = this.BindingSource.Current as DataRowView;
            }

            if (this.BindingSource != null)
            {
                addNewRow = BindingSource.AddNew() as DataRowView;
            }
            else
            {
                addNewRow = this.DefaultView.AddNew();
            }

            addNewRow.EndEdit();

            TEntity currentEntity = CreateEntity(addNewRow);
            addNewRow.EndEdit();

            TEntity originalEntity = CreateEntity(originalRowView);

            FireAfterAddEvent(originalEntity, currentEntity);
            addNewRow.EndEdit();

            return currentEntity;
        }

        private void FireAfterAddEvent(TEntity originalEntity, TEntity currentEntity)
        {
            var _afterAdd = AfterAdd;
            if (_afterAdd != null)
            {
                _afterAdd(this, new EntitySetAddEventArgs<TEntity>(originalEntity, currentEntity));
            }
        }

        /// <summary>
        /// 删除当前实体
        /// </summary>
        public override void DeleteCurrent()
        {
            this.IsBusy = true;
            try
            {
                if (this.CurrentEntity != null)
                {
                    DeleteEntity(this.CurrentEntity);
                }

                foreach (var item in this.ChildEntitySets)
                {
                    item.DeleteCurrent();
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        #region 枚举接口及Base方法
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            return new EntitySetEnumerator<TEntity>(this.DefaultView);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntityBase AddNewData()
        {
            return this.AddNew();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntityBase GetCurrentEntity()
        {
            return this.CurrentEntity;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override IEntityBase GetEntity(int index)
        {
            return this[index];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator GetEntitySetBaseEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// 保存更改.如果实体集挂载了缓存器,则将更新脚本写入缓存器;否则直接更新数据库.
        /// </summary>
        public override void SaveChanges()
        {
            var list = SqlCommandObjectGenerator.GeneratorCommand(this.ConnectionName, this.innerEntity.DbTableName, this.DataTable);
            if (list.Count <= 0) return;
            try
            {
                if (this.ExecuteCache != null)
                {
                    int groupId = ExecuteCache.SystemGroupId;
                    foreach (var item in list)
                    {
                        item.GroupId = groupId;
                        ExecuteCache.Execute(item);
                    }
                }
                else
                {
                    DataPortal.ExecuteNonQueryByTransaction(this.ConnectionName, list);
                    AcceptChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override object GetCurrentKey()
        {
            if (this.CurrentEntity == null)
                return int.MinValue;

            var key = innerEntity.PrimaryKey;
            if (key.IsEmpty())
                throw new Exception("实体中未标记主键字段.");
            return this.CurrentEntity.GetFieldValue(key, int.MinValue);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasChanged
        {
            get
            {
                return this.DataTable.GetChanges() != null;
            }
        }

        /// <summary>
        /// 返回一个新的不分页的数据集
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public override IEntitySetBase Select(string commandText, params object[] parameterValues)
        {
            EntitySet<TEntity> es = new EntitySet<TEntity>();
            es.ConnectionName = this.ConnectionName;
            es.PageSize = 0;
            es.Query(commandText, parameterValues);
            return es;
        }
        /// <summary>
        /// TODO:SyncEntitySet需要测试
        /// </summary>
        /// <param name="list"></param>
        /// <param name="predicate"></param>
        public void SyncEntitySet(IEnumerable<TEntity> list, Func<TEntity, bool> predicate)
        {
            foreach (var item in list)
            {
                var obj = this.FirstOrDefault(predicate);
                if (obj == null)
                {
                    var entity = this.AddNew();
                    entity.Copy(obj);
                }
            }
            for (int i = list.Count() - 1; i >= 0; i--)
            {
                if (!list.Any(predicate))
                {
                    this[i].Delete();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EntitySet<TEntity> GetChanges()
        {
            var changes = this.DataTable.GetChanges();
            return new EntitySet<TEntity>(changes)
            {
                ConnectionName = this.ConnectionName,
                ExecuteCache = this.ExecuteCache,
                PageSize = this.PageSize
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        public EntitySet<TEntity> GetChanges(DataRowState rowStates)
        {
            var changes = this.DataTable.GetChanges(rowStates);
            return new EntitySet<TEntity>(changes)
            {
                ConnectionName = this.ConnectionName,
                ExecuteCache = this.ExecuteCache,
                PageSize = this.PageSize
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EntitySet<TEntity> GetModifiedData()
        {
            return GetChanges(DataRowState.Modified);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EntitySet<TEntity> GetAddedData()
        {
            return GetChanges(DataRowState.Added);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EntitySet<TEntity> GetDeletedData()
        {
            return GetChanges(DataRowState.Deleted);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        protected override IEntitySetBase DoGetChanges(DataRowState rowStates)
        {
            return GetChanges(rowStates);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntitySetBase DoGetModifiedData()
        {
            return GetModifiedData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntitySetBase DoGetAddedData()
        {
            return GetAddedData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntitySetBase DoGetDeletedData()
        {
            return GetDeletedData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IEntitySetBase DoGetChanges()
        {
            return GetChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLambdaExpression"></param>
        /// <returns></returns>
        public bool FieldIsExists(Expression<Func<TEntity, object>> propertyLambdaExpression)
        {
            string fieldName = EntityHelper.GetFieldName(propertyLambdaExpression);
            return this.FieldIsExists(fieldName);
        }
    }
}