using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;    
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> AddProduct(Product product)
        {
          return await _repository.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            if(product== null) 
            {
                throw new Exception("product not found");
            }
            _repository.Delete(product);
        }

        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> GetProducts()
        {
           return (List<Product>)_repository.GetAll();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _repository.Update(product);
        }
    }
}
