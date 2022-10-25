using Ecommerce.ServiceLayer.BusinessModel;
using Ecommerce.ServiceLayer.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.ServiceLayer.Handlers
{
    public class GetOrderReportsListHandler : IRequestHandler<GetOrderReportsListQuery, List<OrderReport>>
    {
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IMediator _mediator;

        public GetOrderReportsListHandler(IOrderDetailsService orderDetailsService
                                        , IMediator mediator)
        {
            _orderDetailsService = orderDetailsService;
            _mediator = mediator;
        }

        public async Task<List<OrderReport>> Handle(GetOrderReportsListQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = _orderDetailsService.GetOrderDetails();

            if (orderDetails == null)
            {
                new Exception("orderDetails Empty");
            }
            List<OrderReport> orderReports = new ();
            foreach(var order in orderDetails)
            {
                OrderReport orderReport = new();
                var product = await _mediator.Send(new GetProductByIdQuery(order.ProducId));
                if (product != null)
                {
                    orderReport.Name = product.Name;
                    orderReport.OrderId = order.OrderId;
                    orderReport.quantity = order.quantity;
                    orderReport.userName = "Admin";
                    orderReports.Add(orderReport);
                }
            }

            return orderReports;

        }
    }
}