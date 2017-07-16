using Autofac;
using UserRegistrationAndLoginDemo.Api.App_Start;
using UserRegistrationAndLoginDemo.Core;

namespace UserRegistrationAndLoginDemo.Api.Core
{
    public class DependencyInjection : IDependencyInjection
    {
        IContainer _container;

        public DependencyInjection()
        {
            _container = AutofacConfig.GetContainer();
        }

        public IContainer GetContainer() => _container;

        public T Resolve<T>() => _container.Resolve<T>();
    }
}