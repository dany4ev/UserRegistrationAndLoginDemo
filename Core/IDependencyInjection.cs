using Autofac;

namespace UserRegistrationAndLoginDemo.Core
{
    public interface IDependencyInjection
    {
        IContainer GetContainer();
        T Resolve<T>();
    }
}
