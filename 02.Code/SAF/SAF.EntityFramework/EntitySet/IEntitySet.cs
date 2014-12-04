using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Data.Common;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntitySet<TEntity> : IEntitySetBase
        where TEntity : Entity<TEntity>, new()
    {
        /// <summary>
        /// 实体集当前实体
        /// </summary>
        new TEntity CurrentEntity { get; }
        /// <summary>
        /// 实体集的索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        new TEntity this[int index] { get; }
        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        TEntity AddNew();
        /// <summary>
        /// 新增之后发生。
        /// </summary>
        event EventHandler<EntitySetAddEventArgs<TEntity>> AfterAdd;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new EntitySet<TEntity> GetChanges();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowStates"></param>
        /// <returns></returns>
        new EntitySet<TEntity> GetChanges(DataRowState rowStates);
    }
}
