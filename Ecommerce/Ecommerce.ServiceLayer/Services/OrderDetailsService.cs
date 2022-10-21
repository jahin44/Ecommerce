using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _repository;
        public OrderDetailsService(IOrderDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails)
        {
            return await _repository.AddAsync(orderDetails);
        }

        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            _repository.Delete(orderDetails);
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return (List<OrderDetails>)_repository.GetAll();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            return _repository.GetById(id);
        }

        public Task<OrderDetails> UpdateOrderDetails(OrderDetails orderDetails)
        {
            return _repository.Update(orderDetails);
        }
    }
}
