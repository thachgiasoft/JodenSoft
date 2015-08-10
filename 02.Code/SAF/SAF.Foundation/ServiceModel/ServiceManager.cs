﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    public abstract class ServiceManager : IServiceProvider
    {
        volatile static ServiceManager instance = new DefaultServiceManager();

        /// <summary>
        /// Gets the static ServiceManager instance.
        /// </summary>
        public static ServiceManager Instance
        {
            get { return instance; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                instance = value;
            }
        }

        /// <summary>
        /// Gets a service. Returns null if service is not found.
        /// </summary>
        public abstract object GetService(Type serviceType);

        /// <summary>
        /// Gets a service. Returns null if service is not found.
        /// </summary>
        public T GetService<T>() where T : class
        {
            return GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Gets a service. Throws an exception if service is not found.
        /// </summary>
        public object GetRequiredService(Type serviceType)
        {
            object service = GetService(serviceType);
            if (service == null)
                throw new ServiceNotFoundException();
            return service;
        }

        /// <summary>
        /// Gets a service. Throws an exception if service is not found.
        /// </summary>
        public T GetRequiredService<T>() where T : class
        {
            return (T)GetRequiredService(typeof(T));
        }

        /// <summary>
        /// Gets the logging service.
        /// </summary>
        public virtual ILoggingService LoggingService
        {
            get { return (ILoggingService)GetRequiredService(typeof(ILoggingService)); }
        }

        /// <summary>
        /// Gets the message service.
        /// </summary>
        public virtual IMessageService MessageService
        {
            get { return (IMessageService)GetRequiredService(typeof(IMessageService)); }
        }
    }

    sealed class DefaultServiceManager : ServiceManager
    {
        static ILoggingService loggingService = new TextWriterLoggingService(new DebugTextWriter());
        static IMessageService messageService = new MessageBoxMessageService();

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
            if (serviceType == typeof(ILoggingService))
                return loggingService;
            else if (serviceType == typeof(IMessageService))
                return messageService;
            else
                return null;
        }
    }
}
