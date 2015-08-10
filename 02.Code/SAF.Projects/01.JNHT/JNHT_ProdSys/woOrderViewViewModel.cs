using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;


namespace JNHT_ProdSys
{
    public class woOrderViewViewModel : SingleViewViewModel<woOrder, woOrder>
    {
        private EntitySet<jd_v_parentid> _jd_v_parentidEntity = null;
        public EntitySet<jd_v_parentid> jd_v_parentidEntity
        {
            get
            {
                if (_jd_v_parentidEntity == null)
                    _jd_v_parentidEntity = new EntitySet<jd_v_parentid>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _jd_v_parentidEntity;
            }
        }
        private EntitySet<woDetail> _woDetailEntity = null;
        public EntitySet<woDetail> woDetailEntity
        {
            get
            {
                if (_woDetailEntity == null)
                    _woDetailEntity = new EntitySet<woDetail>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _woDetailEntity;
            }
        }
        private EntitySet<bomParent> _bomParentEntity = null;
        public EntitySet<bomParent> bomParentEntity
        {
            get
            {
                if (_bomParentEntity == null)
                    _bomParentEntity = new EntitySet<bomParent>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _bomParentEntity;
            }
        }
        private EntitySet<bomChild> _bomChildEntity = null;
        public EntitySet<bomChild> bomChildEntity
        {
            get
            {
                if (_bomChildEntity == null)
                    _bomChildEntity = new EntitySet<bomChild>(ConfigContext.DefaultConnection, null, ConfigContext.DefaultPageSize);
                return _bomChildEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("SELECT  Iden ,BomId, WoCode, WoVersion , CParentId, CParentName, Qty ,Isclose FROM  woOrder where ({0})".FormatEx(sCondition));
            this.woDetailEntity.Query("select * from wodetail with(nolock) where 1=0");

        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query(@"SELECT  wo.*,OrganizationName=b.name  
            FROM  woOrder wo left join sysOrganization b on wo.OrganizationId=b.iden where wo.Iden='{0}'".FormatEx(key));
            this.jd_v_parentidEntity.Query("select  Iden,产品代号,产品名称,产品区分号  from jd_v_parentid");

            this.bomParentEntity.Query("select * from bomParent with(nolock) where 1=0");
            this.bomChildEntity.Query("select * from bomChild with(nolock) where 1=0");
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("WoCode", "生产令单号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.woDetailEntity.AfterAdd += woDetailEntity_AfterAdd;
        }

        void woDetailEntity_AfterAdd(object sender, EntitySetAddEventArgs<woDetail> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<woOrder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

    }
}
