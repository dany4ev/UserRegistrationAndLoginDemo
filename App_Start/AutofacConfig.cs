using Autofac;
using Autofac.Integration.WebApi;
using merXcoin.Services;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System.Reflection;
using System.Web.Http;
using UserRegistrationAndLoginDemo.Api.Core;
using UserRegistrationAndLoginDemo.Core;
using UserRegistrationAndLoginDemo.Core.IService;

namespace UserRegistrationAndLoginDemo.Api.App_Start
{
    public class AutofacConfig
    {
        static IContainer _container;

        public static void RegisterComponents(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DependencyInjection>().As<IDependencyInjection>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<StorageService>().As<IStorageService>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            _container = builder.Build();

            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }

        public static IContainer GetContainer() => _container;
    }
}