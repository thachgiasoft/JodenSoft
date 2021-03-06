﻿using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Foundation.ServiceModel;

namespace FSDProdPlan
{
    public class sysBillNoFormulaViewViewModel : SingleViewViewModel<sysBillNoFormula, sysBillNoFormula>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            base.OnQuery(sCondition, parameterValues);
            IndexEntitySet.Query(@"SELECT Iden,BillNoType,CurrentIden,CurrentDate  from sysBillNoFormula with(nolock) where ({0})".FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            base.OnQueryChild(key);
            this.MainEntitySet.Query("SELECT  *  FROM  sysBillNoFormula  with(nolock) where Iden='{0}'".FormatEx(key));
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BillNoType", "单据号类型"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<sysBillNoFormula> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }
        protected override bool OnValidateData()
        {
            if (string.IsNullOrEmpty(this.MainEntitySet.CurrentEntity.BillNoType))
            {
                MessageService.ShowMessage("请输入单据号类型");
                return false;
            }
            return true;
        }
        
    }
}
