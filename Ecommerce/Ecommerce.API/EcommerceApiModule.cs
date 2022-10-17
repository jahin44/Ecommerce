using Autofac;
using Ecommerce.API.Service;

namespace Ecommerce.API
{
    public class EcommerceApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationUserService>().As<IApplicationUserService>().InstancePerLifetimeScope();
          
            base.Load(builder);
        }

    }
}
