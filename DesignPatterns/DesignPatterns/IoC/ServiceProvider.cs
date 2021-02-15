using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC
{
    class ServiceProvider : IServiceProvider
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

        public ServiceProvider(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        private object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors
                       .SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                return null;
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            if (descriptor.Factory != null)
            {
                var impl = descriptor.Factory(this);

                if (descriptor.LifeTime == ServiceLifeTime.Singleton)
                    descriptor.Implementation = impl;

                return impl;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                 .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator
                .CreateInstance(actualType, parameters);

            if (descriptor.LifeTime == ServiceLifeTime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
