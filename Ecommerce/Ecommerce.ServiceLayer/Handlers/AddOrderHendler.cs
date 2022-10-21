using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ServiceLayer.CQRS.Commands;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.ServiceLayer.Handlers
{
    public class AddOrderHendler : IRequestHandler<AddOrderCommand, Order>
    {
        private readonly IOrderService _orderService;
        private readonly IMediator _mediator;

        public AddOrderHendler(IMediator mediator,IOrderService orderService)
        {
            _orderService = orderService;
            _mediator = mediator;
        }

        public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.order == null)
            {
                throw new Exception("product Can not null");
            }

            foreach (var orderData in request.order.OrderDetails)
            {
                if (orderData == null)
                {
                    throw new Exception("product Can not null");
                }

                var product = await _mediator.Send(new GetProductByIdQuery(orderData.ProducId));
                 
                if (product == null)
                {
                    throw new Exception("product Can not null");
                }

                if (product.Stock < orderData.quantity)
                {
                    throw new Exception("Not in Stock");
                }

                request.order.Totalprice += product.Price*orderData.quantity;
                product.Stock =product.Stock - orderData.quantity;

               await _mediator.Send(new UpdateProductCommand(product));
            }

            Order newOrder = new();
            newOrder.Totalprice = request.order.Totalprice;
            newOrder.UserId = 1;
            newOrder.OrderDate = DateTime.Now;

            var order = await _orderService.AddOrder(newOrder);
            foreach (var orderData in request.order.OrderDetails)
            {
                orderData.OrderId = order.Id;
                await _mediator.Send(new AddOrderDetailsCommand(orderData));

            }
            return order;
        }
    }
}
