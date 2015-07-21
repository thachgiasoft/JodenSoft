using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls.ViewConfig;
using SAF.Foundation;
using SAF.EntityFramework;
using SAF.Foundation.ServiceModel;
using SAF.SystemEntity;

namespace SAF.SystemModule
{
    public class sysBillNoFormulaViewViewModel : SingleViewViewModel<sysBillNoFormula, sysBillNoFormula>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            IndexEntitySet.Query(@"SELECT Iden,BillNoType from sysBillNoFormula with(nolock) where ({0}) order by Iden".FormatWith(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            this.MainEntitySet.Query("SELECT  *  FROM  sysBillNoFormula  with(nolock) where Iden=:Iden", key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("BillNoType", "名称"));
        }
        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
        }

        void MainEntitySet_AfterAdd(object sender, SAF.EntityFramework.EntitySetAddEventArgs<sysBillNoFormula> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.CurrentIden = 0;
            e.CurrentEntity.Prefix = string.Empty;
            e.CurrentEntity.Midfix = string.Empty;
            e.CurrentEntity.Suffix = string.Empty;
            e.CurrentEntity.Separator = string.Empty;
            e.CurrentEntity.CurrentDate = DataPortal.Now;
            e.CurrentEntity.YearFormat = "yy";
            e.CurrentEntity.MonthFormat = "mm";
            e.CurrentEntity.DayFormat = "dd";
            e.CurrentEntity.IdenLength = 4;
            e.CurrentEntity.ResetType = "None";
        }
        protected override bool OnValidateData()
        {
            this.MainEntitySet.CurrentEntity.CheckNotNull<sysBillNoFormula>("当前行");
            this.MainEntitySet.CurrentEntity.BillNoType.CheckNotNullOrEmpty("名称");

            return true;
        }

    }
}
