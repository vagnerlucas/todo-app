using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using System.Linq;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
//using TodoApp.Application.CommonInterfaces;
using TodoApp.Application.UseCases.Task;
using TodoApp.Infrastructure.InMemory;

[assembly: OwinStartup(typeof(TodoApp.WebApi.Startup))]

namespace TodoApp.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string DB_REPOSITORY_NAMESPACE = "TodoApp.Infrastructure.InMemory.Repositories";

            var container = new Container();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            var applicationAssembly = typeof(TodoApp.Application.ApplicationException).Assembly;

            var registrations =
                from type in applicationAssembly.GetExportedTypes()
                where type.GetInterfaces().Any() && !type.Name.Contains("Exception")
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            var repositoryAssembly = typeof(TodoApp.Infrastructure.ReferenceType).Assembly;

            registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace == DB_REPOSITORY_NAMESPACE
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }

            //Registeging InMemoryDB
            container.Register(() => new TodoApp.Infrastructure.InMemory.Context(), Lifestyle.Singleton);

            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
