﻿using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.EntityFramework;
using SAF.Foundation;

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
        private EntitySet<woBomParent> _woBomParentEntity = null;
        public EntitySet<woBomParent> woBomParentEntity
        {
            get
            {
                if (_woBomParentEntity == null)
                    _woBomParentEntity = new EntitySet<woBomParent>(ConfigContext.DefaultConnection, null, 0);
                return _woBomParentEntity;
            }
        }
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            queryMain();
        }

        public void queryMain()
        {
            this.woOrderEntity.Query("select * from woorder with(nolock) order by iden desc");
            var woid = this.woOrderEntity.CurrentEntity.Iden;
            this.MainEntitySet.Query("select *  from woBomParent with(nolock) where woid='{0}'".FormatEx(woid));
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
