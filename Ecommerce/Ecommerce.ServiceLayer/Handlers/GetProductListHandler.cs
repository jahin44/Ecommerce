using Ecommerce.ServiceLayer.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.ServiceLayer.Queries.Queries;

namespace Ecommerce.ServiceLayer.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IDataAccess _dataAccess;
        public GetProductListHandler (IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetProduct());
        }
    }
}
