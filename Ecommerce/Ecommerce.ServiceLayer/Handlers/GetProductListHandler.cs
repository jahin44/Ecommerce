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
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IProductService _productService;
        public GetProductListHandler(IProductService productService)
        {
            _productService = productService;
        }

        public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_productService.GetProducts());
        }
    }
}
