using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Foundation.ServiceModel;
using SAF.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    public class SingleViewViewModel<TIndexEntity, TMainEntity> : BusinessViewViewModel, ISingleViewViewModel
        where TIndexEntity : Entity<TIndexEntity>, new()
        where TMainEntity : Entity<TMainEntity>, new()
    {
        /// <summary>
        /// Index做为分组使用
        /// </summary>
        public virtual bool IndexUseForGroup
        {
            get { return false; }
        }

        #region IndexEntitySet

        private EntitySet<TIndexEntity> indexEntitySet = null;

        public virtual EntitySet<TIndexEntity> IndexEntitySet
        {
            get
            {
                if (indexEntitySet == null)
                {
                    indexEntitySet = new EntitySet<TIndexEntity>(this.ExecuteCache);
                    indexEntitySet.IsReadOnly = true;
                }
                return indexEntitySet;
            }
        }

        #endregion

        #region MainEntitySet

        private EntitySet<TMainEntity> mainEntitySet = null;

        public virtual EntitySet<TMainEntity> MainEntitySet
        {
            get
            {
                if (mainEntitySet == null)
                {
                    mainEntitySet = new EntitySet<TMainEntity>(this.ExecuteCache);

                }
                return mainEntitySet;
            }
        }

        #endregion

        IEntitySetBase ISingleViewViewModel.MainEntitySet
        {
            get { return this.MainEntitySet; }
        }

        IEntitySetBase ISingleViewViewModel.IndexEntitySet
        {
            get { return this.IndexEntitySet; }
        }

        protected virtual bool HasChanged
        {
            get
            {
                return false;
            }
        }

        public QueryConfig QueryConfig { get; private set; }
        public void InitQueryConfig()
        {
            QueryConfig = new QueryConfig();
            OnInitQueryConfig(QueryConfig);
        }

        protected virtual void OnInitQueryConfig(QueryConfig queryConfig)
        {

        }

        protected virtual bool OnBeforeSave()
        {
            return true;
        }

        protected virtual void OnAfterSave(bool saveSucceed)
        {
        }

        public event EventHandler<AfterSaveEventArgs> AfterSave;

        private void FireAfterSaveEvent(bool isSavedSuccessfully)
        {
            var handler = AfterSave;
            if (handler != null)
            {
                handler(this, new AfterSaveEventArgs(isSavedSuccessfully));
            }
        }

        public void ApplySave()
        {
            OnApplySave();
        }

        public bool Save()
        {
            return OnSave();
        }

        private EditState preEditStatus = EditState.Browse;

        protected virtual bool OnSave()
        {
            bool canSave = true;
            //预处理数据
            canSave = OnPreHandle();
            if (!canSave) return false;
            //验证数据
            canSave = OnValidateData();
            if (!canSave) return false;
            //保存前处理
            canSave = OnBeforeSave();
            if (!canSave) return false;

            bool isSavedSuccessfully = false;
            preEditStatus = this.EditState;
            try
            {
                this.ApplySave();
                if (ExecuteCache.Count > 0)
                {
                    DataPortal.ExecuteNonQueryByTransaction(this.ConnectionName, ExecuteCache.ToList());
                }
                this.EditState = EditState.Browse;
                isSavedSuccessfully = true;

                return true;
            }
            catch
            {
                isSavedSuccessfully = false;
                throw;
            }
            finally
            {
                if (preEditStatus.In(EditState.AddNew, EditState.Edit))
                    SyncIndexEntitySet();

                this.ExecuteCache.Clear();
                OnAcceptChanges(isSavedSuccessfully);
                OnAfterSave(isSavedSuccessfully);

                FireAfterSaveEvent(isSavedSuccessfully);
            }
        }
        /// <summary>
        /// 数据预处理
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnPreHandle()
        {
            return true;
        }
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnValidateData()
        {
            return true;
        }

        public event EventHandler AfterQuery;

        public void Query(string condition, params object[] parameterValues)
        {
            OnQuery(condition, parameterValues);
            QueryChild(this.IndexEntitySet.CurrentKey);

            this.EditState = EditState.Browse;

            FireAfterQuery();
        }

        private void FireAfterQuery()
        {
            var handler = AfterQuery;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        protected virtual void OnQuery(string sCondition, object[] parameterValues)
        {

        }

        public void QueryChild(object key)
        {
            OnQueryChild(key);
        }

        protected virtual void OnQueryChild(object key)
        {

        }

        public void AddNew()
        {
            try
            {
                this.EditState = EditState.AddNew;
                OnAddNew();
            }
            catch
            {
                this.Cancel();
                this.EditState = EditState.Browse;
                throw;
            }
        }

        protected virtual void OnAddNew()
        {
            this.IndexEntitySet.IsBusy = true;
            try
            {
                if (!this.IndexUseForGroup)
                    this.IndexEntitySet.AddNew();

                this.MainEntitySet.AddNew();

                foreach (var child in this.MainEntitySet.ChildEntitySets)
                {
                    if (!child.IsReadOnly)
                        child.Clear();
                }

                this.SyncIndexEntitySet();
            }
            finally
            {
                this.IndexEntitySet.IsBusy = false;
            }
        }

        public void Edit()
        {
            this.EditState = EditState.Edit;
            OnEdit();       
        }

        protected virtual void OnEdit()
        {

        }

        public void Delete()
        {
            this.IndexEntitySet.IsBusy = true;
            this.MainEntitySet.IsBusy = true;
            try
            {
                this.EditState = EditState.Browse;
                OnDelete();
                Save();
            }
            finally
            {
                this.IndexEntitySet.IsBusy = false;
                this.MainEntitySet.IsBusy = false;
            }
        }

        protected virtual void OnDelete()
        {
            if (this.indexEntitySet.CurrentEntity != null && !this.IndexUseForGroup)
                this.IndexEntitySet.DeleteCurrent();

            if (this.mainEntitySet.CurrentEntity != null)
                this.MainEntitySet.DeleteCurrent();

            foreach (var child in this.MainEntitySet.ChildEntitySets)
            {
                if (!child.IsReadOnly)
                    child.DeleteCurrent();
            }
        }

        public void Cancel()
        {
            this.EditState = EditState.Browse;
            OnCancel();         
        }

        protected virtual void OnCancel()
        {
            foreach (var child in this.MainEntitySet.ChildEntitySets)
            {
                if (!child.IsReadOnly)
                    child.Cancel();
            }

            this.MainEntitySet.Cancel();

            if (!this.IndexUseForGroup)
                this.IndexEntitySet.Cancel();
        }

        protected virtual void OnApplySave()
        {
            //新增的数据先存主表
            this.MainEntitySet.SaveChanges(DataRowState.Added);
            this.MainEntitySet.SaveChanges(DataRowState.Modified);

            //保存明细新增数据
            foreach (var child in this.MainEntitySet.ChildEntitySets)
            {
                if (!child.IsReadOnly)
                {
                    child.SaveChanges(DataRowState.Added);
                    child.SaveChanges(DataRowState.Modified);
                }
            }

            //删除时先存明细表
            foreach (var child in this.MainEntitySet.ChildEntitySets)
            {
                if (!child.IsReadOnly)
                {
                    child.SaveChanges(DataRowState.Deleted);
                }
            }
            this.MainEntitySet.SaveChanges(DataRowState.Deleted);

        }

        public void SyncIndexEntitySet()
        {
            if (!this.IndexUseForGroup)
                OnSyncIndexEntitySet();
        }

        protected virtual void OnSyncIndexEntitySet()
        {
            if (this.IndexEntitySet.CurrentEntity == null)
                return;
            this.IndexEntitySet.CurrentEntity.Copy(this.MainEntitySet.CurrentEntity);
        }

        protected virtual void OnAcceptChanges(bool saveSucceed)
        {
            if (saveSucceed)
            {
                if (!this.IndexUseForGroup)
                    this.IndexEntitySet.AcceptChanges();
                this.MainEntitySet.AcceptChanges();
                foreach (var child in this.MainEntitySet.ChildEntitySets)
                {
                    if (!child.IsReadOnly)
                    {
                        child.AcceptChanges();
                    }
                }
            }
        }

        public void SendToAudit()
        {
            OnSendToAudit();
            this.EditState = EditState.Browse;
        }

        protected virtual void OnSendToAudit()
        {
            var curr = this.mainEntitySet.CurrentEntity;
            if (curr == null) return;

            if (!curr.VersionNumberIsSync)
            {
                MessageService.ShowError("数据已被修改,请重新查询后再送审.");
                return;
            }
        }

        public void UnSendToAudit()
        {
            OnUnSendToAudit();
            this.EditState = EditState.Browse;
        }

        protected virtual void OnUnSendToAudit()
        {
            //TODO:OnUnSendToAudit
        }

        public void EndEdit()
        {
            if (!this.IndexUseForGroup)
                this.IndexEntitySet.EndEdit();
            this.MainEntitySet.EndEdit();
            foreach (var child in this.MainEntitySet.ChildEntitySets)
            {
                if (!child.IsReadOnly)
                {
                    child.EndEdit();
                }
            }

            OnEndEdit();
        }

        protected virtual void OnEndEdit()
        {

        }

        public bool AllowDelete()
        {
            return OnAllowDelete();
        }

        protected virtual bool OnAllowDelete()
        {
            return true;
        }

        public bool AllowEdit()
        {
            return OnAllowEdit();
        }

        protected virtual bool OnAllowEdit()
        {
            return true;
        }

    }
}
