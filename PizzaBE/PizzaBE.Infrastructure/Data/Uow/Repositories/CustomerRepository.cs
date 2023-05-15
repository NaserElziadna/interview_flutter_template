using Microsoft.Extensions.Caching.Memory;
using PizzaBE.Domain.Entities;
using PizzaBE.Domain.Interfaces.Uow.Repositories;
using PizzaBE.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBE.Infrastructure.Data.Uow.Repositories
{
    public class CustomerRepository : Repository<CustomerUser>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext _context,
            IMemoryCache memoryCache) : base(_context, memoryCache)
        {
        }

        public ApplicationDbContext _context
        {
            get { return Context; }
        }

        public List<Order> GetAllOrders(long userId)
        {
           return _context.CustomerUsers.SingleOrDefault(u=>u.Id == userId).orders.ToList();
        }
    }
}