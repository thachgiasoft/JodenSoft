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
using System.Reflection;
using System.ServiceModel.Dispatcher;
using SAF.Foundation.ServiceModel;
using System.Windows.Forms;

namespace SAF.ServiceManager
{
    public class ThreadServiceHost
    {
        const int SleepTime = 100;
        private ServiceHost _serviceHost = null;
        private Thread _thread;
        private bool _isRunning;

        private Guid _UniqueId = Guid.Empty;
        public Guid UniqueId
        {
            get { return _UniqueId; }
        }

        public bool IsActive
        {
            get
            {
                return this._thread != null && this._thread.IsAlive;
            }
        }

        private List<ThreadServiceHost> _hostList = new List<ThreadServiceHost>();
        private DataServiceConfig _serviceConfig = null;
        private Shell _shell = null;

        public ThreadServiceHost(Shell shell, List<ThreadServiceHost> hostList, DataServiceConfig serviceConfig)
        {
            _shell = shell;
            _hostList = hostList;
            _serviceConfig = serviceConfig;
        }

        public void Start()
        {
            this._UniqueId = _serviceConfig.UniqueId;
            string httpEndPstr = @"http://{0}:{1}/WcfPortal".FormatEx(_serviceConfig.HostAddress, _serviceConfig.HostPort);
            Uri httpUri = new Uri(httpEndPstr);

            _serviceHost = new ServiceHost(typeof(SAF.EntityFramework.Server.Hosts.WcfPortal), httpUri);

            Type t = _serviceHost.GetType();
            object obj = t.Assembly.CreateInstance("System.ServiceModel.Dispatcher.DataContractSerializerServiceBehavior", true,
                BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, null,
                new object[] { false, Int32.MaxValue }, null, null);
            IServiceBehavior myServiceBehavior = obj as IServiceBehavior;

            if (myServiceBehavior != null)
            {
                _serviceHost.Description.Behaviors.Add(myServiceBehavior);
            }

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
                _hostList.Add(this);

                if (_shell.InvokeRequired)
                {
                    _shell.Invoke(new Action(_shell.CloseProgressAndRefreshUI));
                }
                else
                {
                    _shell.CloseProgressAndRefreshUI();
                }

                while (_isRunning)
                {
                    Thread.Sleep(SleepTime);
                }
                _serviceHost.Close();
                ((IDisposable)_serviceHost).Dispose();
            }
            catch (Exception ex)
            {
                if (_serviceHost != null && _serviceHost.State.In(CommunicationState.Opened, CommunicationState.Opening))
                    _serviceHost.Close();

                if (_shell.InvokeRequired)
                {
                    _shell.Invoke(new Action(_shell.CloseProgressAndRefreshUI));

                    _shell.Invoke(new Action<Exception>(_shell.ShowThreadException), ex);
                }
                else
                {
                    _shell.CloseProgressAndRefreshUI();
                    _shell.ShowThreadException(ex);
                }
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
