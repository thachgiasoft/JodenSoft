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
    public class sysUserDataRoleViewModel : SingleViewViewModel<sysUser, sysUserDataRole>
    {
        public override bool IndexUseForGroup
        {
            get
            {
                return true;
            }
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            const string sql = @"SELECT Iden,UserName,UserFullName
FROM dbo.sysUser a WITH(NOLOCK) 
WHERE IsActive=1 AND IsDeleted=0 AND ({0})";

            IndexEntitySet.Query(sql.FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            const string sql = "SELECT * FROM dbo.sysUserDataRole WITH(NOLOCK) WHERE UserId=:UserId";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("UserName", "用户名"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("UserFullName", "用户姓名"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Iden", "用户编号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysUserDataRole> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.UserId = IndexEntitySet.CurrentEntity.Iden;
        }

        public object GetUser()
        {
            var es = new EntitySet<QueryEntity>();
            es.Query("SELECT Iden,UserName,UserFullName FROM dbo.sysUser WITH(NOLOCK) where IsDeleted=0");
            return es.DefaultView;
        }

        public object GetDataRole()
        {
            var es = new EntitySet<QueryEntity>();
            es.Query("SELECT Iden,Name FROM dbo.sysDataRole WITH(NOLOCK) WHERE IsDeleted=0");
            return es.DefaultView;
        }

        public object GetOrganization()
        {
            var es = new EntitySet<QueryEntity>();
            es.Query("SELECT Iden,Name,ParentId FROM dbo.sysOrganization WITH(NOLOCK) ORDER BY ParentId, Iden");
            return es.DefaultView;
        }
    }
}
