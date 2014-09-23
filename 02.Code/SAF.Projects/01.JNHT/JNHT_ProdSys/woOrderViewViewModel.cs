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
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.IndexEntitySet.Query("SELECT  Iden , WoCode, WoVersion , CParentId, CParentName, Qty ,Isclose FROM  woOrder where ({0})".FormatEx(sCondition));

        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  Iden , WoCode, WoVersion , CParentId, CParentName, Qty ,Isclose  FROM  woOrder where Iden='{0}'".FormatEx(key));
            this.jd_v_parentidEntity.Query("select  Iden,产品代号,产品名称  from jd_v_parentid");
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
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<woOrder> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<bomChild> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
    }
}
