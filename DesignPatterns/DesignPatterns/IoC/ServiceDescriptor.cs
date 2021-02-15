using System;

namespace IoC
{
    internal class ServiceDescriptor
    {
        public Type ServiceType { get; }

        public Type ImplementationType { get; }

        public object Implementation { get; internal set; }

        public Func<IServiceProvider, object> Factory { get; internal set; }

        public ServiceLifeTime LifeTime { get; }

        public ServiceDescriptor(ServiceLifeTime lifeTime)
        {
            LifeTime = lifeTime;
        }

        public ServiceDescriptor(object implementation, ServiceLifeTime lifeTime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifeTime;
        }

        public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> factory, ServiceLifeTime lifeTime)
        {
            ServiceType = serviceType;
            Factory = factory;
            LifeTime = lifeTime;
        }

        public ServiceDescriptor(Type serviceType, ServiceLifeTime lifeTime)
        {
            ServiceType = serviceType;
            LifeTime = lifeTime;
        }
    }
}
