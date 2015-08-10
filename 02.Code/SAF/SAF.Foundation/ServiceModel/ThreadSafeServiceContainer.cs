﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ServiceModel
{
    // <summary>
    /// A thread-safe service container class.
    /// </summary>
    public class ThreadSafeServiceContainer : IServiceProvider, IDisposable
    {
        Dictionary<Type, object> services = new Dictionary<Type, object>();

        public ThreadSafeServiceContainer()
        {
            services.Add(typeof(ThreadSafeServiceContainer), this);
        }

        public object GetOrCreateService(Type type, Func<object> serviceCreator)
        {
            lock (services)
            {
                object instance;
                if (!services.TryGetValue(type, out instance))
                {
                    instance = serviceCreator();
                    services.Add(type, instance);
                }
                return instance;
            }
        }

        public void TryAddService(Type type, object instance)
        {
            lock (services)
            {
                if (!services.ContainsKey(type))
                    services.Add(type, instance);
            }
        }

        public object GetService(Type type)
        {
            lock (services)
            {
                object instance;
                if (services.TryGetValue(type, out instance))
                    return instance;
                else
                    return null;
            }
        }

        public void Dispose()
        {
            IDisposable[] disposables;
            lock (services)
            {
                disposables = services.Values.OfType<IDisposable>().ToArray();
                services.Clear();
            }
            foreach (IDisposable disposable in disposables)
                disposable.Dispose();
        }
    }
}
