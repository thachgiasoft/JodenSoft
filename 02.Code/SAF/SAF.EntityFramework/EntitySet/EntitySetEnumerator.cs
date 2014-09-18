using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Collections;
using System.Threading;

namespace SAF.EntityFramework
{
    /// <summary>
    /// EntitySet Enumerator
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Serializable]
    internal class EntitySetEnumerator<TEntity> : DisposableObject, IEnumerator<TEntity>
        where TEntity : Entity<TEntity>, new()
    {
        #region private

        private DataView _DataView = null;
        private int _position = -1;

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataView"></param>
        public EntitySetEnumerator(DataView dataView)
        {
            this._DataView = dataView;
            Reset();
        }

        #endregion

        #region IEnumerator<TEntity> Support
        /// <summary>
        /// 
        /// </summary>
        public TEntity Current
        {
            get
            {
                if (_DataView == null) return null;

                TEntity entity = new TEntity();
                entity.DataRowView = _DataView[_position];
                return entity;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                if (_DataView == null) return null;

                TEntity entity = new TEntity();
                entity.DataRowView = _DataView[_position];
                return entity;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (_DataView == null) return false;
            if (_position < _DataView.Count - 1)
            {
                _position++;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }

        #endregion

        #region IDisposable Support
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bool flag = false;
                try
                {
                    Monitor.Enter(this, ref flag);
                    _DataView = null;
                }
                finally
                {
                    if (flag)
                    {
                        Monitor.Exit(this);
                    }
                }
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}
