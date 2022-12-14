using BO = Ecommerce.ServiceLayer.BusinessModel;
using Ecommerce.ServiceLayer.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.CQRS
{
    public class Commands
    {
        public record AddProductCommand(Product product) : IRequest<Product>;
        public record UpdateProductCommand(Product product) : IRequest<Product>;
        public record DeleteProductCommand(int Id) : IRequest<Product>;
        public record AddOrderCommand(BO.Order order) : IRequest<Order>;
        public record AddOrderDetailsCommand(BO.OrderDetails orderDetails) : IRequest<OrderDetails>;
    }
}
