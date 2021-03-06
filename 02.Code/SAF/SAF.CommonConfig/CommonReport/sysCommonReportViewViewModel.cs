﻿using SAF.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.Controls;
using SAF.CommonConfig.Entity;
using System.ComponentModel;
using SAF.Foundation;
using SAF.Framework.Entity;
using SAF.EntityFramework;
using System.Text.RegularExpressions;
using SAF.Foundation.ServiceModel;

namespace SAF.CommonConfig
{
    public class sysCommonReportConfigViewViewModel : MasterDetailViewViewModel<sysReport, sysReport, sysReportFormat>
    {
        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            string sql = @"SELECT * FROM dbo.sysReport A WITH(NOLOCK) WHERE ({0})".FormatWith(sCondition);
            this.IndexEntitySet.Query(sql, parameterValues);
        }

        protected override void OnQueryChild(object key)
        {
            string sql = @"SELECT * FROM dbo.sysReport A WITH(NOLOCK) WHERE Iden=:Iden";
            this.MainEntitySet.Query(sql, key);

            string sqlDtl = @"select * from dbo.sysReportFormat A with(nolock) where ReportId=:Iden";
            this.DetailEntitySet.Query(sqlDtl, key);
        }

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            this.IndexEntitySet.PageSize = 0;
            this.MainEntitySet.PageSize = 0;
            this.DetailEntitySet.PageSize = 0;

        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("A.Name", "报表名称"));
            queryConfig.QuickQuery.QueryFields.Add(new QueryField("A.Iden", "报表序号"));
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();

            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;
            this.DetailEntitySet.AfterAdd += DetailEntitySet_AfterAdd;
        }

        void DetailEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysReportFormat> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.ReportId = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.IsActive = true;
            e.CurrentEntity.OrderIndex = 0;
            e.CurrentEntity.FormatData = null;
            e.CurrentEntity.Name = string.Empty;
            e.CurrentEntity.IsDefault = false;
        }

        void MainEntitySet_AfterAdd(object sender, EntityFramework.EntitySetAddEventArgs<sysReport> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.IdenGroup);
            e.CurrentEntity.IsActive = true;
            e.CurrentEntity.SqlScript = string.Empty;
            e.CurrentEntity.DataSetAlias = string.Empty;
            e.CurrentEntity.ParamList = string.Empty;
            e.CurrentEntity.ParamValueList = string.Empty;
            e.CurrentEntity.NodeType = (int)NodeType.Report;

            if (e.OriginalEntity == null)
            {
                e.CurrentEntity.ParentId = 0;
            }
            else
            {
                e.CurrentEntity.ParentId = e.OriginalEntity.Iden;
            }
        }

        public void ParaseParameters()
        {
            List<string> result = new List<string>();
            Regex paramReg = new Regex(@"[^:](?<p>:\w+)");
            MatchCollection matches = paramReg.Matches(String.Concat(MainEntitySet.CurrentEntity.SqlScript.ToStringEx(), " "));
            foreach (Match m in matches)
            {
                var param = m.Groups["p"].Value;
                if (!result.Any(p => p.Equals(param, StringComparison.CurrentCultureIgnoreCase)))
                    result.Add(param);
            }

            var str = result.Select(p => p.Substring(1)).JoinText();
            this.MainEntitySet.CurrentEntity.ParamList = str;
        }

        protected override bool OnPreHandle()
        {
            var result = base.OnPreHandle();
            ParaseParameters();
            return result;
        }

        protected override bool OnValidateData()
        {
            if (this.DetailEntitySet.Where(p => p.IsDefault).Count() != 1)
            {
                MessageService.ShowError("默认报表格式有且必须只能有一个，请检查。");
                return false;
            }
            return base.OnValidateData();
        }

    }


}
