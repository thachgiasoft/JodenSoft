﻿using System;
using System.Runtime.Serialization;

namespace SAF.Foundation
{
    [Serializable()]
    public class ServiceNotFoundException : CoreException
    {
        public ServiceNotFoundException()
            : base()
        {
        }

        public ServiceNotFoundException(Type serviceType)
            : base("Required service not found: " + serviceType.FullName)
        {
        }

        public ServiceNotFoundException(string message)
            : base(message)
        {
        }

        public ServiceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ServiceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
