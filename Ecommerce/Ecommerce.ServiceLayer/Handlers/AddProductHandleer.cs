using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
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
        private readonly IProductRepository _productRepository;

        public AddProductHandleer(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
