using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await _repository.AddAsync(order);
        }

        public void DeleteOrder(Order order)
        {
            _repository.Delete(order);
        }

        public Order GetOrderById(int id)
        {
           return _repository.GetById(id);
        }

        public List<Order> GetOrders()
        {
            return (List<Order>)_repository.GetAll();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            return await _repository.Update(order);
        }
    }
}
