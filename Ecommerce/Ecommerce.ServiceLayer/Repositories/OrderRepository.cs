using Ecommerce.DataAccessLayer;
using Ecommerce.ServiceLayer.Context;
using Ecommerce.ServiceLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ServiceLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
