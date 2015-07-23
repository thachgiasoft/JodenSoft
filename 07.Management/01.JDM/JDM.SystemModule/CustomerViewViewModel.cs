using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using JDM.Entity;
using SAF.Foundation;
using SAF.EntityFramework;

namespace JDM.SystemModule
{
    public class CustomerViewViewModel : SingleViewViewModel<sysCustomer, sysCustomer>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            var sql = "SELECT * FROM dbo.sysCustomer WITH(NOLOCK) where ({0}) and IsDeleted=0".FormatWith(sCondition);
            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            var sql = "SELECT * FROM dbo.sysCustomer WITH(NOLOCK) WHERE Iden=:Iden";
            this.MainEntitySet.Query(sql, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "客户名称"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<sysCustomer> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsActive = true;
            e.CurrentEntity.IsDeleted = false;
        }

        protected override void OnDelete()
        {
            var curr = this.MainEntitySet.CurrentEntity;
            if (curr == null)
                return;

            this.MainEntitySet.CurrentEntity.IsDeleted = true;
            this.IndexEntitySet.DeleteCurrent();
        }
    }
}
