using SAF.Framework.ViewModel;
using SAF.SystemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;
using DevExpress.XtraTreeList.Nodes;
using SAF.Foundation.ServiceModel;
using SAF.Foundation.Security;

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

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            string sql = "SELECT [Iden],[UserName],[UserFullName] FROM [dbo].[sysUser] WITH(nolock) where ({0})".FormatEx(sCondition);
            this.IndexEntitySet.Query(sql);
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            const string sql = "SELECT * FROM [dbo].[sysUser] WITH(NOLOCK) where Iden=:Iden";
            this.MainEntitySet.Query(sql, key);

            //查询用户角色
            string roleSql = @"
SELECT a.Iden,a.[Name],a.[Remark],ParentId=0
FROM [dbo].[sysRole] a WITH(NOLOCK)
WHERE a.[IsDeleted]=0
order by Iden";
            this.RoleEntitySet.Query(roleSql);

            UserRoleEntitySet.Query("SELECT * FROM dbo.sysUserRole with(nolock) WHERE UserId=:UserId", key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("UserName", "用户名"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("UserFullName", "姓名"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "ID"));
        }

        protected override void OnApplySave()
        {
            base.OnApplySave();

            this.UserRoleEntitySet.SaveChanges();
        }

        protected override void OnEndEdit()
        {
            base.OnEndEdit();

            this.UserRoleEntitySet.EndEdit();
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<SystemEntities.sysUser> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.IsSystem = false;
            e.CurrentEntity.IsActive = true;
            e.CurrentEntity.IsDeleted = false;
            e.CurrentEntity.Password = ConfigContext.DefaultPassword;
        }

        internal void SaveRoles(List<DevExpress.XtraTreeList.Nodes.TreeListNode> list)
        {
            this.UserRoleEntitySet.Clear();
            this.UserRoleEntitySet.AcceptChanges();
            this.UserRoleEntitySet.ExecuteCache.Execute(0, "delete sysUserRole where UserId=:UserId", this.MainEntitySet.CurrentKey);
            foreach (TreeListNode item in list)
            {
                if (item.GetValue("Iden").IsNotEmpty())
                {
                    var entity = this.UserRoleEntitySet.AddNew();
                    entity.Iden = IdenGenerator.NewIden(entity.DbTableName);
                    entity.UserId = this.MainEntitySet.CurrentEntity.Iden;
                    entity.RoleId = Convert.ToInt32(item.GetValue("Iden"));
                }
            }
        }

        protected override void OnDelete()
        {
            if (this.IndexEntitySet.CurrentEntity != null)
                this.IndexEntitySet.DeleteCurrent();

            if (this.MainEntitySet.CurrentEntity != null)
                this.MainEntitySet.CurrentEntity.IsDeleted = true;
        }

        protected override bool OnAllowDelete()
        {
            var canDelete = true;
            var name = string.Empty;
            if (this.MainEntitySet.CurrentEntity != null)
            {
                if (this.MainEntitySet.CurrentEntity.IsSystem)
                {
                    canDelete = false;
                }
                name = this.MainEntitySet.CurrentEntity.UserName;
            }
            if (!canDelete)
            {
                MessageService.ShowError("用户\"{0}\"是系统预定义的用户,无法删除!".FormatEx(name));
            }

            return canDelete;
        }

        protected override bool OnAllowEdit()
        {
            var canEdit = true;
            var name = string.Empty;
            if (this.MainEntitySet.CurrentEntity != null)
            {
                if (this.MainEntitySet.CurrentEntity.IsSystem)
                {
                    canEdit = false;
                }
                name = this.MainEntitySet.CurrentEntity.UserName;
            }
            if (!canEdit)
            {
                MessageService.ShowWarning("用户\"{0}\"是系统预定义的用户,无法编辑!".FormatEx(name));
            }

            return canEdit;
        }

        internal void ResetPassword()
        {
            if (this.MainEntitySet.CurrentEntity != null)
            {
                this.MainEntitySet.CurrentEntity.Password = ConfigContext.DefaultPassword;
                this.MainEntitySet.SaveChanges();
                if (ExecuteCache.Count > 0)
                {
                    DataPortal.ExecuteNonQueryByTransaction(this.ConnectionName, ExecuteCache.ToList());
                }
                this.MainEntitySet.AcceptChanges();
            }
        }
    }
}
