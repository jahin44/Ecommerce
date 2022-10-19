using Ecommerce.ServiceLayer.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.CQRS
{
    public class Commands
    {
        public record AddProductCommand(Product product) : IRequest<Product>;

    }
}
