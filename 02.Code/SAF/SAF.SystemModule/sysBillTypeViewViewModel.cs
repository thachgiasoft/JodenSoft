using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.EntityFramework;
using SAF.Foundation;

namespace SAF.SystemModule
{
    public class sysBillTypeViewViewModel : MasterDetailViewViewModel<sysBillType, sysBillType, sysBillOperateRight>
    {
        private EntitySet<sysBillOperateRight> sysBillOperateRightEntitySet
        {
            get { return this.DetailEntitySet as EntitySet<sysBillOperateRight>; }
        }

        private EntitySet<sysBillDataRight> _sysBillDataRightEntitySet = null;
        public EntitySet<sysBillDataRight> sysBillDataRightEntitySet
        {
            get
            {
                if (_sysBillDataRightEntitySet == null)
                {
                    _sysBillDataRightEntitySet = new EntitySet<sysBillDataRight>(this.ExecuteCache, 0);
                }
                return _sysBillDataRightEntitySet;
            }
        }

        private EntitySet<sysBillRightDefine> _sysBillRightDefineEntitySet = null;
        public EntitySet<sysBillRightDefine> sysBillRightDefineEntitySet
        {
            get
            {
                if (_sysBillRightDefineEntitySet == null)
                {
                    _sysBillRightDefineEntitySet = new EntitySet<sysBillRightDefine>(this.ExecuteCache, 0);
                }
                return _sysBillRightDefineEntitySet;
            }
        }

        protected override void OnInit()
        {
            base.OnInit();

            this.sysBillRightDefineEntitySet.PageSize = 0;
        }

        protected override void OnInitEvents()
        {
            base.OnInitEvents();
            this.MainEntitySet.AfterAdd += MainEntitySet_AfterAdd;

        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysBillType> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
        }

        protected override void OnQuery(string sCondition, object[] parameterValues)
        {
            const string sql = "SELECT Iden,Name,IsActive,IsSystem FROM dbo.sysBillType WITH(NOLOCK) Where ({0})";
            this.IndexEntitySet.Query(sql.FormatEx(sCondition));
        }

        protected override void OnQueryChild(object key)
        {
            const string sql = @"SELECT * FROM dbo.sysBillType WITH(NOLOCK) WHERE Iden=:Iden";
            this.MainEntitySet.Query(sql, key);

            const string sql2 = @"SELECT * FROM dbo.sysBillOperateRight WHERE BillTypeId=:Iden";
            this.sysBillDataRightEntitySet.Query(sql2, key);

            const string sql3 = @"SELECT * FROM dbo.sysBillDataRight WHERE BillTypeId=:Iden";
            this.sysBillOperateRightEntitySet.Query(sql3, key);

            const string sql4 = @"SELECT * FROM dbo.sysBillRightDefine WHERE BillTypeId=:Iden";
            this.sysBillRightDefineEntitySet.Query(sql4, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "单据类型"));
        }
    }
}
