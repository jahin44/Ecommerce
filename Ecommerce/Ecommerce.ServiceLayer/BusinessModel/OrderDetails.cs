using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.BusinessModel
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ProducId { get; set; }
        public int OrderId { get; set; }
        public int quantity { get; set; }
    }
}
