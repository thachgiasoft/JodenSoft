using SAF.Foundation.ServiceModel;
using SAF.Framework.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Framework.ServiceModel
{
    public class SAFServiceManager : ServiceManager
    {
        readonly ILoggingService loggingService = new Log4netLoggingService();
        readonly IMessageService messageService = new WinFormsMessageService();
        readonly ThreadSafeServiceContainer container = new ThreadSafeServiceContainer();

        public override ILoggingService LoggingService
        {
            get { return loggingService; }
        }

        public override IMessageService MessageService
        {
            get { return messageService; }
        }

        public override object GetService(Type serviceType)
        {
            return container.GetService(serviceType);
        }
    }
}
