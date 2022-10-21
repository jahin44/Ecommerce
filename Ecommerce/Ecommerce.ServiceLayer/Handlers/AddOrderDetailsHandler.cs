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
    public class AddOrderDetailsHandler : IRequestHandler<AddOrderDetailsCommand, OrderDetails>
    {
        private readonly IOrderDetailsService _orderDetailsService;


        public AddOrderDetailsHandler( IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        public async Task<OrderDetails> Handle(AddOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                new ArgumentNullException(nameof(request));
            }

            OrderDetails neworderDetails = new();
            neworderDetails.quantity = request.orderDetails.quantity;
            neworderDetails.OrderId = request.orderDetails.OrderId;
            neworderDetails.ProducId = request.orderDetails.ProducId;
            
            return await _orderDetailsService.AddOrderDetails(neworderDetails);
        }
    }
}