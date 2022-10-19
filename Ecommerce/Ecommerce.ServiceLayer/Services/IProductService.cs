using Ecommerce.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        Product GetProductById(int id);
        void DeleteProduct(int id);


    }
}
