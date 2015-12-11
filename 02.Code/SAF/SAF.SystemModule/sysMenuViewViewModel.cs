using SAF.Framework.ViewModel;
using SAF.SystemEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Framework.Controls;
using SAF.Framework.Entity;
using SAF.Framework;

namespace SAF.SystemModule
{
    public class sysMenuViewViewModel : SingleViewViewModel<sysMenu, sysMenu>
    {
        #region ParentEntitySet

        private EntitySet<sysMenu> _parentEntitySet = null;

        public virtual EntitySet<sysMenu> ParentEntitySet
        {
            get
            {
                if (_parentEntitySet == null)
                {
                    _parentEntitySet = new EntitySet<sysMenu>();
                    _parentEntitySet.PageSize = 0;
                    _parentEntitySet.IsReadOnly = true;
                }
                return _parentEntitySet;
            }
        }

        #endregion

        #region MenuParamEntitySet

        private EntitySet<sysMenuParam> _menuParamEntitySet = null;

        public virtual EntitySet<sysMenuParam> MenuParamEntitySet
        {
            get
            {
                if (_menuParamEntitySet == null)
                {
                    _menuParamEntitySet = new EntitySet<sysMenuParam>(this.ExecuteCache, 0);
                }
                return _menuParamEntitySet;
            }
        }

        #endregion

        protected override void OnQuery(string sCondition, params object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);

            string sql = @"
SELECT Iden,Name,[ParentId],[MenuOrder] ,IsAutoOpen,MenuType,[IsShowDialog],
    BusinessView=(SELECT top 1 [ClassName] FROM dbo.sysBusinessView with(nolock) WHERE [Iden]=a.BusinessViewId)
FROM [dbo].[sysMenu] a with(nolock)
where {0}
ORDER BY [ParentId],[MenuOrder]".FormatWith(sCondition);

            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "名称", FieldName = "Name", IsDefault = true });
            queryConfig.QuickQuery.QueryFields.Add(new QueryField() { Caption = "序号", FieldName = "Iden" });
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);

            this.MainEntitySet.Query(@"
select a.Iden, a.Name, a.ParentId, a.BusinessViewId, a.MenuOrder, a.Remark, a.IsSystem,
    a.IsAutoOpen,a.MenuType,a.[FileName],a.FileParameter,a.IsShowDialog,
    a.CreatedBy, a.CreatedOn, a.ModifiedBy, a.ModifiedOn, a.VersionNumber,
    BusinessView=b.[ClassName],
    BusinessViewDescription=b.[Description]
from [sysMenu] a with(nolock) 
LEFT JOIN dbo.sysBusinessView b WITH(NOLOCK) ON a.BusinessViewId=b.Iden
where a.Iden=:Iden", key);

            QueryParent(key);

            QueryMenuParam();
        }

        public void QueryParent(object key)
        {
            string sql = @"
;WITH tree AS 
(
    SELECT Iden
    FROM [dbo].[sysMenu] with(nolock)
    WHERE [Iden]={0}
    UNION ALL
    SELECT b.Iden
    FROM [tree] a 
    JOIN [dbo].[sysMenu] b with(nolock)  ON b.[ParentId]=a.[Iden]
)
SELECT Iden,Name,[ParentId]
FROM [dbo].[sysMenu]  with(nolock)
WHERE [Iden] NOT IN(SELECT [Iden] FROM [tree])
    AND MenuType=0
ORDER BY [ParentId],[MenuOrder]".FormatWith(key ?? int.MinValue);
            this.ParentEntitySet.Query(sql);
        }

        public void QueryMenuParam()
        {
            string sql = @"
SELECT A.Iden,A.MenuId,Name,A.ControlType,A.Description,ValueAlias=A.Value,A.Category, A.CreatedBy,A.CreatedOn,A.ModifiedBy,A.ModifiedOn,A.VersionNumber
FROM dbo.sysMenuParam A WITH(NOLOCK)
WHERE [MenuId]=:MenuId";

            this.MenuParamEntitySet.Query(sql, this.MainEntitySet.CurrentKey);
            this.MenuParamEntitySet.DataTable.Columns.Add("Value", typeof(object));

            foreach (var item in MenuParamEntitySet)
            {
                var type = (ViewParameterControlType)item.ControlType;
                switch (type)
                {
                    case ViewParameterControlType.CheckEdit:
                        bool bValue = false;
                        bool.TryParse(item.ValueAlias.ToStringEx(), out bValue);
                        item.Value = bValue;
                        break;
                    case ViewParameterControlType.ComboboxEdit:
                    case ViewParameterControlType.IntEdit:
                        int iValue;
                        int.TryParse(item.ValueAlias.ToStringEx(), out iValue);
                        item.Value = iValue;
                        break;
                    case ViewParameterControlType.FloatEdit:
                        decimal fValue;
                        decimal.TryParse(item.ValueAlias.ToStringEx(), out fValue);
                        item.Value = fValue;
                        break;
                    default:
                        item.Value = item.ValueAlias.ToStringEx();
                        break;
                }
            }
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysMenu> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsSystem = false;
            e.CurrentEntity.MenuOrder = 0;
            e.CurrentEntity.IsAutoOpen = false;
            e.CurrentEntity.IsShowDialog = false;

            if (e.OriginalEntity != null)
            {
                if (e.OriginalEntity.BusinessViewId.IsEmpty())
                {
                    e.CurrentEntity.ParentId = e.OriginalEntity.Iden;
                }
                else
                {
                    e.CurrentEntity.ParentId = e.OriginalEntity.ParentId;
                }
            }
        }

        protected override void OnDelete()
        {
            this.ExecuteCache.Execute(0, "DELETE [sysRoleMenu] WHERE MenuId=:menuId", this.MainEntitySet.CurrentEntity.Iden);
            base.OnDelete();
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.MainEntitySet.ChildEntitySets.Add(this.MenuParamEntitySet);
        }

        protected override void OnEndEdit()
        {
            base.OnEndEdit();
            this.MenuParamEntitySet.EndEdit();
        }

    }
}
