using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework.ViewModel
{
    public class MasterDetailViewViewModel<TIndexEntity, TMainEntity, TDetailEntity> : SingleViewViewModel<TIndexEntity, TMainEntity>, IMasterDetailViewViewModel
        where TIndexEntity : Entity<TIndexEntity>, new()
        where TMainEntity : Entity<TMainEntity>, new()
        where TDetailEntity : Entity<TDetailEntity>, new()
    {
        #region DetailEntity

        private EntitySet<TDetailEntity> detailEntitySet = null;

        public virtual EntitySet<TDetailEntity> DetailEntitySet
        {
            get
            {
                if (detailEntitySet == null)
                {
                    detailEntitySet = new EntitySet<TDetailEntity>(this.ExecuteCache);
                }
                return detailEntitySet;
            }
        }

        IEntitySetBase IMasterDetailViewViewModel.DetailEntitySet
        {
            get { return this.DetailEntitySet; }
        }

        #endregion

        protected override void OnInit()
        {
            base.OnInit();

            this.MainEntitySet.ChildEntitySets.Add(this.DetailEntitySet);
        }

        public void DetailAddNew()
        {
            this.DetailEntitySet.AddNew();
        }

        public void DetailDelete()
        {
            this.DetailEntitySet.DeleteCurrent();
        }

        public void DetailCopy()
        {
            this.DetailEntitySet.AddNewByCurrent();
        }
    }
}
