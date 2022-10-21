using Autofac;
using Ecommerce.ServiceLayer.Repositories;
using Ecommerce.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer
{
    public class ServiceLayerModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsRepository>().As<IOrderDetailsRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsService>().As<IOrderDetailsService>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
