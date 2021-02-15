using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptors = new Dictionary<Type, ServiceDescriptor>();

        public IServiceCollection AddTransient<T>()
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), ServiceLifeTime.Transient));
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), provider => factory(), ServiceLifeTime.Transient));
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), provider => factory(provider), ServiceLifeTime.Transient));
            return this;
        }

        public IServiceCollection AddSingleton<T>()
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), ServiceLifeTime.Singleton));
            return this;
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(service, ServiceLifeTime.Singleton));
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(factory.Invoke(), ServiceLifeTime.Singleton));
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            _serviceDescriptors.Add(typeof(T), new ServiceDescriptor(typeof(T), provider => factory(provider), ServiceLifeTime.Singleton));
            return this;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_serviceDescriptors.Select(value => value.Value).ToList());
        }
    }
}
