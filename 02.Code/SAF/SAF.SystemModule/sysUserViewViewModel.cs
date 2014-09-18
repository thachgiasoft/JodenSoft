using SAF.Framework.ViewModel;
using SAF.SystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;

namespace SAF.SystemModule
{
    public class sysUserViewViewModel : SingleViewViewModel<SAF.SystemEntities.sysUser, SAF.SystemEntities.sysUser>
    {
        #region 角色
        private EntitySet<sysRole> roleEntitySet = null;
        public EntitySet<sysRole> RoleEntitySet
        {
            get
            {
                if (roleEntitySet == null)
                {
                    roleEntitySet = new EntitySet<sysRole>();
                    roleEntitySet.PageSize = 0;
                }
                return roleEntitySet;
            }
        }
        #endregion

        #region 用户角色
        private EntitySet<sysUserRole> userRoleEntitySet = null;
        public EntitySet<sysUserRole> UserRoleEntitySet
        {
            get
            {
                if (userRoleEntitySet == null)
                    userRoleEntitySet = new EntitySet<sysUserRole>(this.ExecuteCache, 0);

                return userRoleEntitySet;
            }
        }
        #endregion

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            const string sql = "SELECT [Iden],[UserName],[UserFullName] FROM [dbo].[sysUser] WITH(nolock)";
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            const string sql = "SELECT * FROM [dbo].[sysUser] WITH(NOLOCK) where Iden=:Iden";
            this.MainEntitySet.Query(sql, key);

            //查询用户角色
            string roleSql = @"
SELECT 
IsSelected=CAST(CASE WHEN EXISTS(SELECT TOP 1 1 FROM [dbo].[sysUserRole] a1 WHERE a1.[RoleId]=a.[Iden] AND a1.[UserId]=:UserId) THEN 1 ELSE 0 END AS BIT),
a.Iden,a.[Name],a.[Remark]
FROM [dbo].[sysRole] a WITH(NOLOCK)
WHERE a.[IsDeleted]=0";
            this.RoleEntitySet.Query(roleSql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }

        protected override void OnApplySave()
        {
            base.OnApplySave();

            if (this.RoleEntitySet.GetChanges().IsNotEmpty())
            {
                this.UserRoleEntitySet.Clear();

            }
        }

        protected override void OnEndEdit()
        {
            base.OnEndEdit();

            this.UserRoleEntitySet.EndEdit();
        }
    }
}
