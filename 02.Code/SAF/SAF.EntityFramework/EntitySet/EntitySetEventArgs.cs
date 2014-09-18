using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 实体集的事件参数
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    public class EntitySetAddEventArgs<TEntity> : EventArgs where TEntity : Entity<TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        public TEntity OriginalEntity
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public TEntity CurrentEntity
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public EntitySetAddEventArgs()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalEntity"></param>
        /// <param name="currentEntity"></param>
        public EntitySetAddEventArgs(TEntity originalEntity, TEntity currentEntity)
        {
            OriginalEntity = originalEntity;
            CurrentEntity = currentEntity;
        }
    }
}
