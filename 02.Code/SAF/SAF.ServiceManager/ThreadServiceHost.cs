using SAF.EntityFramework.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using SAF.Foundation;
using System.Runtime.Serialization;

namespace SAF.ServiceManager
{
    public class ThreadServiceHost
    {
        const int SleepTime = 100;
        private ServiceHost _serviceHost = null;
        private Thread _thread;
        private bool _isRunning;

        public bool IsActive
        {
            get
            {
                return this._thread != null && this._thread.IsAlive;
            }
        }

        public ThreadServiceHost(DataServiceConfig serviceConfig)
        {
            string httpHostName = "localhost";
            int httpPort = 8732;
            string httpEndPstr = @"http://{0}:{1}/WcfPortal".FormatEx(httpHostName, httpPort);
            Uri httpUri = new Uri(httpEndPstr);

            _serviceHost = new ServiceHost(typeof(SAF.EntityFramework.Server.Hosts.WcfPortal), httpUri);

            //if (_serviceHost.Description.Behaviors.Find<DataContractSerializer>() == null)
            //{
            //    var behavior = new DataContractSerializer();

            //    //将行为添加到宿主上
            //    _serviceHost.Description.Behaviors.Add(behavior);
            //}

            if (_serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
            {
                var behavior = new ServiceMetadataBehavior();
                //交换方式
                behavior.HttpGetEnabled = true;
                //元数据交换地址
                behavior.HttpGetUrl = httpUri;
                //将行为添加到宿主上
                _serviceHost.Description.Behaviors.Add(behavior);
            }

            if (_serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>() == null)
            {
                var behavior = new ServiceDebugBehavior();
                //交换方式
                behavior.IncludeExceptionDetailInFaults = true;
                //将行为添加到宿主上
                _serviceHost.Description.Behaviors.Add(behavior);
            }

            _serviceHost.AddServiceEndpoint(typeof(SAF.EntityFramework.Server.Hosts.IWcfPortal), new WSHttpBinding(SecurityMode.None), "");

            _serviceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            _thread = new Thread(RunService);
            _thread.IsBackground = true;
            _thread.Start();
        }

        void RunService()
        {
            try
            {
                _isRunning = true;
                _serviceHost.Open();
                while (_isRunning)
                {
                    Thread.Sleep(SleepTime);
                }
                _serviceHost.Close();
                ((IDisposable)_serviceHost).Dispose();
            }
            catch (Exception ex)
            {
                if (_serviceHost != null)
                    _serviceHost.Close();
                throw ex;
            }
        }

        public void Stop()
        {
            lock (this)
            {
                _isRunning = false;
            }
        }
    }
}
