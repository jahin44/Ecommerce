using Autofac;
using Ecommerce.API.Context;
using Ecommerce.API.Service;
using Ecommerce.ServiceLayer.Context;

namespace Ecommerce.API
{
    public class EcommerceApiModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public EcommerceApiModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserService>().As<IApplicationUserService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
