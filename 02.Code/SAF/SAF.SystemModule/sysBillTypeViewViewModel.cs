using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Framework.ViewModel;
using SAF.Framework.Controls.ViewConfig;
using SAF.SystemEntities;
using SAF.EntityFramework;
using SAF.Foundation;
using System.Data;

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

        public EntitySet<QueryEntity> GetDataRoles()
        {
            var es = new EntitySet<QueryEntity>();
            es.Query("SELECT Iden,Name FROM dbo.sysDataRole WITH(NOLOCK) WHERE IsDeleted=0");
            return es;
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
            this.sysBillOperateRightEntitySet.AfterAdd += sysBillOperateRightEntitySet_AfterAdd;
            this.sysBillDataRightEntitySet.AfterAdd += sysBillDataRightEntitySet_AfterAdd;
        }

        void sysBillDataRightEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysBillDataRight> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.BillTypeId = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.QueryRight = (int)BillDataRight.None;
            e.CurrentEntity.UpdateRight = (int)BillDataRight.None;
            e.CurrentEntity.DeleteRight = (int)BillDataRight.None;
            e.CurrentEntity.AuditRight = (int)BillDataRight.None;
            e.CurrentEntity.PrintRight = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight1 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight2 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight3 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight4 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight5 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight6 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight7 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight8 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight9 = (int)BillDataRight.None;
            e.CurrentEntity.ExtendRight10 = (int)BillDataRight.None;
            e.CurrentEntity.IsActive = true;

        }

        void sysBillOperateRightEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysBillOperateRight> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.BillTypeId = this.MainEntitySet.CurrentEntity.Iden;
            e.CurrentEntity.AddNew = false;
            e.CurrentEntity.ExtendRight1 = false;
            e.CurrentEntity.ExtendRight2 = false;
            e.CurrentEntity.ExtendRight3 = false;
            e.CurrentEntity.ExtendRight4 = false;
            e.CurrentEntity.ExtendRight5 = false;
            e.CurrentEntity.ExtendRight6 = false;
            e.CurrentEntity.ExtendRight7 = false;
            e.CurrentEntity.ExtendRight8 = false;
            e.CurrentEntity.ExtendRight9 = false;
            e.CurrentEntity.ExtendRight10 = false;
            e.CurrentEntity.IsActive = true;
        }

        void MainEntitySet_AfterAdd(object sender, EntitySetAddEventArgs<sysBillType> e)
        {
            e.CurrentEntity.Iden = IdenGenerator.NewIden(e.CurrentEntity.DbTableName);
            e.CurrentEntity.IsActive = true;
            e.CurrentEntity.IsSystem = false;
            e.CurrentEntity.UseBillDataRight = true;
            e.CurrentEntity.UseBillOperateRight = true;
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

            const string sql2 = @"SELECT * FROM dbo.sysBillDataRight WHERE BillTypeId=:Iden";
            this.sysBillDataRightEntitySet.Query(sql2, key);

            const string sql3 = @"SELECT * FROM dbo.sysBillOperateRight WHERE BillTypeId=:Iden";
            this.sysBillOperateRightEntitySet.Query(sql3, key);

            const string sql4 = @"SELECT * FROM dbo.sysBillRightDefine WHERE BillTypeId=:Iden";
            this.sysBillRightDefineEntitySet.Query(sql4, key);
        }

        protected override void OnInitQueryConfig(QueryConfig queryConfig)
        {
            base.OnInitQueryConfig(queryConfig);

            queryConfig.QuickQuery.QueryFields.Add(new QueryField("Name", "单据类型"));
        }

        public void AddDataRight()
        {
            this.sysBillDataRightEntitySet.AddNew();
        }

        public void CopyDataRight()
        {
            this.sysBillDataRightEntitySet.AddNewByCurrent();
        }

        public void DeleteDataRight()
        {
            this.sysBillDataRightEntitySet.DeleteCurrent();
        }

        public DataTable _dtDataRightDefine = new DataTable();

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            InitDataRightDefine();
        }

        private void InitDataRightDefine()
        {
            _dtDataRightDefine.Columns.Add("RightType", typeof(string));
            _dtDataRightDefine.Columns.Add("FieldName", typeof(string));
            _dtDataRightDefine.Columns.Add("Caption", typeof(string));
            _dtDataRightDefine.Columns.Add("IsActive", typeof(bool));

            for (int i = 1; i <= 10; i++)
            {
                _dtDataRightDefine.Rows.Add("操作权限", "ExtendRight{0}".FormatEx(i), string.Empty, false);
            }
            for (int i = 1; i <= 10; i++)
            {
                _dtDataRightDefine.Rows.Add("数据权限", "ExtendRight{0}".FormatEx(i), string.Empty, false);
            }
        }

        public void MergeBillRightDefine()
        {
            foreach (DataRow item in this._dtDataRightDefine.Rows)
            {
                item["Caption"] = string.Empty;
                item["IsActive"] = false;
                item.EndEdit();
            }

            foreach (var item in sysBillRightDefineEntitySet)
            {
                var obj = this._dtDataRightDefine.AsEnumerable().FirstOrDefault(p => p.Field<string>("RightType") == item.RightType && p.Field<string>("FieldName") == item.FieldName);
                if (obj != null)
                {
                    obj["Caption"] = item.Caption;
                    obj["IsActive"] = item.IsActive;
                    obj.EndEdit();
                }
            }
        }

        protected override void OnApplySave()
        {
            foreach (DataRow item in this._dtDataRightDefine.Rows)
            {
                var obj = this.sysBillRightDefineEntitySet.FirstOrDefault(p => p.RightType == item["RightType"].ToString() && p.FieldName == item["FieldName"].ToString());
                if (obj == null)
                {
                    obj = this.sysBillRightDefineEntitySet.AddNew();
                    obj.Iden = IdenGenerator.NewIden(obj.DbTableName);
                    obj.BillTypeId = this.MainEntitySet.CurrentEntity.Iden;
                    obj.FieldName = item["FieldName"].ToString();
                }

                obj.Caption = item["Caption"].ToString();
                obj.IsActive = Convert.ToBoolean(item["IsActive"]);
            }

            base.OnApplySave();
        }
    }
}
