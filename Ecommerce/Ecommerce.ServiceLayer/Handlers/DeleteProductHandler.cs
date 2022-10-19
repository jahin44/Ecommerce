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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand,Product>
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public DeleteProductHandler(IProductService productService,
                                     IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                throw new Exception("product Empty");
            }

            var product = await _mediator.Send(new GetProductByIdQuery(request.Id));

            if (product == null)
            {
                throw new Exception("product Empty");
            }
             _productService.DeleteProduct(product);
            return product;
        }
    }
}
