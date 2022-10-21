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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public UpdateProductHandler(IProductService productService,
                                     IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.product == null)
            {
                throw new Exception("product Empty");
            }

            var product = await _mediator.Send(new GetProductByIdQuery(request.product.Id));

            if (product == null)
            {
                throw new Exception("product Empty");
            }

            product.Name = request.product.Name;
            product.Stock = request.product.Stock;
            product.Price = request.product.Price;

            return await _productService.UpdateProduct(product);
        }

    }
}