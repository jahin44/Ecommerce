using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
using Ecommerce.ServiceLayer.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ServiceLayer.CQRS.Commands;

namespace Ecommerce.ServiceLayer.Handlers
{
    public class AddProductHandleer : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductService _productService;

        public AddProductHandleer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.AddProduct(request.product);
        }
    }
}
