using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;

namespace JNHT_ProdSys
{
    public class woBomParentViewViewModel : SingleViewViewModel<woBomParent, woBomParent>
    {
       
        private EntitySet<woOrder> _woOrderEntity = null;
        public EntitySet<woOrder> woOrderEntity
        {
            get
            {
                if (_woOrderEntity == null)
                    _woOrderEntity = new EntitySet<woOrder>(ConfigContext.DefaultConnection, null, 0);
                return _woOrderEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            this.woOrderEntity.Query("select * from woorder with(nolock) order by iden desc");
            var woid = this.woOrderEntity.CurrentEntity.Iden;
            this.MainEntitySet.Query("select *  from woBomParent with(nolock) where 1=0 ");
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
        }
    }
}
