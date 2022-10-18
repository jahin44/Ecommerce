using Ecommerce.ServiceLayer.Model;

namespace Ecommerce.ServiceLayer
{
    public class DataAccess : IDataAccess
    {
        private List<Product> _products = new();
        public DataAccess()
        {
            _products.Add(new Product { Id = 1, Name = "Phone",Quantity = 5,Price =10, CreatedDate = DateTime.Now });
            _products.Add(new Product { Id = 2, Name = "Watch", Quantity = 5, Price = 10, CreatedDate = DateTime.Now });
        }
        public Product AddProduct(string name,int quantity, decimal price)
        {
            Product newProduct = new() { Name = name, Quantity = quantity, Price = price, CreatedDate = DateTime.Now };
            newProduct.Id = _products.Max(p => p.Id)+1;
            return newProduct;
        }

        public List<Product> GetProduct()
        {
            return _products;
        }
    }
}