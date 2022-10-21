using Ecommerce.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Services
{
    public interface IOrderDetailsService
    {
        List<OrderDetails> GetOrderDetails();
        Task<OrderDetails> AddOrderDetails(OrderDetails orderDetails);
        Task<OrderDetails> UpdateOrderDetails(OrderDetails orderDetails);
        OrderDetails GetOrderDetailsById(int id);
        void DeleteOrderDetails(OrderDetails orderDetails);
    }
}
