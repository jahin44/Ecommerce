using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.BusinessModel
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Totalprice { get; set; }
        public int UserId { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
