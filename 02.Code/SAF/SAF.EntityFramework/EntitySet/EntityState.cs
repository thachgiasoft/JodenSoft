using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    /// <summary>
    /// 实体的状态
    /// </summary>
    [Flags]
    public enum EntityState
    {
        /// <summary>
        /// 无状态
        /// </summary>
        None = 1,
        /// <summary>
        /// 未改变
        /// </summary>
        Unchanged = 2,
        /// <summary>
        /// 增加
        /// </summary>
        Added = 4,
        /// <summary>
        /// 删除
        /// </summary>
        Deleted = 8,
        /// <summary>
        /// 修改
        /// </summary>
        Modified = 16
    }

    /// <summary>
    /// 实体状态转换类
    /// </summary>
    public static class EntityStateConverter
    {
        public static EntityState DataRowStateToEntityState(DataRowState state)
        {
            switch (state)
            {
                case DataRowState.Added:
                    return EntityState.Added;
                case DataRowState.Deleted:
                    return EntityState.Deleted;
                case DataRowState.Detached:
                    return EntityState.None;
                case DataRowState.Modified:
                    return EntityState.Modified;
                case DataRowState.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.None;
            }
        }

        public static DataRowState EntityStateToDataRowState(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return DataRowState.Added;
                case EntityState.Deleted:
                    return DataRowState.Deleted;
                case EntityState.Modified:
                    return DataRowState.Modified;
                case EntityState.Unchanged:
                    return DataRowState.Unchanged;
                default:
                    return DataRowState.Unchanged;
            }
        }
    }

}
