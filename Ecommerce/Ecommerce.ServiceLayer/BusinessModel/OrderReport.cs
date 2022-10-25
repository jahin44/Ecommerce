using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.BusinessModel
{
    public class OrderReport
    {
        public string Name { get; set; }
        public string userName { get; set; }
        public int quantity { get; set; }
        public int OrderId { get; set; }
    }
}
