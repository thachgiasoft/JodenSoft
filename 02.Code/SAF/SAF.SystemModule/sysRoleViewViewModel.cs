using SAF.Framework.ViewModel;
using SAF.SystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using SAF.Framework.Controls;
using SAF.Foundation.ServiceModel;
using SAF.EntityFramework;
using DevExpress.XtraTreeList.Nodes;
using SAF.Framework.Entity;

namespace SAF.SystemModule
{
    public class sysRoleViewViewModel : SingleViewViewModel<sysRole, sysRole>
    {
        private EntitySet<sysRoleMenu> _RoleMenuEntitySet;
        public EntitySet<sysRoleMenu> RoleMenuEntitySet
        {
            get
            {
                if (_RoleMenuEntitySet == null)
                    _RoleMenuEntitySet = new EntitySet<sysRoleMenu>(this.ExecuteCache, 0);
                return _RoleMenuEntitySet;
            }
        }

        private EntitySet<sysMenu> _MenuEntitySet;
        public EntitySet<sysMenu> MenuEntitySet
        {
            get
            {
                if (_MenuEntitySet == null)
                {
                    _MenuEntitySet = new EntitySet<sysMenu>();
                    _MenuEntitySet.PageSize = 0;
                    _MenuEntitySet.IsReadOnly = true;
                }
                return _MenuEntitySet;
            }
        }

        protected override void OnInit()
        {
            base.OnInit();

            const string sql = @"
SELECT Iden,[Name],[ParentId] ,MenuType
FROM [dbo].[sysMenu] WITH(NOLOCK)
ORDER BY [ParentId],[MenuOrder] ";
            MenuEntitySet.Query(sql);
        }

        protected override void OnQuery(string condition, object[] parameterValues)
        {
            base.OnQuery(condition, parameterValues);

            const string sql = @"SELECT Iden,[Name], [IsSystem], [IsAdministrator] FROM [dbo].[sysRole] WITH(nolock) WHERE [IsDeleted]=0 AND {0}";
            this.IndexEntitySet.Query(sql.FormatWith(condition));
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            const string sql = "SELECT * FROM [dbo].[sysRole] WITH(nolock) WHERE Iden=:Iden";
            this.MainEntitySet.Query(sql, key);

            const string sqlMenu = @"
SELECT a.*
FROM dbo.sysRoleMenu a WITH(NOLOCK)
JOIN [dbo].[sysMenu] b WITH(NOLOCK) ON a.[MenuId]=b.[Iden]
WHERE a.[RoleId]=:Iden AND B.MenuType>0";
            RoleMenuEntitySet.Query(sqlMenu, key);

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "角色名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "角色Id"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.RoleMenuEntitySet.AfterAdd += RoleMenuEntitySet_AfterAdd;
        }

        void RoleMenuEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysRoleMenu> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.RoleId = this.MainEntitySet.CurrentEntity.Iden;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysRole> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsDeleted = false;
            e.CurrentEntity.IsSystem = false;
            e.CurrentEntity.IsAdministrator = false;
        }

        protected override bool OnAllowDelete()
        {
            var canDelete = true;
            var roleName = string.Empty;
            if (this.MainEntitySet.CurrentEntity != null)
            {
                if (this.MainEntitySet.CurrentEntity.IsSystem)
                {
                    canDelete = false;
                }
                roleName = this.MainEntitySet.CurrentEntity.Name;
            }
            if (!canDelete)
            {
                MessageService.ShowError("角色\"{0}\"是系统预定义的角色,无法删除!".FormatWith(roleName));
            }

            return canDelete;
        }

        protected override bool OnAllowEdit()
        {
            var canEdit = true;
            var roleName = string.Empty;
            if (this.MainEntitySet.CurrentEntity != null)
            {
                if (this.MainEntitySet.CurrentEntity.IsSystem)
                {
                    canEdit = false;
                }
                roleName = this.MainEntitySet.CurrentEntity.Name;
            }
            if (!canEdit)
            {
                MessageService.ShowWarning("角色\"{0}\"是系统预定义的角色,无法编辑!".FormatWith(roleName));
            }

            return canEdit;
        }

        protected override void OnDelete()
        {
            if (this.IndexEntitySet.CurrentEntity != null)
                this.IndexEntitySet.DeleteCurrent();

            if (this.MainEntitySet.CurrentEntity != null)
                this.MainEntitySet.CurrentEntity.IsDeleted = true;
        }

        internal void SaveCheckNodes(List<DevExpress.XtraTreeList.Nodes.TreeListNode> list)
        {
            this.RoleMenuEntitySet.Clear();
            this.RoleMenuEntitySet.AcceptChanges();
            this.ExecuteCache.Execute(0, "delete sysRoleMenu where RoleId=:RoleId", this.MainEntitySet.CurrentKey);
            foreach (TreeListNode item in list)
            {
                var menuType = item.GetValue("MenuType");
                if (menuType != null && Convert.ToInt32(menuType) > 0)
                {
                    var entity = this.RoleMenuEntitySet.AddNew();
                    entity.MenuId = Convert.ToInt32(item.GetValue("Iden"));
                }
            }
        }

        protected override void OnApplySave()
        {
            base.OnApplySave();
            this.RoleMenuEntitySet.SaveChanges();
        }
    }
}
