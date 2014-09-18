using SAF.EntityFramework;
using SAF.Foundation;
using SAF.Framework.Controls.ViewConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ViewModel
{
    public class SingleViewViewModel<TIndexEntity, TMainEntity> : BusinessViewViewModel, ISingleViewViewModel
        where TIndexEntity : Entity<TIndexEntity>, new()
        where TMainEntity : Entity<TMainEntity>, new()
    {
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

        protected override void OnInitConfig()
        {
            base.OnInitConfig();
            InitQueryConfig();
        }

        public QueryConfig QueryConfig { get; private set; }
        protected void InitQueryConfig()
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

        private void FireAfterSaveEvent()
        {
            var handler = AfterSave;
            if (handler != null)
            {
                handler(this, new AfterSaveEventArgs());
            }
        }

        public void ApplySave()
        {
            OnApplySave();
        }

        public void Save()
        {
            OnSave();
        }

        private EditStatus preEditStatus = EditStatus.Browse;

        protected virtual void OnSave()
        {
            bool canSave = OnBeforeSave();
            if (!canSave) return;

            bool saveSucceed = false;
            preEditStatus = this.EditStatus;
            try
            {
                this.ApplySave();
                if (ExecuteCache.Count > 0)
                {
                    DataPortal.ExecuteNonQueryByTransaction(this.ConnectionName, ExecuteCache.ToList());
                }
                this.EditStatus = EditStatus.Browse;
                saveSucceed = true;

                if (preEditStatus.In(EditStatus.AddNew, EditStatus.Edit))
                    OnSyncIndexEntitySet();
            }
            catch
            {
                saveSucceed = false;
                throw;
            }
            finally
            {
                this.ExecuteCache.Clear();
                OnAcceptChanges(saveSucceed);
                OnAfterSave(saveSucceed);

                if (saveSucceed)
                {
                    FireAfterSaveEvent();
                }
            }
        }

        public event EventHandler AfterQuery;

        public void Query(string condition, params object[] parameterValues)
        {
            OnQuery(condition, parameterValues);
            QueryChild(this.IndexEntitySet.CurrentKey);

            this.EditStatus = EditStatus.Browse;

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
            OnAddNew();
            this.EditStatus = EditStatus.AddNew;
        }

        protected virtual void OnAddNew()
        {
            this.MainEntitySet.IsBusy = true;
            try
            {
                this.IndexEntitySet.AddNew();
                this.MainEntitySet.AddNew();

                this.SyncIndexEntitySet();
            }
            finally
            {
                this.MainEntitySet.IsBusy = false;
            }
        }

        public void Edit()
        {
            OnEdit();
            this.EditStatus = EditStatus.Edit;
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
                OnDelete();

                Save();
                this.EditStatus = EditStatus.Browse;
            }
            finally
            {
                this.IndexEntitySet.IsBusy = false;
                this.MainEntitySet.IsBusy = false;
            }

        }

        protected virtual void OnDelete()
        {
            if (this.indexEntitySet.CurrentEntity != null)
                this.IndexEntitySet.DeleteCurrent();

            if (this.mainEntitySet.CurrentEntity != null)
                this.MainEntitySet.DeleteCurrent();
        }

        public void Cancel()
        {
            OnCancel();
            this.EditStatus = EditStatus.Browse;
        }

        protected virtual void OnCancel()
        {
            this.MainEntitySet.Cancel();
            this.IndexEntitySet.Cancel();
        }

        protected virtual void OnApplySave()
        {
            this.MainEntitySet.SaveChanges();
        }

        public void SyncIndexEntitySet()
        {
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
                this.IndexEntitySet.AcceptChanges();
                this.MainEntitySet.AcceptChanges();
            }
        }

        public void EndEdit()
        {
            this.IndexEntitySet.EndEdit();
            this.MainEntitySet.EndEdit();

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
