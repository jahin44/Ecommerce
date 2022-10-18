using Ecommerce.ServiceLayer.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.ServiceLayer.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IMediator _mediator;
        public GetProductByIdHandler (IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var employees =  await _mediator.Send(new GetProductListQuery());
            var searchedProduct = employees.FirstOrDefault(x=>x.Id == request.Id);
            return searchedProduct;
        }
    }
}
