﻿using Ecommerce.ServiceLayer.Model;
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
        public void AddProduct(Product product)
        {
          
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> GetProducts()
        {
           return (List<Product>)_repository.GetAll();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
