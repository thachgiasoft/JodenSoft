using SAF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAF.Foundation;

namespace SAF.Framework.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessViewViewModel : BaseViewViewModel, IBusinessViewViewModel
    {
        private IExecuteCache executeCache;
        /// <summary>
        /// 
        /// </summary>
        public IExecuteCache ExecuteCache
        {
            get { return this.executeCache; }
        }

        protected string ConnectionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BusinessViewViewModel()
            : this(ConfigContext.DefaultConnection)
        {

        }

        public BusinessViewViewModel(string connectionName)
        {
            this.EditState = EditState.Browse;

            this.ConnectionName = connectionName.IsEmpty() ? ConfigContext.DefaultConnection : connectionName;
            this.executeCache = new ExecuteCache(this.ConnectionName);

            Init();
        }

        private void Init()
        {
            OnInit();
            OnInitConfig();
            OnInitEvents();
        }

        protected virtual void OnInit()
        {

        }

        protected virtual void OnInitConfig()
        {

        }

        protected virtual void OnInitEvents()
        {

        }

    }
}
