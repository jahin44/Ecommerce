using Ecommerce.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer
{
    public interface IDataAccess
    {
        List<Product> GetProduct();
        Product AddProduct(string name, int quantity, decimal price);
    }
}
