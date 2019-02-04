using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleInjector;

namespace TodoApp.WebApi.Hub
{
    public class SimpleInjectorSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly Container _container;

        public SimpleInjectorSignalRDependencyResolver(Container container)
        {
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            return ((IServiceProvider)_container).GetService(serviceType) ?? base.GetService(serviceType);
        }
    }
}