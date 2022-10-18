using Ecommerce.ServiceLayer.Model;
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
        private readonly IDataAccess _dataAccess;

        public AddProductHandleer(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddProduct(request.Name, request.Quentity, request.Price));
        }
    }
}
