using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
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
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IMediator _mediator;
        private readonly IProductService _productService;
        public GetProductByIdHandler(IMediator mediator, IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _productService.GetProductById(request.Id);
        }
    }
}
