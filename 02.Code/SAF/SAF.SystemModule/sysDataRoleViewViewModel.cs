using SAF.Framework.ViewModel;
using SAF.SystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation.ServiceModel;
using SAF.Foundation;
using SAF.EntityFramework;

namespace SAF.SystemModule
{
    public class sysDataRoleViewViewModel : SingleViewViewModel<sysDataRole, sysDataRole>
    {
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysDataRole> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsSystem = false;
            e.CurrentEntity.IsDeleted = false;
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            const string sql = @"SELECT Iden,[Name],[IsSystem] FROM [dbo].[sysDataRole] WITH(NOLOCK) WHERE [IsDeleted]=0 and {0}";
            this.IndexEntitySet.Query(sql.FormatWith(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            string sql = @"SELECT * FROM [dbo].[sysDataRole] with(nolock) WHERE [Iden]=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "角色"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "角色Id"));
        }

        protected override bool OnAllowDelete()
        {
            var canDelete = true;
            var roleName = string.Empty;
            if (this.IndexEntitySet.CurrentEntity != null)
            {
                if (this.IndexEntitySet.CurrentEntity.IsSystem)
                {
                    canDelete = false;
                }
                roleName = this.IndexEntitySet.CurrentEntity.Name;
            }
            if (!canDelete)
            {
                MessageService.ShowError("角色\"{0}\"是系统预定义的数据角色,无法删除!".FormatWith(roleName));
            }

            return canDelete;
        }

        protected override bool OnAllowEdit()
        {
            var canEdit = true;
            var roleName = string.Empty;
            if (this.IndexEntitySet.CurrentEntity != null)
            {
                if (this.IndexEntitySet.CurrentEntity.IsSystem)
                {
                    canEdit = false;
                }
                roleName = this.IndexEntitySet.CurrentEntity.Name;
            }
            if (!canEdit)
            {
                MessageService.ShowWarning("角色\"{0}\"是系统预定义的数据角色,无法编辑!".FormatWith(roleName));
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

    }
}
