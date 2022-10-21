using Ecommerce.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Order GetOrderById(int id);
        void DeleteOrder(Order order);
    }
}
